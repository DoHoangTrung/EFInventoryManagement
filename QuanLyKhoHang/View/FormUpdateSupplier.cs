using QuanLyKhoHang.DAL;
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
    public partial class FormUpdateSupplier : Form
    {
        public Supplier supplierSelectedFromListView;
        public FormUpdateSupplier()
        {
            InitializeComponent();
        }

        private void FormUpdateSupplier_Load(object sender, EventArgs e)
        {
            labelSupplierID.Text = supplierSelectedFromListView.ID;

            textBoxSupplierName.Text = supplierSelectedFromListView.Name;
            textBoxSupplierAddress.Text = supplierSelectedFromListView.Address;
            textBoxSupplierPhone.Text = supplierSelectedFromListView.Phone;
            textBoxSupplierEmail.Text = supplierSelectedFromListView.Email;

            textBoxSupplierNameUpdate.Text = supplierSelectedFromListView.Name;
            textBoxSupplierAddressUpdate.Text = supplierSelectedFromListView.Address;
            textBoxSupplierPhoneUpdate.Text = supplierSelectedFromListView.Phone;
            textBoxSupplierEmailUpdate.Text = supplierSelectedFromListView.Email;

            labelSupplierIDUpdate.Text = supplierSelectedFromListView.ID;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string id, name, adderss, phoneNum, email;
            id = labelSupplierIDUpdate.Text;
            name = textBoxSupplierNameUpdate.Text;
            adderss = textBoxSupplierAddressUpdate.Text;
            phoneNum = textBoxSupplierPhoneUpdate.Text;
            email = textBoxSupplierEmailUpdate.Text;

            
            int rowAffected = SupplierDAO.Instance.UpdateSupplier(id,name,adderss,phoneNum,email);
            if(rowAffected > 0)
            {
                MessageBox.Show("Sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }
    }
}
