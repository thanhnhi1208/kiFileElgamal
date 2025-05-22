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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Security_Elgamal.View
{
    internal partial class Sender : Form
    {
        //BigInteger PrivateKey_A = BigInteger.Zero;
        //BigInteger PublicKey_P = BigInteger.Zero;
        //BigInteger PublicKey_Alpha = BigInteger.Zero;
        //BigInteger PublicKey_Beta = BigInteger.Zero;
        DigitalSignature ds = null;
        DatabaseClass db = new DatabaseClass();
        string email = "";

        public Sender(DigitalSignature dse, string email)
        {
            this.ds = dse;
            this.email = email;
            InitializeComponent();
        }

        private void guiEmailButton_Click(object sender, EventArgs e)
        {
            string filePath = fileGuiEmaiTextbox.Text;
            byte[] fileBytes = File.ReadAllBytes(fileGuiEmaiTextbox.Text);
            string senderEmail = email;
            string receiverEmail = receiverTextbox.Text;
            try
            {
                db.SendEmailAndSaveFile(
                    fileName: Path.GetFileName(filePath),
                    fileData: fileBytes,
                    senderEmail: senderEmail,
                    receiverEmail: receiverEmail
                );
                MessageBox.Show("Đã lưu chữ ký số và gửi email thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void moFileKySoTextbox_Click(object sender, EventArgs e)
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
                fileGuiEmaiTextbox.Text = filePath;

                // Thực hiện các thao tác với file (ví dụ: đọc nội dung file)
                // Ví dụ: Đọc toàn bộ nội dung file
                string fileContent = System.IO.File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("Không chọn file.");
            }
        }

        private void Sender_Load(object sender, EventArgs e)
        {
            PrivateKeyLabel.Text = ds.PrivateKey.A.ToString();
            PublicKeyPLabel.Text = ds.PublicKey.P.ToString();
            PublicKeyAlpha.Text = ds.PublicKey.Alpha.ToString();
            PublicKeyBetaLabel.Text = ds.PublicKey.Beta.ToString();
        }
    }
}
