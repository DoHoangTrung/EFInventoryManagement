using QuanLyKhoHang.DAL;
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
    public partial class FormDeleteReceiveVoucher : Form
    {
        public ReceiveVoucher voucherSelected;
        public FormDeleteReceiveVoucher()
        {
            InitializeComponent();
        }

        private void FormDeleteReceiveVoucher_Load(object sender, EventArgs e)
        {
            labelReceiveVoucherID.Text = voucherSelected.ID;
            labelDateReceive.Text = voucherSelected.Date.ToString();
            labelSupplierID.Text = voucherSelected.IDSupplier;
            labelSupplierName.Text = voucherSelected.Supplier.Name;

            LoadDTGViewVoucherInfo();
        }

        private void LoadDTGViewVoucherInfo()
        {
            var reVoucherInfos = ReceiveVoucherInfoDAO.Instance.GetListDTO(voucherSelected.ID);

            dtgvVoucherInfo.DataSource = new SortableBindingList<ReceiveVoucherInfoDTO>(reVoucherInfos);
            dtgvVoucherInfo.Columns["IDProduct"].Visible = false;
            dtgvVoucherInfo.Columns["IDReceiveVoucher"].Visible = false;
            dtgvVoucherInfo.Columns["QuantityOutput"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 51, 51);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //if this receive voucher doesn't have products that been sold
            if (!ReceiveVoucherDAO.Instance.HaveTheProductBeenSold(voucherSelected.ID)){
                int rowAffected = ReceiveVoucherDAO.Instance.RemoveReceiveVoucher(voucherSelected.ID);
                if (rowAffected > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
            else
            {
                MessageBox.Show("Không thể xóa phiếu nhập tồn tại sản phẩm đã xuất kho");
            }
        }
    }
}