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

namespace QuanLyKhoHang
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            LoadIDCombobox();

            LoadTypeCombobox();

            labelGoodName.ForeColor = System.Drawing.Color.Red;
            labelGoodName.Text = "*Bắt buộc";

            labelNotificationIDGood.ForeColor = System.Drawing.Color.Red;
            labelNotificationIDGood.Text = "*Bắt buộc";
        }

        private void LoadTypeCombobox()
        {
            List<ProductType> productTypes = ProductTypeDAO.Instance.GetListProductTypes();
            comboBoxProductType.DataSource = productTypes;
            comboBoxProductType.DisplayMember = "name";
            comboBoxProductType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void LoadIDCombobox()
        {
            List<string> listID = ProductDAO.Instance.GetListProductID();
            comboBoxIDGood.DataSource = listID;
            comboBoxIDGood.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxIDGood.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        int AddGood()
        {
            int rowAffected = 0;
            string id, name, unit, typeID;
            id = comboBoxIDGood.Text;
            name = textBoxGoodName.Text;
            unit = textBoxGoodUnit.Text;
            typeID = (comboBoxProductType.SelectedItem as ProductType).ID;

            if (CheckComboBoxID())
            {
                rowAffected = ProductDAO.Instance.InsertProduct(id, name, unit, typeID);
            }
            return rowAffected;
        }
        
        bool CheckComboBoxID()
        {
            string id = comboBoxIDGood.Text;
            bool checkLength = true;
            bool isIDDuplicate = false;

            if (id.Length > 30 || id.Length == 0) return checkLength = false;
            isIDDuplicate = GoodDAO.Instance.IsIDDuplicate(id);

            return checkLength && (!isIDDuplicate);
        }

        bool CheckTextBoxName()
        {
            if (textBoxGoodName.TextLength == 0 || textBoxGoodName.TextLength > 100) 
                return false;
            else
                return true;
        }

        private void buttonAddGood_Click(object sender, EventArgs e)
        { 
            if (CheckComboBoxID() && CheckTextBoxName())
            {
                var result = MessageBox.Show("Bạn chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo);
                if(result== DialogResult.Yes)
                {
                    int rowAffected = AddGood();
                    if (rowAffected != 0)
                    {
                        MessageBox.Show("Da them thanh cong");
                        this.Close();
                    }
                }
            }
        }

        private void comboBoxIDGood_TextUpdate(object sender, EventArgs e)
        {
            string id = comboBoxIDGood.Text;
            bool isIDDuplicate = GoodDAO.Instance.IsIDDuplicate(id);

            if (id.Length > 30)
            {
                labelNotificationIDGood.ForeColor = System.Drawing.Color.Red;
                labelNotificationIDGood.Text = "Bạn đã nhập quá 30 kí tự ";
            }
            else if(id.Length == 0)
            {
                labelNotificationIDGood.ForeColor = System.Drawing.Color.Red;
                labelNotificationIDGood.Text = "*Bắt buộc";
            }
            else if (isIDDuplicate)
            {
                labelNotificationIDGood.ForeColor = System.Drawing.Color.Red;
                labelNotificationIDGood.Text = "ID đã tồn tại";
            }
            else
            {
                labelNotificationIDGood.ForeColor = System.Drawing.Color.Black;
                labelNotificationIDGood.Text = "Nhập mã không quá 30 kí tự\nKhông trùng lặp với các ID sẵn có";
            }
        }

        private void textBoxGoodName_TextChanged(object sender, EventArgs e)
        {
            string name = textBoxGoodName.Text;
            if(name.Length == 0)
            {
                labelGoodName.ForeColor = System.Drawing.Color.Red;
                labelGoodName.Text = "*Bắt buộc";
            }
            else if(name.Length > 100)
            {
                labelGoodName.ForeColor = System.Drawing.Color.Red;
                labelGoodName.Text = "Bạn đã nhập quá 100 ký tự";
            }
            else
            {
                labelGoodName.ForeColor = System.Drawing.Color.Black;
                labelGoodName.Text = "Nhập không quá 100 kí tự";
            }
        }
    }
}
