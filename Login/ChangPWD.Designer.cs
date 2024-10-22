namespace Login
{
    partial class ChangPWD
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
            this.BT_changePWD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_newPWD_2 = new System.Windows.Forms.TextBox();
            this.TB_newPWD_1 = new System.Windows.Forms.TextBox();
            this.TB_oldPWD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_changePWD
            // 
            this.BT_changePWD.ForeColor = System.Drawing.Color.Red;
            this.BT_changePWD.Location = new System.Drawing.Point(241, 123);
            this.BT_changePWD.Name = "BT_changePWD";
            this.BT_changePWD.Size = new System.Drawing.Size(133, 35);
            this.BT_changePWD.TabIndex = 13;
            this.BT_changePWD.Text = "Lưu mật khẩu";
            this.BT_changePWD.UseVisualStyleBackColor = true;
            this.BT_changePWD.Click += new System.EventHandler(this.BT_changePWD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(18, 88);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(180, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nhập lại mật khẩu mới:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(39, 51);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label2.Size = new System.Drawing.Size(159, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nhập mật khẩu mới:";
            // 
            // TB_newPWD_2
            // 
            this.TB_newPWD_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_newPWD_2.Location = new System.Drawing.Point(204, 86);
            this.TB_newPWD_2.Multiline = true;
            this.TB_newPWD_2.Name = "TB_newPWD_2";
            this.TB_newPWD_2.Size = new System.Drawing.Size(170, 31);
            this.TB_newPWD_2.TabIndex = 10;
            // 
            // TB_newPWD_1
            // 
            this.TB_newPWD_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_newPWD_1.Location = new System.Drawing.Point(204, 49);
            this.TB_newPWD_1.Multiline = true;
            this.TB_newPWD_1.Name = "TB_newPWD_1";
            this.TB_newPWD_1.Size = new System.Drawing.Size(170, 31);
            this.TB_newPWD_1.TabIndex = 9;
            // 
            // TB_oldPWD
            // 
            this.TB_oldPWD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_oldPWD.Location = new System.Drawing.Point(204, 12);
            this.TB_oldPWD.Multiline = true;
            this.TB_oldPWD.Name = "TB_oldPWD";
            this.TB_oldPWD.Size = new System.Drawing.Size(170, 31);
            this.TB_oldPWD.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(49, 14);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label1.Size = new System.Drawing.Size(149, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nhập mật khẩu cũ:";
            // 
            // ChangPWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 171);
            this.Controls.Add(this.BT_changePWD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_newPWD_2);
            this.Controls.Add(this.TB_newPWD_1);
            this.Controls.Add(this.TB_oldPWD);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChangPWD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.ChangPWD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_changePWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_newPWD_2;
        private System.Windows.Forms.TextBox TB_newPWD_1;
        private System.Windows.Forms.TextBox TB_oldPWD;
        private System.Windows.Forms.Label label1;
    }
}