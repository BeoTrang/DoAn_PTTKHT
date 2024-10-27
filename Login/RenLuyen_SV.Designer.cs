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
            this.BT_Reload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.LB_SUM_SV = new System.Windows.Forms.Label();
            this.LB_SUM_KHOA = new System.Windows.Forms.Label();
            this.LB_SUM_CVHT = new System.Windows.Forms.Label();
            this.LB_Tong = new System.Windows.Forms.Label();
            this.LB_XepLoai = new System.Windows.Forms.Label();
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
            this.DGV.Location = new System.Drawing.Point(12, 136);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(1279, 478);
            this.DGV.TabIndex = 2;
            this.DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellEndEdit);
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
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // BT_Reload
            // 
            this.BT_Reload.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BT_Reload.Location = new System.Drawing.Point(1177, 101);
            this.BT_Reload.Name = "BT_Reload";
            this.BT_Reload.Size = new System.Drawing.Size(114, 29);
            this.BT_Reload.TabIndex = 8;
            this.BT_Reload.Text = "Tải lại";
            this.BT_Reload.UseVisualStyleBackColor = true;
            this.BT_Reload.Click += new System.EventHandler(this.BT_Reload_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(956, 617);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label6.Size = new System.Drawing.Size(95, 31);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tổng điểm:";
            // 
            // LB_SUM_SV
            // 
            this.LB_SUM_SV.AutoSize = true;
            this.LB_SUM_SV.Location = new System.Drawing.Point(1066, 617);
            this.LB_SUM_SV.Name = "LB_SUM_SV";
            this.LB_SUM_SV.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.LB_SUM_SV.Size = new System.Drawing.Size(34, 31);
            this.LB_SUM_SV.TabIndex = 10;
            this.LB_SUM_SV.Text = "SV";
            // 
            // LB_SUM_KHOA
            // 
            this.LB_SUM_KHOA.AutoSize = true;
            this.LB_SUM_KHOA.Location = new System.Drawing.Point(1209, 617);
            this.LB_SUM_KHOA.Name = "LB_SUM_KHOA";
            this.LB_SUM_KHOA.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.LB_SUM_KHOA.Size = new System.Drawing.Size(63, 31);
            this.LB_SUM_KHOA.TabIndex = 11;
            this.LB_SUM_KHOA.Text = "KHOA";
            // 
            // LB_SUM_CVHT
            // 
            this.LB_SUM_CVHT.AutoSize = true;
            this.LB_SUM_CVHT.Location = new System.Drawing.Point(1133, 617);
            this.LB_SUM_CVHT.Name = "LB_SUM_CVHT";
            this.LB_SUM_CVHT.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.LB_SUM_CVHT.Size = new System.Drawing.Size(61, 31);
            this.LB_SUM_CVHT.TabIndex = 12;
            this.LB_SUM_CVHT.Text = "CVHT";
            // 
            // LB_Tong
            // 
            this.LB_Tong.AutoSize = true;
            this.LB_Tong.ForeColor = System.Drawing.Color.Red;
            this.LB_Tong.Location = new System.Drawing.Point(252, 643);
            this.LB_Tong.Name = "LB_Tong";
            this.LB_Tong.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.LB_Tong.Size = new System.Drawing.Size(117, 31);
            this.LB_Tong.TabIndex = 13;
            this.LB_Tong.Text = "Điểm công bố";
            // 
            // LB_XepLoai
            // 
            this.LB_XepLoai.AutoSize = true;
            this.LB_XepLoai.ForeColor = System.Drawing.Color.Red;
            this.LB_XepLoai.Location = new System.Drawing.Point(277, 674);
            this.LB_XepLoai.Name = "LB_XepLoai";
            this.LB_XepLoai.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.LB_XepLoai.Size = new System.Drawing.Size(72, 31);
            this.LB_XepLoai.TabIndex = 14;
            this.LB_XepLoai.Text = "Xếp loại";
            // 
            // RenLuyen_SV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 740);
            this.Controls.Add(this.LB_XepLoai);
            this.Controls.Add(this.LB_Tong);
            this.Controls.Add(this.LB_SUM_CVHT);
            this.Controls.Add(this.LB_SUM_KHOA);
            this.Controls.Add(this.LB_SUM_SV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BT_Reload);
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
        private System.Windows.Forms.Button BT_Reload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LB_SUM_SV;
        private System.Windows.Forms.Label LB_SUM_KHOA;
        private System.Windows.Forms.Label LB_SUM_CVHT;
        private System.Windows.Forms.Label LB_Tong;
        private System.Windows.Forms.Label LB_XepLoai;
    }
}