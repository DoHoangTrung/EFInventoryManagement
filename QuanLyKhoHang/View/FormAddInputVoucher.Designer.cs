
namespace QuanLyKhoHang
{
    partial class FormAddInputVoucher
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddGoodForm = new System.Windows.Forms.Button();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.numericUpDownOutputPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInputPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInputQuatity = new System.Windows.Forms.NumericUpDown();
            this.comboBoxProductName = new System.Windows.Forms.ComboBox();
            this.comboBoxProductID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDeleteGood = new System.Windows.Forms.Button();
            this.buttonAddGood = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddSupplierForm = new System.Windows.Forms.Button();
            this.comboBoxIDInputVoucher = new System.Windows.Forms.ComboBox();
            this.labelInputVoucherIDNotification = new System.Windows.Forms.Label();
            this.labelAddressSupplier = new System.Windows.Forms.Label();
            this.comboBoxNameSupplier = new System.Windows.Forms.ComboBox();
            this.comboBoxIDSupplier = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInputDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputQuatity)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxNote);
            this.panel2.Controls.Add(this.buttonAddGoodForm);
            this.panel2.Controls.Add(this.dataGridViewProduct);
            this.panel2.Controls.Add(this.numericUpDownOutputPrice);
            this.panel2.Controls.Add(this.numericUpDownInputPrice);
            this.panel2.Controls.Add(this.numericUpDownInputQuatity);
            this.panel2.Controls.Add(this.comboBoxProductName);
            this.panel2.Controls.Add(this.comboBoxProductID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.buttonDeleteGood);
            this.panel2.Controls.Add(this.buttonAddGood);
            this.panel2.Location = new System.Drawing.Point(32, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1333, 404);
            this.panel2.TabIndex = 21;
            // 
            // buttonAddGoodForm
            // 
            this.buttonAddGoodForm.Location = new System.Drawing.Point(415, 33);
            this.buttonAddGoodForm.Name = "buttonAddGoodForm";
            this.buttonAddGoodForm.Size = new System.Drawing.Size(75, 62);
            this.buttonAddGoodForm.TabIndex = 8;
            this.buttonAddGoodForm.Text = "Thêm sản phẩm";
            this.buttonAddGoodForm.UseVisualStyleBackColor = true;
            this.buttonAddGoodForm.Click += new System.EventHandler(this.buttonAddGoodForm_Click);
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(526, 21);
            this.dataGridViewProduct.MultiSelect = false;
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowHeadersWidth = 51;
            this.dataGridViewProduct.RowTemplate.Height = 24;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.Size = new System.Drawing.Size(779, 351);
            this.dataGridViewProduct.TabIndex = 30;
            // 
            // numericUpDownOutputPrice
            // 
            this.numericUpDownOutputPrice.Location = new System.Drawing.Point(217, 214);
            this.numericUpDownOutputPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownOutputPrice.Name = "numericUpDownOutputPrice";
            this.numericUpDownOutputPrice.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownOutputPrice.TabIndex = 11;
            // 
            // numericUpDownInputPrice
            // 
            this.numericUpDownInputPrice.Location = new System.Drawing.Point(217, 171);
            this.numericUpDownInputPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownInputPrice.Name = "numericUpDownInputPrice";
            this.numericUpDownInputPrice.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownInputPrice.TabIndex = 10;
            // 
            // numericUpDownInputQuatity
            // 
            this.numericUpDownInputQuatity.Location = new System.Drawing.Point(217, 124);
            this.numericUpDownInputQuatity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownInputQuatity.Name = "numericUpDownInputQuatity";
            this.numericUpDownInputQuatity.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownInputQuatity.TabIndex = 9;
            this.numericUpDownInputQuatity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxProductName
            // 
            this.comboBoxProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductName.FormattingEnabled = true;
            this.comboBoxProductName.Location = new System.Drawing.Point(151, 71);
            this.comboBoxProductName.Name = "comboBoxProductName";
            this.comboBoxProductName.Size = new System.Drawing.Size(242, 24);
            this.comboBoxProductName.TabIndex = 7;
            // 
            // comboBoxProductID
            // 
            this.comboBoxProductID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductID.FormattingEnabled = true;
            this.comboBoxProductID.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxProductID.Location = new System.Drawing.Point(151, 30);
            this.comboBoxProductID.Name = "comboBoxProductID";
            this.comboBoxProductID.Size = new System.Drawing.Size(242, 24);
            this.comboBoxProductID.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Giá xuất (nghìn đồng):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Giá nhập (nghìn đồng):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ghi chú:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID Sản phẩm";
            // 
            // buttonDeleteGood
            // 
            this.buttonDeleteGood.Location = new System.Drawing.Point(262, 349);
            this.buttonDeleteGood.Name = "buttonDeleteGood";
            this.buttonDeleteGood.Size = new System.Drawing.Size(131, 23);
            this.buttonDeleteGood.TabIndex = 13;
            this.buttonDeleteGood.Text = "Xóa sản  phẩm";
            this.buttonDeleteGood.UseVisualStyleBackColor = true;
            this.buttonDeleteGood.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // buttonAddGood
            // 
            this.buttonAddGood.Location = new System.Drawing.Point(79, 349);
            this.buttonAddGood.Name = "buttonAddGood";
            this.buttonAddGood.Size = new System.Drawing.Size(133, 23);
            this.buttonAddGood.TabIndex = 12;
            this.buttonAddGood.Text = "Thêm sản phẩm";
            this.buttonAddGood.UseVisualStyleBackColor = true;
            this.buttonAddGood.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(691, 713);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(266, 38);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Thoát";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(381, 713);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(266, 38);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "Xác nhận";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxIDInputVoucher);
            this.panel1.Controls.Add(this.labelInputVoucherIDNotification);
            this.panel1.Controls.Add(this.dateTimePickerInputDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(32, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 282);
            this.panel1.TabIndex = 22;
            // 
            // buttonAddSupplierForm
            // 
            this.buttonAddSupplierForm.Location = new System.Drawing.Point(243, 233);
            this.buttonAddSupplierForm.Name = "buttonAddSupplierForm";
            this.buttonAddSupplierForm.Size = new System.Drawing.Size(168, 23);
            this.buttonAddSupplierForm.TabIndex = 5;
            this.buttonAddSupplierForm.Text = "Thêm nhà cung cấp";
            this.buttonAddSupplierForm.UseVisualStyleBackColor = true;
            this.buttonAddSupplierForm.Click += new System.EventHandler(this.buttonAddSupplierForm_Click);
            // 
            // comboBoxIDInputVoucher
            // 
            this.comboBoxIDInputVoucher.FormattingEnabled = true;
            this.comboBoxIDInputVoucher.Location = new System.Drawing.Point(177, 83);
            this.comboBoxIDInputVoucher.Name = "comboBoxIDInputVoucher";
            this.comboBoxIDInputVoucher.Size = new System.Drawing.Size(157, 24);
            this.comboBoxIDInputVoucher.TabIndex = 1;
            this.comboBoxIDInputVoucher.TextChanged += new System.EventHandler(this.comboBoxIDInputVoucher_TextChanged_1);
            // 
            // labelInputVoucherIDNotification
            // 
            this.labelInputVoucherIDNotification.AutoSize = true;
            this.labelInputVoucherIDNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInputVoucherIDNotification.Location = new System.Drawing.Point(247, 42);
            this.labelInputVoucherIDNotification.Name = "labelInputVoucherIDNotification";
            this.labelInputVoucherIDNotification.Size = new System.Drawing.Size(389, 18);
            this.labelInputVoucherIDNotification.TabIndex = 28;
            this.labelInputVoucherIDNotification.Text = "ID không quá 30 kí tự\\nKhông trùng với ID trong danh sách";
            // 
            // labelAddressSupplier
            // 
            this.labelAddressSupplier.AutoSize = true;
            this.labelAddressSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddressSupplier.Location = new System.Drawing.Point(8, 178);
            this.labelAddressSupplier.Name = "labelAddressSupplier";
            this.labelAddressSupplier.Size = new System.Drawing.Size(53, 18);
            this.labelAddressSupplier.TabIndex = 29;
            this.labelAddressSupplier.Text = "Địa chỉ";
            // 
            // comboBoxNameSupplier
            // 
            this.comboBoxNameSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNameSupplier.FormattingEnabled = true;
            this.comboBoxNameSupplier.Location = new System.Drawing.Point(176, 121);
            this.comboBoxNameSupplier.Name = "comboBoxNameSupplier";
            this.comboBoxNameSupplier.Size = new System.Drawing.Size(453, 24);
            this.comboBoxNameSupplier.TabIndex = 4;
            // 
            // comboBoxIDSupplier
            // 
            this.comboBoxIDSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDSupplier.FormattingEnabled = true;
            this.comboBoxIDSupplier.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxIDSupplier.Location = new System.Drawing.Point(176, 80);
            this.comboBoxIDSupplier.Name = "comboBoxIDSupplier";
            this.comboBoxIDSupplier.Size = new System.Drawing.Size(256, 24);
            this.comboBoxIDSupplier.TabIndex = 3;
            this.comboBoxIDSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxIDSupplier_SelectedIndexChanged);
            // 
            // dateTimePickerInputDate
            // 
            this.dateTimePickerInputDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerInputDate.Location = new System.Drawing.Point(177, 126);
            this.dateTimePickerInputDate.Name = "dateTimePickerInputDate";
            this.dateTimePickerInputDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerInputDate.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tên nhà cung cấp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ngày nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "ID nhà cung cấp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID Phiếu nhập";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(217, 256);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(255, 22);
            this.textBoxNote.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonAddSupplierForm);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.comboBoxIDSupplier);
            this.panel3.Controls.Add(this.labelAddressSupplier);
            this.panel3.Controls.Add(this.comboBoxNameSupplier);
            this.panel3.Location = new System.Drawing.Point(681, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 280);
            this.panel3.TabIndex = 23;
            // 
            // FormAddInputVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 763);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormAddInputVoucher";
            this.Text = "Thêm phiếu nhập";
            this.Load += new System.EventHandler(this.FormAddInputVoucher_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputQuatity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownInputPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownInputQuatity;
        private System.Windows.Forms.ComboBox comboBoxProductName;
        private System.Windows.Forms.ComboBox comboBoxProductID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDeleteGood;
        private System.Windows.Forms.Button buttonAddGood;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxIDInputVoucher;
        private System.Windows.Forms.Label labelInputVoucherIDNotification;
        private System.Windows.Forms.Label labelAddressSupplier;
        private System.Windows.Forms.ComboBox comboBoxNameSupplier;
        private System.Windows.Forms.ComboBox comboBoxIDSupplier;
        private System.Windows.Forms.DateTimePicker dateTimePickerInputDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.Button buttonAddGoodForm;
        private System.Windows.Forms.Button buttonAddSupplierForm;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Panel panel3;
    }
}