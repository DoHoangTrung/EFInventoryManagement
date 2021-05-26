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
using QuanLyKhoHang.Helper;
using QuanLyKhoHang.View;

namespace QuanLyKhoHang
{

    public partial class FormHome : Form
    {
        //Fields

        private Button currentBtnCategory;
        private Random random;
        private int tempIndex;

        private Color colorButtonCategoryWhenClicked;
        private ListViewColumnSorter lvwColumnSorter;

        object currentPagedList;

        //Constructor
        public FormHome()
        {
            InitializeComponent();
            random = new Random();
        }

        //Methods

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);

            //if selected color == previous color, we random again
            while(tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }

            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActiveButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentBtnCategory != (Button)btnSender)
                {
                    DisableButton();
                    currentBtnCategory = (Button)btnSender;
                    Color color = SelectThemeColor();
                    currentBtnCategory.BackColor = color;
                    currentBtnCategory.ForeColor = Color.White;
                    currentBtnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color,-0.3);
                    panelTitle.BackColor = color;
                    lbTitle.Text = currentBtnCategory.Text;
                    
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control btn in panelMenu.Controls)
            {
                if(btn.GetType() == typeof(Button))
                {
                    btn.BackColor = Color.FromArgb(51, 51, 76);
                    btn.ForeColor = Color.White;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }



        #region category button

        private void buttonCategoryGoods_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryProduct);
            ActiveButton(sender);
        }

        private void buttonCategorySupplier_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategorySupplier);
            ActiveButton(sender);
        }

        private void buttonCategoryInputVoucher_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryReceiveVoucher);
            ActiveButton(sender);
        }

        private void buttonCategoryOutputVoucher_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryDeliveryVoucher);
            ActiveButton(sender);
        }

        private void buttonCategoryCustomer_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryCustomer);
            ActiveButton(sender);
        }

        private void buttonCategoryReport_Click(object sender, EventArgs e)
        {
            TagThisCategoryButtomToActionButton(buttonCategoryReport);
            ActiveButton(sender);
        }

        private void TagThisCategoryButtomToActionButton(Button categoryButton)
        {
            buttonAdd.Tag = categoryButton;
            buttonUpdate.Tag = categoryButton;
            buttonDelete.Tag = categoryButton;
            buttonShow.Tag = categoryButton;
            buttonPrint.Tag = categoryButton;
        }

        #endregion

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


        private void LoadDtgvProduct(int pageNum = 1, int pageSize = Const.pageSize)
        {

            SearchModel searchModel = GetSearchModel();
            var data = ProductDAO.Instance.GetList(searchModel);


            var products = data.ToPagedList(pageNum, pageSize);

            bool b = products.HasNextPage;
            bool bc = products.HasPreviousPage;
            var a = products.ToList();
            //load paged list button
            btnPrevious.Enabled = products.HasPreviousPage;
            btnNext.Enabled = products.HasNextPage;
            labelPageNumber.Text = $"Page {products.PageNumber}/{products.PageCount}";

            //load dtgvHome
            dtgvHome.DataSource = new SortableBindingList<ProductDTO>(products.ToList());
            dtgvHome.Columns["ID"].Visible = false;
            dtgvHome.Columns["TypeID"].Visible = false;

            currentPagedList = products;
        }


        private void LoadDtgvSupplier(int pageNumber = 1, int pageSize = Const.pageSize)
        {
            SearchModel searchModel = GetSearchModel();
            var data = SupplierDAO.Instance.GetList(searchModel);

            var suppliers = data.ToPagedList(pageNumber, pageSize);

            dtgvHome.DataSource = new SortableBindingList<Supplier>(suppliers.ToList());

            //load paged list button
            btnPrevious.Enabled = suppliers.HasPreviousPage;
            btnNext.Enabled = suppliers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{suppliers.PageCount}";


            currentPagedList = suppliers;
        }


        private void LoadDtgvCustomer(int pageNumber = 1, int pageSize = Const.pageSize)
        {
            SearchModel searchModel = GetSearchModel();
            var data = CustomerDAO.Instance.GetList(searchModel);

            var customers = data.ToPagedList(pageNumber, pageSize);

            dtgvHome.DataSource = new SortableBindingList<Customer>(customers.ToList());

            //load paged list button
            btnPrevious.Enabled = customers.HasPreviousPage;
            btnNext.Enabled = customers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{customers.PageCount}";

            currentPagedList = customers;
        }


        private void LoadDtgvReceiveVoucher(int pageNumber = 1, int pageSize = Const.pageSize)
        {
            SearchModel searchModel = GetSearchModel();

            var data = ReceiveVoucherDAO.Instance.GetList(searchModel);
            var vouchers = data.ToPagedList(pageNumber, pageSize);

            dtgvHome.DataSource = new SortableBindingList<ReceiveVoucherDTO>(vouchers.ToList());

            dtgvHome.Columns["ProductID"].Visible = false;
            dtgvHome.Columns["QuantityOutput"].Visible = false;
            dtgvHome.Columns["SupplierID"].Visible = false;

            //load paged list button
            btnPrevious.Enabled = vouchers.HasPreviousPage;
            btnNext.Enabled = vouchers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{vouchers.PageCount}";


            currentPagedList = vouchers;
        }


        private void LoadDtgvDeliveryVoucher(int pageNumber = 1, int pageSize = Const.pageSize)
        {

            SearchModel searchModel = GetSearchModel();

            DeliveryVoucherViewDAO dao = new DeliveryVoucherViewDAO();
            var data = dao.GetList(searchModel);
            var vouchers = data.ToPagedList(pageNumber, pageSize);

            dtgvHome.DataSource = new SortableBindingList<DeliveryVoucherView>(vouchers.ToList());

            //load paged list button
            btnPrevious.Enabled = vouchers.HasPreviousPage;
            btnNext.Enabled = vouchers.HasNextPage;
            labelPageNumber.Text = $"Page {pageNumber}/{vouchers.PageCount}";


            currentPagedList = vouchers;
        }


        private void LoadDtgvReport(int pageNumber = 1, int pageSize = Const.pageSize)
        {
            if (checkBoxDatetimePicker.Checked)
            {
                SearchModel searchModel = GetSearchModel();

                ReportDAO dao = new ReportDAO();
                var data = dao.GetList(searchModel);
                var reports = data.ToPagedList(pageNumber, pageSize);

                dtgvHome.DataSource = new SortableBindingList<ReportDTO>(reports.ToList());

                //load paged list button
                btnPrevious.Enabled = reports.HasPreviousPage;
                btnNext.Enabled = reports.HasNextPage;
                labelPageNumber.Text = $"Page {pageNumber}/{reports.PageCount}";

                currentPagedList = reports;
            }
            else
            {
                MessageBox.Show("Bạn hãy xem báo cáo theo khoảng thời gian");
            }
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

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //ReLoadListViewInventory();
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

                LoadDtgvDeliveryVoucher();
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
                ProductDTO selectedProduct = rowSelectedObj as ProductDTO;
                if (selectedProduct != null)
                {
                    formUpdate.selectedProductFromDtgv = selectedProduct;
                    formUpdate.ShowDialog();

                    //reload dtgv
                    LoadDtgvProduct();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm");
                }
            }

            if (categoryButtonClicked == buttonCategorySupplier)
            {
                Supplier supplierSelected = rowSelectedObj as Supplier;
                if (supplierSelected != null)
                {
                    FormUpdateSupplier fUpSupp = new FormUpdateSupplier();
                    fUpSupp.supplierSelectedFromDtgv = supplierSelected;
                    fUpSupp.ShowDialog();

                    LoadDtgvSupplier();
                }
                else
                {
                    MessageBox.Show("Hãy click vào nhà cung cấp bạn muốn");
                }
            }

            if (categoryButtonClicked == buttonCategoryCustomer)
            {
                Customer customerSelected = rowSelectedObj as Customer;
                if (customerSelected != null)
                {
                    FormUpdateCustomer f = new FormUpdateCustomer();
                    f.customerSelectedFromListView = customerSelected;
                    f.ShowDialog();

                    LoadDtgvCustomer();
                }
                else
                {
                    MessageBox.Show("Hãy click vào khách hàng bạn muốn");
                }
            }

            if (categoryButtonClicked == buttonCategoryReceiveVoucher)
            {
                ReceiveVoucherDTO voucherInfoSelected = rowSelectedObj as ReceiveVoucherDTO;
                if (voucherInfoSelected != null)
                {
                    string idVoucher = voucherInfoSelected.ReceiveVoucherID;

                    ReceiveVoucher voucher = ReceiveVoucherDAO.Instance.GetByID(idVoucher);

                    FormUpdateReceiveVoucher fUpdate = new FormUpdateReceiveVoucher(voucher);
                    this.Hide();
                    fUpdate.ShowDialog();
                    this.Show();

                    LoadDtgvReceiveVoucher();
                }
                else
                {
                    MessageBox.Show("Hãy click  vào hóa đơn bạn muốn sửa.");
                }
            }

            if (categoryButtonClicked == buttonCategoryDeliveryVoucher)
            {

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Button categoryButtonTagged = buttonDelete.Tag as Button;

            if (categoryButtonTagged == buttonCategoryProduct)
            {
                ProductDTO productSelected = rowSelectedObj as ProductDTO;
                if (productSelected != null)
                {
                    FormDeleteProduct formDelete = new FormDeleteProduct();
                    formDelete.productSelected = productSelected;
                    formDelete.ShowDialog();

                    LoadDtgvProduct();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm");
                }

            }

            if (categoryButtonTagged == buttonCategorySupplier)
            {
                Supplier supplierSelected = rowSelectedObj as Supplier;
                if (supplierSelected != null)
                {
                    FormDeleteSupplier fDel = new FormDeleteSupplier();
                    fDel.supplierSelectedFromDtgv = supplierSelected;
                    fDel.ShowDialog();

                    LoadDtgvSupplier();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn nhà cung cấp");
                }
            }

            if (categoryButtonTagged == buttonCategoryCustomer)
            {
                Customer customerSelected = rowSelectedObj as Customer;
                if (customerSelected != null)
                {
                    FormDeleteCustomer fDel = new FormDeleteCustomer();
                    fDel.customerSelectedFromListView = customerSelected;
                    fDel.ShowDialog();

                    LoadDtgvCustomer();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng");
                }
            }

            if (categoryButtonTagged == buttonCategoryReceiveVoucher)
            {
                ReceiveVoucherDTO voucherInfoSelected = rowSelectedObj as ReceiveVoucherDTO;
                if (voucherInfoSelected != null)
                {
                    if (ReceiveVoucherDAO.Instance.HaveTheProductBeenSold(voucherInfoSelected.ReceiveVoucherID))
                    {
                        MessageBox.Show("Phiếu nhập hàng này đã có sản phẩm được xuất kho. Bạn không thể xóa");
                    }
                    else
                    {
                        ReceiveVoucher voucher = ReceiveVoucherDAO.Instance.GetByID(voucherInfoSelected.ReceiveVoucherID);

                        FormDeleteReceiveVoucher f = new FormDeleteReceiveVoucher();
                        f.voucherSelected = voucher;
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
                var voucher = rowSelectedObj as DeliveryVoucherView;
                if (voucher != null)
                {
                    string deliveryVoucherID = voucher.VoucherID.ToString();

                    FormDeleteDeliveryVoucher f = new FormDeleteDeliveryVoucher();
                    f.DeliveryVoucherID = deliveryVoucherID;
                    f.ShowDialog();

                    LoadDtgvDeliveryVoucher();
                }
                else
                {
                    MessageBox.Show("Hãy chọn phiếu xuất bạn muốn xóa");
                }
            }
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyWord = textBoxSearch.Text;

            Button category = buttonShow.Tag as Button;

            if (category == null)
            {
                MessageBox.Show("Bạn hãy chọn mục muốn tìm kiếm");
            }

            if (category == buttonCategoryProduct)
            {
                LoadDtgvProduct();
            }

            if (category == buttonCategoryCustomer)
            {
                LoadDtgvCustomer();
            }

            if (category == buttonCategorySupplier)
            {
                LoadDtgvSupplier();
            }

            if (category == buttonCategoryReceiveVoucher)
            {
                LoadDtgvReceiveVoucher();
            }

            if (category == buttonCategoryDeliveryVoucher)
            {
                LoadDtgvDeliveryVoucher();
            }

            if (category == buttonCategoryReport)
            {
                LoadDtgvReport();
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

            /*if (categoryButtonTagged == buttonCategoryReport && listViewGeneral.Columns.Count > 0)
            {
                FormReportPrint f = new FormReportPrint(showingDtgv as List<ReportDTO>);
                f.Show();
            }*/
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            var products = currentPagedList as IPagedList<ProductDTO>;
            if (products != null && products.HasPreviousPage)
            {
                LoadDtgvProduct(products.PageNumber - 1, products.PageSize);
            }


            var suppliers = currentPagedList as IPagedList<Supplier>;
            if (suppliers != null && suppliers.HasPreviousPage)
            {
                LoadDtgvSupplier(suppliers.PageNumber - 1, suppliers.PageSize);
            }

            var customers = currentPagedList as IPagedList<Customer>;
            if (customers != null && customers.HasPreviousPage)
            {
                LoadDtgvCustomer(customers.PageNumber - 1, customers.PageSize);
            }

            var reports = currentPagedList as IPagedList<ReportDTO>;
            if (reports != null && reports.HasPreviousPage)
            {
                LoadDtgvReport(reports.PageNumber - 1, reports.PageSize);
            }

            var reVouchers = currentPagedList as IPagedList<ReceiveVoucherDTO>;
            if (reVouchers != null && reVouchers.HasPreviousPage)
            {
                LoadDtgvReceiveVoucher(reVouchers.PageNumber - 1, reVouchers.PageSize);
            }

            var deVouchers = currentPagedList as IPagedList<DeliveryVoucherView>;
            if (deVouchers != null && deVouchers.HasPreviousPage)
            {
                LoadDtgvReceiveVoucher(deVouchers.PageNumber - 1, deVouchers.PageSize);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var products = currentPagedList as IPagedList<ProductDTO>;
            if (products != null && products.HasNextPage)
            {
                LoadDtgvProduct(products.PageNumber + 1, products.PageSize);
            }


            var suppliers = currentPagedList as IPagedList<Supplier>;
            if (suppliers != null && suppliers.HasNextPage)
            {
                LoadDtgvSupplier(suppliers.PageNumber + 1, suppliers.PageSize);
            }

            var customers = currentPagedList as IPagedList<Customer>;
            if (customers != null && customers.HasNextPage)
            {
                LoadDtgvCustomer(customers.PageNumber+1,customers.PageSize);
            }

            var reports = currentPagedList as IPagedList<ReportDTO>;
            if (reports != null && reports.HasNextPage)
            {
                LoadDtgvReport(reports.PageNumber + 1, reports.PageSize);
            }

            var reVouchers = currentPagedList as IPagedList<ReceiveVoucherDTO>;
            if (reVouchers != null && reVouchers.HasNextPage)
            {
                LoadDtgvReceiveVoucher(reVouchers.PageNumber + 1, reVouchers.PageSize);
            }

            var deVouchers = currentPagedList as IPagedList<DeliveryVoucherView>;
            if (deVouchers != null && deVouchers.HasNextPage)
            {
                LoadDtgvReceiveVoucher(deVouchers.PageNumber + 1, deVouchers.PageSize);
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


        object rowSelectedObj;

        private void dtgvHome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Button btnCatgory = buttonShow.Tag as Button;


                if (btnCatgory == buttonCategoryProduct)
                {
                    var product = dtgvHome.Rows[e.RowIndex].DataBoundItem as ProductDTO;
                    rowSelectedObj = product;
                }

                if (btnCatgory == buttonCategorySupplier)
                {
                    var supplier = dtgvHome.Rows[e.RowIndex].DataBoundItem as Supplier;
                    rowSelectedObj = supplier;
                }

                if (btnCatgory == buttonCategoryCustomer)
                {
                    var customer = dtgvHome.Rows[e.RowIndex].DataBoundItem as Customer;
                    rowSelectedObj = customer;
                }

                if (btnCatgory == buttonCategoryReceiveVoucher)
                {
                    var reVoucher = dtgvHome.Rows[e.RowIndex].DataBoundItem as ReceiveVoucherDTO;
                    rowSelectedObj = reVoucher;
                }

                if (btnCatgory == buttonCategoryDeliveryVoucher)
                {
                    var deVoucher = dtgvHome.Rows[e.RowIndex].DataBoundItem as DeliveryVoucherView;
                    rowSelectedObj = deVoucher;
                }
            }
        }

        SearchModel GetSearchModel()
        {
            SearchModel searchModel = new SearchModel();

            string keyWords = textBoxSearch.Text.Format();
            if (!string.IsNullOrEmpty(keyWords))
            {
                searchModel.KeyWords = keyWords;
            }

            if (checkBoxDatetimePicker.Checked)
            {
                searchModel.FromDate = dtpickerFromDate.Value; ;
                searchModel.ToDate = dtpickerToDate.Value;
            }

            int min = (int)numUpDownMin.Value;
            int max = (int)numUpDownMax.Value;

            if (max > min)
            {
                searchModel.MinValue = min;
                searchModel.MaxValue = max;
            }

            return searchModel;
        }

      
    }
}
