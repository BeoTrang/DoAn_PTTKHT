using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll_connectSQL;

namespace Login
{
    public partial class ShowClass : Form
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public int Row { get; set; }
        public string LoaiTK { get; set; }
        public string TenLop { get; set; }
        public string MaLop { get; set; }
        public ShowClass()
        {
            InitializeComponent();
        }

        private void ShowClass_Load(object sender, EventArgs e)
        {
            Row = -1;
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            DGV.DataSource = dataBase_SQL.DS_Lop(MaKhoa);
            LB_TenKhoa.Text=TenKhoa;
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGV.ScrollBars = ScrollBars.Both;
            DGV.AllowUserToAddRows = false;
            
            DGV.Columns[0].ReadOnly = true;
            DGV.Columns[1].ReadOnly = true;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Row = e.RowIndex;
                MaLop = DGV.Rows[Row].Cells[0].Value.ToString();
                TenLop = DGV.Rows[Row].Cells[1].Value.ToString();
                MessageBox.Show(MaLop);
                MessageBox.Show(TenLop);
            }
        }

        private void BT_Choose_Click(object sender, EventArgs e)
        {
            if (Row < 0)
            {
                MessageBox.Show("Bạn chưa chọn lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DS_Sinhvien dS_Sinhvien = new DS_Sinhvien();
            dS_Sinhvien.MaLop = this.MaLop;
            dS_Sinhvien.TenLop = this.TenLop;
            dS_Sinhvien.LoaiTK = this.LoaiTK;
            dS_Sinhvien.ShowDialog();
        }
    }
}
