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
                FormHome fAdd = new FormHome();
                this.Hide();
                fAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ban da nhap sai, hay nhap lai","Thông báo");
            }
        }

        private bool Login(string userName, string passWord)
        {
            //return AccountDAO.Instance.Login(userName, passWord);
            return false;
        }

    }
}
