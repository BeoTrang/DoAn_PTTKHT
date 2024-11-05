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
    public partial class ChangPWD : Form
    {
        public string uid = "";
        public string pwd_old = "";
        public string pwd_new_1 = "";
        public string pwd_new_2 = "";
        public ChangPWD()
        {
            InitializeComponent();
        }

        private void BT_changePWD_Click(object sender, EventArgs e)
        {
            if (TB_oldPWD.Text == "" || TB_newPWD_1.Text == "" || TB_newPWD_2.Text == "")
            {
                MessageBox.Show("Điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pwd_old = TB_oldPWD.Text;
            pwd_new_1 = TB_newPWD_1.Text;
            pwd_new_2 = TB_newPWD_2.Text;
            if (pwd_old == pwd_new_2 || pwd_old == pwd_new_1)
            {
                MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pwd_new_1 != pwd_new_2)
            {
                MessageBox.Show("Mật khẩu mới không khớp nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataBase_SQL dataBase_SQL = new DataBase_SQL();
            bool checkPWD = dataBase_SQL.CheckPWD(uid, pwd_old);
            if (checkPWD == false)
            {
                MessageBox.Show("Nhập sai mật khẩu cũ hoặc lỗi kết nối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                bool CheckUpdate = dataBase_SQL.updatePWD(uid, pwd_new_1);
                if (CheckUpdate == false)
                {
                    MessageBox.Show("Thay đổi mật khẩu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }

        private void ChangPWD_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            TB_newPWD_1.PasswordChar = '*';
            TB_newPWD_2.PasswordChar = '*';
            TB_oldPWD.PasswordChar = '*';
        }
    }
}
