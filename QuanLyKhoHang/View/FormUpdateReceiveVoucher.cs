using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
using QuanLyKhoHang.DTO;
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

        private ReceiveVoucher reVoucherSelected;

        private List<ReceiveVoucherInfoDTO> reVoucherInfos;

        private Supplier supplierInVoucher;

        private List<Product> listProductOutOfReceiveVoucher;


        ReceiveVoucherInfoDTO rowSeletedObj;

        #region EVENT   

        public FormUpdateReceiveVoucher(ReceiveVoucher voucher)
        {
            InitializeComponent();

            reVoucherSelected = voucher;

            reVoucherInfos = ReceiveVoucherInfoDAO.Instance.GetListDTO(reVoucherSelected.ID);

            supplierInVoucher = reVoucherSelected.Supplier;

            listProductOutOfReceiveVoucher = ProductDAO.Instance.GetListProductOutOfReceiveVoucher(reVoucherSelected.ID);
        }

        private void FormUpdateInputVoucher_Load(object sender, EventArgs e)
        {
            LoadVoucherCombobox();
            LoadProductCombobox();
            LoadSupplierCombobox();
            LoadDtgvVoucherInfo();
        }
        private void LoadDtgvVoucherInfo()
        {
            //Create dataGridView product
            /*dtgvProduct.Columns.Add("productID", "ID");
            dtgvProduct.Columns.Add("productName", "Tên sản phẩm");
            dtgvProduct.Columns.Add("quantityInput", "Số lượng nhập");
            dtgvProduct.Columns.Add("inputPrice", "Giá nhập");
            dtgvProduct.Columns.Add("outputPrice", "Giá xuất");
            dtgvProduct.Columns.Add("quantityOutput", "Số lượng xuất");
            dtgvProduct.Columns.Add("note", "Ghi chú");

            dtgvProduct.Columns["quantityOutput"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 51, 51);
            */

            dtgvProduct.DataSource = new SortableBindingList<ReceiveVoucherInfoDTO>(reVoucherInfos);
            dtgvProduct.Columns["IDProduct"].Visible = false;
            dtgvProduct.Columns["IDReceiveVoucher"].Visible = false;
            dtgvProduct.Columns["QuantityOutput"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 51, 51);
        }

        private void LoadSupplierCombobox()
        {
            List<Supplier> suppliers = SupplierDAO.Instance.GetList();

            comboBoxIDSupplier.DataSource = suppliers;
            comboBoxIDSupplier.DisplayMember = "ID";

            comboBoxNameSupplier.DataSource = suppliers;
            comboBoxNameSupplier.DisplayMember = "Name";

            comboBoxIDSupplier.SelectedIndex = comboBoxIDSupplier.FindStringExact(reVoucherSelected.IDSupplier);
        }

        private void LoadProductCombobox()
        {
            listProductOutOfReceiveVoucher = listProductOutOfReceiveVoucher.OrderBy(p => p.ID).ToList();

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
            textBoxIDInputVoucher.Text = reVoucherSelected.ID;

            if (reVoucherSelected != null)
            {
                dateTimePickerInputDate.Value = (DateTime)reVoucherSelected.Date;
            }
        }

        private void comboBoxIDSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelAddressSupplier.Text = (comboBoxIDSupplier.SelectedItem as Supplier).Address;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            //if there are at least one product on combobox
            if ((comboBoxProductID.SelectedItem as Product) != null)
            {
                string pID, pName, note, voucherID;
                int inputQuantity, inputPrice;

                voucherID = reVoucherSelected.ID;
                pID = comboBoxProductID.Text;
                pName = comboBoxProductName.Text;
                inputQuantity = (int)numericUpDownInputQuantity.Value;
                inputPrice = (int)numericUpDownInputPrice.Value;
                note = textBoxNote.Text;
                const int outputQuantity = 0;

                if (inputQuantity > 0)
                {
                    ReceiveVoucherInfoDTO info = new ReceiveVoucherInfoDTO();
                    info.IDProduct = pID;
                    info.ProductName = pName;
                    info.QuantityInput = inputQuantity;
                    info.PriceInput = inputPrice;
                    info.QuantityOutput = outputQuantity;
                    info.Note = note;
                    info.IDReceiveVoucher = voucherID;

                    reVoucherInfos.Add(info);

                    LoadDtgvVoucherInfo();
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

        }


        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            //if still have data row on dtgv
            if (rowSeletedObj != null)
            {
                //you can't delete product  if it's quantityOutput > 0 (has been sold)
                if (rowSeletedObj.QuantityOutput == 0)
                {
                    string idProduct = rowSeletedObj.IDProduct;
                    Product productRemoved = ProductDAO.Instance.GetByID(idProduct);

                    //before delete product in datagridview, we must add that product to comboboxProduct
                    List<Product> productsCombobox = comboBoxProductID.Items.Cast<Product>().ToList();
                    productsCombobox.Add(productRemoved);

                    LoadProductCombobox(productsCombobox);

                    reVoucherInfos.Remove(rowSeletedObj);
                    LoadDtgvVoucherInfo();

                    rowSeletedObj = null;
                }
                else
                {
                    MessageBox.Show("Bạn không thể xóa sản phẩm đã được bán");
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvProduct.RowCount)
            {
                rowSeletedObj = dtgvProduct.Rows[e.RowIndex].DataBoundItem as ReceiveVoucherInfoDTO;
            }
            else
            {
                rowSeletedObj = null;
            }
        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            ReceiveVoucherInfo voucherInfo = new ReceiveVoucherInfo();
            string idVoucher = reVoucherSelected.ID;
            string idProduct, nameProduct, note;
            int quantityInput, inputPrice, outputPrice, quantityOutput;


            if (rowSeletedObj != null)
            {

                FormUpdateReceiveVoucherInfo f = new FormUpdateReceiveVoucherInfo();
                //send data to form f
                f.reVoucherInfoSelected = rowSeletedObj;
                f.productHaveNotChosenAndThisSelectedProduct = listProductOutOfReceiveVoucher;
                f.ShowDialog();

                //get data update from form f
                var infoAfterUpdate = f.infoUpdate;
                if(infoAfterUpdate != null)
                {
                    reVoucherInfos.Remove(rowSeletedObj);
                    reVoucherInfos.Add(infoAfterUpdate);
                    rowSeletedObj = null;

                    LoadDtgvVoucherInfo();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn thông tin bạn muốn sửa trong bảng");
            }
        }
        #endregion

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Xác nhận thay đổi?", "Xác nhận", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                int rowAffected = 0;
                //step1: update receive voucher
                ReceiveVoucher voucherUpdate = new ReceiveVoucher();
                voucherUpdate.ID = reVoucherSelected.ID;
                voucherUpdate.IDSupplier = (comboBoxIDSupplier.SelectedItem as Supplier).ID;
                voucherUpdate.Date = dateTimePickerInputDate.Value;

                //ReceiveVoucherDAO.Instance.UpdateReceiveVoucher(voucherUpdate);

                //step2: update receive voucher infomation
                //step2.1: remove all product have quantityOutput = 0( not been sold)
                //step2.2: if product in dtgview has been sold, the only thing we can do is update it
                //step2.3: add product in dtgrview never be sold, add it to receive voucher

                //add new product info have quantity output = 0 
                //or update if it's quantity output > 0

                for (int i = 0; i < dtgvProduct.RowCount; i++)
                {
                    ReceiveVoucherInfoDTO infoDTO = dtgvProduct.Rows[i].DataBoundItem as ReceiveVoucherInfoDTO;

                    ReceiveVoucherInfo voucherInfo = new ReceiveVoucherInfo();
                    voucherInfo.IDProduct = infoDTO.IDProduct;
                    voucherInfo.IDReceiveVoucher = infoDTO.IDReceiveVoucher;
                    voucherInfo.QuantityInput = infoDTO.QuantityInput;
                    voucherInfo.PriceInput = infoDTO.PriceInput;
                    voucherInfo.QuantityOutput = infoDTO.QuantityOutput;
                    voucherInfo.Note = infoDTO.Note;

                    voucherUpdate.ReceiveVoucherInfoes.Add(voucherInfo);
                }

                rowAffected = ReceiveVoucherDAO.Instance.UpdateReceiveVoucher(voucherUpdate);
                if (rowAffected > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
                this.Close();
            }
            
        }
    }
}