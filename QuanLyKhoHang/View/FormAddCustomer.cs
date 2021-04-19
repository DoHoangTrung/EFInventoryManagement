using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang
{
    public partial class FormAddCustomer : Form
    {
        public FormAddCustomer()
        {
            InitializeComponent();
        }

        private void LoadComboBoxID()
        {
            List<string> listID = CustomerDAO.Instance.GetListCustomerID();

            comboBoxCustomerID.DataSource = listID;
            comboBoxCustomerID.AutoCompleteMode = AutoCompleteMode.Suggest;
            
        }

        private void FormAddCustomer_Load(object sender, EventArgs e)
        {
            LoadComboBoxID();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string id = comboBoxCustomerID.Text;
            if (CustomerDAO.Instance.CheckID(id))
            {
                string name, address, phone, email;
                name = textBoxCustomerName.Text;
                address = textBoxCustomerAddress.Text;
                phone = textBoxCustomerPhone.Text;
                email = textBoxCustomerEmail.Text;

                int rowAffted = CustomerDAO.Instance.InsertCustomer(id, name, address, phone, email);
                if (rowAffted > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
        }

        private void comboBoxCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (CustomerDAO.Instance.CheckID(comboBoxCustomerID.Text))
            {
                labeCustomerIDNotification.Text = "ID không quá 30 kí tự \nvà KHÔNG trùng lặp với ID trong danh sách";
                labeCustomerIDNotification.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                labeCustomerIDNotification.Text = "ID không hợp lệ";
                labeCustomerIDNotification.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBoxCustomerName_TextChanged(object sender, EventArgs e)
        {
            int lengthName = textBoxCustomerName.Text.Length;
            if(lengthName == 0 || lengthName > 100)
            {
                labelCustomerNameNotification.Text = "Tên không hợp lệ";
                labelCustomerNameNotification.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                labelCustomerNameNotification.Text = "Độ dài tên không quá 100 kí tự";
                labelCustomerNameNotification.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}
