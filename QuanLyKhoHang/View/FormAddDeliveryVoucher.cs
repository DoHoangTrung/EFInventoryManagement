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
            /*LoadDeliveryVoucher();
            LoadCustomer();
            
            LoadProductType();
            //LoadDTGViewInfo();*/

            comboBoxTest.DataSource = ProductCanSellDAO.Instance.GetProductCanSellByType("1");
            labelTest.Text = "";

        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            comboBoxTest.DataSource = null;
            comboBoxTest.Items.Clear();
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
            List<ProductCanSell> productCanSell = ProductCanSellDAO.Instance.GetProductCanSellByType(typeID);

            if(productCanSell == null)
            {
                comboBoxProductID.DataSource = null;
                comboBoxProductName.DataSource = null;

                comboBoxProductID.ResetText();
            }
            else
            {
                comboBoxProductID.DataSource = productCanSell;
                comboBoxProductName.DataSource = productCanSell;

                comboBoxProductID.DisplayMember = "ProductID";
                comboBoxProductName.DisplayMember = "ProductName";
            }
        }

        private void comboBoxProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTest.Text = comboBoxProductID.Items.Count.ToString();
            int? inventoryNum = 0;
            float? averagePrice = 0;
            
            ProductCanSell p = (sender as ComboBox).SelectedItem as ProductCanSell;
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
            }
        }

        
    }
}
