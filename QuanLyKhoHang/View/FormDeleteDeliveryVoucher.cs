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
            var deliVoucher = DeliveryVoucherDAO.Instance.GetByID(DeliveryVoucherID);

            //load voucher
            textBoxDeliveryVoucherID.Text = deliVoucher.ID;
            dateTimePickerDeliveryDate.Value = (DateTime)deliVoucher.Date;
            textBoxNote.Text = deliVoucher.Note;

            //load customer
            Customer customer = deliVoucher.Customer;
            textBoxCustomerID.Text = deliVoucher.Customer.ID;
            textBoxCustomerName.Text = deliVoucher.Customer.Name;
            labelPhone.Text = deliVoucher.Customer.Phone;

            //load list product
            DeliveryVoucherInfoViewDAO voucherDao = new DeliveryVoucherInfoViewDAO();
            var products = voucherDao.GetListByIDVoucher(deliVoucher.ID);

            dtgvDeliveryInfo.DataSource = products;

            //rename column header text
            dtgvDeliveryInfo.Columns["ProductID"].HeaderText = "ID sản phẩm";
            dtgvDeliveryInfo.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            dtgvDeliveryInfo.Columns["SumQuantity"].HeaderText = "Số lượng xuất";
            dtgvDeliveryInfo.Columns["PriceOutput"].HeaderText = "Giá xuất";
            dtgvDeliveryInfo.Columns["DeliveryVoucherID"].HeaderText = "ID phiếu xuất";

            //hide column of dtgv:
            dtgvDeliveryInfo.Columns["ProductID"].Visible = false;
            dtgvDeliveryInfo.Columns["DeliveryVoucherID"].Visible = false;

            dtgvDeliveryInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                int rowAffected = DeliveryVoucherDAO.Instance.DeleteByID(DeliveryVoucherID);
                if(rowAffected > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
        }
    }
}
