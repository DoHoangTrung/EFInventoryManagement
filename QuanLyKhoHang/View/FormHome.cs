using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using PagedList;
using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using QuanLyKhoHang.View;

namespace QuanLyKhoHang
{
    public partial class FormHome : Form
    {
        const int size = 10;
        private Color colorButtonCategoryWhenClicked;
        private ListViewColumnSorter lvwColumnSorter;

        private int currentPage;
        private object currentPagedList;
        object showingDtgv;
        public FormHome()
        {
            InitializeComponent();
        }

        private void SetMyCustomeFomateDatetimePicker(string format)
        {
            dtpickerFromDate.Format = DateTimePickerFormat.Custom;
            dtpickerFromDate.CustomFormat = format;

            dtpickerToDate.Format = DateTimePickerFormat.Custom;
            dtpickerToDate.CustomFormat = format;
        }

        private void LoadDateTimePicker()
        {
            //dtpickerFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpickerFromDate.Value = new DateTime(2021, 2, 1);
            dtpickerFromDate.MinDate = new DateTime(2020, 1, 1);
            dtpickerFromDate.MaxDate = DateTime.Now;

            dtpickerToDate.Value = DateTime.Now;
            dtpickerToDate.MinDate = new DateTime(2020, 1, 1);
            dtpickerToDate.MaxDate = DateTime.Now;
        }

        private async Task LoadDtgvProduct(int pageNumber=1,int pageSize= size)
        {
            currentPage = pageNumber;

            IPagedList<ProductDTO> products = await ProductDAO.Instance.GetPagedListProductDTOs(pageNumber,pageSize);

            currentPagedList = products;

            //load paged list button
            btnPrevious.Enabled = products.HasPreviousPage;
            btnNext.Enabled = products.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{products.PageCount}";

            //load dtgvHome
            dtgvHome.DataSource = new SortableBindingList<ProductDTO>(products.ToList());

        }

        private void LoadListViewProduct()
        {
            listViewGeneral.Clear();

            //create listview
            listViewGeneral.Columns.Add(CreateListViewHeader("productID", "ID sản phẩm"));
            listViewGeneral.Columns.Add(CreateListViewHeader("productName", "Tên sản phẩm"));
            listViewGeneral.Columns.Add(CreateListViewHeader("unit", "Đơn vị"));
            listViewGeneral.Columns.Add(CreateListViewHeader("typeName", "Loại sản phẩm"));


            listViewGeneral.View = System.Windows.Forms.View.Details;
            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            List<Product> products = ProductDAO.Instance.GetListProduct();


            foreach (var p in products)
            {
                ListViewItem lvwItem = new ListViewItem(p.ID);
                lvwItem.SubItems.Add(p.Name);
                lvwItem.SubItems.Add(p.Unit);
                lvwItem.SubItems.Add(p.ProductType.Name);

                listViewGeneral.Items.Add(lvwItem);
            }

            AutoResizeColumnListView();
        }
        private void LoadListViewProduct(List<Product> products)
        {
            listViewGeneral.Clear();

            //create listview
            listViewGeneral.Columns.Add(CreateListViewHeader("productID", "ID sản phẩm"));
            listViewGeneral.Columns.Add(CreateListViewHeader("productName", "Tên sản phẩm"));
            listViewGeneral.Columns.Add(CreateListViewHeader("unit", "Đơn vị"));
            listViewGeneral.Columns.Add(CreateListViewHeader("typeName", "Loại sản phẩm"));


            listViewGeneral.View = System.Windows.Forms.View.Details;
            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            foreach (var p in products)
            {
                ListViewItem lvwItem = new ListViewItem(p.ID);
                lvwItem.SubItems.Add(p.Name);
                lvwItem.SubItems.Add(p.Unit);
                lvwItem.SubItems.Add(p.ProductType.Name);

                listViewGeneral.Items.Add(lvwItem);
            }

            AutoResizeColumnListView();
        }


