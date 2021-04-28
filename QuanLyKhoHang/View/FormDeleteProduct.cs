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
    public partial class FormDeleteProduct : Form
    {
        internal Product productSelected;
        public FormDeleteProduct()
        {
            InitializeComponent();
        }


        void LoadTextBox()
        {
            if (productSelected != null)
            {
                labelProductID.Text = productSelected.ID;
                labelProductName.Text = productSelected.Name;
                labelProductUnit.Text = productSelected.Unit;
                
                string typeName = ProductTypeDAO.Instance.GetTypeByID( productSelected.IdType);
                labelProductType.Text = typeName;
            }
        }

        private void FormDeleteGood_Load(object sender, EventArgs e)
        {
            LoadTextBox();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string idProduct = labelProductID.Text;
            int rowAffected = ProductDAO.Instance.DeleteProductByID(idProduct);
            if (rowAffected > 0)
            {
                MessageBox.Show("Xóa thành công");
                this.Close();
            }
        }
    }
}
