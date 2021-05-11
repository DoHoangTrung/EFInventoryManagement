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
    public partial class FormDeleteDeliveryVoucher : Form
    {
        public string DeliveryVoucherID { get; set; }
        public FormDeleteDeliveryVoucher()
        {
            InitializeComponent();
        }

        private void FormDeleteDeliveryVoucher_Load(object sender, EventArgs e)
        {
            var DeliVoucher = DeliveryVoucherDAO.Instance.GetByID(DeliveryVoucherID);

            //load voucher
            textBoxDeliveryVoucherID.Text = DeliVoucher.ID;
            dateTimePickerDeliveryDate.Value = (DateTime)DeliVoucher.Date;
            textBoxNote.Text = DeliVoucher.Note;

            //load customer
            textBoxCustomerID.Text = DeliVoucher.Customer.ID;
            textBoxCustomerName.Text = DeliVoucher.Customer.Name;
            labelPhone.Text = DeliVoucher.Customer.Phone;

            //load list product
            DeliveryVoucherInfoViewDAO voucherDao = new DeliveryVoucherInfoViewDAO();
            var products = voucherDao.GetListByIDVoucher(DeliVoucher.ID);

            dataGridViewDeliveryInfo.DataSource = products;

            //rename column header text
            dataGridViewDeliveryInfo.Columns["ProductID"].HeaderText = "ID sản phẩm";
            dataGridViewDeliveryInfo.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            dataGridViewDeliveryInfo.Columns["SumQuantity"].HeaderText = "Số lượng xuất";
            dataGridViewDeliveryInfo.Columns["PriceOutput"].HeaderText = "Giá xuất";
            dataGridViewDeliveryInfo.Columns["DeliveryVoucherID"].HeaderText = "ID phiếu xuất";

            //hide column of dtgv:
            dataGridViewDeliveryInfo.Columns["ProductID"].Visible = false;
            dataGridViewDeliveryInfo.Columns["DeliveryVoucherID"].Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var action = MessageBox.Show("Bạn chắc chắn muốn xóa", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (action == DialogResult.OK)
            {
                DeliveryVoucherDAO.Instance.DeleteByID(DeliveryVoucherID);
            }
        }
    }
}
