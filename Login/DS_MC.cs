using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using dll_connectSQL;

namespace Login
{
    public partial class DS_MC : Form
    {
        public string MSV { get; set; }
        public string Tieuchi { get; set; }
        public string MaHK { get; set; }
        public string LoaiTK { get; set; }
        public List<int> Anh { get; set; }
        public int id { get; set; }
        public int ROW { get; set; }
        public DS_MC()
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
            CreateDGV();
        }

        private void CreateDGV()
        {
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            var Anh = dataBase_SQL.LayAnh(MSV, MaHK, Tieuchi); 
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGV.ScrollBars = ScrollBars.Both;
            DGV.Columns.Add("0", "STT");
            DGV.Columns.Add("1", "Mã hình ảnh");
            DGV.Columns[0].ReadOnly = true;
            DGV.Columns[1].ReadOnly = true;
            for (int i = 0; i < Anh.Count; i++)
            {
                DGV.Rows.Add(i+1, Anh[i]);
            }
            DGV.AllowUserToAddRows = false;
        }

        private void DS_MC_Load(object sender, EventArgs e)
        {
            CreateDGV();
            ROW = -1;
        }

        private void BT_SHOW_Click(object sender, EventArgs e)
        {
            if (ROW < 0)
            {
                MessageBox.Show("Bạn chưa chọn ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ShowMC showMC = new ShowMC();
                showMC.id=this.id;
                showMC.ShowDialog();
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                ROW = -1;
                return;
            }
            ROW = e.RowIndex;
            id = (int)DGV.Rows[e.RowIndex].Cells[1].Value;
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            if (ROW < 0)
            {
                MessageBox.Show("Bạn chưa chọn ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            bool kq = dataBase_SQL.XoaMinhchung(id);
            if (kq==true)
            {
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("Xoá không thành công");
            }
            CreateDGV();
        }
    }
}
