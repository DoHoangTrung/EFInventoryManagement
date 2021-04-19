using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAT;

namespace QuanLyKhoHang
{
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();

            //BindingReceiveVoucherTextBox();

            LoadDataGridviewOfGood();
            //BindingGoodWithTextBox();
            //SortDataGridviewGood();

            LoadDataGridviewSupplier();
        }

        #region ReceiveVoucher
       

        void BindingReceiveVoucherTextBox()
        {
            textBoxIDReceiveVoucher.DataBindings.Add(new Binding("text", dataGridViewReceiveVoucher.DataSource, "ID"));

            Binding b = new Binding("text", dataGridViewReceiveVoucher.DataSource, "Ngaynhap");
            b.Format += new ConvertEventHandler(DateTimeToStringOfDate);
            textBoxDateReceived.DataBindings.Add(b);

            textBoxIDSupplierInReceiveVoucher.DataBindings.Add(new Binding("text", dataGridViewReceiveVoucher.DataSource, "IDNCC"));
        }

        private void DateTimeToStringOfDate(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(string)) return;
            e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
        }
        #endregion

        #region Goods
        void LoadDataGridviewOfGood()
        {
            //create event sort data in column
            dataGridViewGoods.SortCompare += DataGridViewGoods_SortCompare;

            //
            dataGridViewGoods.ColumnCount = 3;
            dataGridViewGoods.Columns[0].Name = "ID";
            dataGridViewGoods.Columns[1].Name = "Name";
            dataGridViewGoods.Columns[2].Name = "Unit";
            dataGridViewGoods.Columns["ID"].HeaderText = "ID";
            dataGridViewGoods.Columns["Name"].HeaderText = "Ten san pham";
            dataGridViewGoods.Columns["Unit"].HeaderText = "Don vi";

            List<Good1> listGoods = GoodDAO.Instance.GetListGoods();
            foreach (Good1 g in listGoods)
            {
                dataGridViewGoods.Rows.Add(g.ID, g.Name, g.Unit);
            }

            dataGridViewGoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void LoadDataGridviewOfGood(List<Good1> listGoods)
        {
            //create event sort data in column
            dataGridViewGoods.SortCompare += DataGridViewGoods_SortCompare;

            //
            dataGridViewGoods.ColumnCount = 3;
            dataGridViewGoods.Columns[0].Name = "ID";
            dataGridViewGoods.Columns[1].Name = "Name";
            dataGridViewGoods.Columns[2].Name = "Unit";
            dataGridViewGoods.Columns["ID"].HeaderText = "ID";
            dataGridViewGoods.Columns["Name"].HeaderText = "Ten san pham";
            dataGridViewGoods.Columns["Unit"].HeaderText = "Don vi";

            foreach (Good1 g in listGoods)
            {
                dataGridViewGoods.Rows.Add(g.ID, g.Name, g.Unit);
            }

            dataGridViewGoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DataGridViewGoods_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.SortResult == 0 && e.Column.Name != "ID")
            {
                e.SortResult = System.String.Compare(
                    dataGridViewGoods.Rows[e.RowIndex1].Cells["ID"].Value.ToString(),
                    dataGridViewGoods.Rows[e.RowIndex2].Cells["ID"].Value.ToString()
                );
            }
            e.Handled = true;
        }

        void BindingGoodWithTextBox()
        {
            textBoxIDGoods.DataBindings.Add(new Binding("text", dataGridViewGoods.DataSource, "ID"));
            textBoxNameOfGoods.DataBindings.Add(new Binding("text", dataGridViewGoods.DataSource, "Name"));
            textBoxUnitOfGoods.DataBindings.Add(new Binding("text", dataGridViewGoods.DataSource, "Unit"));
        }

        private void buttonAddGood_Click(object sender, EventArgs e)
        {
            string id, name, unit;
            id = textBoxIDGoods.Text;
            name = textBoxNameOfGoods.Text;
            unit = textBoxUnitOfGoods.Text;
            int numberRows = 0;
            numberRows = GoodDAO.Instance.InsertGood(id, name, unit);
            if (numberRows == 0)
            {

                MessageBox.Show("ID da ton tai", "Error");
            }
            else
            {
                RefreshDtgvGood();
                MessageBox.Show($"Đã thêm {numberRows} sản phẩm", "Successed");
            }
        }

        void RefreshDtgvGood()
        {
            dataGridViewGoods.Rows.Clear();
            LoadDataGridviewOfGood();
        }

        void RefreshDtgvGood(List<Good1> listGoods)
        {
            dataGridViewGoods.Rows.Clear();
            LoadDataGridviewOfGood(listGoods);
        }

        private void buttonDeleteGood_Click(object sender, EventArgs e)
        {

            if (buttonDeleteGood.Tag != null)
            {
                int rowIdx = (int)buttonDeleteGood.Tag;
                string id = dataGridViewGoods.Rows[rowIdx].Cells["id"].Value.ToString();
                string name = dataGridViewGoods.Rows[rowIdx].Cells["name"].Value.ToString();
                string unit = dataGridViewGoods.Rows[rowIdx].Cells["unit"].Value.ToString();

                string s = string.Format("Ban có chắc muốn xóa sản phẩm:\n\n{0}: {1}\n{2}: {3}\n{4}: {5}", "ID", id, "Ten", name, "Don vi", unit);
                DialogResult result = MessageBox.Show(s, "Thông báo", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int rowAffected = GoodDAO.Instance.DeleteGood(id);
                    RefreshDtgvGood();
                    buttonDeleteGood.Tag = null;
                }
            }
            else
            {
                MessageBox.Show("Hay click vao dong ban muon xoa");
            }
        }

        private void dataGridViewGoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                buttonDeleteGood.Tag = (object)e.RowIndex;
                buttonUpdateGood.Tag = (object)e.RowIndex;
            }
            else if (e.RowIndex == -1)
            {
                buttonDeleteGood.Tag = null;
                buttonUpdateGood.Tag = null;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string _id, _name, _unit;
            _id = textBoxIDGoods.Text;
            _name = textBoxNameOfGoods.Text;
            _unit = textBoxUnitOfGoods.Text;

            if (_id != "")
            {
                if (_name != "") GoodDAO.Instance.UpdateGoodName(_id, _name);
                if (_unit != "") GoodDAO.Instance.UpdateGoodUnit(_id, _unit);
                RefreshDtgvGood();
            }
            else
                MessageBox.Show("Ban chua nhap ID");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string idSearch, nameSearch, unitSearch;
            idSearch = textBoxIDGoods.Text;
            nameSearch = textBoxNameOfGoods.Text;
            unitSearch = textBoxUnitOfGoods.Text;

            List<Good1> searchList = GoodDAO.Instance.SearchGood(idSearch, nameSearch, unitSearch);

            RefreshDtgvGood(searchList);
        }

        #endregion

        #region Supplier
        void LoadDataGridviewSupplier()
        {
            dataGridViewSupplier.ColumnCount = 5;
            dataGridViewSupplier.Columns[0].Name = "ID";
            dataGridViewSupplier.Columns[1].Name = "name";
            dataGridViewSupplier.Columns[2].Name = "address";
            dataGridViewSupplier.Columns[3].Name = "phoneNumber";
            dataGridViewSupplier.Columns[4].Name = "email";

            dataGridViewSupplier.Columns[0].HeaderText = "Ma nha cung cap";
            dataGridViewSupplier.Columns[1].HeaderText = "Ten";
            dataGridViewSupplier.Columns[2].HeaderText = "Dia chi";
            dataGridViewSupplier.Columns[3].HeaderText = "So dien thoai";
            dataGridViewSupplier.Columns[4].HeaderText = "Email";

            dataGridViewGoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<Supplier1> listSup = SupplierDAO.Instance.GetListSupplier1();

            foreach (Supplier1 sp in listSup)
            {
                dataGridViewSupplier.Rows.Add(sp.ID, sp.Name, sp.Address, sp.PhoneNumber, sp.Email);
            }
        }

        void LoadDataGridviewSupplier(List<Supplier1> suppliers)
        {
            dataGridViewSupplier.ColumnCount = 5;
            dataGridViewSupplier.Columns[0].Name = "ID";
            dataGridViewSupplier.Columns[1].Name = "name";
            dataGridViewSupplier.Columns[2].Name = "address";
            dataGridViewSupplier.Columns[3].Name = "phoneNumber";
            dataGridViewSupplier.Columns[4].Name = "email";

            dataGridViewSupplier.Columns[0].HeaderText = "Ma nha cung cap";
            dataGridViewSupplier.Columns[1].HeaderText = "Ten";
            dataGridViewSupplier.Columns[2].HeaderText = "Dia chi";
            dataGridViewSupplier.Columns[3].HeaderText = "So dien thoai";
            dataGridViewSupplier.Columns[4].HeaderText = "Email";

            dataGridViewGoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            foreach (Supplier1 sp in suppliers)
            {
                dataGridViewSupplier.Rows.Add(sp.ID, sp.Name, sp.Address, sp.PhoneNumber, sp.Email);
            }
        }

        void RefreshDataGridviewSupplier()
        {
            dataGridViewSupplier.Rows.Clear();
            LoadDataGridviewSupplier();
        }

        void RefreshDataGridviewSupplier(List<Supplier1> suppliers)
        {
            dataGridViewSupplier.Rows.Clear();
            LoadDataGridviewSupplier(suppliers);
        }


        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            string id = null, name = null, address = null, phoneNumber = null, email = null;
            id = textBoxIDSupplier.Text;
            name = textBoxNameSupplier.Text;
            address = textBoxAddressSupplier.Text;
            phoneNumber = textBoxPhoneNumberSupplier.Text;
            email = textBoxEmailSupplier.Text;

            int rowAffected = SupplierDAO.Instance.InsertSupplier(id, name, address, phoneNumber, email);
            if (rowAffected > 0)
            {
                MessageBox.Show($"Da them {rowAffected} dong");
            }
            else
                MessageBox.Show("ID da bi trung");

            RefreshDataGridviewSupplier();
        }

        private void buttonDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (buttonDeleteSupplier.Tag != null)
            {
                string id, name;
                int rowIdx = (int)buttonDeleteSupplier.Tag;
                id = dataGridViewSupplier.Rows[rowIdx].Cells["id"].Value.ToString();
                name = dataGridViewSupplier.Rows[rowIdx].Cells["name"].Value.ToString();

                DialogResult result = MessageBox.Show($"Ban co chac muon xoa nha cung cap:\nID: {id}\nTen: {name}", "Thong bao", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int rowAffected = SupplierDAO.Instance.DeleteSupplier(id);
                    RefreshDataGridviewSupplier();
                    buttonDeleteGood.Tag = null;
                }
            }
            else
            {
                MessageBox.Show("Hay click vao dong ban muon xoa");
            }
        }

        private void dataGridViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDeleteSupplier.Tag = (object)e.RowIndex;
        }

        private void buttonUpdateSupplier_Click(object sender, EventArgs e)
        {
            string id = textBoxIDSupplier.Text;
            
            if (id != "")
            {
                string name ,address, phoneNumber, email;
                name = textBoxNameSupplier.Text;
                address = textBoxAddressSupplier.Text;
                phoneNumber = textBoxPhoneNumberSupplier.Text;
                email = textBoxEmailSupplier.Text;

                int rowCount = SupplierDAO.Instance.UpdateSupplier(id, name, address, phoneNumber, email);
                if(rowCount > 0)
                {
                    RefreshDataGridviewSupplier();
                    MessageBox.Show("Cap nhat thanh cong");
                }
                else
                {
                    MessageBox.Show("ID khong tim thay");
                }
            }
            else
                MessageBox.Show("Hay nhap ID");
        }

        private void buttonSearchSupplier_Click(object sender, EventArgs e)
        {
            string id, name, address, phoneNumber, email;
            id = textBoxIDSupplier.Text;
            name = textBoxNameSupplier.Text;
            address = textBoxAddressSupplier.Text;
            phoneNumber = textBoxPhoneNumberSupplier.Text;
            email = textBoxEmailSupplier.Text;

            List<Supplier1> searchList = SupplierDAO.Instance.SearchSupplier(id, name, address, phoneNumber, email);

            if (searchList != null)
            {
                RefreshDataGridviewSupplier(searchList);
            }
            else
            {
                MessageBox.Show("Khong tim thay");
            }
        }
        #endregion
    }
}
