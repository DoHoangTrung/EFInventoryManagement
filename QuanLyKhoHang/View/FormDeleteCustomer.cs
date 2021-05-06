using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity_EF;
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
    public partial class FormDeleteCustomer : Form
    {
        public Customer customerSelectedFromListView;
        public FormDeleteCustomer()
        {
            InitializeComponent();
        }

        private void FormDeleteCustomer_Load(object sender, EventArgs e)
        {
            labelCustomerID.Text = customerSelectedFromListView.ID;
            labelCustomerName.Text = customerSelectedFromListView.Name;
            labelCustomerAddress.Text = customerSelectedFromListView.Address;
            labelCustomerPhone.Text = customerSelectedFromListView.Phone;
            labelCustomerEmail.Text = customerSelectedFromListView.Email;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int rowAffectd = CustomerDAO.Instance.DeleteCustomer(labelCustomerID.Text);
            if (rowAffectd > 0)
            {
                MessageBox.Show("Xóa thành công");
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
