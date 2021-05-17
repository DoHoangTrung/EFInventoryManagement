
namespace QuanLyKhoHang
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.côngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDatetimePicker = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonCategoryCustomer = new System.Windows.Forms.Button();
            this.buttonCategorySupplier = new System.Windows.Forms.Button();
            this.labelToDate = new System.Windows.Forms.Label();
            this.buttonCategoryProduct = new System.Windows.Forms.Button();
            this.labelFromDate = new System.Windows.Forms.Label();
            this.buttonCategoryDeliveryVoucher = new System.Windows.Forms.Button();
            this.dateTimePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.buttonCategoryReceiveVoucher = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewGeneral = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCategoryReport = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.dtgvHome = new System.Windows.Forms.DataGridView();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.labelPageNumber = new System.Windows.Forms.Label();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.côngCụToolStripMenuItem,
            this.càiĐặtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1693, 31);
            this.menuStrip1.TabIndex = 2;
            // 
            // côngCụToolStripMenuItem
            // 
            this.côngCụToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.côngCụToolStripMenuItem.Name = "côngCụToolStripMenuItem";
            this.côngCụToolStripMenuItem.Size = new System.Drawing.Size(88, 27);
            this.côngCụToolStripMenuItem.Text = "Công cụ";
            // 
            // càiĐặtToolStripMenuItem
            // 
            this.càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
            this.càiĐặtToolStripMenuItem.Size = new System.Drawing.Size(78, 27);
            this.càiĐặtToolStripMenuItem.Text = "Cài đặt";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.checkBoxDatetimePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.buttonCategoryReport);
            this.panel1.Controls.Add(this.buttonCategoryCustomer);
            this.panel1.Controls.Add(this.buttonCategorySupplier);
            this.panel1.Controls.Add(this.labelToDate);
            this.panel1.Controls.Add(this.buttonCategoryProduct);
            this.panel1.Controls.Add(this.labelFromDate);
            this.panel1.Controls.Add(this.buttonCategoryDeliveryVoucher);
            this.panel1.Controls.Add(this.dateTimePickerToDate);
            this.panel1.Controls.Add(this.dateTimePickerFromDate);
            this.panel1.Controls.Add(this.buttonCategoryReceiveVoucher);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 792);
            this.panel1.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(143, 574);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(157, 22);
            this.numericUpDown2.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(143, 526);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(157, 22);
            this.numericUpDown1.TabIndex = 13;
            // 
            // checkBoxDatetimePicker
            // 
            this.checkBoxDatetimePicker.AutoSize = true;
            this.checkBoxDatetimePicker.Location = new System.Drawing.Point(76, 344);
            this.checkBoxDatetimePicker.Name = "checkBoxDatetimePicker";
            this.checkBoxDatetimePicker.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDatetimePicker.TabIndex = 12;
            this.checkBoxDatetimePicker.UseVisualStyleBackColor = true;
            this.checkBoxDatetimePicker.CheckedChanged += new System.EventHandler(this.checkBoxDatetimePicker_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 576);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "MAX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 526);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "MIN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Theo khoảng thời gian:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nhập từ tìm kiếm:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 491);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Đang cập nhật";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Khoàng giá:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(120, 664);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(144, 53);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(143, 293);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 22);
            this.textBoxSearch.TabIndex = 3;
            // 
            // buttonCategoryCustomer
            // 
            this.buttonCategoryCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryCustomer.Location = new System.Drawing.Point(24, 183);
            this.buttonCategoryCustomer.Name = "buttonCategoryCustomer";
            this.buttonCategoryCustomer.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryCustomer.TabIndex = 2;
            this.buttonCategoryCustomer.Text = "Khách hàng";
            this.buttonCategoryCustomer.UseVisualStyleBackColor = false;
            this.buttonCategoryCustomer.Click += new System.EventHandler(this.buttonCategoryCustomer_Click);
            // 
            // buttonCategorySupplier
            // 
            this.buttonCategorySupplier.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategorySupplier.Location = new System.Drawing.Point(24, 148);
            this.buttonCategorySupplier.Name = "buttonCategorySupplier";
            this.buttonCategorySupplier.Size = new System.Drawing.Size(353, 29);
            this.buttonCategorySupplier.TabIndex = 2;
            this.buttonCategorySupplier.Text = "Nhà cung cấp";
            this.buttonCategorySupplier.UseVisualStyleBackColor = false;
            this.buttonCategorySupplier.Click += new System.EventHandler(this.buttonCategorySupplier_Click);
            // 
            // labelToDate
            // 
            this.labelToDate.AutoSize = true;
            this.labelToDate.Location = new System.Drawing.Point(99, 419);
            this.labelToDate.Name = "labelToDate";
            this.labelToDate.Size = new System.Drawing.Size(38, 17);
            this.labelToDate.TabIndex = 9;
            this.labelToDate.Text = "Đến:";
            // 
            // buttonCategoryProduct
            // 
            this.buttonCategoryProduct.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryProduct.Location = new System.Drawing.Point(24, 113);
            this.buttonCategoryProduct.Name = "buttonCategoryProduct";
            this.buttonCategoryProduct.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryProduct.TabIndex = 2;
            this.buttonCategoryProduct.Text = "Hàng hóa";
            this.buttonCategoryProduct.UseVisualStyleBackColor = false;
            this.buttonCategoryProduct.Click += new System.EventHandler(this.buttonCategoryGoods_Click);
            // 
            // labelFromDate
            // 
            this.labelFromDate.AutoSize = true;
            this.labelFromDate.Location = new System.Drawing.Point(73, 375);
            this.labelFromDate.Name = "labelFromDate";
            this.labelFromDate.Size = new System.Drawing.Size(64, 17);
            this.labelFromDate.TabIndex = 10;
            this.labelFromDate.Text = "Từ ngày:";
            // 
            // buttonCategoryDeliveryVoucher
            // 
            this.buttonCategoryDeliveryVoucher.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryDeliveryVoucher.Location = new System.Drawing.Point(24, 78);
            this.buttonCategoryDeliveryVoucher.Name = "buttonCategoryDeliveryVoucher";
            this.buttonCategoryDeliveryVoucher.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryDeliveryVoucher.TabIndex = 2;
            this.buttonCategoryDeliveryVoucher.Text = "Phiếu xuất";
            this.buttonCategoryDeliveryVoucher.UseVisualStyleBackColor = false;
            this.buttonCategoryDeliveryVoucher.Click += new System.EventHandler(this.buttonCategoryOutputVoucher_Click);
            // 
            // dateTimePickerToDate
            // 
            this.dateTimePickerToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerToDate.Location = new System.Drawing.Point(143, 414);
            this.dateTimePickerToDate.Name = "dateTimePickerToDate";
            this.dateTimePickerToDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerToDate.TabIndex = 7;
            this.dateTimePickerToDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePickerFromDate
            // 
            this.dateTimePickerFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFromDate.Location = new System.Drawing.Point(143, 372);
            this.dateTimePickerFromDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFromDate.Name = "dateTimePickerFromDate";
            this.dateTimePickerFromDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFromDate.TabIndex = 8;
            this.dateTimePickerFromDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // buttonCategoryReceiveVoucher
            // 
            this.buttonCategoryReceiveVoucher.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryReceiveVoucher.Location = new System.Drawing.Point(24, 43);
            this.buttonCategoryReceiveVoucher.Name = "buttonCategoryReceiveVoucher";
            this.buttonCategoryReceiveVoucher.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryReceiveVoucher.TabIndex = 2;
            this.buttonCategoryReceiveVoucher.Text = "Phiếu nhập";
            this.buttonCategoryReceiveVoucher.UseVisualStyleBackColor = false;
            this.buttonCategoryReceiveVoucher.Click += new System.EventHandler(this.buttonCategoryInputVoucher_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.labelPageNumber);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.dtgvHome);
            this.panel2.Controls.Add(this.listViewGeneral);
            this.panel2.Location = new System.Drawing.Point(437, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1237, 704);
            this.panel2.TabIndex = 4;
            // 
            // listViewGeneral
            // 
            this.listViewGeneral.FullRowSelect = true;
            this.listViewGeneral.GridLines = true;
            this.listViewGeneral.HideSelection = false;
            this.listViewGeneral.Location = new System.Drawing.Point(3, 3);
            this.listViewGeneral.Name = "listViewGeneral";
            this.listViewGeneral.Size = new System.Drawing.Size(167, 61);
            this.listViewGeneral.TabIndex = 0;
            this.listViewGeneral.UseCompatibleStateImageBehavior = false;
            this.listViewGeneral.View = System.Windows.Forms.View.Details;
            this.listViewGeneral.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewInventory_ColumnClick);
            this.listViewGeneral.SelectedIndexChanged += new System.EventHandler(this.listViewGeneral_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonPrint);
            this.panel3.Controls.Add(this.buttonDelete);
            this.panel3.Controls.Add(this.buttonUpdate);
            this.panel3.Controls.Add(this.buttonAdd);
            this.panel3.Controls.Add(this.buttonShow);
            this.panel3.Location = new System.Drawing.Point(437, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(955, 85);
            this.panel3.TabIndex = 5;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(393, 43);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Xoa";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(265, 43);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 11;
            this.buttonUpdate.Text = "Sua";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(132, 43);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Them";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(3, 43);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(77, 23);
            this.buttonShow.TabIndex = 11;
            this.buttonShow.Text = "Xem";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 3000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // buttonCategoryReport
            // 
            this.buttonCategoryReport.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryReport.Location = new System.Drawing.Point(24, 218);
            this.buttonCategoryReport.Name = "buttonCategoryReport";
            this.buttonCategoryReport.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryReport.TabIndex = 2;
            this.buttonCategoryReport.Text = "Thống kê-Báo cáo";
            this.buttonCategoryReport.UseVisualStyleBackColor = false;
            this.buttonCategoryReport.Click += new System.EventHandler(this.buttonCategoryReport_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(863, 46);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 11;
            this.buttonPrint.Text = "In";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // dtgvHome
            // 
            this.dtgvHome.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dtgvHome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHome.Location = new System.Drawing.Point(3, 70);
            this.dtgvHome.Name = "dtgvHome";
            this.dtgvHome.RowHeadersWidth = 51;
            this.dtgvHome.RowTemplate.Height = 24;
            this.dtgvHome.Size = new System.Drawing.Size(1083, 495);
            this.dtgvHome.TabIndex = 1;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(425, 603);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(616, 603);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // labelPageNumber
            // 
            this.labelPageNumber.AutoSize = true;
            this.labelPageNumber.Location = new System.Drawing.Point(516, 605);
            this.labelPageNumber.Name = "labelPageNumber";
            this.labelPageNumber.Size = new System.Drawing.Size(40, 17);
            this.labelPageNumber.TabIndex = 3;
            this.labelPageNumber.Text = "page";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(QuanLyKhoHang.Entity.Product);
            // 
            // FormHome
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1693, 838);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mêm quản lý kho hàng";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem côngCụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem càiĐặtToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelToDate;
        private System.Windows.Forms.Label labelFromDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerToDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFromDate;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonCategoryReceiveVoucher;
        private System.Windows.Forms.Button buttonCategoryProduct;
        private System.Windows.Forms.Button buttonCategoryDeliveryVoucher;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCategorySupplier;
        private System.Windows.Forms.Button buttonCategoryCustomer;
        internal System.Windows.Forms.ListView listViewGeneral;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckBox checkBoxDatetimePicker;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCategoryReport;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.DataGridView dtgvHome;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Label labelPageNumber;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
    }
}