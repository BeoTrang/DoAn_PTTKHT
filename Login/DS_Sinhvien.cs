using dll_connectSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class DS_Sinhvien : Form
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int Row { get; set; }
        public string MaSV { get; set; }
        public string LoaiTK { get; set; }
        public DS_Sinhvien()
        {
            InitializeComponent();
        }

        private void DS_Sinhvien_Load(object sender, EventArgs e)
        {
            LB_TenLop.Text = TenLop;
            Row = -1;
            CreateDGV();
        }
        public void CreateDGV()
        {
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGV.ScrollBars = ScrollBars.Both;
            DGV.AllowUserToAddRows = false;
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            DGV.DataSource = dataBase_SQL.DS_sinhvien(MaLop);
            DGV.Columns[0].ReadOnly = true;
            DGV.Columns[1].ReadOnly = true;
        }

        private void BT_Choose_Click(object sender, EventArgs e)
        {
            if (Row < 0)
            {
                MessageBox.Show("Bạn chưa chọn sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RenLuyen_SV renLuyen_SV = new RenLuyen_SV();
            renLuyen_SV.LoaiTK = this.LoaiTK;
            renLuyen_SV.MSV = this.MaSV;
            renLuyen_SV.ShowDialog();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Row = e.RowIndex;
                MaSV = DGV.Rows[Row].Cells[0].Value.ToString();
            }
        }
    }
}
