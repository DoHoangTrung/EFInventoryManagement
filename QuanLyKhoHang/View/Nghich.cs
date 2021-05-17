using DGVPrinterHelper;
using QuanLyKhoHang.DAO;
using QuanLyKhoHang.Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKhoHang.View
{

    public partial class Nghich : Form
    {

        InventoryContext db = new InventoryContext();

        public Nghich()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Product Report";
            printer.SubTitle = "Your subtitle";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Create by TrungDH";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void Nghich_Load(object sender, EventArgs e)
        {
            var products = ProductDAO.Instance.GetListProduct();
            dataGridView1.DataSource = products;
        }

        void CreateNewExcel()
        {
            Excel ex = new Excel();
            ex.CreateNewFile();
            ex.CreateNewSheet();
            ex.CreateNewSheet();
            ex.SaveAs(@"C:\Users\Trung Do Hoang\Desktop\hello.xlsx");
            ex.Close();
        }

        public void OpenFile()
        {
            Excel excel = new Excel(@"C:\Users\Trung Do Hoang\Desktop\TTNhom_Trung_Long_Do.xlsx", 1);
            textBox1.Text = excel.ReadCell(3, 2);
        }

        public void WriteToExcel()
        {
            Excel excel = new Excel(@"C:\Users\Trung Do Hoang\Desktop\TTNhom_Trung_Long_Do.xlsx", 1);
            excel.WriteToCell(0, 0, 18031998);
            excel.Save();
        }
    }
}
