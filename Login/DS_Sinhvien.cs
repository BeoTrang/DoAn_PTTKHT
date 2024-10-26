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
        
        public DS_Sinhvien()
        {
            InitializeComponent();
        }

        private void DS_Sinhvien_Load(object sender, EventArgs e)
        {
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
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            DGV.DataSource = dataBase_SQL;
        }
    }
}
