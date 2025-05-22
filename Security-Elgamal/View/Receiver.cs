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
    internal partial class Receiver : Form
    {
        DigitalSignature ds = null;
        DatabaseClass db = new DatabaseClass();
        string email = "";
        public Receiver(DigitalSignature dse, string email)
        {
            this.ds = dse;
            this.email = email;
            InitializeComponent();
        }

        private void kiVaGuiEmailButton_Click(object sender, EventArgs e)
        {
            ds.K = ds.TaoSoK(ds.PublicKey.P);
            string fileId = fileIdTextBox.Text;
            BigInteger m = db.TinhSoMTuFilePostgres(Int32.Parse(fileId), ds.PublicKey.P);
            BigInteger s1 = ds.TinhS1(ds.PublicKey.Alpha, ds.K, ds.PublicKey.P);
            BigInteger s2 = ds.TinhS2(ds.K, m, ds.PrivateKey.A, s1, ds.PublicKey.P - 1);


            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadFolder, "digital_signature_" + fileIdTextBox.Text+".txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("s1: " + s1);  // Ghi s1 vào file
                writer.WriteLine("s2: " + s2);  // Ghi s2 vào file
                writer.WriteLineAsync("p: " + ds.PublicKey.P);
                writer.WriteLineAsync("alpha: " + ds.PublicKey.Alpha);
                writer.WriteLineAsync("beta: " + ds.PublicKey.Beta);
            }

            byte[] fileBytes = File.ReadAllBytes(filePath);

            db.SaveSignatureAndSendEmail(fileId, email, fileBytes);

            MessageBox.Show("Lưu chữ ký số thành công");
        }

        private void Receiver_Load(object sender, EventArgs e)
        {
            PrivateKeyLabel.Text = ds.PrivateKey.A.ToString();
            PublicKeyPLabel.Text = ds.PublicKey.P.ToString();
            PublicKeyAlpha.Text = ds.PublicKey.Alpha.ToString();
            PublicKeyBetaLabel.Text = ds.PublicKey.Beta.ToString();
        }


    }
}
