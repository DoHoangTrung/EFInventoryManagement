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
        DateTime dt;
        public Nghich()
        {
            InitializeComponent();
        }

        private void Nghich_Load(object sender, EventArgs e)
        {
            InventoryContext db = new InventoryContext();
            //db.Customers.Load();

        }

        
}
