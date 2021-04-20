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

namespace QuanLyKhoHang
{
    public partial class FormUpdateReceiveVoucher : Form
    {
        public string idInputVoucher { get; set; }

        public ReceiveVoucher receiveVoucher;

        private List<ReceicveVoucherInfo> receicveVoucherInfos;

        private Supplier supplierInVoucher;

        private List<Product> listProductOutOfReceiveVoucher;
        public FormUpdateReceiveVoucher()
        {
            InitializeComponent();
        }


        #region EVENT   
        private void FormUpdateInputVoucher_Load(object sender, EventArgs e)
        {
            InitField();
            LoadVoucherCombobox();
            LoadProductCombobox();
            LoadSupplierCombobox();
            LoadVoucherInfoDatagridview();
        }

        private void comboBoxIDSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelAddressSupplier.Text = (comboBoxIDSupplier.SelectedItem as Supplier).Address;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            string id, name, note;
            int inputQuantity, inputPrice, outputPrice;
            id = comboBoxProductID.Text;
            name = comboBoxProductName.Text;
            inputQuantity = (int)numericUpDownInputQuatity.Value;
            inputPrice = (int)numericUpDownInputPrice.Value;
            outputPrice = (int)numericUpDownOutputPrice.Value;
            note = textBoxNote.Text;
            const int outputQuantity = 0;
            if (inputQuantity > 0)
            {
                dataGridViewProduct.Rows.Add(id, name, inputQuantity, inputPrice, outputPrice, outputQuantity, note);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
            }

            //after add good: remove id of that good from combobox (id good can't dupplication)
            //and clear textboxNote
            var products = comboBoxProductID.Items.Cast<Product>().ToList();
            products.RemoveAt(comboBoxProductID.SelectedIndex);
            textBoxNote.Clear();

            LoadProductCombobox(products);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if(dataGridViewProduct.Tag != null)
            {
                int rowIndex = (int)dataGridViewProduct.Tag;
                if (rowIndex >= 0 && rowIndex < dataGridViewProduct.RowCount - 1)
                {
                    string idProduct = dataGridViewProduct.Rows[rowIndex].Cells["productID"].Value.ToString();
                    Product productRemoved = ProductDAO.Instance.GetProductByID(idProduct);

                    //before delete product in datagridview, we must add that product to comboboxProduct
                    List<Product> productsCombobox = comboBoxProductID.Items.Cast<Product>().ToList();
                    productsCombobox.Add(productRemoved);

                    LoadProductCombobox(productsCombobox);

                    dataGridViewProduct.Rows.RemoveAt(rowIndex);

                    dataGridViewProduct.Tag = null;
                }
            }
        }
        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewProduct.Tag = e.RowIndex;
        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            buttonAddProduct.Enabled = false;
        }
        #endregion

        private void LoadVoucherInfoDatagridview()
        {
            //Create dataGridView product
            dataGridViewProduct.Columns.Add("productID", "ID");
            dataGridViewProduct.Columns.Add("productName", "Tên sản phẩm");
            dataGridViewProduct.Columns.Add("quantityInput", "Số lượng nhập");
            dataGridViewProduct.Columns.Add("inputPrice", "Giá nhập");
            dataGridViewProduct.Columns.Add("outputPrice", "Giá xuất");
            dataGridViewProduct.Columns.Add("quatityOutput", "Số lượng xuất");
            dataGridViewProduct.Columns.Add("note", "Ghi chú");

            //add data
            foreach (var voucherInfo in receicveVoucherInfos)
            {
                Product productInVoucherInfo = voucherInfo.Product;

                string id, name, note;
                int? quantityInput, inputPrice, outputPrice, quantityOutput;

                id = productInVoucherInfo.ID;
                name = productInVoucherInfo.Name;
                quantityInput = voucherInfo.QuatityInput;
                inputPrice = voucherInfo.PriceInput;
                outputPrice = voucherInfo.PriceOutput;
                quantityOutput = voucherInfo.QuatityOutput;
                note = voucherInfo.Note;
                
                dataGridViewProduct.Rows.Add(id, name, quantityInput, inputPrice, outputPrice, quantityOutput, note);
            }
        }

        private void LoadSupplierCombobox()
        {
            List<Supplier> suppliers = SupplierDAO.Instance.GetListSupplier();

            comboBoxIDSupplier.DataSource = suppliers;
            comboBoxIDSupplier.DisplayMember = "ID";

            comboBoxNameSupplier.DataSource = suppliers;
            comboBoxNameSupplier.DisplayMember = "Name";

        }

        private void LoadProductCombobox()
        {
            listProductOutOfReceiveVoucher = listProductOutOfReceiveVoucher.OrderBy(p => p.ID).ToList() ;

            comboBoxProductID.DataSource = listProductOutOfReceiveVoucher;
            comboBoxProductID.DisplayMember = "ID";

            comboBoxProductName.DataSource = listProductOutOfReceiveVoucher;
            comboBoxProductName.DisplayMember = "Name";
        }

        private void LoadProductCombobox(List<Product> products)
        {
            products = products.OrderBy(p => p.ID).ToList();

            comboBoxProductID.DataSource = products;
            comboBoxProductID.DisplayMember = "ID";

            comboBoxProductName.DataSource = products;
            comboBoxProductName.DisplayMember = "Name";
        }

        private void LoadVoucherCombobox()
        {
            textBoxIDInputVoucher.Text = receiveVoucher.ID;

            if(receiveVoucher != null)
            {
                dateTimePickerInputDate.Value = (DateTime)receiveVoucher.Date;
            }
        }

        private void InitField()
        {
            receicveVoucherInfos = receiveVoucher.ReceicveVoucherInfoes.ToList();

            supplierInVoucher = receiveVoucher.Supplier;

            listProductOutOfReceiveVoucher = ProductDAO.Instance.GetListProductOutOfReceiveVoucher(receiveVoucher.ID);
        }

        
    }
}
