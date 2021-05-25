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

namespace QuanLyKhoHang
{
    public partial class FormUpdateProduct : Form
    {
        public ProductDTO selectedProductFromDtgv; 
        public FormUpdateProduct()
        {
            InitializeComponent();
        }

        private void FormUpdateProduct_Load(object sender, EventArgs e)
        {
            labelProductID.Text = selectedProductFromDtgv.ID;
            labelProductIDUpdate.Text = selectedProductFromDtgv.ID;

            textBoxProductName.Text = selectedProductFromDtgv.Name;
            textBoxProductNameUpdate.Text = selectedProductFromDtgv.Name;

            textBoxProductUnit.Text = selectedProductFromDtgv.Unit;
            textBoxProductUnitUpdate.Text = selectedProductFromDtgv.Unit;

            LoadComboboxType();
            //set selected item is product type (before update)
            comboBoxType.SelectedIndex = comboBoxType.FindStringExact(selectedProductFromDtgv.TypeName);
        }

        private void LoadComboboxType()
        {
            comboBoxType.DataSource = ProductTypeDAO.Instance.GetList();
            comboBoxType.DisplayMember = "name";
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string id, name, unit, typeID;
            id = labelProductIDUpdate.Text;
            name = textBoxProductNameUpdate.Text;
            unit = textBoxProductUnitUpdate.Text;
            typeID = (comboBoxType.SelectedItem as ProductType).ID;

            if (!string.IsNullOrEmpty(name))
            {
                int rowAffected = ProductDAO.Instance.UpdateProduct(id, name, unit, typeID);

                if (rowAffected > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tên cho sản phẩm");
            }
        }

    }
}
