using QuanLyKhoHang.DAO;
using QuanLyKhoHang.DTO;
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
    public partial class FormUpdateReceiveVoucherInfo : Form
    {
        public ReceiveVoucherInfoDTO reVoucherInfoSelected;

        public ReceiveVoucherInfoDTO infoUpdate;

        public List<Product> productHaveNotChosenAndThisSelectedProduct;

        public FormUpdateReceiveVoucherInfo()
        {
            InitializeComponent();
        }
        #region EVENT
        private void FormUpdateReceiveVoucherInfo_Load(object sender, EventArgs e)
        {
            LoadComboboxProduct();

            labelInputQuantity.Text = reVoucherInfoSelected.QuantityInput.ToString();
            labelInputPrice.Text = reVoucherInfoSelected.PriceInput.ToString();
            labelQuantityOutput.Text = reVoucherInfoSelected.QuantityOutput.ToString();
            labelNote.Text = reVoucherInfoSelected.Note;

            numericUpDownInputQuantity.Value = (decimal)reVoucherInfoSelected.QuantityInput;
            numericUpDownInputPrice.Value = (decimal)reVoucherInfoSelected.PriceInput;
            textBoxNote.Text = reVoucherInfoSelected.Note;

            FieldCantChangeIfProductSold();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (CheckQuantityInput())
            {
                string idProduct, note, productName, voucherID;
                int quantityInput, priceInput, outputPrice, quantityOutput;

                voucherID = reVoucherInfoSelected.IDReceiveVoucher;
                idProduct = (comboBoxProductID.SelectedItem as Product).ID;
                productName = (comboBoxProductName.SelectedItem as Product).Name;
                quantityInput = (int)numericUpDownInputQuantity.Value;
                priceInput = (int)numericUpDownInputPrice.Value;
                quantityOutput = int.Parse(labelQuantityOutput.Text);
                note = textBoxNote.Text;

                infoUpdate = new ReceiveVoucherInfoDTO(idProduct, productName, voucherID, quantityInput, priceInput, quantityOutput, note);

                this.Close();
            }
            else
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn hoặc bằng số lượng xuất");
            }
        }
        #endregion

        private bool CheckQuantityInput()
        {
            bool check = true;
            decimal quantityInput, quantityOutput;
            quantityInput = numericUpDownInputQuantity.Value;
            quantityOutput = decimal.Parse(labelQuantityOutput.Text);

            if (quantityInput < quantityOutput)
            {
                check = false;
            }

            return check;
        }

        private void FieldCantChangeIfProductSold()
        {
            //if product had been sold, you can't change productID, name
            int quantityOutput = (int)reVoucherInfoSelected.QuantityOutput;

            if (quantityOutput > 0)
            {
                comboBoxProductID.Enabled = false;
                comboBoxProductName.Enabled = false;
            }
        }

        private void LoadComboboxProduct()
        {
            //get product: include selected product and products that aren't in voucher

            string idProduct = reVoucherInfoSelected.IDProduct;
            productHaveNotChosenAndThisSelectedProduct.Add(ProductDAO.Instance.GetByID(idProduct));

            comboBoxProductID.DataSource = productHaveNotChosenAndThisSelectedProduct;
            comboBoxProductName.DataSource = productHaveNotChosenAndThisSelectedProduct;

            comboBoxProductID.DisplayMember = "ID";
            comboBoxProductName.DisplayMember = "Name";

            //combobox show this product
            comboBoxProductID.SelectedIndex = comboBoxProductID.FindStringExact(idProduct);
        }

        private void numericUpDownInputQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckQuantityInput())
            {
                toolStripStatusLabel1.Text = "Số lượng nhập không được nhỏ hơn số lượng xuất";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
            }
        }

    }
}
