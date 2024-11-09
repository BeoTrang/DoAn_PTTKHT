namespace Login
{
    partial class ShowMC
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
            this.FLP = new System.Windows.Forms.FlowLayoutPanel();
            this.Upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FLP
            // 
            this.FLP.Location = new System.Drawing.Point(27, 32);
            this.FLP.Name = "FLP";
            this.FLP.Size = new System.Drawing.Size(877, 754);
            this.FLP.TabIndex = 0;
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(805, 792);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(99, 37);
            this.Upload.TabIndex = 1;
            this.Upload.Text = "Tải ảnh";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // ShowMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 856);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.FLP);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ShowMC";
            this.Text = "Minh chứng";
            this.Load += new System.EventHandler(this.ShowMC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FLP;
        private System.Windows.Forms.Button Upload;
    }
}