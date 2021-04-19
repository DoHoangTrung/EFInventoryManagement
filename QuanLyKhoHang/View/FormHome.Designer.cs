
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.côngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTest = new System.Windows.Forms.Label();
            this.buttonCategoryCustomer = new System.Windows.Forms.Button();
            this.buttonCategorySupplier = new System.Windows.Forms.Button();
            this.buttonCategoryProduct = new System.Windows.Forms.Button();
            this.buttonCategoryOutputVoucher = new System.Windows.Forms.Button();
            this.buttonCategoryInputVoucher = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewGeneral = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1301, 31);
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
            this.panel1.Controls.Add(this.labelTest);
            this.panel1.Controls.Add(this.buttonCategoryCustomer);
            this.panel1.Controls.Add(this.buttonCategorySupplier);
            this.panel1.Controls.Add(this.buttonCategoryProduct);
            this.panel1.Controls.Add(this.buttonCategoryOutputVoucher);
            this.panel1.Controls.Add(this.buttonCategoryInputVoucher);
            this.panel1.Location = new System.Drawing.Point(12, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 557);
            this.panel1.TabIndex = 3;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(204, 247);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(46, 17);
            this.labelTest.TabIndex = 3;
            this.labelTest.Text = "label3";
            // 
            // buttonCategoryCustomer
            // 
            this.buttonCategoryCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryCustomer.Location = new System.Drawing.Point(24, 162);
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
            this.buttonCategorySupplier.Location = new System.Drawing.Point(24, 127);
            this.buttonCategorySupplier.Name = "buttonCategorySupplier";
            this.buttonCategorySupplier.Size = new System.Drawing.Size(353, 29);
            this.buttonCategorySupplier.TabIndex = 2;
            this.buttonCategorySupplier.Text = "Nhà cung cấp";
            this.buttonCategorySupplier.UseVisualStyleBackColor = false;
            this.buttonCategorySupplier.Click += new System.EventHandler(this.buttonCategorySupplier_Click);
            // 
            // buttonCategoryProduct
            // 
            this.buttonCategoryProduct.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryProduct.Location = new System.Drawing.Point(24, 92);
            this.buttonCategoryProduct.Name = "buttonCategoryProduct";
            this.buttonCategoryProduct.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryProduct.TabIndex = 2;
            this.buttonCategoryProduct.Text = "Hàng hóa";
            this.buttonCategoryProduct.UseVisualStyleBackColor = false;
            this.buttonCategoryProduct.Click += new System.EventHandler(this.buttonCategoryGoods_Click);
            // 
            // buttonCategoryOutputVoucher
            // 
            this.buttonCategoryOutputVoucher.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryOutputVoucher.Location = new System.Drawing.Point(24, 57);
            this.buttonCategoryOutputVoucher.Name = "buttonCategoryOutputVoucher";
            this.buttonCategoryOutputVoucher.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryOutputVoucher.TabIndex = 2;
            this.buttonCategoryOutputVoucher.Text = "Phiếu xuất";
            this.buttonCategoryOutputVoucher.UseVisualStyleBackColor = false;
            this.buttonCategoryOutputVoucher.Click += new System.EventHandler(this.buttonCategoryOutputVoucher_Click);
            // 
            // buttonCategoryInputVoucher
            // 
            this.buttonCategoryInputVoucher.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCategoryInputVoucher.Location = new System.Drawing.Point(24, 22);
            this.buttonCategoryInputVoucher.Name = "buttonCategoryInputVoucher";
            this.buttonCategoryInputVoucher.Size = new System.Drawing.Size(353, 29);
            this.buttonCategoryInputVoucher.TabIndex = 2;
            this.buttonCategoryInputVoucher.Text = "Phiếu nhập";
            this.buttonCategoryInputVoucher.UseVisualStyleBackColor = false;
            this.buttonCategoryInputVoucher.Click += new System.EventHandler(this.buttonCategoryInputVoucher_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.listViewGeneral);
            this.panel2.Location = new System.Drawing.Point(437, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 560);
            this.panel2.TabIndex = 4;
            // 
            // listViewGeneral
            // 
            this.listViewGeneral.FullRowSelect = true;
            this.listViewGeneral.GridLines = true;
            this.listViewGeneral.HideSelection = false;
            this.listViewGeneral.Location = new System.Drawing.Point(3, 3);
            this.listViewGeneral.Name = "listViewGeneral";
            this.listViewGeneral.Size = new System.Drawing.Size(830, 554);
            this.listViewGeneral.TabIndex = 0;
            this.listViewGeneral.UseCompatibleStateImageBehavior = false;
            this.listViewGeneral.View = System.Windows.Forms.View.Details;
            this.listViewGeneral.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewInventory_ColumnClick);
            this.listViewGeneral.SelectedIndexChanged += new System.EventHandler(this.listViewGeneral_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonDelete);
            this.panel3.Controls.Add(this.buttonUpdate);
            this.panel3.Controls.Add(this.buttonAdd);
            this.panel3.Controls.Add(this.buttonShow);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dateTimePickerToDate);
            this.panel3.Controls.Add(this.dateTimePickerFromDate);
            this.panel3.Location = new System.Drawing.Point(12, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1270, 85);
            this.panel3.TabIndex = 5;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(732, 47);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Xoa";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(631, 47);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 11;
            this.buttonUpdate.Text = "Sua";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(530, 47);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Them";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(425, 47);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 11;
            this.buttonShow.Text = "Xem";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1018, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(969, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Từ ngày";
            // 
            // dateTimePickerToDate
            // 
            this.dateTimePickerToDate.Location = new System.Drawing.Point(1058, 48);
            this.dateTimePickerToDate.Name = "dateTimePickerToDate";
            this.dateTimePickerToDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerToDate.TabIndex = 7;
            this.dateTimePickerToDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePickerFromDate
            // 
            this.dateTimePickerFromDate.Location = new System.Drawing.Point(1058, 3);
            this.dateTimePickerFromDate.Name = "dateTimePickerFromDate";
            this.dateTimePickerFromDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFromDate.TabIndex = 8;
            this.dateTimePickerFromDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 690);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormHome";
            this.Text = "Phần mêm quản lý kho hàng";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerToDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFromDate;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonCategoryInputVoucher;
        private System.Windows.Forms.Button buttonCategoryProduct;
        private System.Windows.Forms.Button buttonCategoryOutputVoucher;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCategorySupplier;
        private System.Windows.Forms.Button buttonCategoryCustomer;
        internal System.Windows.Forms.ListView listViewGeneral;
        private System.Windows.Forms.Label labelTest;
    }
}