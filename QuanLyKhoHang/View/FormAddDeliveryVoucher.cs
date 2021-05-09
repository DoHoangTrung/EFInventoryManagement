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
using QuanLyKhoHang.DTO;

namespace QuanLyKhoHang.View
{
    public partial class FormAddDeliveryVoucher : Form
    {
        private List<ProductType> sourceType;

        private List<ProductCanSellView> sourceProductCanSell;

        private List<Customer> sourceCustomer;

        private BindingSource bindingSource;

        private List<string> sourceIDDeliveryVoucher;
        public FormAddDeliveryVoucher()
        {
            InitializeComponent();
            sourceProductCanSell = ProductCanSellDAO.Instance.GetProductCanSell();
            sourceType = ProductTypeDAO.Instance.GetListProductTypes();
            sourceCustomer = CustomerDAO.Instance.GetListCustomer();
            bindingSource = new BindingSource();
            sourceIDDeliveryVoucher = new List<string>();
        }

        private void FormAddDeliveryVoucher_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";

            LoadDeliveryVoucher(sourceIDDeliveryVoucher);
            LoadCustomer(sourceCustomer);

            LoadProductType(sourceType);
            LoadDTGViewInfo();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            comboBoxTest.DataSource = null;
            comboBoxTest.Items.Clear();
        }
        private void LoadProductType(List<ProductType> types)
        {
            comboBoxProductType.DataSource = null;
            comboBoxProductType.DataSource = types;
            comboBoxProductType.DisplayMember = "Name";
        }

        private void LoadCustomer(List<Customer> customers)
        {
            comboBoxIDCustomer.DataSource = customers;
            comboBoxIDCustomer.DisplayMember = "ID";

            comboBoxNameCustomer.DataSource = customers;
            comboBoxNameCustomer.DisplayMember = "Name";

        }

        private void LoadDeliveryVoucher(List<string> sourceID)
        {
            comboBoxIDDeliveryVoucher.DataSource = null;
            comboBoxIDDeliveryVoucher.DataSource = sourceID;
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
            List<ProductCanSellView> products = sourceProductCanSell.Where(p => p.IDType == typeID).OrderBy(p => p.ProductName).ToList();

            comboBoxProductID.DataSource = null;
            comboBoxProductName.DataSource = null;

            comboBoxProductID.DataSource = products;
            comboBoxProductName.DataSource = products;

            comboBoxProductID.DisplayMember = "ProductID";
            comboBoxProductName.DisplayMember = "ProductName";
        }

        private void comboBoxProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTest.Text = comboBoxProductID.Items.Count.ToString();
            int? inventoryNum = 0;
            float? averagePrice = 0;

            ProductCanSellView p = (sender as ComboBox).SelectedItem as ProductCanSellView;
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

        public void LoadDTGViewInfo()
        {
            //create dtgv
            dataGridViewDeliveryInfo.Columns.Add("productType", "Loại sản phẩm");
            dataGridViewDeliveryInfo.Columns.Add("productID", "ID sản phẩm");
            dataGridViewDeliveryInfo.Columns.Add("productName", "Tên sản phẩm");
            dataGridViewDeliveryInfo.Columns.Add("deliveryQuantity", "Số lượng xuất");
            dataGridViewDeliveryInfo.Columns.Add("deliveryPrice", "Giá xuất");

            dataGridViewDeliveryInfo.Columns["productType"].DataPropertyName = "ProductTypeName";
            dataGridViewDeliveryInfo.Columns["productID"].DataPropertyName = "ProductID";
            dataGridViewDeliveryInfo.Columns["productName"].DataPropertyName = "ProductName";
            dataGridViewDeliveryInfo.Columns["deliveryQuantity"].DataPropertyName = "DeliveryQuantity";
            dataGridViewDeliveryInfo.Columns["deliveryPrice"].DataPropertyName = "DeliveryPrice";
        }

