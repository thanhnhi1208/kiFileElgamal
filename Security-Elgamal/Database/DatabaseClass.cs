using Npgsql;
using NpgsqlTypes;
using Security_Elgamal.Model;
using Security_Elgamal.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Security_Elgamal.Database
{
    internal class DatabaseClass
    {
        public DatabaseClass()
        {
        }

        public NpgsqlConnection getConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=security_elgamal;User Id=postgres;Password=root;");
            return conn;
        }

        public DigitalSignature AddOrGetUser(DigitalSignature dse, string email)
        {
            using (var conn = getConnection())
            {
                conn.Open();

                // 1. Kiểm tra người dùng có tồn tại không
                string selectQuery = @"SELECT public_key_p, public_key_alpha, public_key_beta, private_key 
                             FROM users WHERE email = @Email";

                bool userExists = false;
                using (var selectCmd = new NpgsqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Đọc giá trị numeric từ PostgreSQL và chuyển sang BigInteger
                            dse.PublicKey.P = BigInteger.Parse(reader["public_key_p"].ToString());
                            dse.PublicKey.Alpha = BigInteger.Parse(reader["public_key_alpha"].ToString());
                            dse.PublicKey.Beta = BigInteger.Parse(reader["public_key_beta"].ToString());
                            dse.PrivateKey.A = BigInteger.Parse(reader["private_key"].ToString());
                            userExists = true;
                        }
                    }
                }

                // 2. Nếu không tồn tại thì tạo mới
                if (!userExists)
                {
                    DigitalSignature ds = new DigitalSignature();

                    // Vòng lặp để đảm bảo private key (a) không trùng
                    while (true)
                    {
                        string checkPrivateKeyQuery = @"SELECT COUNT(*) FROM users WHERE private_key = @PrivateKey::numeric";

                        using (var checkCmd = new NpgsqlCommand(checkPrivateKeyQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@PrivateKey", ds.PrivateKey.A.ToString());
                            var count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count == 0)
                            {
                                // Không trùng private key => dùng luôn
                                break;
                            }

                            // Nếu trùng => tạo lại A mới và tính lại Beta
                            ds.PrivateKey.A = ds.PrivateKey.TaoSoA(ds.PublicKey.P);
                            ds.PublicKey.Beta = BigInteger.ModPow(ds.PublicKey.Alpha, ds.PrivateKey.A, ds.PublicKey.P);
                        }
                    }

                    // Insert vào bảng users
                    string insertQuery = @"INSERT INTO users 
                (email, public_key_p, public_key_alpha, public_key_beta, private_key) 
                VALUES 
                (@Email, @PublicKey_P::numeric, @PublicKey_Alpha::numeric, 
                 @PublicKey_Beta::numeric, @PrivateKey::numeric)";

                    using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@PublicKey_P", ds.PublicKey.P.ToString());
                        insertCmd.Parameters.AddWithValue("@PublicKey_Alpha", ds.PublicKey.Alpha.ToString());
                        insertCmd.Parameters.AddWithValue("@PublicKey_Beta", ds.PublicKey.Beta.ToString());
                        insertCmd.Parameters.AddWithValue("@PrivateKey", ds.PrivateKey.A.ToString());

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            dse = ds;
                        }
                        else
                        {
                            throw new Exception("Không thể tạo tài khoản mới.");
                        }
                    }
                }



            }

            return dse;
        }


        public void SendEmailAndSaveFile(string fileName, byte[] fileData, string senderEmail, string receiverEmail)
        {
            const string insertQuery = @"
                            INSERT INTO files (file_name, file_data, sender_id, receiver_id)
                            VALUES (@fileName, @fileData, @senderId, @receiverId)";

            try
            {
                using (var conn = getConnection())
                {
                    conn.Open();

                    // 1. Lấy sender_id từ email
                    int senderId = GetUserIdByEmail(conn, senderEmail);
                    if (senderId == 0)
                        throw new Exception($"Không tìm thấy người gửi với email: {senderEmail}");

                    // 2. Lấy receiver_id từ email
                    int receiverId = GetUserIdByEmail(conn, receiverEmail);
                    if (receiverId == 0)
                        throw new Exception($"Không tìm thấy người nhận với email: {receiverEmail}");

                    // 3. Lưu file vào database
                    using (var command = new NpgsqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("@fileName", NpgsqlDbType.Varchar, fileName);
                        command.Parameters.AddWithValue("@fileData", NpgsqlDbType.Bytea, fileData);
                        command.Parameters.AddWithValue("@senderId", NpgsqlDbType.Integer, senderId);
                        command.Parameters.AddWithValue("@receiverId", NpgsqlDbType.Integer, receiverId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new Exception("Không thể thêm file vào database");
                    }

                    // 4. Gửi email thông báo (tuỳ chọn)
                    // gửi email nhớ gửi nội dung chứa fileId
                    //SendEmailNotification(senderEmail, receiverEmail, fileName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xử lý file: {ex.Message}");
            }
        }

        // Hàm hỗ trợ lấy UserID từ email
        private int GetUserIdByEmail(NpgsqlConnection connection, string email)
        {
            const string query = "SELECT id FROM users WHERE email = @email";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", NpgsqlDbType.Varchar, email);
                var result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public void SaveSignatureAndSendEmail(string fileId, string senderEmail, byte[] signatures)
        {
            const string query = @"
        INSERT INTO signatures (file_id, user_id, signature)
        VALUES (@fileId, @userId, @signature)";

            try
            {
                using (var conn = getConnection())
                {
                    conn.Open();

                    // 1. Lấy user_id từ email
                    int userId = GetUserIdByEmail(conn, senderEmail);
                    if (userId == 0)
                        throw new Exception($"Không tìm thấy người dùng với email: {senderEmail}");

                    // 2. Kiểm tra file_id tồn tại
                    if (!FileExists(conn, fileId))
                        throw new Exception($"Không tìm thấy file với ID: {fileId}");

                    // 3. Lưu chữ ký
                    using (var command = new NpgsqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@fileId", NpgsqlDbType.Integer, int.Parse(fileId));
                        command.Parameters.AddWithValue("@userId", NpgsqlDbType.Integer, userId);
                        command.Parameters.AddWithValue("@signature", NpgsqlDbType.Bytea, signatures);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new Exception("Không thể lưu chữ ký");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu chữ ký: {ex.Message}");
            }
        }

        private bool FileExists(NpgsqlConnection connection, string fileId)
        {
            const string query = "SELECT 1 FROM files WHERE id = @fileId";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fileId", NpgsqlDbType.Integer, int.Parse(fileId));
                return command.ExecuteScalar() != null;
            }
        }

        public BigInteger TinhSoMTuFilePostgres(int fileId, BigInteger p)
        {
            byte[] fileBytes;

            // 1. Kết nối và truy vấn PostgreSQL
            using (var conn = getConnection())
            {
                conn.Open();
                string query = "SELECT file_data FROM files WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", fileId); 
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fileBytes = (byte[])reader["file_data"];
                        }
                        else
                        {
                            throw new Exception("File not found in database.");
                        }
                    }
                }
            }

            // 2. Tính SHA256
            byte[] hash = SHA256.Create().ComputeHash(fileBytes);

            // 3. Tính m = hash mod p
            BigInteger m = new BigInteger(hash);

            // 4. Đảm bảo m dương
            m = m % p;
            if (m < 0) m += p;

            return m;
        }
    }
}
