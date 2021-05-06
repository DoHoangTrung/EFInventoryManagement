using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
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
            LoadDTGViewInfo();
        }

        

        private void LoadProductType()
        {
            comboBoxProductType.DataSource = null;
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
            comboBoxIDDeliveryVoucher.DataSource = null;
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
            List<Product> proCanSell = ProductDAO.Instance.GetProductsCanSellByType(typeID);
            comboBoxProductID.DataSource = null;
            comboBoxProductName.DataSource = null;

            comboBoxProductID.DataSource = proCanSell;
            comboBoxProductName.DataSource = proCanSell;

            comboBoxProductID.DisplayMember = "ID";
            comboBoxProductName.DisplayMember = "Name";
        }

        private void comboBoxProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*int? inventoryNum = 0;
            float? averagePrice = 0;

            ProductCanSellDAT p = (sender as ComboBox).SelectedItem as ProductCanSellDAT;
            if (p != null)
            {
                inventoryNum = p.SumQuantityInput - p.SumQuantityOutput;
                averagePrice = (float)p.SumPriceInput / p.Count;

                labelInventoryNumber.Text = inventoryNum.ToString();
                labelAveragePrice.Text = averagePrice.ToString();

            }
            else
            {
                labelInventoryNumber.Text = "";
                labelAveragePrice.Text = "";
            }*/
        }

        private void LoadDTGViewInfo()
        {
            //create DTGView
            dataGridViewDeliveryInfo.Columns.Add("ProductID","ID sản phẩm");
            dataGridViewDeliveryInfo.Columns.Add("ProductName","Tên");
            dataGridViewDeliveryInfo.Columns.Add("DeliveryQuantity","Số lượng xuất");
            dataGridViewDeliveryInfo.Columns.Add("DeliveryPrice", "Giá xuất");

            //load data
        }

        
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
