using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.View
{
    public partial class Nghich : Form
    {
        InventoryContext db = new InventoryContext();
        DateTime dt;
        public Nghich()
        {
            InitializeComponent();
        }
        ToolTip toolTip = new ToolTip();
        private void Nghich_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            List<Product> products = ProductDAO.Instance.GetListProduct();
            foreach (var p in products)
            {
                bs.Add(p);
            }
            dataGridView1.DataSource = bs;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = dataGridView1.Rows[e.RowIndex].DataBoundItem as Product;
            label1.Text = p.ID;
        }
    }
}