        private async Task LoadDtgvSupplier(int pageNumber = 1, int pageSize = size)
        {
            var suppliers = await SupplierDAO.Instance.GetPagedList(pageNumber,pageSize);

            dtgvHome.DataSource = new SortableBindingList<Supplier>(suppliers.ToList());

            //load paged list button
            btnPrevious.Enabled = suppliers.HasPreviousPage;
            btnNext.Enabled = suppliers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{suppliers.PageCount}";


            currentPagedList = suppliers;
            currentPage = pageNumber;
        }
        private void LoadListViewSupplier(List<Supplier> suppliers)
        {
            listViewGeneral.Clear();

            //create listview
            listViewGeneral.Columns.Add(CreateListViewHeader("Mã nhà cung cấp"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Tên"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Địa chỉ"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Số điện thoại"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Email"));

            listViewGeneral.View = System.Windows.Forms.View.Details;
            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            foreach (var supplier in suppliers)
            {
                ListViewItem lvwItem = new ListViewItem(supplier.ID);
                lvwItem.SubItems.Add(supplier.Name);
                lvwItem.SubItems.Add(supplier.Address);
                lvwItem.SubItems.Add(supplier.Phone);
                lvwItem.SubItems.Add(supplier.Email);

                listViewGeneral.Items.Add(lvwItem);
            }

            AutoResizeColumnListView();
        }


