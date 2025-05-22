namespace Security_Elgamal.View
{
    partial class MDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dangNhapButton = new System.Windows.Forms.Button();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.đăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gửiFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gửiFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kýFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xácThựcFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.dangNhapButton);
            this.panel1.Controls.Add(this.emailTextbox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(829, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 249);
            this.panel1.TabIndex = 5;
            // 
            // dangNhapButton
            // 
            this.dangNhapButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.dangNhapButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangNhapButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dangNhapButton.Location = new System.Drawing.Point(16, 160);
            this.dangNhapButton.Name = "dangNhapButton";
            this.dangNhapButton.Size = new System.Drawing.Size(361, 47);
            this.dangNhapButton.TabIndex = 16;
            this.dangNhapButton.Text = "Đăng nhập";
            this.dangNhapButton.UseVisualStyleBackColor = false;
            this.dangNhapButton.Click += new System.EventHandler(this.dangNhapButton_Click);
            // 
            // emailTextbox
            // 
            this.emailTextbox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.Location = new System.Drawing.Point(148, 113);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(172, 25);
            this.emailTextbox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhậpToolStripMenuItem,
            this.gửiFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1279, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            this.đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            this.đăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.đăngNhậpToolStripMenuItem.Text = "Tài khoản";
            // 
            // gửiFileToolStripMenuItem
            // 
            this.gửiFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gửiFileToolStripMenuItem1,
            this.kýFileToolStripMenuItem,
            this.xácThựcFileToolStripMenuItem});
            this.gửiFileToolStripMenuItem.Name = "gửiFileToolStripMenuItem";
            this.gửiFileToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.gửiFileToolStripMenuItem.Text = "Thao tác";
            // 
            // gửiFileToolStripMenuItem1
            // 
            this.gửiFileToolStripMenuItem1.Name = "gửiFileToolStripMenuItem1";
            this.gửiFileToolStripMenuItem1.Size = new System.Drawing.Size(174, 26);
            this.gửiFileToolStripMenuItem1.Text = "Gửi file";
            this.gửiFileToolStripMenuItem1.Click += new System.EventHandler(this.gửiFileToolStripMenuItem1_Click);
            // 
            // kýFileToolStripMenuItem
            // 
            this.kýFileToolStripMenuItem.Name = "kýFileToolStripMenuItem";
            this.kýFileToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.kýFileToolStripMenuItem.Text = "Ký file";
            this.kýFileToolStripMenuItem.Click += new System.EventHandler(this.kýFileToolStripMenuItem_Click);
            // 
            // xácThựcFileToolStripMenuItem
            // 
            this.xácThựcFileToolStripMenuItem.Name = "xácThựcFileToolStripMenuItem";
            this.xácThựcFileToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.xácThựcFileToolStripMenuItem.Text = "Xác thực file";
            this.xácThựcFileToolStripMenuItem.Click += new System.EventHandler(this.xácThựcFileToolStripMenuItem_Click);
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 736);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDI";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button dangNhapButton;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gửiFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gửiFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kýFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xácThựcFileToolStripMenuItem;
    }
}