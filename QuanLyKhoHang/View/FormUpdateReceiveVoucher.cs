using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
using QuanLyKhoHang.Entity;
using QuanLyKhoHang.View;
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

        public ReceiveVoucher receiveVoucherTagged;

        private List<ReceiveVoucherInfo> receicveVoucherInfos;

        private Supplier supplierInVoucher;

        private List<Product> listProductOutOfReceiveVoucher;
        public FormUpdateReceiveVoucher()
        {
            InitializeComponent();
        }

        private ReceiveVoucherInfo voucherInfoUpdate;
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
            inputQuantity = (int)numericUpDownInputQuantity.Value;
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
                //you can't delete product  if it's quantityOutput > 0 (has been sold)
                if ((int)dataGridViewProduct.Rows[rowIndex].Cells["quantityOutput"].Value == 0)
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
                else
                {
                    MessageBox.Show("Bạn không thể xóa sản phẩm đã được bán");
                }
            }
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>= 0 && e.RowIndex < dataGridViewProduct.RowCount - 1)
            {
                dataGridViewProduct.Tag = e.RowIndex;
            }
        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {

            ReceiveVoucherInfo voucherInfo = new ReceiveVoucherInfo();
            string idVoucher = receiveVoucherTagged.ID;
            string idProduct, nameProduct, note;
            int quantityInput, inputPrice, outputPrice, quantityOutput;


            if (dataGridViewProduct.Tag != null)
            {
                int idxRow = (int)dataGridViewProduct.Tag;

                voucherInfo = GetValueFromDTGViewReceiveVoucherInfo(idxRow);
                dataGridViewProduct.Tag = null;

                FormUpdateReceiveVoucherInfo f = new FormUpdateReceiveVoucherInfo();
                //send data to form f
                f.receiveVoucherInfoTransfer = voucherInfo;
                f.productsOutOfVoucherAndThisSelected = listProductOutOfReceiveVoucher;
                f.ShowDialog();

                //get data update from form f
                voucherInfoUpdate = f.receiveVoucherInfoTransfer;
                UpdateDTGViewReceiveVoucherInfo(idxRow,voucherInfoUpdate);
            }
            else
            {
                MessageBox.Show("Hãy chọn thông tin bạn muốn sửa trong bảng");
            }
        }
        #endregion

        private ReceiveVoucherInfo GetValueFromDTGViewReceiveVoucherInfo(int rowIndex)
        {
            ReceiveVoucherInfo voucherInfo = new ReceiveVoucherInfo();

            voucherInfo.IDReceiveVoucher = receiveVoucherTagged.ID;
            voucherInfo.IDProduct = dataGridViewProduct.Rows[rowIndex].Cells["productID"].Value.ToString();
            voucherInfo.QuantityInput = (int)dataGridViewProduct.Rows[rowIndex].Cells["quantityInput"].Value;
            voucherInfo.PriceInput = (int)dataGridViewProduct.Rows[rowIndex].Cells["inputPrice"].Value;
            voucherInfo.PriceOutput = (int)dataGridViewProduct.Rows[rowIndex].Cells["outputPrice"].Value;
            voucherInfo.QuantityOutput = (int)dataGridViewProduct.Rows[rowIndex].Cells["quantityOutput"].Value;
            if (dataGridViewProduct.Rows[rowIndex].Cells["note"].Value == null)
            {
                voucherInfo.Note = string.Empty;
            }
            else
            {
                voucherInfo.Note = dataGridViewProduct.Rows[rowIndex].Cells["note"].Value.ToString();
            }

            return voucherInfo;
        }

        private void UpdateDTGViewReceiveVoucherInfo(int rowIndex, ReceiveVoucherInfo voucherInfo)
        {
            //update row
            dataGridViewProduct.Rows[rowIndex].Cells["productID"].Value = voucherInfo.IDProduct;
            dataGridViewProduct.Rows[rowIndex].Cells["productName"].Value = ProductDAO.Instance.GetNameByID(voucherInfo.IDProduct);
            dataGridViewProduct.Rows[rowIndex].Cells["quantityInput"].Value = voucherInfo.QuantityInput;
            dataGridViewProduct.Rows[rowIndex].Cells["inputPrice"].Value = voucherInfo.PriceInput;
            dataGridViewProduct.Rows[rowIndex].Cells["outputPrice"].Value = voucherInfo.PriceOutput;
            dataGridViewProduct.Rows[rowIndex].Cells["quantityOutput"].Value = voucherInfo.QuantityOutput;
            dataGridViewProduct.Rows[rowIndex].Cells["note"].Value = voucherInfo.Note;
        }

        private void LoadVoucherInfoDatagridview()
        {
            //Create dataGridView product
            dataGridViewProduct.Columns.Add("productID", "ID");
            dataGridViewProduct.Columns.Add("productName", "Tên sản phẩm");
            dataGridViewProduct.Columns.Add("quantityInput", "Số lượng nhập");
            dataGridViewProduct.Columns.Add("inputPrice", "Giá nhập");
            dataGridViewProduct.Columns.Add("outputPrice", "Giá xuất");
            dataGridViewProduct.Columns.Add("quantityOutput", "Số lượng xuất");
            dataGridViewProduct.Columns.Add("note", "Ghi chú");

            dataGridViewProduct.Columns["quantityOutput"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 51, 51);

            //add data
            foreach (var voucherInfo in receicveVoucherInfos)
            {
                Product productInVoucherInfo = voucherInfo.Product;

                string id, name, note;
                int? quantityInput, inputPrice, outputPrice, quantityOutput;

                id = productInVoucherInfo.ID;
                name = productInVoucherInfo.Name;
                quantityInput = voucherInfo.QuantityInput;
                inputPrice = voucherInfo.PriceInput;
                outputPrice = voucherInfo.PriceOutput;
                quantityOutput = voucherInfo.QuantityOutput;
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

            comboBoxIDSupplier.SelectedIndex = comboBoxIDSupplier.FindStringExact(receiveVoucherTagged.IDSupplier);
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
            textBoxIDInputVoucher.Text = receiveVoucherTagged.ID;

            if(receiveVoucherTagged != null)
            {
                dateTimePickerInputDate.Value = (DateTime)receiveVoucherTagged.Date;
            }
        }

        private void InitField()
        {
            receicveVoucherInfos = receiveVoucherTagged.ReceiveVoucherInfoes.ToList();

            supplierInVoucher = receiveVoucherTagged.Supplier;

            listProductOutOfReceiveVoucher = ProductDAO.Instance.GetListProductOutOfReceiveVoucher(receiveVoucherTagged.ID);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int rowAffected = 0;
            //step1: update receive voucher
            ReceiveVoucher voucherUpdate = new ReceiveVoucher();
            voucherUpdate.ID = receiveVoucherTagged.ID;
            voucherUpdate.IDSupplier = (comboBoxIDSupplier.SelectedItem as Supplier).ID;
            voucherUpdate.Date = dateTimePickerInputDate.Value;

            ReceiveVoucherDAO.Instance.UpdateReceiveVoucher(voucherUpdate);

            //step2: update receive voucher infomation
            //step2.1: remove all product have quantityOutput = 0( not been sold)
            //step2.2: if product in dtgview has been sold, the only thing we can do is update it
            //step2.3: add product in dtgrview never be sold, add it to receive voucher

            //remove product info have quantity output = 0
            ReceiveVoucherInfoDAO.Instance.RemoveReceiveVoucherInfoNeverSell(receiveVoucherTagged.ID);

            for (int i = 0; i < dataGridViewProduct.RowCount-1; i++)
            {
                ReceiveVoucherInfo voucherInfo = GetValueFromDTGViewReceiveVoucherInfo(i);

                int quantityOutput = (int)voucherInfo.QuantityOutput;
                if(quantityOutput > 0) // the product has been sold can only be updated
                {
                    rowAffected = ReceiveVoucherInfoDAO.Instance.UpdateReceiveVoucherInfo(voucherInfo);
                }
                else if(quantityOutput == 0)
                {
                    // add new product info into receive voucher info
                    ReceiveVoucherInfoDAO.Instance.InsertReceiveVoucherInfo(voucherInfo);
                }
            }

        }

        void ShowMessage(int rowAffected)
        {
            MessageBox.Show(rowAffected.ToString());
        }
    }
}
