using Npgsql;
using Security_Elgamal.Database;
using Security_Elgamal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security_Elgamal.View
{
    public partial class MDI : Form
    {

        DatabaseClass db = new DatabaseClass();
        string email = "";
        DigitalSignature dse = null;

        public MDI()
        {
            InitializeComponent();
        }


        private void dangNhapButton_Click(object sender, EventArgs e)
        {
            email = emailTextbox.Text;

            DigitalSignature ds = new DigitalSignature();
            dse = db.AddOrGetUser(ds, email);

            //string message = $"Public Key P: {dse.PublicKey.P}\n" +
            //    $"Public Key Alpha: {dse.PublicKey.Alpha}\n" +
            //    $"Public Key Beta: {dse.PublicKey.Beta}\n" +
            //    $"Private Key: {dse.PrivateKey.A}";

            //MessageBox.Show(message, "Thông tin khóa đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Đăng nhập thành công");
        }

        private void gửiFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Sender(dse, email).Show();
        }

        private void kýFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Receiver(dse, email).Show();
        }

        private void xácThựcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SignatureAuthentication(dse, email).Show();
        }
    }
}
