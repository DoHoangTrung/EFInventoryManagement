using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
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
    public partial class FormAddReceiveVoucher : Form
    {
        
        public FormAddReceiveVoucher()
        {
            InitializeComponent();

        }

        private void FormAddReceiveVoucher_Load(object sender, EventArgs e)
        {
            LoadSupplierCombobox();
            LoadProductCombobox();
            LoadComboBoxReceiveVoucherID();

            //create datagridview
            dataGridViewProduct.Columns.Add("productID", "ID");
            dataGridViewProduct.Columns.Add("productName", "Tên sản phẩm");
            dataGridViewProduct.Columns.Add("quantityInput", "Số lượng nhập");
            dataGridViewProduct.Columns.Add("inputPrice", "Giá nhập");
            dataGridViewProduct.Columns.Add("outputPrice", "Giá xuất");
            dataGridViewProduct.Columns.Add("note", "Ghi chú");

        }

        void LoadSupplierCombobox()
        {
            List<Supplier> suppliers = SupplierDAO.Instance.GetListSupplier();
            comboBoxIDSupplier.DataSource = suppliers;
            comboBoxIDSupplier.DisplayMember = "ID";

            comboBoxNameSupplier.DataSource = suppliers;
            comboBoxNameSupplier.DisplayMember = "Name";

        }

        void LoadProductCombobox()
        {
            List<Product> products = ProductDAO.Instance.GetListProduct();
            var sortedProducts = products.OrderBy(p => p.ID).ToList();
            comboBoxProductID.DataSource = sortedProducts;
            comboBoxProductID.DisplayMember = "ID";

            comboBoxProductName.DataSource = sortedProducts;
            comboBoxProductName.DisplayMember = "Name";
        }

        void LoadProductCombobox(List<Product> products)
        {
            var sortedProducts = products.OrderBy(p => p.ID).ToList();
            comboBoxProductID.DataSource = sortedProducts;
            comboBoxProductID.DisplayMember = "ID";
            
            comboBoxProductName.DataSource = sortedProducts;
            comboBoxProductName.DisplayMember = "Name";
        }


        void LoadComboBoxReceiveVoucherID()
        {
            List<string> listID = ReceiveVoucherDAO.Instance.GetListID();
            comboBoxIDInputVoucher.DataSource = listID;
            comboBoxIDInputVoucher.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxIDInputVoucher.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBoxIDInputVoucher_TextChanged(object sender, EventArgs e)
        {
            string id = comboBoxIDInputVoucher.Text;
            if (ReceiveVoucherDAO.Instance.CheckID(id))
            {
                labelInputVoucherIDNotification.Text = "ID không quá 30 kí tự\nKHÔNG trùng với ID trong danh sách";
                labelInputVoucherIDNotification.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                labelInputVoucherIDNotification.Text = "ID không hợp lệ";
                labelInputVoucherIDNotification.ForeColor = System.Drawing.Color.Red;
            }
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
            if (inputQuantity > 0)
            {
                dataGridViewProduct.Rows.Add(id, name, inputQuantity, inputPrice, outputPrice,note);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
            }

            //after add good: remove id of that good from combobox (id good can't dupplication)
            //  and clear textboxNote
            var products =comboBoxProductID.Items.Cast<Product>().ToList();
            products.RemoveAt(comboBoxProductID.SelectedIndex);
            textBoxNote.Clear();

            LoadProductCombobox(products);
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            int indexRow = dataGridViewProduct.SelectedRows[0].Index;
            int lastRowIndex = dataGridViewProduct.Rows.Count - 1;
            if (indexRow < lastRowIndex)
            {
                string idProductRemove = dataGridViewProduct.Rows[indexRow].Cells["productID"].Value.ToString();
                string nameProductRemove = dataGridViewProduct.Rows[indexRow].Cells["productName"].Value.ToString();
                DialogResult result = MessageBox.Show($"Hãy xác nhận bạn muốn xóa sản phẩm:\n{nameProductRemove}\nID:{idProductRemove}", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    //before delete good, add that good's id into combobox id good
                    var products = comboBoxProductID.Items.Cast<Product>().ToList();
                    Product proRemoved = ProductDAO.Instance.GetProductByID(idProductRemove);
                    products.Add(proRemoved);
                    LoadProductCombobox(products);

                    dataGridViewProduct.Rows.RemoveAt(indexRow);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int InsertReceiveVoucherAndInfo()
        {
            string idVoucher, idSupplier, idProduct, note;
            int inputQuantity, inputPrice, outputPrice;
            const int outputQuantity = 0;
            DateTime inputDate;

            idVoucher = comboBoxIDInputVoucher.Text;
            inputDate = dateTimePickerInputDate.Value;
            idSupplier = comboBoxIDSupplier.Text;

            int rowAffected = 0;

            if (ReceiveVoucherDAO.Instance.CheckID(idVoucher))
            {
                //step1:insert receive voucher

                rowAffected = ReceiveVoucherDAO.Instance.InserReceivetVoucher(idVoucher,inputDate,idSupplier);
                if(rowAffected<=0)
                {
                    MessageBox.Show("khong them duoc phieu nhap");
                }
                else
                {
                    //step2: insert receive voucher information
                    int indexLastRow = dataGridViewProduct.Rows.Count - 1;
                    for (int i = 0; i < indexLastRow; i++)
                    {
                        idProduct = dataGridViewProduct.Rows[i].Cells["ProductID"].Value.ToString();
                        inputQuantity = (int)dataGridViewProduct.Rows[i].Cells["quantityInput"].Value;
                        inputPrice = (int)dataGridViewProduct.Rows[i].Cells["inputPrice"].Value;
                        outputPrice = (int)dataGridViewProduct.Rows[i].Cells["outputPrice"].Value;
                        note = dataGridViewProduct.Rows[i].Cells["note"].Value.ToString();

                        rowAffected = ReceiveVoucherInfoDAO.Instance.InsertReceiveVoucherInfo(idProduct, idVoucher, inputQuantity, inputPrice, outputPrice, outputQuantity, note);
                    }
                }
                
            }
            return rowAffected;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            int rowAffected = InsertReceiveVoucherAndInfo();
            if (rowAffected > 0)
            {
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void comboBoxIDInputVoucher_TextChanged_1(object sender, EventArgs e)
        {
            string id = comboBoxIDInputVoucher.Text;
            if (ReceiveVoucherDAO.Instance.CheckID(id))
            {
                labelInputVoucherIDNotification.Text = "ID không quá 30 kí tự\nKhông trùng với ID trong danh sách";
                labelInputVoucherIDNotification.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                labelInputVoucherIDNotification.Text = "ID không hợp lệ";
                labelInputVoucherIDNotification.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void comboBoxIDSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier supplierSelected = comboBoxIDSupplier.SelectedItem as Supplier;
            labelAddressSupplier.Text = "Địa chỉ: "+supplierSelected.Address;
        }

        private void buttonAddSupplierForm_Click(object sender, EventArgs e)
        {
            FormAddSupplier fAddSup = new FormAddSupplier();
            fAddSup.ShowDialog();

            LoadSupplierCombobox();
        }

        private void buttonAddGoodForm_Click(object sender, EventArgs e)
        {
            FormAddProduct fAddGood = new FormAddProduct();
            fAddGood.ShowDialog();

            LoadProductCombobox();
        }
    }
}
