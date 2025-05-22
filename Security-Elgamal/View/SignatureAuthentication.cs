using Security_Elgamal.Database;
using Security_Elgamal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security_Elgamal.View
{
    internal partial class SignatureAuthentication : Form
    {
        DigitalSignature ds = null;
        DatabaseClass db = new DatabaseClass();
        string email = "";

        BigInteger p =BigInteger.Zero;
        BigInteger alpha = BigInteger.Zero;
        BigInteger beta = BigInteger.Zero;

        public SignatureAuthentication(DigitalSignature dse, string email)
        {
            this.ds = dse;
            this.email = email;
            InitializeComponent();
        }



        private void moFileChuKyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính của OpenFileDialog
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads"; // Chỉ định thư mục mặc định khi mở hộp thoại
            openFileDialog.Filter = "All files (*.*)|*.*";  // Hiển thị tất cả các file
            openFileDialog.FilterIndex = 1;  // Chỉ định bộ lọc mặc định (ở đây là tất cả file)
            openFileDialog.RestoreDirectory = true;  // Giữ lại thư mục đã chọn khi đóng hộp thoại

            // Hiển thị hộp thoại chọn file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file đã chọn
                string filePath = openFileDialog.FileName;
                fileChuKyTextBox.Text = filePath;

                string[] lines = File.ReadAllLines(filePath);

                Dictionary<string, string> values = new Dictionary<string, string>();
                // Kiểm tra xem file có đủ 2 dòng không
                if (lines.Length >= 5)
                {

                    foreach (string line in lines)
                    {
                        var parts = line.Split(':');
                        if (parts.Length == 2) // Đảm bảo rằng dòng có đúng dấu ":"
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            values[key] = value; // Lưu vào từ điển
                        }
                    }

                    string s1 = values["s1"];
                    string s2 = values["s2"] ;
                    p = BigInteger.Parse (values["p"]) ;
                    alpha = BigInteger.Parse(values["alpha"]) ;
                    beta =  BigInteger.Parse(values["beta"]);

                    // Hiển thị vào TextBox
                    s1_Bang3_TextBox.Text = s1;
                    s2_Bang3_TextBox.Text = s2;
                }
                else
                {
                    MessageBox.Show("File không chứa đủ 5 dòng dữ liệu ");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger s1 = BigInteger.Parse(s1_Bang3_TextBox.Text);
            BigInteger s2 = BigInteger.Parse(s2_Bang3_TextBox.Text);
            string fileId = fileIDTextBox.Text;
            BigInteger m = db.TinhSoMTuFilePostgres(Int32.Parse(fileId), p);

            if (ds.XacMinhChuKy(alpha, m, p, beta, s1, s2))
            {
                MessageBox.Show("Xác thực chữ ký thành công");
            }
            else
            {
                MessageBox.Show("Xác thực chữ ký không thành công, chữ ký không hợp lệ");
            }
        }
    }
}
