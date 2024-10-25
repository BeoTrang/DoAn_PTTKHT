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
    public partial class mainGV : Form
    {
        public string MGV { get; set; } 
        public string LoaiTK { get; set; }
        public mainGV()
        {
            InitializeComponent();
        }

        private void mainGV_Load(object sender, EventArgs e)
        {
            LB_uid.Text = MGV;
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            var (HVT_GV, MaLop, TenLop, MaKhoa, TenKhoa ) = dataBase_SQL.GetGV(MGV);
            LB_MGV.Text = MGV;
            LB_HVT.Text = HVT_GV;
            LB_HVT_GV.Text = HVT_GV;
            LB_MaLop.Text = MaLop;
            LB_TenLop.Text = TenLop;
            LB_MaKhoa.Text = MaKhoa;
            LB_TenKhoa.Text = TenKhoa;
            LB_HVT_GV.Text = HVT_GV;
        }

        private void LB_ChangePWD_Click(object sender, EventArgs e)
        {
            ChangPWD changPWD = new ChangPWD();
            changPWD.uid = MGV;
            changPWD.ShowDialog();
        }

        private void ChucNang_RL_MouseEnter(object sender, EventArgs e)
        {
            ChucNang_RL.Cursor = Cursors.Hand;
        }

        private void ChucNang_RL_MouseLeave(object sender, EventArgs e)
        {
            ChucNang_RL.Cursor = Cursors.Default;
        }                                               

        private void BT_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
