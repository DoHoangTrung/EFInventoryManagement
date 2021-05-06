using QuanLyKhoHang.Entity_EF;
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
            toolStripStatusLabel1.Text = "helleo";
            toolTip.InitialDelay = 10;
            toolTip.ReshowDelay = 100000;
            
            toolTip.SetToolTip(label1, "this is label 1");

        }

    }
}
