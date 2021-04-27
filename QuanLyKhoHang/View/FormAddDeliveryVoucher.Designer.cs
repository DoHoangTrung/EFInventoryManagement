﻿namespace QuanLyKhoHang.View
{
    partial class FormAddDeliveryVoucher
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxIDCustomer = new System.Windows.Forms.ComboBox();
            this.labelPhoneCustomer = new System.Windows.Forms.Label();
            this.comboBoxNameCustomer = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.comboBoxIDDeliveryVoucher = new System.Windows.Forms.ComboBox();
            this.labelInputVoucherIDNotification = new System.Windows.Forms.Label();
            this.dateTimePickerDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewDeliveryInfo = new System.Windows.Forms.DataGridView();
            this.numericUpDownDeliveryQuantity = new System.Windows.Forms.NumericUpDown();
            this.comboBoxProductName = new System.Windows.Forms.ComboBox();
            this.comboBoxProductID = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelInventoryNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelReceivePrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownDeliveryPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveryInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeliveryQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeliveryPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonAddCustomer);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.comboBoxIDCustomer);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.labelPhoneCustomer);
            this.panel3.Controls.Add(this.comboBoxNameCustomer);
            this.panel3.Location = new System.Drawing.Point(673, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 280);
            this.panel3.TabIndex = 28;
            // 
            // buttonAddCustomer
            // 
            this.buttonAddCustomer.Location = new System.Drawing.Point(243, 233);
            this.buttonAddCustomer.Name = "buttonAddCustomer";
            this.buttonAddCustomer.Size = new System.Drawing.Size(168, 23);
            this.buttonAddCustomer.TabIndex = 5;
            this.buttonAddCustomer.Text = "Thêm khách hàng";
            this.buttonAddCustomer.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "ID khách hàng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tên khách hàng";
            // 
            // comboBoxIDCustomer
            // 
            this.comboBoxIDCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDCustomer.FormattingEnabled = true;
            this.comboBoxIDCustomer.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxIDCustomer.Location = new System.Drawing.Point(176, 80);
            this.comboBoxIDCustomer.Name = "comboBoxIDCustomer";
            this.comboBoxIDCustomer.Size = new System.Drawing.Size(198, 24);
            this.comboBoxIDCustomer.TabIndex = 3;
            this.comboBoxIDCustomer.SelectedValueChanged += new System.EventHandler(this.comboBoxIDCustomer_SelectedValueChanged);
            // 
            // labelPhoneCustomer
            // 
            this.labelPhoneCustomer.AutoSize = true;
            this.labelPhoneCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhoneCustomer.Location = new System.Drawing.Point(173, 180);
            this.labelPhoneCustomer.Name = "labelPhoneCustomer";
            this.labelPhoneCustomer.Size = new System.Drawing.Size(98, 18);
            this.labelPhoneCustomer.TabIndex = 29;
            this.labelPhoneCustomer.Text = "Số điện thoại:";
            // 
            // comboBoxNameCustomer
            // 
            this.comboBoxNameCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNameCustomer.FormattingEnabled = true;
            this.comboBoxNameCustomer.Location = new System.Drawing.Point(176, 121);
            this.comboBoxNameCustomer.Name = "comboBoxNameCustomer";
            this.comboBoxNameCustomer.Size = new System.Drawing.Size(453, 24);
            this.comboBoxNameCustomer.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxNote);
            this.panel1.Controls.Add(this.comboBoxIDDeliveryVoucher);
            this.panel1.Controls.Add(this.labelInputVoucherIDNotification);
            this.panel1.Controls.Add(this.dateTimePickerDeliveryDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 282);
            this.panel1.TabIndex = 27;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(177, 180);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(338, 22);
            this.textBoxNote.TabIndex = 31;
            // 
            // comboBoxIDDeliveryVoucher
            // 
            this.comboBoxIDDeliveryVoucher.FormattingEnabled = true;
            this.comboBoxIDDeliveryVoucher.Location = new System.Drawing.Point(177, 83);
            this.comboBoxIDDeliveryVoucher.Name = "comboBoxIDDeliveryVoucher";
            this.comboBoxIDDeliveryVoucher.Size = new System.Drawing.Size(157, 24);
            this.comboBoxIDDeliveryVoucher.TabIndex = 1;
            // 
            // labelInputVoucherIDNotification
            // 
            this.labelInputVoucherIDNotification.AutoSize = true;
            this.labelInputVoucherIDNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInputVoucherIDNotification.Location = new System.Drawing.Point(259, 42);
            this.labelInputVoucherIDNotification.Name = "labelInputVoucherIDNotification";
            this.labelInputVoucherIDNotification.Size = new System.Drawing.Size(389, 18);
            this.labelInputVoucherIDNotification.TabIndex = 28;
            this.labelInputVoucherIDNotification.Text = "ID không quá 30 kí tự\\nKhông trùng với ID trong danh sách";
            // 
            // dateTimePickerDeliveryDate
            // 
            this.dateTimePickerDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerDeliveryDate.Location = new System.Drawing.Point(177, 126);
            this.dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            this.dateTimePickerDeliveryDate.Size = new System.Drawing.Size(338, 22);
            this.dateTimePickerDeliveryDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ngày xuất";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID Phiếu xuất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ghi chú:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewDeliveryInfo);
            this.panel2.Controls.Add(this.numericUpDownDeliveryPrice);
            this.panel2.Controls.Add(this.numericUpDownDeliveryQuantity);
            this.panel2.Controls.Add(this.comboBoxProductName);
            this.panel2.Controls.Add(this.comboBoxProductID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.labelReceivePrice);
            this.panel2.Controls.Add(this.labelInventoryNumber);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.buttonDeleteProduct);
            this.panel2.Controls.Add(this.buttonAddProduct);
            this.panel2.Location = new System.Drawing.Point(4, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1353, 404);
            this.panel2.TabIndex = 26;
            // 
            // dataGridViewDeliveryInfo
            // 
            this.dataGridViewDeliveryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeliveryInfo.Location = new System.Drawing.Point(445, 12);
            this.dataGridViewDeliveryInfo.MultiSelect = false;
            this.dataGridViewDeliveryInfo.Name = "dataGridViewDeliveryInfo";
            this.dataGridViewDeliveryInfo.ReadOnly = true;
            this.dataGridViewDeliveryInfo.RowHeadersWidth = 51;
            this.dataGridViewDeliveryInfo.RowTemplate.Height = 24;
            this.dataGridViewDeliveryInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDeliveryInfo.Size = new System.Drawing.Size(900, 380);
            this.dataGridViewDeliveryInfo.TabIndex = 30;
            // 
            // numericUpDownDeliveryQuantity
            // 
            this.numericUpDownDeliveryQuantity.Location = new System.Drawing.Point(151, 187);
            this.numericUpDownDeliveryQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownDeliveryQuantity.Name = "numericUpDownDeliveryQuantity";
            this.numericUpDownDeliveryQuantity.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownDeliveryQuantity.TabIndex = 9;
            this.numericUpDownDeliveryQuantity.Value = new decimal(new int[] {
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "Số lượng xuất:";
            // 
            // labelInventoryNumber
            // 
            this.labelInventoryNumber.AutoSize = true;
            this.labelInventoryNumber.Location = new System.Drawing.Point(18, 115);
            this.labelInventoryNumber.Name = "labelInventoryNumber";
            this.labelInventoryNumber.Size = new System.Drawing.Size(49, 17);
            this.labelInventoryNumber.TabIndex = 11;
            this.labelInventoryNumber.Text = "Số dư:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID Sản phẩm";
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(262, 288);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(131, 31);
            this.buttonDeleteProduct.TabIndex = 13;
            this.buttonDeleteProduct.Text = "Xóa sản  phẩm";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(79, 288);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(133, 31);
            this.buttonAddProduct.TabIndex = 12;
            this.buttonAddProduct.Text = "Thêm sản phẩm";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(684, 711);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(266, 38);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Thoát";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(374, 711);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(266, 38);
            this.buttonOK.TabIndex = 24;
            this.buttonOK.Text = "Xác nhận";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelReceivePrice
            // 
            this.labelReceivePrice.AutoSize = true;
            this.labelReceivePrice.Location = new System.Drawing.Point(15, 153);
            this.labelReceivePrice.Name = "labelReceivePrice";
            this.labelReceivePrice.Size = new System.Drawing.Size(142, 17);
            this.labelReceivePrice.TabIndex = 11;
            this.labelReceivePrice.Text = "Giá nhập trung bình: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Giá xuất:";
            // 
            // numericUpDownDeliveryPrice
            // 
            this.numericUpDownDeliveryPrice.Location = new System.Drawing.Point(151, 234);
            this.numericUpDownDeliveryPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownDeliveryPrice.Name = "numericUpDownDeliveryPrice";
            this.numericUpDownDeliveryPrice.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownDeliveryPrice.TabIndex = 9;
            this.numericUpDownDeliveryPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Số điện thoại:";
            // 
            // FormAddDeliveryVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 747);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormAddDeliveryVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddDeliveryVoucher";
            this.Load += new System.EventHandler(this.FormAddDeliveryVoucher_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveryInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeliveryQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeliveryPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonAddCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxIDCustomer;
        private System.Windows.Forms.Label labelPhoneCustomer;
        private System.Windows.Forms.ComboBox comboBoxNameCustomer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxIDDeliveryVoucher;
        private System.Windows.Forms.Label labelInputVoucherIDNotification;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.DataGridView dataGridViewDeliveryInfo;
        private System.Windows.Forms.NumericUpDown numericUpDownDeliveryQuantity;
        private System.Windows.Forms.ComboBox comboBoxProductName;
        private System.Windows.Forms.ComboBox comboBoxProductID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelInventoryNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numericUpDownDeliveryPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelReceivePrice;
        private System.Windows.Forms.Label label4;
    }
}