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
    public partial class FormUpdateInputVoucher : Form
    {
        public string idInputVoucher { get; set; }
        public FormUpdateInputVoucher()
        {
            InitializeComponent();
        }

        private void FormUpdateInputVoucher_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idInputVoucher))
            {
               textBoxIDVoucher.Text = idInputVoucher;
            }
        }
    }
}
