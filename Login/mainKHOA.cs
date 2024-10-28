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
    public partial class mainKHOA : Form
    {
        public string MGV { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string LoaiTK { get; set; }
        public mainKHOA()
        {
            InitializeComponent();
        }

        private void LB_ChangePWD_Click(object sender, EventArgs e)
        {
            ChangPWD changPWD = new ChangPWD();
            changPWD.uid = MGV;
            changPWD.ShowDialog();
        }

        private void mainKHOA_Load(object sender, EventArgs e)
        {
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            var (HVT, MaKhoa, TenKhoa) = dataBase_SQL.getKHOA(MGV);
            LB_uid.Text = MGV;
            LB_MGV.Text = MGV;
            LB_HVT.Text = HVT;
            LB_HVT_GV.Text = HVT;
            LB_TenKhoa.Text = TenKhoa;
            LB_MaKhoa.Text = MaKhoa;
            this.MaKhoa = MaKhoa;
            this.TenKhoa = TenKhoa;
        }

        private void BT_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChucNang_RL_Click(object sender, EventArgs e)
        {
            ShowClass showClass = new ShowClass();
            showClass.MaKhoa = this.MaKhoa;
            showClass.TenKhoa=this.TenKhoa;
            showClass.ShowDialog();
        }
    }
}
