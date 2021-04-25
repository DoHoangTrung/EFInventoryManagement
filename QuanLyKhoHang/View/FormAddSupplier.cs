using QuanLyKhoHang.DAL;
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
    public partial class FormAddSupplier : Form
    {
        public FormAddSupplier()
        {
            InitializeComponent();
        }

        private void FormAddSupplier_Load(object sender, EventArgs e)
        {
            List<string> listID = SupplierDAO.Instance.GetListSupplierID();
            comboBoxSupplierID.DataSource = listID;
            comboBoxSupplierID.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxSupplierID.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void comboBoxSupplierID_TextChanged(object sender, EventArgs e)
        {
            if (!SupplierDAO.Instance.CheckID(comboBoxSupplierID.Text))
            {
                labelSupplierIDNotification.Text = "ID không phù hợp";
                labelSupplierIDNotification.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                labelSupplierIDNotification.Text = "Nhập không quá 30 kí tự \nKHÔNG TRÙNG LẶP với các id khác";
                labelSupplierIDNotification.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string id = comboBoxSupplierID.Text;
            if (SupplierDAO.Instance.CheckID(id))
            {
                string name, address, phone, email;
                name = textBoxSupplierName.Text;
                address = textBoxSupplierAddress.Text;
                phone = textBoxSupplierPhone.Text;
                email = textBoxSupplierEmail.Text;

                int rowAffted = SupplierDAO.Instance.InsertSupplier(id, name, address, phone, email);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string name = textBoxSupplierName.Text;
            if (name.Length > 100 || name.Length == 0)
            {
                labelSupplierNameNotification.Text = "Bạn đã nhập sai";
                labelSupplierNameNotification.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                labelSupplierNameNotification.Text = "Hãy nhập tên không vượt quá 100 kí tự";
                labelSupplierNameNotification.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}