        private async Task LoadDtgvReceiveVoucher(int pageNumber = 1, int pageSize = size)
        {
            var vouchers = await ReceiveVoucherDAO.Instance.GetPagedList(pageNumber, pageSize);

            dtgvHome.DataSource = new SortableBindingList<ReceiveVoucherDTO>(vouchers.ToList());

            //load paged list button
            btnPrevious.Enabled = vouchers.HasPreviousPage;
            btnNext.Enabled = vouchers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{vouchers.PageCount}";


            currentPagedList = vouchers;
            currentPage = pageNumber;
        }
        private void LoadListViewReceiveVoucher(List<ReceiveVoucherInfo> receiveVoucherInfoes)
        {
            listViewGeneral.Clear();

            //create list view input voucher
            listViewGeneral.Columns.Add(CreateListViewHeader("IDReceiveVoucher", "ID phieu nhap"));
            listViewGeneral.Columns.Add(CreateListViewHeader("ID san pham"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Ten san pham"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Don vi"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Ngay"));
            listViewGeneral.Columns.Add(CreateListViewHeader("So luong nhap"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Gia nhap"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Ghi chú"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Nha cung cap"));
            listViewGeneral.Columns.Add(CreateListViewHeader("DC"));
            listViewGeneral.Columns.Add(CreateListViewHeader("SDT"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Email"));
            listViewGeneral.Columns.Add(CreateListViewHeader("ID NCC"));

            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            if (receiveVoucherInfoes == null)
            {
                List<ReceiveVoucher> receiveVouchers = ReceiveVoucherDAO.Instance.GetListReceiveVoucher();

                foreach (var v in receiveVouchers)
                {
                    ListViewItem lvwItem = new ListViewItem(v.ID);
                }

            }
            else
            {
                receiveVoucherInfoes = receiveVoucherInfoes.OrderByDescending(i =>
                    {
                        return i.ReceiveVoucher.Date;
                    }).ToList();

                foreach (var v in receiveVoucherInfoes)
                {
                    ListViewItem lvwItem = new ListViewItem(v.ReceiveVoucher.ID);
                    lvwItem.SubItems.Add(v.Product.ID);
                    lvwItem.SubItems.Add(v.Product.Name);
                    lvwItem.SubItems.Add(v.Product.Unit);
                    lvwItem.SubItems.Add(v.ReceiveVoucher.Date.ToString());
                    lvwItem.SubItems.Add(v.QuantityInput.ToString());
                    lvwItem.SubItems.Add(v.PriceInput.ToString());
                    lvwItem.SubItems.Add(v.Note);
                    lvwItem.SubItems.Add(v.ReceiveVoucher.Supplier.Name);
                    lvwItem.SubItems.Add(v.ReceiveVoucher.Supplier.Address);
                    lvwItem.SubItems.Add(v.ReceiveVoucher.Supplier.Phone);
                    lvwItem.SubItems.Add(v.ReceiveVoucher.Supplier.Email);
                    lvwItem.SubItems.Add(v.ReceiveVoucher.Supplier.ID);

                    listViewGeneral.Items.Add(lvwItem);
                }
                AutoResizeColumnListView();
            }
        }


        private void LoadListViewDeliveryVoucher(List<DeliveryVoucherView> voucherViews)
        {
            listViewGeneral.Clear();

            listViewGeneral.Columns.Add(CreateListViewHeader("IDDeliveryVoucher", "ID phiếu xuất"));
            listViewGeneral.Columns.Add(CreateListViewHeader("NgayXuat"));
            listViewGeneral.Columns.Add(CreateListViewHeader("TenSanPham"));
            listViewGeneral.Columns.Add(CreateListViewHeader("DonVi"));
            listViewGeneral.Columns.Add(CreateListViewHeader("SoLuongXuat"));
            listViewGeneral.Columns.Add(CreateListViewHeader("GiaXuat"));
            listViewGeneral.Columns.Add(CreateListViewHeader("TenKhachHang"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Phone", "So dien thoai"));
            listViewGeneral.Columns.Add(CreateListViewHeader("IDSanPham"));
            listViewGeneral.Columns.Add(CreateListViewHeader("IDKhachHang"));

            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            foreach (var voucher in voucherViews)
            {
                ListViewItem lvwItem = new ListViewItem(voucher.VoucherID);
                lvwItem.SubItems.Add(voucher.Date.ToString());
                lvwItem.SubItems.Add(voucher.ProductName);
                lvwItem.SubItems.Add(voucher.Unit);
                lvwItem.SubItems.Add(voucher.SumQuantity.ToString());
                lvwItem.SubItems.Add(voucher.PriceOutput.ToString());
                lvwItem.SubItems.Add(voucher.CustomerName);
                lvwItem.SubItems.Add(voucher.Phone);
                lvwItem.SubItems.Add(voucher.ProductID);
                lvwItem.SubItems.Add(voucher.CustomerID);

                listViewGeneral.Items.Add(lvwItem);
            }

            AutoResizeColumnListView();
        }
        private async Task LoadDtgvDeliveryVoucher(int pageNumber = 1, int pageSize = size)
        {
            DeliveryVoucherViewDAO dao = new DeliveryVoucherViewDAO();
            var vouchers = await dao.GetPagedList(pageNumber, pageSize);

            dtgvHome.DataSource = new SortableBindingList<DeliveryVoucherView>(vouchers.ToList());

            //load paged list button
            btnPrevious.Enabled = vouchers.HasPreviousPage;
            btnNext.Enabled = vouchers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{vouchers.PageCount}";


            currentPagedList = vouchers;
            currentPage = pageNumber;
        }
    

        private void AutoResizeColumnListView()
        {
            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private async Task LoadDtgvCustomer(int pageNumber = 1, int pageSize = size)
        {
            var customers = await CustomerDAO.Instance.GetPagedList();
            dtgvHome.DataSource = new SortableBindingList<Customer>(customers.ToList());

            //load paged list button
            btnPrevious.Enabled = customers.HasPreviousPage;
            btnNext.Enabled = customers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{customers.PageCount}";

            currentPagedList = customers;
            currentPage = pageNumber;
        }
        private void LoadListViewCustomer(List<Customer> customers)
        {
            listViewGeneral.Clear();

            //create listview
            listViewGeneral.Columns.Add(CreateListViewHeader("Mã khách hàng"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Tên"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Địa chỉ"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Số điện thoại"));
            listViewGeneral.Columns.Add(CreateListViewHeader("Email"));

            listViewGeneral.View = System.Windows.Forms.View.Details;
            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            foreach (var customer in customers)
            {
                ListViewItem lvwItem = new ListViewItem(customer.ID);
                lvwItem.SubItems.Add(customer.Name);
                lvwItem.SubItems.Add(customer.Address);
                lvwItem.SubItems.Add(customer.Phone);
                lvwItem.SubItems.Add(customer.Email);

                listViewGeneral.Items.Add(lvwItem);
            }

            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }


        private async void LoadListViewReport(List<ReportDTO> reports)
        {
            if (checkBoxDatetimePicker.Checked)
            {
                listViewGeneral.Clear();

                //create listview
                listViewGeneral.Columns.Add(CreateListViewHeader("ProductID", "ID sản phẩm"));
                listViewGeneral.Columns.Add(CreateListViewHeader("ProductName", "Tên sản phẩm"));
                listViewGeneral.Columns.Add(CreateListViewHeader("ProductUnit", "Đơn vị"));
                listViewGeneral.Columns.Add(CreateListViewHeader("ReceiveQuantity", "Số lượng nhập"));
                listViewGeneral.Columns.Add(CreateListViewHeader("ReceivePrice", "Giá nhập"));
                listViewGeneral.Columns.Add(CreateListViewHeader("ReceiveTotalPrice", "Thành tiền"));
                listViewGeneral.Columns.Add(CreateListViewHeader("DeliveryQuantity", "Số lượng xuất"));
                listViewGeneral.Columns.Add(CreateListViewHeader("DeliveryPrice", "Giá xuất"));
                listViewGeneral.Columns.Add(CreateListViewHeader("DeliveryTotalPrice", "Thành tiền"));
                listViewGeneral.Columns.Add(CreateListViewHeader("InventoryNumber", "Tồn kho cuối kì"));
                listViewGeneral.Columns.Add(CreateListViewHeader("Profit", "Lợi nhuận"));


                listViewGeneral.View = System.Windows.Forms.View.Details;
                listViewGeneral.ListViewItemSorter = lvwColumnSorter;

                foreach (var r in reports)
                {
                    ListViewItem lvwItem = new ListViewItem(r.ProductID);
                    lvwItem.SubItems.Add(r.ProductName);
                    lvwItem.SubItems.Add(r.ProductUnit);
                    lvwItem.SubItems.Add(r.ReceiveQuantity.ToString());
                    lvwItem.SubItems.Add(r.ReceivePrice.ToString());
                    lvwItem.SubItems.Add(r.ReceiveTotalPrice.ToString());
                    lvwItem.SubItems.Add(r.DeliveryQuantity.ToString());
                    lvwItem.SubItems.Add(r.DeliveryPrice.ToString());
                    lvwItem.SubItems.Add(r.DeliveryTotalPrice.ToString());
                    lvwItem.SubItems.Add(r.InventoryNumber.ToString());
                    lvwItem.SubItems.Add(r.Profit.ToString());

                    listViewGeneral.Items.Add(lvwItem);
                }

                AutoResizeColumnListView();

                showingDtgv = reports;
            }
            else
            {
                MessageBox.Show("Bạn hãy xem báo cáo theo khoảng thời gian");
            }
        }
        private async Task LoadDtgvReport(int pageNumber = 1, int pageSize = size)
        {
            if (checkBoxDatetimePicker.Checked)
            {
                ReportDAO dao = new ReportDAO();
                var reports = await dao.GetListByDuration(dtpickerFromDate.Value, dtpickerToDate.Value,pageNumber,pageSize);

                dtgvHome.DataSource = new SortableBindingList<ReportDTO>(reports.ToList());

                //load paged list button
                btnPrevious.Enabled = reports.HasPreviousPage;
                btnNext.Enabled = reports.HasNextPage;
                labelPageNumber.Text = $"Page {pageNumber}/{reports.PageCount}";

                currentPagedList = reports;
                currentPage = pageNumber;
            }
            else
            {
                MessageBox.Show("Bạn hãy xem báo cáo theo khoảng thời gian");
            }
        }

        private ColumnHeader CreateListViewHeader(string text)
        {
            ColumnHeader columnHeader;
            columnHeader = new ColumnHeader();
            columnHeader.Text = text;
            columnHeader.Name = text;
            return columnHeader;
        }

        private ColumnHeader CreateListViewHeader(string name, string displayText)
        {
            ColumnHeader columnHeader;
            columnHeader = new ColumnHeader();
            columnHeader.Text = displayText;
            columnHeader.Name = name;
            return columnHeader;
        }

        private void LoadToolTip()
        {
            toolTip1.SetToolTip(textBoxSearch, "Tìm kiếm theo id, tên, đơn vị, địa chỉ, số điện thoại, email");
        }

        #region EVENT!
        private void FormHome_Load(object sender, EventArgs e)
        {
            lvwColumnSorter = new ListViewColumnSorter();

            LoadDateTimePicker();

            colorButtonCategoryWhenClicked = Color.FromArgb(203, 225, 247);

            LoadToolTip();

            SetMyCustomeFomateDatetimePicker("dd/MM/yyyy");

            checkBoxDatetimePicker.Checked = true;

            dtgvHome.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void listViewInventory_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            listViewGeneral.Sort();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //ReLoadListViewInventory();
        }

        #region category button

        private void buttonCategoryGoods_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryProduct);
            ChangeColorCategoryButtonWhenClicked(sender as Button);
        }

        private void buttonCategorySupplier_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategorySupplier);
            ChangeColorCategoryButtonWhenClicked(sender as Button);
        }

        private void buttonCategoryInputVoucher_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryReceiveVoucher);
            ChangeColorCategoryButtonWhenClicked(sender as Button);
        }

        private void buttonCategoryOutputVoucher_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryDeliveryVoucher);
            ChangeColorCategoryButtonWhenClicked(sender as Button);
        }

        private void buttonCategoryCustomer_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryCustomer);
            ChangeColorCategoryButtonWhenClicked(buttonCategoryCustomer);
        }
        private void buttonCategoryReport_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryReport);
            ChangeColorCategoryButtonWhenClicked(buttonCategoryReport);
        }
        private void ChangeColorCategoryButtonWhenClicked(Button button)
        {
            buttonCategoryProduct.BackColor = default;
            buttonCategorySupplier.BackColor = default;
            buttonCategoryReceiveVoucher.BackColor = default;
            buttonCategoryDeliveryVoucher.BackColor = default;
            buttonCategoryCustomer.BackColor = default;
            buttonCategoryReport.BackColor = default;

            if (button == buttonCategoryProduct)
            {
                buttonCategoryProduct.BackColor = colorButtonCategoryWhenClicked;
            }

            if (button == buttonCategorySupplier)
            {
                buttonCategorySupplier.BackColor = colorButtonCategoryWhenClicked;
            }

            if (button == buttonCategoryReceiveVoucher)
            {
                buttonCategoryReceiveVoucher.BackColor = colorButtonCategoryWhenClicked;
            }

            if (button == buttonCategoryDeliveryVoucher)
            {
                buttonCategoryDeliveryVoucher.BackColor = colorButtonCategoryWhenClicked;
            }

            if (button == buttonCategoryCustomer)
            {
                buttonCategoryCustomer.BackColor = colorButtonCategoryWhenClicked;
            }

            if (button == buttonCategoryReport)
            {
                buttonCategoryReport.BackColor = colorButtonCategoryWhenClicked;
            }
        }

