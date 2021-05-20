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
        public Supplier supplierSelectedFromDtgv;
        public FormUpdateSupplier()
        {
            InitializeComponent();
        }

        private void FormUpdateSupplier_Load(object sender, EventArgs e)
        {
            labelSupplierID.Text = supplierSelectedFromDtgv.ID;

            textBoxSupplierName.Text = supplierSelectedFromDtgv.Name;
            textBoxSupplierAddress.Text = supplierSelectedFromDtgv.Address;
            textBoxSupplierPhone.Text = supplierSelectedFromDtgv.Phone;
            textBoxSupplierEmail.Text = supplierSelectedFromDtgv.Email;

            textBoxSupplierNameUpdate.Text = supplierSelectedFromDtgv.Name;
            textBoxSupplierAddressUpdate.Text = supplierSelectedFromDtgv.Address;
            textBoxSupplierPhoneUpdate.Text = supplierSelectedFromDtgv.Phone;
            textBoxSupplierEmailUpdate.Text = supplierSelectedFromDtgv.Email;

            labelSupplierIDUpdate.Text = supplierSelectedFromDtgv.ID;
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
