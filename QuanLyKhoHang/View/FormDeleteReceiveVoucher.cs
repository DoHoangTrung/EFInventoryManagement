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

namespace QuanLyKhoHang.View
{
    public partial class FormDeleteReceiveVoucher : Form
    {
        public ReceiveVoucher voucherTagged;
        public FormDeleteReceiveVoucher()
        {
            InitializeComponent();
        }

        private void FormDeleteReceiveVoucher_Load(object sender, EventArgs e)
        {
            labelReceiveVoucherID.Text = voucherTagged.ID;
            labelDateReceive.Text = voucherTagged.Date.ToString();
            labelSupplierID.Text= voucherTagged.IDSupplier;
            labelSupplierName.Text = SupplierDAO.Instance.GetNameByID(voucherTagged.IDSupplier);

            LoadDTGViewVoucherInfo();
        }

        private void LoadDTGViewVoucherInfo()
        {
                //Create dataGridView product
                dataGridViewVoucherInfo.Columns.Add("productID", "ID");
                dataGridViewVoucherInfo.Columns.Add("productName", "Tên sản phẩm");
                dataGridViewVoucherInfo.Columns.Add("quantityInput", "Số lượng nhập");
                dataGridViewVoucherInfo.Columns.Add("inputPrice", "Giá nhập");
                dataGridViewVoucherInfo.Columns.Add("quantityOutput", "Số lượng xuất");
                dataGridViewVoucherInfo.Columns.Add("note", "Ghi chú");

                dataGridViewVoucherInfo.Columns["quantityOutput"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 51, 51);

                //add data
                foreach (var voucherInfo in voucherTagged.ReceiveVoucherInfoes)
                {
                    Product productInVoucherInfo = voucherInfo.Product;

                    string id, name, note;
                    int? quantityInput, inputPrice, outputPrice, quantityOutput;

                    id = productInVoucherInfo.ID;
                    name = productInVoucherInfo.Name;
                    quantityInput = voucherInfo.QuantityInput;
                    inputPrice = voucherInfo.PriceInput;
                    quantityOutput = voucherInfo.QuantityOutput;
                    note = voucherInfo.Note;

                    dataGridViewVoucherInfo.Rows.Add(id, name, quantityInput, inputPrice, quantityOutput, note);
                }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int rowAffected = ReceiveVoucherDAO.Instance.RemoveReceiveVoucher(voucherTagged.ID);
            if(rowAffected > 0)
            {
                MessageBox.Show("Xóa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }
    }
}
