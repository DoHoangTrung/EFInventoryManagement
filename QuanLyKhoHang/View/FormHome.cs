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
using QuanLyKhoHang.DAL;
using QuanLyKhoHang.DAO;
using QuanLyKhoHang.DAT;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using QuanLyKhoHang.View;

namespace QuanLyKhoHang
{
    public partial class FormHome : Form
    {
        private Color colorButtonCategoryWhenClicked;
        private ListViewColumnSorter lvwColumnSorter;

        public FormHome()
        {
            InitializeComponent();

        }

        private void LoadDateTimePicker()
        {
            dateTimePickerFromDate.Value = new DateTime(2021, 02, 01);
            dateTimePickerToDate.Value = DateTime.Now;
        }
        private void ReLoadListViewProduct()
        {
            listViewGeneral.Clear();

            //create listview
            listViewGeneral.Columns.Add(CreateListViewHeader("productID","ID sản phẩm"));
            listViewGeneral.Columns.Add(CreateListViewHeader("productName","Tên sản phẩm"));
            listViewGeneral.Columns.Add(CreateListViewHeader("unit","Đơn vị"));
            listViewGeneral.Columns.Add(CreateListViewHeader("type","Loại sản phẩm"));

            listViewGeneral.View = System.Windows.Forms.View.Details;
            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            List<ProductAndType> products = ProductDAO.Instance.GetListProductAndType();

            
            foreach (ProductAndType p in products)
            {
                ListViewItem lvwItem = new ListViewItem(p.ProductField.ID);
                lvwItem.SubItems.Add(p.ProductField.Name);
                lvwItem.SubItems.Add(p.ProductField.Unit);
                lvwItem.SubItems.Add(p.TypeField);

                listViewGeneral.Items.Add(lvwItem);
            }

            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ReLoadListViewSupplier()
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

            List<Supplier> supplies = SupplierDAO.Instance.GetListSupplier();
            foreach (var supplier in supplies)
            {
                ListViewItem lvwItem = new ListViewItem(supplier.ID);
                lvwItem.SubItems.Add(supplier.Name);
                lvwItem.SubItems.Add(supplier.Address);
                lvwItem.SubItems.Add(supplier.Phone);
                lvwItem.SubItems.Add(supplier.Email);

                listViewGeneral.Items.Add(lvwItem);
            }

            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewGeneral.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ReLoadListViewReceiveVoucher()
        {
            listViewGeneral.Clear();

            //create list view input voucher
            listViewGeneral.Columns.Add(CreateListViewHeader("IDReceiveVoucher","ID phieu nhap"));
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

            List<ReceiveVoucher> listVoucher = ReceiveVoucherDAO.Instance.GetListReceiveVoucher();
            listVoucher = listVoucher.OrderByDescending(o => o.Date).ToList();

            foreach (ReceiveVoucher voucher in listVoucher)
            {
                Supplier supplierInVoucher = voucher.Supplier;

                List<ReceiveVoucherInfo> voucherInfos = voucher.ReceiveVoucherInfoes.ToList();
                if(voucherInfos.Count == 0 )
                {
                    ListViewItem lvwItem = new ListViewItem(voucher.ID);
                    listViewGeneral.Items.Add(lvwItem);
                }
                foreach (var vouInfo in voucherInfos)
                {
                    Product productInVoucher = vouInfo.Product;

                    ListViewItem lvwItem = new ListViewItem(voucher.ID);
                    lvwItem.SubItems.Add(productInVoucher.ID);
                    lvwItem.SubItems.Add(productInVoucher.Name);
                    lvwItem.SubItems.Add(productInVoucher.Unit);
                    lvwItem.SubItems.Add(voucher.Date.ToString());
                    lvwItem.SubItems.Add(vouInfo.QuantityInput.ToString());
                    lvwItem.SubItems.Add(vouInfo.PriceInput.ToString());
                    lvwItem.SubItems.Add(vouInfo.Note);
                    lvwItem.SubItems.Add(supplierInVoucher.Name);
                    lvwItem.SubItems.Add(supplierInVoucher.Address);
                    lvwItem.SubItems.Add(supplierInVoucher.Phone);
                    lvwItem.SubItems.Add(supplierInVoucher.Email);
                    lvwItem.SubItems.Add(supplierInVoucher.ID);

                    listViewGeneral.Items.Add(lvwItem);
                }
                
            }
        }

        private void ReLoadListViewOutputVoucher()
        {
            listViewGeneral.Clear();

            listViewGeneral.Columns.Add(CreateListViewHeader("IDDeliveryVoucher", "ID phiếu xuất"));
            listViewGeneral.Columns.Add(CreateListViewHeader("NgayXuat"));
            listViewGeneral.Columns.Add(CreateListViewHeader("TenSanPham"));
            listViewGeneral.Columns.Add(CreateListViewHeader("DonVi"));
            listViewGeneral.Columns.Add(CreateListViewHeader("SoLuongXuat"));
            listViewGeneral.Columns.Add(CreateListViewHeader("GiaXuat"));
            listViewGeneral.Columns.Add(CreateListViewHeader("TenKhachHang"));
            listViewGeneral.Columns.Add(CreateListViewHeader("IDSanPham"));
            listViewGeneral.Columns.Add(CreateListViewHeader("IDKhachHang"));

            listViewGeneral.ListViewItemSorter = lvwColumnSorter;

            List<DeliveryVoucher> listVoucher = DeliveryVoucherDAO.Instance.GetDeliveryVouchersAllInfo();
            foreach (var voucher in listVoucher)
            {
                List<DeliveryVoucherInfo> voucherInfoes = voucher.DeliveryVoucherInfoes.ToList();

                //add value to dtgv genenral type delivery voucher 
                if (voucherInfoes.Count == 0)
                {
                    ListViewItem lvwItem = new ListViewItem(voucher.ID);
                    listViewGeneral.Items.Add(lvwItem);
                }
                else if (voucherInfoes.Count > 0)
                {
                    foreach (var info in voucherInfoes)
                    {
                        ListViewItem lvwItem = new ListViewItem(voucher.ID);
                        lvwItem.SubItems.Add(voucher.Date.ToString());
                        lvwItem.SubItems.Add(info.Product.Name);
                        lvwItem.SubItems.Add(info.Product.Unit);
                        lvwItem.SubItems.Add(info.Quantity.ToString());
                        lvwItem.SubItems.Add(info.PriceOutput.ToString());
                        lvwItem.SubItems.Add(voucher.Customer.Name);
                        lvwItem.SubItems.Add(info.Product.ID);
                        lvwItem.SubItems.Add(voucher.Customer.ID);

                        listViewGeneral.Items.Add(lvwItem);
                    }
                }
            }
        }

        private void ReLoadListViewCustomer()
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

            List<Customer> customers = CustomerDAO.Instance.GetListCustomer();
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

        #region EVENT!
        private void FormHome_Load(object sender, EventArgs e)
        {
            lvwColumnSorter = new ListViewColumnSorter();

            LoadDateTimePicker();

            colorButtonCategoryWhenClicked = Color.FromArgb(203, 225, 247);
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

        private void ChangeColorCategoryButtonWhenClicked(Button button)
        {
            buttonCategoryProduct.BackColor = default;
            buttonCategorySupplier.BackColor = default;
            buttonCategoryReceiveVoucher.BackColor = default;
            buttonCategoryDeliveryVoucher.BackColor = default;

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
        }

        private void TagThisCategoryButtomToActionButton(Button categoryButton)
        {
            buttonShow.Tag = categoryButton;
            buttonAdd.Tag = categoryButton;
            buttonUpdate.Tag = categoryButton;
            buttonDelete.Tag = categoryButton;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            Button categoryButtonTagged = buttonShow.Tag as Button;

            if (categoryButtonTagged == buttonCategoryProduct)
            {
                ReLoadListViewProduct();
            }

            if (categoryButtonTagged == buttonCategorySupplier)
            {
                ReLoadListViewSupplier();
            }

            if (categoryButtonTagged == buttonCategoryReceiveVoucher)
            {
                ReLoadListViewReceiveVoucher();
            }

            if (categoryButtonTagged == buttonCategoryDeliveryVoucher)
            {
                ReLoadListViewOutputVoucher();
            }


            if (categoryButtonTagged == buttonCategoryCustomer)
            {
                ReLoadListViewCustomer();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button categoryButtonTagged = buttonAdd.Tag as Button;

            if (categoryButtonTagged == buttonCategoryProduct)
            {
                FormAddProduct formAddGood = new FormAddProduct();
                formAddGood.ShowDialog();

                ReLoadListViewProduct();
            }

            if (categoryButtonTagged == buttonCategorySupplier)
            {
                FormAddSupplier formAddSupplier = new FormAddSupplier();
                formAddSupplier.ShowDialog();

                ReLoadListViewSupplier();
            }

            if (categoryButtonTagged == buttonCategoryReceiveVoucher)
            {
                FormAddReceiveVoucher fAddInputVoucher = new FormAddReceiveVoucher();
                fAddInputVoucher.ShowDialog();

                ReLoadListViewReceiveVoucher();
            }

            if (categoryButtonTagged == buttonCategoryDeliveryVoucher)
            {
            }


            if (categoryButtonTagged == buttonCategoryCustomer)
            {
                FormAddCustomer fAdd = new FormAddCustomer();
                fAdd.ShowDialog();

                ReLoadListViewCustomer();
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

                    ReLoadListViewProduct();
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

                    ReLoadListViewSupplier();
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
                    if(voucherTagged != null)
                    {
                        FormUpdateReceiveVoucher fUpdate = new FormUpdateReceiveVoucher();
                        fUpdate.receiveVoucherTagged = voucherTagged;
                        this.Hide();
                        fUpdate.ShowDialog();
                        this.Show();

                        ReLoadListViewReceiveVoucher();
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

                    ReLoadListViewCustomer();
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

                    ReLoadListViewProduct();
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

                    ReLoadListViewSupplier();
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

                        ReLoadListViewReceiveVoucher();

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
            }


            if (categoryButtonTagged == buttonCategoryCustomer)
            {
                Customer customerTagged = listViewGeneral.Tag as Customer;
                if (customerTagged != null)
                {
                    FormDeleteCustomer fDel = new FormDeleteCustomer();
                    fDel.customerSelectedFromListView = customerTagged;
                    fDel.ShowDialog();

                    ReLoadListViewSupplier();
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
                    supplier.Address= addr;
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
                    int indexColumnIDVoucher = listViewGeneral.Columns.IndexOfKey("IDDeliveryVoucher");
                    string idVoucher = lvwItem.SubItems[indexColumnIDVoucher].Text;

                    DeliveryVoucher deliveryVoucher = DeliveryVoucherDAO.Instance.GetDeliveryVouchersAllInfoByID(idVoucher);

                    listViewGeneral.Tag = deliveryVoucher;
                }
            }
        }
        #endregion
    }
}