        private void TagThisCategoryButtomToActionButton(Button categoryButton)
        {
            buttonShow.Tag = categoryButton;
            buttonAdd.Tag = categoryButton;
            buttonUpdate.Tag = categoryButton;
            buttonDelete.Tag = categoryButton;
            buttonSearch.Tag = categoryButton;
            buttonPrint.Tag = categoryButton;
        }

        #endregion

        private void buttonShow_Click(object sender, EventArgs e)
        {
            Button categoryButtonTagged = buttonShow.Tag as Button;

            if (categoryButtonTagged == buttonCategoryProduct)
            {
                LoadDtgvProduct();
            }

            if (categoryButtonTagged == buttonCategorySupplier)
            {
                LoadDtgvSupplier();
            }

            if (categoryButtonTagged == buttonCategoryCustomer)
            {
                LoadDtgvCustomer();
            }

            if (categoryButtonTagged == buttonCategoryReceiveVoucher)
            {
                LoadDtgvReceiveVoucher();
            }

            if (categoryButtonTagged == buttonCategoryDeliveryVoucher)
            {
                LoadDtgvDeliveryVoucher();
            }

            if (categoryButtonTagged == buttonCategoryReport)
            {
                //LoadListViewReport();
                LoadDtgvReport();
            }

            if (categoryButtonTagged == null)
            {
                MessageBox.Show("Bạn hãy chọn mục muốn hiển thị");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button categoryButtonTagged = buttonAdd.Tag as Button;

            if (categoryButtonTagged == buttonCategoryProduct)
            {
                FormAddProduct formAddGood = new FormAddProduct();
                formAddGood.ShowDialog();

                LoadDtgvProduct();
            }

            if (categoryButtonTagged == buttonCategorySupplier)
            {
                FormAddSupplier formAddSupplier = new FormAddSupplier();
                formAddSupplier.ShowDialog();

                LoadDtgvSupplier();
            }

            if (categoryButtonTagged == buttonCategoryReceiveVoucher)
            {
                FormAddReceiveVoucher fAddInputVoucher = new FormAddReceiveVoucher();
                fAddInputVoucher.ShowDialog();

                LoadDtgvReceiveVoucher();
            }

            if (categoryButtonTagged == buttonCategoryDeliveryVoucher)
            {
                FormAddDeliveryVoucher f = new FormAddDeliveryVoucher();
                f.ShowDialog();

            }


            if (categoryButtonTagged == buttonCategoryCustomer)
            {
                FormAddCustomer fAdd = new FormAddCustomer();
                fAdd.ShowDialog();

                LoadDtgvCustomer();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Button categoryButtonClicked = buttonUpdate.Tag as Button;

            if (categoryButtonClicked == buttonCategoryProduct)
            {
                FormUpdateProduct formUpdate = new FormUpdateProduct();
                Product selectedProduct = listViewGeneral.Tag as Product;
                if (selectedProduct != null)
                {
                    formUpdate.selectedProductFromListView = selectedProduct;
                    formUpdate.ShowDialog();

                    LoadListViewProduct();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm");
                }
            }

            if (categoryButtonClicked == buttonCategorySupplier)
            {
                Supplier supplierTagged = listViewGeneral.Tag as Supplier;
                if (supplierTagged != null)
                {
                    FormUpdateSupplier fUpSupp = new FormUpdateSupplier();
                    fUpSupp.supplierSelectedFromListView = supplierTagged;
                    fUpSupp.ShowDialog();

                    LoadDtgvSupplier();
                }
                else
                {
                    MessageBox.Show("Hãy click vào nhà cung cấp bạn muốn");
                }
            }

            if (categoryButtonClicked == buttonCategoryReceiveVoucher)
            {
                if (listViewGeneral.Tag != null)
                {
                    ReceiveVoucher voucherTagged = listViewGeneral.Tag as ReceiveVoucher;
                    if (voucherTagged != null)
                    {
                        FormUpdateReceiveVoucher fUpdate = new FormUpdateReceiveVoucher();
                        fUpdate.receiveVoucherTagged = voucherTagged;
                        this.Hide();
                        fUpdate.ShowDialog();
                        this.Show();

                        LoadDtgvReceiveVoucher();
                    }
                }
                else
                {
                    MessageBox.Show("Hãy click  vào hóa đơn bạn muốn sửa.");
                }
            }

            if (categoryButtonClicked == buttonCategoryDeliveryVoucher)
            {

            }


            if (categoryButtonClicked == buttonCategoryCustomer)
            {
                Customer customerTagged = listViewGeneral.Tag as Customer;
                if (customerTagged != null)
                {
                    FormUpdateCustomer fUp = new FormUpdateCustomer();
                    fUp.customerSelectedFromListView = customerTagged;
                    fUp.ShowDialog();

                    LoadDtgvCustomer();
                }
                else
                {
                    MessageBox.Show("Hãy click vào khách hàng bạn muốn");
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Button categoryButtonTagged = buttonDelete.Tag as Button;

            if (categoryButtonTagged == buttonCategoryProduct)
            {
                Product productSelected = listViewGeneral.Tag as Product;
                if (productSelected != null)
                {
                    FormDeleteProduct formDelete = new FormDeleteProduct();
                    formDelete.productSelected = productSelected;
                    formDelete.ShowDialog();

                    LoadListViewProduct();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm");
                }

            }

            if (categoryButtonTagged == buttonCategorySupplier)
            {
                Supplier supplierTagged = listViewGeneral.Tag as Supplier;
                if (supplierTagged != null)
                {
                    FormDeleteSupplier fDel = new FormDeleteSupplier();
                    fDel.supplierSelectedFromListView = supplierTagged;
                    fDel.ShowDialog();

                    LoadDtgvSupplier();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn nhà cung cấp");
                }
            }

            if (categoryButtonTagged == buttonCategoryReceiveVoucher)
            {
                ReceiveVoucher voucherTagged = listViewGeneral.Tag as ReceiveVoucher;
                if (voucherTagged != null)
                {
                    if (ReceiveVoucherDAO.Instance.HaveTheProductBeenSold(voucherTagged.ID))
                    {
                        MessageBox.Show("Phiếu nhập hàng này đã có sản phẩm được xuất kho. Bạn không thể xóa");
                    }
                    else
                    {
                        FormDeleteReceiveVoucher f = new FormDeleteReceiveVoucher();
                        f.voucherTagged = voucherTagged;
                        this.Hide();
                        f.ShowDialog();

                        LoadDtgvReceiveVoucher();

                        this.Show();

                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn dòng thông tin bạn muốn xóa");
                }
            }

            if (categoryButtonTagged == buttonCategoryDeliveryVoucher)
            {
                if (listViewGeneral.Tag != null)
                {
                    string deliveryVoucherID = listViewGeneral.Tag.ToString();

                    FormDeleteDeliveryVoucher f = new FormDeleteDeliveryVoucher();
                    f.DeliveryVoucherID = deliveryVoucherID;
                    f.ShowDialog();
                }
            }
            if (categoryButtonTagged == buttonCategoryCustomer)
            {
                Customer customerTagged = listViewGeneral.Tag as Customer;
                if (customerTagged != null)
                {
                    FormDeleteCustomer fDel = new FormDeleteCustomer();
                    fDel.customerSelectedFromListView = customerTagged;
                    fDel.ShowDialog();

                    LoadDtgvSupplier();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng");
                }
            }
        }

        private void listViewGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGeneral.SelectedItems.Count > 0)
            {
                Button btnCatgory = buttonShow.Tag as Button;

                ListViewItem lvwItem = listViewGeneral.SelectedItems[0];

                if (btnCatgory == buttonCategoryProduct)
                {
                    Product product = new Product();
                    product.ID = lvwItem.SubItems[0].Text;
                    product.Name = lvwItem.SubItems[1].Text;
                    product.Unit = lvwItem.SubItems[2].Text;
                    product.IdType = ProductTypeDAO.Instance.GetIDByName(lvwItem.SubItems[3].Text);
                    listViewGeneral.Tag = product as object;
                }

                if (btnCatgory == buttonCategorySupplier)
                {
                    string id, name, addr, phone, email;
                    id = lvwItem.SubItems[0].Text;
                    name = lvwItem.SubItems[1].Text;
                    addr = lvwItem.SubItems[2].Text;
                    phone = lvwItem.SubItems[3].Text;
                    email = lvwItem.SubItems[4].Text;

                    Supplier supplier = new Supplier();
                    supplier.ID = id;
                    supplier.Name = name;
                    supplier.Address = addr;
                    supplier.Phone = phone;
                    supplier.Email = email;


                    listViewGeneral.Tag = supplier as object;
                }

                if (btnCatgory == buttonCategoryCustomer)
                {
                    string id, name, addr, phone, email;
                    id = lvwItem.SubItems[0].Text;
                    name = lvwItem.SubItems[1].Text;
                    addr = lvwItem.SubItems[2].Text;
                    phone = lvwItem.SubItems[3].Text;
                    email = lvwItem.SubItems[4].Text;

                    Customer customer = CustomerDAO.Instance.NewCustomer(id, name, addr, phone, email);
                    customer.ID = id;

                    listViewGeneral.Tag = customer as object;
                }

                if (btnCatgory == buttonCategoryReceiveVoucher)
                {
                    int indexColumnIDVoucher = listViewGeneral.Columns.IndexOfKey("IDReceiveVoucher");
                    string idReceiveVoucher = lvwItem.SubItems[indexColumnIDVoucher].Text;

                    ReceiveVoucher receiveVoucher = ReceiveVoucherDAO.Instance.GetReceiveVoucherAllInfoByID(idReceiveVoucher);

                    listViewGeneral.Tag = receiveVoucher as object;
                }

                if (btnCatgory == buttonCategoryDeliveryVoucher)
                {
                    int columnIDVoucher = listViewGeneral.Columns.IndexOfKey("IDDeliveryVoucher");
                    string deliveryVoucherID = lvwItem.SubItems[columnIDVoucher].Text;

                    listViewGeneral.Tag = deliveryVoucherID;
                }
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyWord = textBoxSearch.Text;

            Button category = buttonSearch.Tag as Button;

            if (category == null)
            {
                MessageBox.Show("Bạn hãy chọn mục muốn tìm kiếm");
            }

            if (category == buttonCategoryProduct)
            {
                List<Product> products = ProductDAO.Instance.Search(keyWord);
                LoadListViewProduct(products);
            }

            if (category == buttonCategoryCustomer)
            {
                List<Customer> searchList = CustomerDAO.Instance.Search(keyWord);
                LoadListViewCustomer(searchList);
            }

            if (category == buttonCategorySupplier)
            {
                List<Supplier> searchList = SupplierDAO.Instance.Search(keyWord);
                LoadListViewSupplier(searchList);
            }

            if (category == buttonCategoryReceiveVoucher)
            {
                List<ReceiveVoucherInfo> searchList = ReceiveVoucherInfoDAO.Instance.GetList();

                //search by time duration
                if (checkBoxDatetimePicker.Checked)
                {
                    searchList = ReceiveVoucherInfoDAO.Instance.SearchByTime(searchList, dtpickerFromDate.Value, dtpickerToDate.Value);
                }
                //keep searching by key words
                string keyWords = textBoxSearch.Text;
                if (!string.IsNullOrEmpty(keyWords))
                {
                    searchList = ReceiveVoucherInfoDAO.Instance.SearchByWords(searchList, keyWord);
                }

                LoadListViewReceiveVoucher(searchList);
            }

            if (category == buttonCategoryDeliveryVoucher)
            {
                DeliveryVoucherViewDAO dao = new DeliveryVoucherViewDAO();

                List<DeliveryVoucherView> voucherInfoViews = dao.SearchByWords(keyWord);

                //keep searching by time range
                if (checkBoxDatetimePicker.Checked)
                {
                    voucherInfoViews = dao.SearchByTimeRange(voucherInfoViews, dtpickerFromDate.Value, dtpickerToDate.Value);
                }

                LoadListViewDeliveryVoucher(voucherInfoViews);
            }

            if (category == buttonCategoryReport)
            {
                ReportDAO dao = new ReportDAO();
                List<ReportDTO> reports = dao.GetPagedListByDuration(dtpickerFromDate.Value, dtpickerToDate.Value);

                //search by key words
                reports = dao.SearchByWords(reports, keyWord);

                LoadListViewReport(reports);
            }
        }

        private void checkBoxDatetimePicker_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDatetimePicker.Checked)
            {
                labelFromDate.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                labelToDate.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            }
            else
            {
                labelFromDate.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                labelToDate.Font = new Font(Label.DefaultFont, FontStyle.Regular);
            }
        }


        #endregion

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Button categoryButtonTagged = buttonPrint.Tag as Button;

            if (categoryButtonTagged == buttonCategoryReport && listViewGeneral.Columns.Count > 0)
            {
                FormReportPrint f = new FormReportPrint(showingDtgv as List<ReportDTO>);
                f.Show();
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            labelTest.Text = currentPage.ToString();

            var products = currentPagedList as IPagedList<ProductDTO>;
            if (products != null && products.HasPreviousPage)
            {
                LoadDtgvProduct(--currentPage);
            }


            var suppliers = currentPagedList as IPagedList<Supplier>;
            if (suppliers != null && suppliers.HasPreviousPage)
            {
                LoadDtgvSupplier(--currentPage);
            }

            var customers = currentPagedList as IPagedList<Customer>;
            if (customers != null && customers.HasPreviousPage)
            {
                LoadDtgvCustomer(--currentPage);
            }

            var reports = currentPagedList as IPagedList<ReportDTO>;
            if (reports != null && reports.HasPreviousPage)
            {
                LoadDtgvReport(--currentPage);
            }

            var reVouchers = currentPagedList as IPagedList<ReceiveVoucherDTO>;
            if (reVouchers != null && reVouchers.HasPreviousPage)
            {
                LoadDtgvReceiveVoucher(--currentPage);
            }

            var deVouchers = currentPagedList as IPagedList<DeliveryVoucherView>;
            if (deVouchers != null && deVouchers.HasPreviousPage)
            {
                LoadDtgvReceiveVoucher(--currentPage);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            labelTest.Text = currentPage.ToString();
            var products = currentPagedList as IPagedList<ProductDTO>;
            if (products != null && products.HasNextPage)
            {
                LoadDtgvProduct(++currentPage);
            }


            var suppliers = currentPagedList as IPagedList<Supplier>;
            if (suppliers != null && suppliers.HasNextPage)
            {
                LoadDtgvSupplier(++currentPage);
            }

            var customers = currentPagedList as IPagedList<Customer>;
            if (customers != null && customers.HasNextPage)
            {
                LoadDtgvCustomer(++currentPage);
            }

            var reports = currentPagedList as IPagedList<ReportDTO>;
            if (reports != null && reports.HasNextPage)
            {
                LoadDtgvReport(++currentPage);
            }

            var reVouchers = currentPagedList as IPagedList<ReceiveVoucherDTO>;
            if (reVouchers != null && reVouchers.HasNextPage)
            {
                LoadDtgvReceiveVoucher(++currentPage);
            }

            var deVouchers = currentPagedList as IPagedList<DeliveryVoucherView>;
            if (deVouchers != null && deVouchers.HasNextPage)
            {
                LoadDtgvReceiveVoucher(++currentPage);
            }
        }

        private void dtgvHome_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dtgvHome.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void dtgvHome_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dtgvHome.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dtgvHome.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dtgvHome.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dtgvHome.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
        }

        private void dtgvHome_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