        private bool CheckDeliveryQuantity()
        {
            decimal deliveryQuantity, inventoryNumber;
            deliveryQuantity = numericUpDownDeliveryQuantity.Value;
            if (!decimal.TryParse(labelInventoryNumber.Text, out inventoryNumber))
            {
                return false;
            }

            return deliveryQuantity <= inventoryNumber;
        }
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (CheckDeliveryQuantity())
            {
                string productType, productName, productID, typeID;
                decimal deliveryQuantity, deliveryPrice;

                ProductType type = (comboBoxProductType.SelectedItem as ProductType);
                ProductCanSellView pSell = (comboBoxProductName.SelectedItem as ProductCanSellView);

                typeID = type.ID;
                productID = pSell.ProductID;
                productType = type.Name;
                productName = pSell.ProductName;
                deliveryQuantity = numericUpDownDeliveryQuantity.Value;
                deliveryPrice = numericUpDownDeliveryPrice.Value;

                DTGViewAddDeliveryVoucherDTO dto = new DTGViewAddDeliveryVoucherDTO(productType, productID, productName, deliveryQuantity, deliveryPrice, typeID);

                bindingSource.Add(dto);

                dataGridViewDeliveryInfo.DataSource = bindingSource;

                // after add productcansell to dtgv, remove it in combobox
                ProductCanSellView product = sourceProductCanSell.Where(p => p.ProductID == productID).FirstOrDefault();
                sourceProductCanSell.Remove(product);

                LoadProductByType(dto.TypeID);
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void buttonAddProduct_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Lưu ý:Số lượng xuất kho không thể lớn hơn số lượng tồn kho";
        }

        private void buttonAddProduct_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void dataGridViewDeliveryInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDeliveryInfo.Tag = e.RowIndex;
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeliveryInfo.Tag != null)
            {
                int rowIndex = int.Parse(dataGridViewDeliveryInfo.Tag.ToString());
                {
                    if (rowIndex >= 0 && rowIndex < dataGridViewDeliveryInfo.Rows.Count - 1)
                    {
                        DTGViewAddDeliveryVoucherDTO rowObj = dataGridViewDeliveryInfo.Rows[rowIndex].DataBoundItem as DTGViewAddDeliveryVoucherDTO;
                        ProductCanSellView product = ProductCanSellDAO.Instance.GetProductCanSellByProductID(rowObj.ProductID);

                        //remove row clicked from dtgv
                        bindingSource.Remove(rowObj);
                        dataGridViewDeliveryInfo.DataSource = bindingSource;
                        //add productcansell that removed to combobox product
                        sourceProductCanSell.Add(product);
                        LoadProductByType(rowObj.TypeID);
                    }
                }
            }
            {
                MessageBox.Show("Bạn hãy chọn dòng muốn xóa");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckIDValid(string _id)
        {
            string idTrim =_id.Trim();
            string id = sourceIDDeliveryVoucher.Where(i => i == _id).FirstOrDefault();
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(idTrim)) return false;
            else return true;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string idDeliveryVoucher, idCustomer;
            DateTime date = dateTimePickerDeliveryDate.Value;
            idDeliveryVoucher = comboBoxIDDeliveryVoucher.Text;
            idCustomer = sourceCustomer[comboBoxIDCustomer.SelectedIndex].ID;
            if (CheckIDValid(idDeliveryVoucher))
            {
                DeliveryVoucher voucher = new DeliveryVoucher();
                voucher.ID = idDeliveryVoucher;
                voucher.IDCustomer = idCustomer;
                voucher.Date = date;
                DeliveryVoucherDAO.Instance.Insert(voucher);

                //insert delivery voucher info
                

                foreach (var proCanSell in bindingSource)
                {
                    DTGViewAddDeliveryVoucherDTO deVoucherInfo = (proCanSell as DTGViewAddDeliveryVoucherDTO);
                    int quantity = (int)deVoucherInfo.DeliveryQuantity;

                    List<ReceiveVoucherInfo> receiveVouchers = ReceiveVoucherInfoDAO.Instance.GetListProductCanSellByID(deVoucherInfo.ProductID)
                    .OrderBy(i => i.ReceiveVoucher.Date).ToList();

                    foreach (var info in receiveVouchers)
                    {
                        if (info.QuantityOutput <  quantity)
                        {
                            quantity = quantity - info.QuantityOutput??default(int);
                        }
                        else if(info.QuantityOutput >= quantity)
                        {

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ID phiếu xuất không hợp lệ");
            }
                
        }
    }
}
