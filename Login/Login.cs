using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using dll_connectSQL;

namespace Login
{
    public partial class Login : Form
    {
        public bool stop = false;
        public int dem_login = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Login_Click(object sender, EventArgs e)
        {
            if (TB_pwd.Text == "" || TB_uid.Text == "")
            {
                MessageBox.Show("Điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string LoaiTK = "";
            string uid = TB_uid.Text;
            string pwd = TB_pwd.Text;
            if (dem_login >= 3)
            {
                Form_Captcha captcha = new Form_Captcha();
                captcha.FormClosing += new FormClosingEventHandler(Captcha_FormClosing);
                captcha.ShowDialog();
                if (stop == true)
                {
                    MessageBox.Show("Bạn không điền Captcha nên không thể đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            DataBase_SQL db = new DataBase_SQL();
            string DangNhap = db.Login(uid, pwd);
            if (DangNhap != null)
            {
                LoaiTK = DangNhap;
                MessageBox.Show("Đăng nhập thành công!");
                dem_login = 0;
                TB_pwd.Text = "";
                if (LoaiTK == "SV")
                {
                    mainSV mainSV = new mainSV();
                    mainSV.MSV = uid;
                    mainSV.LoaiTK = LoaiTK;
                    this.Hide();
                    mainSV.ShowDialog();
                    this.Show();
                }
                else if (LoaiTK == "GV")
                {
                    MessageBox.Show("Main GV!");
                }
                else if (LoaiTK == "KHOA")
                {
                    MessageBox.Show("Main KHOA!");
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dem_login++;
                TB_pwd.Text = "";
                return;
            }

        }
        private void Captcha_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form_Captcha captcha = sender as Form_Captcha;
            if (e.CloseReason == CloseReason.UserClosing && !captcha.IsProgrammaticClose)
            {
                stop = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TB_pwd.PasswordChar = '*';
        }
    }
}
