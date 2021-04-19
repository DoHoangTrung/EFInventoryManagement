using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAT;
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
    public partial class FormDeleteSupplier : Form
    {
        public Supplier supplierSelectedFromListView;
        public FormDeleteSupplier()
        {
            InitializeComponent();
        }

        private void FormDeleteSupplier_Load(object sender, EventArgs e)
        {
            labelSupplierID.Text = supplierSelectedFromListView.ID;
            labelSupplierName.Text = supplierSelectedFromListView.Name;
            labelSupplierAddress.Text = supplierSelectedFromListView.Address;
            labelSupplierPhone.Text = supplierSelectedFromListView.Phone;
            labelSupplierEmail.Text = supplierSelectedFromListView.Email;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int rowAffectd = SupplierDAO.Instance.DeleteSupplier(labelSupplierID.Text);
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
    }
}
