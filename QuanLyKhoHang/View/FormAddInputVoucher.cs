using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAT;
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
    public partial class FormAddInputVoucher : Form
    {
        public FormAddInputVoucher()
        {
            InitializeComponent();

        }

        private void FormAddInputVoucher_Load(object sender, EventArgs e)
        {
            LoadSupplierCombobox();
            LoadGoodCombobox();
            LoadIDInputVoucherComboBox();

            //create datagridview
            dataGridViewGood.Columns.Add("idGood", "ID");
            dataGridViewGood.Columns.Add("nameGood", "Tên sản phẩm");
            dataGridViewGood.Columns.Add("count", "Số lượng nhập");
            dataGridViewGood.Columns.Add("inputPrice", "Giá nhập");
            dataGridViewGood.Columns.Add("outputPrice", "Giá xuất");

        }

        void LoadSupplierCombobox()
        {
            List<Supplier1> suppliers = SupplierDAO.Instance.GetListSupplier1();
            comboBoxIDSupplier.DataSource = suppliers;
            comboBoxIDSupplier.DisplayMember = "ID";

            comboBoxNameSupplier.DataSource = suppliers;
            comboBoxNameSupplier.DisplayMember = "Name";

        }

        void LoadGoodCombobox()
        {
            List<Good1> goods = GoodDAO.Instance.GetListGoods();
            comboBoxIDGood.DataSource = goods;
            comboBoxIDGood.DisplayMember = "ID";

            comboBoxNameGood.DataSource = goods;
            comboBoxNameGood.DisplayMember = "Name";
        }

        void LoadGoodCombobox(List<Good1> goods)
        {
            var sortedGoods = goods.OrderBy(g => g.ID).ToList();
            comboBoxIDGood.DataSource = sortedGoods;
            comboBoxIDGood.DisplayMember = "ID";
            
            comboBoxNameGood.DataSource = sortedGoods;
            comboBoxNameGood.DisplayMember = "Name";
        }


        void LoadIDInputVoucherComboBox()
        {
            List<string> listID = InputVoucherDAO.Instance.GetListID();
            comboBoxIDInputVoucher.DataSource = listID;
            comboBoxIDInputVoucher.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxIDInputVoucher.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void AddInputVoucher()
        {

        }

        private void comboBoxIDInputVoucher_TextChanged(object sender, EventArgs e)
        {
            string id = comboBoxIDInputVoucher.Text;
            if (InputVoucherDAO.Instance.CheckID(id))
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

        private void buttonAddGood_Click(object sender, EventArgs e)
        {
            string id, name;
            int count, inputPrice, outputPrice;
            id = comboBoxIDGood.Text;
            name = comboBoxNameGood.Text;
            count = (int)numericUpDownInputCount.Value;
            inputPrice = (int)numericUpDownInputPrice.Value;
            outputPrice = (int)numericUpDownOutputPrice.Value;

            if (count > 0)
            {
                dataGridViewGood.Rows.Add(id, name, count, inputPrice, outputPrice);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập số lượng");
            }

            //after add good, remove id of that good from combobox (id good can't dupplication)
            var goods =comboBoxIDGood.Items.Cast<Good1>().ToList();
            goods.RemoveAt(comboBoxIDGood.SelectedIndex);
            LoadGoodCombobox(goods);
        }

        private void buttonDeleteGood_Click(object sender, EventArgs e)
        {
            int indexRow = dataGridViewGood.SelectedRows[0].Index;
            int lastRowIndex = dataGridViewGood.Rows.Count - 1;
            if (indexRow < lastRowIndex)
            {
                string idGoodRemove = dataGridViewGood.Rows[indexRow].Cells["idGood"].Value.ToString();
                DialogResult result = MessageBox.Show($"Hãy xác nhận bạn muốn xóa id: {idGoodRemove}", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    //before delete good, add that good's id into combobox id good
                    var goods = comboBoxIDGood.Items.Cast<Good1>().ToList();
                    Good1 goodRemoved = GoodDAO.Instance.GetGoodByID(idGoodRemove);
                    goods.Add(goodRemoved);
                    LoadGoodCombobox(goods);

                    dataGridViewGood.Rows.RemoveAt(indexRow);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string idVoucher, idSupplier, idGood;
            int inputCount, inputPrice, outputPrice;
            DateTime inputDate;
            idVoucher = comboBoxIDInputVoucher.Text;
            inputDate = dateTimePickerInputDate.Value;
            idSupplier = comboBoxIDSupplier.Text;
            if (InputVoucherDAO.Instance.CheckID(idVoucher))
            {
                //an input report include: inputvoucher and inputvoucher informations about good
                InputVoucherDAO.Instance.InsertInputVoucher(idVoucher, idSupplier, inputDate);

                int indexLastRow = dataGridViewGood.Rows.Count - 1;
                for (int i = 0; i < indexLastRow; i++)
                {
                    idGood = dataGridViewGood.Rows[i].Cells["idGood"].Value.ToString();
                    inputCount = (int)dataGridViewGood.Rows[i].Cells["count"].Value;
                    inputPrice = (int)dataGridViewGood.Rows[i].Cells["inputPrice"].Value;
                    outputPrice = (int)dataGridViewGood.Rows[i].Cells["outputPrice"].Value;

                    int rowAffected = InputVoucherDAO.Instance.InsertInputVoucherInfor(idVoucher, idGood, inputCount, inputPrice, outputPrice);
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                }
            }
        }

        private void comboBoxIDInputVoucher_TextChanged_1(object sender, EventArgs e)
        {
            string id = comboBoxIDInputVoucher.Text;
            if (InputVoucherDAO.Instance.CheckID(id))
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
            Supplier1 supplierSelected = comboBoxIDSupplier.SelectedItem as Supplier1;
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

            LoadGoodCombobox();
        }
    }
}
