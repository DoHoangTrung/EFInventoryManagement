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
    public partial class FormUpdateCustomer : Form
    {
        public Customer customerSelectedFromListView;

        public FormUpdateCustomer()
        {
            InitializeComponent();
        }

        private void FormUpdateCustomer_Load(object sender, EventArgs e)
        {
            labelCustomerID.Text = customerSelectedFromListView.ID;

            textBoxCustomerName.Text = customerSelectedFromListView.Name;
            textBoxCustomerAddress.Text = customerSelectedFromListView.Address;
            textBoxCustomerPhone.Text = customerSelectedFromListView.Phone;
            textBoxCustomerEmail.Text = customerSelectedFromListView.Email;

            textBoxCustomerNameUpdate.Text = customerSelectedFromListView.Name;
            textBoxCustomerAddressUpdate.Text = customerSelectedFromListView.Address;
            textBoxCustomerPhoneUpdate.Text = customerSelectedFromListView.Phone;
            textBoxCustomerEmailUpdate.Text = customerSelectedFromListView.Email;

            labelCustomerIDUpdate.Text = customerSelectedFromListView.ID;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string id, name, adderss, phoneNum, email;
            id = labelCustomerIDUpdate.Text;
            name = textBoxCustomerNameUpdate.Text;
            adderss = textBoxCustomerAddressUpdate.Text;
            phoneNum = textBoxCustomerPhoneUpdate.Text;
            email = textBoxCustomerEmailUpdate.Text;


            int rowAffected = CustomerDAO.Instance.UpdateCustomer(id, name, adderss, phoneNum, email);
            if (rowAffected > 0)
            {
                MessageBox.Show("Sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
