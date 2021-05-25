using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHang.DAL;

namespace QuanLyKhoHang
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            lbNotification.Text = "";
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult choice = MessageBox.Show("Bạn đồng ý thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (choice != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string userName, passWord;
            userName = textBoxUserName.Text;
            passWord = textBoxPassword.Text;

            if (Login(userName,passWord))
            {
                FormHome f = new FormHome();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                lbNotification.ForeColor = Color.DarkRed;
                lbNotification.Text = "Tài khoản hoặc mật khẩu không chính xác.\r\n Vui lòng nhập lại";
                textBoxUserName.Text = "Tài khoản";
                textBoxPassword.Text = "Mật khẩu";

                userClick = 1;
                passwordClick = 1;
                textBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private bool Login(string userName, string passWord)
        {
            AccountDAO dao = new AccountDAO();
            return dao.Login(userName, passWord);
        }

        int userClick = 1;
       
        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            if (userClick == 1) //first click
            {
                textBoxUserName.Text = "";

                userClick++;
            }

            textBoxUserName.SelectAll();
            textBoxPassword.SelectionLength = 0;

            textBoxUserName.ForeColor = Color.FromArgb(20, 39, 82);
            panel1.BackColor = Color.FromArgb(20, 39, 82);

            textBoxPassword.ForeColor = Color.White;
            panel2.BackColor = Color.White;
        }

        int passwordClick = 1;

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (passwordClick == 1)//first click
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;

                passwordClick++;
            }

            textBoxPassword.SelectAll();
            textBoxUserName.SelectionLength = 0;

            textBoxPassword.ForeColor = Color.FromArgb(20, 39, 82);
            panel2.BackColor = Color.FromArgb(20, 39, 82);

            textBoxUserName.ForeColor = Color.White;
            panel1.BackColor = Color.White;

        }
    }
}
