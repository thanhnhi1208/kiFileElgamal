namespace Security_Elgamal.View
{
    partial class Sender
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
            this.guiEmailButton = new System.Windows.Forms.Button();
            this.moFileGuiEmailTextbox = new System.Windows.Forms.Button();
            this.fileGuiEmaiTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PublicKeyBetaLabel = new System.Windows.Forms.Label();
            this.PublicKeyAlpha = new System.Windows.Forms.Label();
            this.PublicKeyPLabel = new System.Windows.Forms.Label();
            this.PrivateKeyLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.receiverTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guiEmailButton
            // 
            this.guiEmailButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.guiEmailButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiEmailButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guiEmailButton.Location = new System.Drawing.Point(16, 349);
            this.guiEmailButton.Name = "guiEmailButton";
            this.guiEmailButton.Size = new System.Drawing.Size(380, 48);
            this.guiEmailButton.TabIndex = 18;
            this.guiEmailButton.Text = "Gửi qua email";
            this.guiEmailButton.UseVisualStyleBackColor = false;
            this.guiEmailButton.Click += new System.EventHandler(this.guiEmailButton_Click);
            // 
            // moFileGuiEmailTextbox
            // 
            this.moFileGuiEmailTextbox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.moFileGuiEmailTextbox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moFileGuiEmailTextbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moFileGuiEmailTextbox.Location = new System.Drawing.Point(276, 185);
            this.moFileGuiEmailTextbox.Name = "moFileGuiEmailTextbox";
            this.moFileGuiEmailTextbox.Size = new System.Drawing.Size(121, 46);
            this.moFileGuiEmailTextbox.TabIndex = 5;
            this.moFileGuiEmailTextbox.Text = "Mở file";
            this.moFileGuiEmailTextbox.UseVisualStyleBackColor = false;
            this.moFileGuiEmailTextbox.Click += new System.EventHandler(this.moFileKySoTextbox_Click);
            // 
            // fileGuiEmaiTextbox
            // 
            this.fileGuiEmaiTextbox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileGuiEmaiTextbox.Location = new System.Drawing.Point(16, 185);
            this.fileGuiEmaiTextbox.Multiline = true;
            this.fileGuiEmaiTextbox.Name = "fileGuiEmaiTextbox";
            this.fileGuiEmaiTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fileGuiEmaiTextbox.Size = new System.Drawing.Size(238, 48);
            this.fileGuiEmaiTextbox.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "Chọn file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "GỬI FILE QUA EMAIL";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.PublicKeyBetaLabel);
            this.panel2.Controls.Add(this.PublicKeyAlpha);
            this.panel2.Controls.Add(this.PublicKeyPLabel);
            this.panel2.Controls.Add(this.PrivateKeyLabel);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.receiverTextbox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.guiEmailButton);
            this.panel2.Controls.Add(this.moFileGuiEmailTextbox);
            this.panel2.Controls.Add(this.fileGuiEmaiTextbox);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(384, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 643);
            this.panel2.TabIndex = 6;
            // 
            // PublicKeyBetaLabel
            // 
            this.PublicKeyBetaLabel.AutoSize = true;
            this.PublicKeyBetaLabel.Location = new System.Drawing.Point(156, 585);
            this.PublicKeyBetaLabel.Name = "PublicKeyBetaLabel";
            this.PublicKeyBetaLabel.Size = new System.Drawing.Size(20, 17);
            this.PublicKeyBetaLabel.TabIndex = 28;
            this.PublicKeyBetaLabel.Text = "...";
            // 
            // PublicKeyAlpha
            // 
            this.PublicKeyAlpha.AutoSize = true;
            this.PublicKeyAlpha.Location = new System.Drawing.Point(156, 552);
            this.PublicKeyAlpha.Name = "PublicKeyAlpha";
            this.PublicKeyAlpha.Size = new System.Drawing.Size(20, 17);
            this.PublicKeyAlpha.TabIndex = 27;
            this.PublicKeyAlpha.Text = "...";
            // 
            // PublicKeyPLabel
            // 
            this.PublicKeyPLabel.AutoSize = true;
            this.PublicKeyPLabel.Location = new System.Drawing.Point(156, 523);
            this.PublicKeyPLabel.Name = "PublicKeyPLabel";
            this.PublicKeyPLabel.Size = new System.Drawing.Size(20, 17);
            this.PublicKeyPLabel.TabIndex = 26;
            this.PublicKeyPLabel.Text = "...";
            // 
            // PrivateKeyLabel
            // 
            this.PrivateKeyLabel.AutoSize = true;
            this.PrivateKeyLabel.Location = new System.Drawing.Point(156, 490);
            this.PrivateKeyLabel.Name = "PrivateKeyLabel";
            this.PrivateKeyLabel.Size = new System.Drawing.Size(20, 17);
            this.PrivateKeyLabel.TabIndex = 25;
            this.PrivateKeyLabel.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 585);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Public key Beta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 552);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Public key Alpha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Public key P";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Private Key";
            // 
            // receiverTextbox
            // 
            this.receiverTextbox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiverTextbox.Location = new System.Drawing.Point(225, 278);
            this.receiverTextbox.Name = "receiverTextbox";
            this.receiverTextbox.Size = new System.Drawing.Size(172, 25);
            this.receiverTextbox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Email người nhận";
            // 
            // Sender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 678);
            this.Controls.Add(this.panel2);
            this.Name = "Sender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sender";
            this.Load += new System.EventHandler(this.Sender_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button guiEmailButton;
        private System.Windows.Forms.Button moFileGuiEmailTextbox;
        private System.Windows.Forms.TextBox fileGuiEmaiTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox receiverTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PublicKeyBetaLabel;
        private System.Windows.Forms.Label PublicKeyAlpha;
        private System.Windows.Forms.Label PublicKeyPLabel;
        private System.Windows.Forms.Label PrivateKeyLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}