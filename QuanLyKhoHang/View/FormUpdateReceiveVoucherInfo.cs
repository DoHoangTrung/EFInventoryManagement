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
    public partial class FormUpdateReceiveVoucherInfo : Form
    {
        public ReceiveVoucherInfo receiveVoucherInfoTransfer;

        public List<Product> productsOutOfVoucherAndThisSelected;

        public FormUpdateReceiveVoucherInfo()
        {
            InitializeComponent();
        }
        #region EVENT
        private void FormUpdateReceiveVoucherInfo_Load(object sender, EventArgs e)
        {
            LoadComboboxProduct();

            labelInputQuantity.Text = receiveVoucherInfoTransfer.QuantityInput.ToString();
            labelInputPrice.Text = receiveVoucherInfoTransfer.PriceInput.ToString();
            labelQuantityOutput.Text = receiveVoucherInfoTransfer.QuantityOutput.ToString();
            labelNote.Text = receiveVoucherInfoTransfer.Note;

            numericUpDownInputQuantity.Value = (decimal)receiveVoucherInfoTransfer.QuantityInput;
            numericUpDownInputPrice.Value = (decimal)receiveVoucherInfoTransfer.PriceInput;
            textBoxNote.Text = receiveVoucherInfoTransfer.Note;

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
                string idProduct, note;
                int quantityInput, inputPrice, outputPrice, quantityOutput;

                idProduct = (comboBoxProductID.SelectedItem as Product).ID;
                quantityInput = (int)numericUpDownInputQuantity.Value;
                inputPrice = (int)numericUpDownInputPrice.Value;
                quantityOutput = int.Parse(labelQuantityOutput.Text);
                outputPrice = (int)numericUpDownOutputPrice.Value;
                note = textBoxNote.Text;

                receiveVoucherInfoTransfer = ReceiveVoucherInfoDAO.Instance.InitReceiveVoucherInfo(idProduct, "", quantityInput, inputPrice, quantityOutput, note);

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
            int quantityOutput = (int)receiveVoucherInfoTransfer.QuantityOutput;

            if (quantityOutput > 0)
            {
                comboBoxProductID.Enabled = false;
                comboBoxProductName.Enabled = false;
            }
        }

        private void LoadComboboxProduct()
        {
            //get product: include selected product and products that aren't in voucher

            string idProduct = receiveVoucherInfoTransfer.IDProduct;
            productsOutOfVoucherAndThisSelected.Add(ProductDAO.Instance.GetProductByID(idProduct));

            comboBoxProductID.DataSource = productsOutOfVoucherAndThisSelected;
            comboBoxProductName.DataSource = productsOutOfVoucherAndThisSelected;

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
