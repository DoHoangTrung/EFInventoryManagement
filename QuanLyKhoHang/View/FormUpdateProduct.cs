using QuanLyKhoHang.DAL;
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

namespace QuanLyKhoHang
{
    public partial class FormUpdateProduct : Form
    {
        public Product selectedProductFromListView; 
        public FormUpdateProduct()
        {
            InitializeComponent();
        }

        private void FormUpdateProduct_Load(object sender, EventArgs e)
        {
            labelProductID.Text = selectedProductFromListView.ID;
            labelProductIDUpdate.Text = selectedProductFromListView.ID;

            textBoxProductName.Text = selectedProductFromListView.Name;

            textBoxProductUnit.Text = selectedProductFromListView.Unit;

            LoadComboboxType();
            //set selected item is product type (before update)
            comboBoxType.SelectedIndex = comboBoxType.FindStringExact(selectedProductFromListView.IdType);
        }

        private void LoadComboboxType()
        {
            comboBoxType.DataSource = ProductTypeDAO.Instance.GetListProductTypes();
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

            int rowAffected = ProductDAO.Instance.UpdateProduct(id, name, unit, typeID);
            if(rowAffected > 0)
            {
                MessageBox.Show("Sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }
    }
}
