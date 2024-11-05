namespace Login
{
    partial class Form_Captcha
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
            this.PicBox_Captcha = new System.Windows.Forms.PictureBox();
            this.TB_Captcha = new System.Windows.Forms.TextBox();
            this.BT_Captcha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_reloadCaptcha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Captcha)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBox_Captcha
            // 
            this.PicBox_Captcha.Location = new System.Drawing.Point(30, 37);
            this.PicBox_Captcha.Name = "PicBox_Captcha";
            this.PicBox_Captcha.Size = new System.Drawing.Size(400, 171);
            this.PicBox_Captcha.TabIndex = 0;
            this.PicBox_Captcha.TabStop = false;
            // 
            // TB_Captcha
            // 
            this.TB_Captcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Captcha.Location = new System.Drawing.Point(155, 253);
            this.TB_Captcha.Multiline = true;
            this.TB_Captcha.Name = "TB_Captcha";
            this.TB_Captcha.Size = new System.Drawing.Size(173, 31);
            this.TB_Captcha.TabIndex = 1;
            // 
            // BT_Captcha
            // 
            this.BT_Captcha.Location = new System.Drawing.Point(340, 253);
            this.BT_Captcha.Name = "BT_Captcha";
            this.BT_Captcha.Size = new System.Drawing.Size(87, 31);
            this.BT_Captcha.TabIndex = 2;
            this.BT_Captcha.Text = "Xác thực";
            this.BT_Captcha.UseVisualStyleBackColor = true;
            this.BT_Captcha.Click += new System.EventHandler(this.BT_Captcha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập Captcha: ";
            // 
            // BT_reloadCaptcha
            // 
            this.BT_reloadCaptcha.Location = new System.Drawing.Point(352, 218);
            this.BT_reloadCaptcha.Name = "BT_reloadCaptcha";
            this.BT_reloadCaptcha.Size = new System.Drawing.Size(75, 29);
            this.BT_reloadCaptcha.TabIndex = 4;
            this.BT_reloadCaptcha.Text = "Tạo lại";
            this.BT_reloadCaptcha.UseVisualStyleBackColor = true;
            this.BT_reloadCaptcha.Click += new System.EventHandler(this.BT_reloadCaptcha_Click);
            // 
            // Form_Captcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 298);
            this.Controls.Add(this.BT_reloadCaptcha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_Captcha);
            this.Controls.Add(this.TB_Captcha);
            this.Controls.Add(this.PicBox_Captcha);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form_Captcha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác thực Captcha";
            this.Load += new System.EventHandler(this.Captcha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Captcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBox_Captcha;
        private System.Windows.Forms.TextBox TB_Captcha;
        private System.Windows.Forms.Button BT_Captcha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_reloadCaptcha;
    }
}