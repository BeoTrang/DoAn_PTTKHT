namespace Login
{
    partial class RenLuyen_SV
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.comboBox_HK = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BT_Save = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1279, 44);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(445, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐÁNH GIÁ KẾT QUẢ RÈN LUYỆN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(457, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn học kỳ:";
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 120);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(1279, 478);
            this.DGV.TabIndex = 2;
            // 
            // comboBox_HK
            // 
            this.comboBox_HK.FormattingEnabled = true;
            this.comboBox_HK.Location = new System.Drawing.Point(574, 78);
            this.comboBox_HK.Name = "comboBox_HK";
            this.comboBox_HK.Size = new System.Drawing.Size(267, 29);
            this.comboBox_HK.TabIndex = 3;
            this.comboBox_HK.SelectedIndexChanged += new System.EventHandler(this.comboBox_HK_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 643);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(248, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "- Điểm rèn luyện được công bố:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 674);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(275, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "- Xếp loại rèn luyện được công bố: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 705);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label5.Size = new System.Drawing.Size(530, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "- Điểm này là căn cứ để xét cấp học bổng, khen thưởng của sinh viên.";
            // 
            // BT_Save
            // 
            this.BT_Save.BackColor = System.Drawing.Color.White;
            this.BT_Save.ForeColor = System.Drawing.Color.Red;
            this.BT_Save.Location = new System.Drawing.Point(1154, 692);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(137, 36);
            this.BT_Save.TabIndex = 7;
            this.BT_Save.Text = "Lưu thay đổi";
            this.BT_Save.UseVisualStyleBackColor = false;
            // 
            // RenLuyen_SV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 740);
            this.Controls.Add(this.BT_Save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_HK);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RenLuyen_SV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đánh giá điểm rèn luyện";
            this.Load += new System.EventHandler(this.RenLuyen_SV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ComboBox comboBox_HK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BT_Save;
    }
}