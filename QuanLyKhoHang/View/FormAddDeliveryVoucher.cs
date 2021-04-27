using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
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

namespace QuanLyKhoHang.View
{
    public partial class FormAddDeliveryVoucher : Form
    {
        public FormAddDeliveryVoucher()
        {
            InitializeComponent();
        }

        private void FormAddDeliveryVoucher_Load(object sender, EventArgs e)
        {
            LoadDeliveryVoucher();
            LoadCustomer();
            //LoadProduct();
            //LoadDTGViewInfo();
        }

        private void LoadCustomer()
        {
            List<Customer> customers = CustomerDAO.Instance.GetListCustomer();

            comboBoxIDCustomer.DataSource = customers;
            comboBoxIDCustomer.DisplayMember = "ID";

            comboBoxNameCustomer.DataSource = customers;
            comboBoxNameCustomer.DisplayMember = "Name";

        }

        private void LoadDeliveryVoucher()
        {
            comboBoxIDDeliveryVoucher.DataSource = DeliveryVoucherDAO.Instance.GetListID();
        }

        private void comboBoxIDCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            labelPhoneCustomer.Text = (comboBoxIDCustomer.SelectedItem as Customer).Phone;
        }
    }
}
