namespace Login
{
    partial class ShowClass
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
            this.LB_TenKhoa = new System.Windows.Forms.Label();
            this.BT_Choose = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_TenKhoa
            // 
            this.LB_TenKhoa.AutoSize = true;
            this.LB_TenKhoa.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_TenKhoa.ForeColor = System.Drawing.Color.Red;
            this.LB_TenKhoa.Location = new System.Drawing.Point(375, 9);
            this.LB_TenKhoa.Name = "LB_TenKhoa";
            this.LB_TenKhoa.Size = new System.Drawing.Size(116, 31);
            this.LB_TenKhoa.TabIndex = 7;
            this.LB_TenKhoa.Text = "Tên khoa";
            // 
            // BT_Choose
            // 
            this.BT_Choose.Location = new System.Drawing.Point(414, 477);
            this.BT_Choose.Name = "BT_Choose";
            this.BT_Choose.Size = new System.Drawing.Size(99, 31);
            this.BT_Choose.TabIndex = 6;
            this.BT_Choose.Text = "Chọn lớp";
            this.BT_Choose.UseVisualStyleBackColor = true;
            this.BT_Choose.Click += new System.EventHandler(this.BT_Choose_Click);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 53);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(512, 418);
            this.DGV.TabIndex = 5;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(77, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Danh sách lớp trong khoa:";
            // 
            // ShowClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 517);
            this.Controls.Add(this.LB_TenKhoa);
            this.Controls.Add(this.BT_Choose);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "ShowClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách lớp";
            this.Load += new System.EventHandler(this.ShowClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_TenKhoa;
        private System.Windows.Forms.Button BT_Choose;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label2;
    }
}