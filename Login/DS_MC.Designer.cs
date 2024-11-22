namespace Login
{
    partial class DS_MC
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Upload = new System.Windows.Forms.Button();
            this.BT_Delete = new System.Windows.Forms.Button();
            this.BT_SHOW = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(33, 78);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(671, 509);
            this.DGV.TabIndex = 0;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH MINH CHỨNG";
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(33, 593);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(99, 37);
            this.Upload.TabIndex = 2;
            this.Upload.Text = "Thêm ảnh";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // BT_Delete
            // 
            this.BT_Delete.Location = new System.Drawing.Point(138, 593);
            this.BT_Delete.Name = "BT_Delete";
            this.BT_Delete.Size = new System.Drawing.Size(99, 37);
            this.BT_Delete.TabIndex = 3;
            this.BT_Delete.Text = "Xoá ảnh";
            this.BT_Delete.UseVisualStyleBackColor = true;
            this.BT_Delete.Click += new System.EventHandler(this.BT_Delete_Click);
            // 
            // BT_SHOW
            // 
            this.BT_SHOW.Location = new System.Drawing.Point(605, 595);
            this.BT_SHOW.Name = "BT_SHOW";
            this.BT_SHOW.Size = new System.Drawing.Size(99, 37);
            this.BT_SHOW.TabIndex = 4;
            this.BT_SHOW.Text = "Xem ảnh";
            this.BT_SHOW.UseVisualStyleBackColor = true;
            this.BT_SHOW.Click += new System.EventHandler(this.BT_SHOW_Click);
            // 
            // DS_MC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 644);
            this.Controls.Add(this.BT_SHOW);
            this.Controls.Add(this.BT_Delete);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "DS_MC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DS_MC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Button BT_Delete;
        private System.Windows.Forms.Button BT_SHOW;
    }
}