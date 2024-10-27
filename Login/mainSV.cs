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
    public partial class mainSV : Form
    {
        public string MSV { get; set; }
        public string LoaiTK { get; set; }

        public mainSV()
        {
            InitializeComponent();
        }

        private void ChucNang_RL_Click(object sender, EventArgs e)
        {
            RenLuyen_SV renLuyen_SV = new RenLuyen_SV();
            renLuyen_SV.MSV = MSV;
            renLuyen_SV.LoaiTK = LoaiTK;
            renLuyen_SV.ShowDialog();
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

        private void LB_ChangePWD_Click(object sender, EventArgs e)
        {
            ChangPWD changPWD = new ChangPWD();
            changPWD.uid = MSV;
            changPWD.ShowDialog();
        }

        private void mainSV_Load(object sender, EventArgs e)
        {
            LB_uid.Text = MSV;
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            var (HVT_SV, MaLop, TenLop, MaKhoa, TenKhoa, MGV, HVT_GV) = dataBase_SQL.GetSV(MSV);
            LB_HVT.Text = HVT_SV;
            LB_HVT_SV.Text = HVT_SV;
            LB_MSV.Text = MSV;
            LB_MaLop.Text = MaLop;
            LB_TenLop.Text = TenLop;
            LB_MaKhoa.Text = MaKhoa;
            LB_TenKhoa.Text = TenKhoa;
            LB_MGV.Text = MGV;
            LB_HVT_GV.Text = HVT_GV;
        }
    }
}
