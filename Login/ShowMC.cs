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
        public int id { get; set; }
        public ShowMC()
        {
            InitializeComponent();
        }
        public void LoadImage()
        {
            FLP.Controls.Clear();
            FLP.AutoScroll = true;
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            DataTable dataTable = dataBase_SQL.GetMinhchung(id);
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
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadImage();
        }
    }
}
