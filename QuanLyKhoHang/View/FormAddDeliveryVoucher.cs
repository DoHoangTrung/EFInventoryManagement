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
            
            LoadProductType();
            //LoadDTGViewInfo();
        }

        private void LoadProductType()
        {
            comboBoxProductType.DataSource = ProductTypeDAO.Instance.GetListProductTypes();
            comboBoxProductType.DisplayMember = "Name";
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

        private void comboBoxProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductType type = ((sender as ComboBox).SelectedItem as ProductType);
            string typeID = type.ID;

            LoadProductByType(typeID);
        }

        private void LoadProductByType(string typeID)
        {
            switch (typeID)
            {
                case "1":

                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }
    }
}
