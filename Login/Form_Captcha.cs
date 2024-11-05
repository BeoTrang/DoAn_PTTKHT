using dll_captcha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Login
{
    public partial class Form_Captcha : Form
    {
        public bool IsProgrammaticClose { get; set; } = false;
        private string captcha_output = "";
        public Form_Captcha()
        {
            InitializeComponent();
        }

        private void BT_Captcha_Click(object sender, EventArgs e)
        {
            if (TB_Captcha.Text=="")
            {
                MessageBox.Show("Điền Captcha đi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string captcha_input = TB_Captcha.Text;
            if (captcha_input == captcha_output)
            {
                IsProgrammaticClose = true;
                Close();
            }
            else
            {
                MessageBox.Show("Nhập sai captcha!");
                New_Captcha();
                TB_Captcha.Text = "";
            }
        }
        private string Tao_Text_Random(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] captcha = new char[length];

            for (int i = 0; i < length; i++)
            {
                captcha[i] = chars[random.Next(chars.Length)];
            }
            return new string(captcha);
        }

        private void Captcha_Load(object sender, EventArgs e)
        {
            New_Captcha();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        public void New_Captcha()
        {
            captcha_output = Tao_Text_Random(6);
            Bitmap Anh_Captcha = tao_captcha.TaoCaptcha(captcha_output);
            PicBox_Captcha.Image = Anh_Captcha;
            PicBox_Captcha.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void BT_reloadCaptcha_Click(object sender, EventArgs e)
        {
            New_Captcha();
        }
    }
}
