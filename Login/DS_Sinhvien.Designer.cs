namespace Login
{
    partial class DS_Sinhvien
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
            this.label2 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.BT_Choose = new System.Windows.Forms.Button();
            this.LB_TenLop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(77, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh sách sinh viên lớp:";
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 65);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(512, 418);
            this.DGV.TabIndex = 1;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // BT_Choose
            // 
            this.BT_Choose.Location = new System.Drawing.Point(408, 489);
            this.BT_Choose.Name = "BT_Choose";
            this.BT_Choose.Size = new System.Drawing.Size(99, 31);
            this.BT_Choose.TabIndex = 2;
            this.BT_Choose.Text = "Chọn SV";
            this.BT_Choose.UseVisualStyleBackColor = true;
            this.BT_Choose.Click += new System.EventHandler(this.BT_Choose_Click);
            // 
            // LB_TenLop
            // 
            this.LB_TenLop.AutoSize = true;
            this.LB_TenLop.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_TenLop.ForeColor = System.Drawing.Color.Red;
            this.LB_TenLop.Location = new System.Drawing.Point(364, 21);
            this.LB_TenLop.Name = "LB_TenLop";
            this.LB_TenLop.Size = new System.Drawing.Size(99, 31);
            this.LB_TenLop.TabIndex = 3;
            this.LB_TenLop.Text = "Tên lớp";
            // 
            // DS_Sinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 542);
            this.Controls.Add(this.LB_TenLop);
            this.Controls.Add(this.BT_Choose);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DS_Sinhvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS_Sinhvien";
            this.Load += new System.EventHandler(this.DS_Sinhvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button BT_Choose;
        private System.Windows.Forms.Label LB_TenLop;
    }
}