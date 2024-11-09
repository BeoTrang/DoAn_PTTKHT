using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using dll_connectSQL;

namespace Login
{
    public partial class ShowMC : Form
    {
        public string MSV { get; set; }
        public string Tieuchi { get; set; }
        public string MaHK { get; set; }
        public string LoaiTK { get; set; }
        public ShowMC()
        {
            InitializeComponent();
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff",
                Title = "Select an Image"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(filePath);
                SaveImage(imageData);
            }

        }
        private void SaveImage(byte[] imageData)
        {
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            dataBase_SQL.LuuMinhchung(MSV, MaHK, Tieuchi, imageData);
            MessageBox.Show("Tải ảnh thành công!");
            LoadImage();
        }
        public void LoadImage()
        {
            FLP.Controls.Clear();
            FLP.AutoScroll = true;
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            DataTable dataTable = dataBase_SQL.GetMinhchung(MSV, MaHK, Tieuchi);
            foreach (DataRow row in dataTable.Rows)
            {
                byte[] imageData = row["Anh"] as byte[];
                PictureBox pictureBox = new PictureBox
                {
                    Width = FLP.Width,
                    Height = FLP.Height,
                    SizeMode = PictureBoxSizeMode.Zoom, 
                    Margin = new Padding(5)
                };
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
                FLP.Controls.Add(pictureBox);
            }
        }
        private void ShowMC_Load(object sender, EventArgs e)
        {
            if (LoaiTK != "SV")
            {
                Upload.Hide();
            }
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadImage();
        }
    }
}
