using Security_Elgamal.Model;
using Security_Elgamal.View;
using System;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Security_Elgamal
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DigitalSignature a = new DigitalSignature();
            Application.Run(new MDI());
        }
    }
}
