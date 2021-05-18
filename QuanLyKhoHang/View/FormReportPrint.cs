using QuanLyKhoHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.View
{
    public partial class FormReportPrint : Form
    {
        List<ReportDTO> reports;
        public FormReportPrint(List<ReportDTO> reports)
        {
            InitializeComponent();
            this.reports = reports;
        }

        private void FormReportPrint_Load(object sender, EventArgs e)
        {
            ReportDTOBindingSource.DataSource = reports;
            this.reportViewer1.RefreshReport();
        }
    }
}
