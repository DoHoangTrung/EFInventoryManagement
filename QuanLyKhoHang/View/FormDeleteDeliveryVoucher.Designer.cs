
namespace QuanLyKhoHang.View
{
    partial class FormDeleteDeliveryVoucher
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
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.labelInputVoucherIDNotification = new System.Windows.Forms.Label();
            this.dateTimePickerDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewDeliveryInfo = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxDeliveryVoucherID = new System.Windows.Forms.TextBox();
            this.textBoxCustomerID = new System.Windows.Forms.TextBox();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveryInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.textBoxCustomerName);
            this.panel3.Controls.Add(this.textBoxCustomerID);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.labelPhone);
            this.panel3.Location = new System.Drawing.Point(691, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 280);
            this.panel3.TabIndex = 33;
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
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.Location = new System.Drawing.Point(173, 180);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(103, 18);
            this.labelPhone.TabIndex = 29;
            this.labelPhone.Text = "Chưa cập nhật";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxDeliveryVoucherID);
            this.panel1.Controls.Add(this.textBoxNote);
            this.panel1.Controls.Add(this.labelInputVoucherIDNotification);
            this.panel1.Controls.Add(this.dateTimePickerDeliveryDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 282);
            this.panel1.TabIndex = 32;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(177, 180);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.ReadOnly = true;
            this.textBoxNote.Size = new System.Drawing.Size(338, 22);
            this.textBoxNote.TabIndex = 31;
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
            this.dateTimePickerDeliveryDate.Enabled = false;
            this.dateTimePickerDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerDeliveryDate.Location = new System.Drawing.Point(177, 126);
            this.dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            this.dateTimePickerDeliveryDate.Size = new System.Drawing.Size(213, 22);
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
            this.panel2.Location = new System.Drawing.Point(22, 298);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1353, 404);
            this.panel2.TabIndex = 31;
            // 
            // dataGridViewDeliveryInfo
            // 
            this.dataGridViewDeliveryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeliveryInfo.Location = new System.Drawing.Point(16, 13);
            this.dataGridViewDeliveryInfo.MultiSelect = false;
            this.dataGridViewDeliveryInfo.Name = "dataGridViewDeliveryInfo";
            this.dataGridViewDeliveryInfo.ReadOnly = true;
            this.dataGridViewDeliveryInfo.RowHeadersWidth = 51;
            this.dataGridViewDeliveryInfo.RowTemplate.Height = 24;
            this.dataGridViewDeliveryInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDeliveryInfo.Size = new System.Drawing.Size(1324, 350);
            this.dataGridViewDeliveryInfo.TabIndex = 30;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(702, 723);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(266, 38);
            this.buttonCancel.TabIndex = 30;
            this.buttonCancel.Text = "Thoát";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(392, 723);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(266, 38);
            this.buttonOK.TabIndex = 29;
            this.buttonOK.Text = "Đồng ý";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxDeliveryVoucherID
            // 
            this.textBoxDeliveryVoucherID.Location = new System.Drawing.Point(177, 78);
            this.textBoxDeliveryVoucherID.Name = "textBoxDeliveryVoucherID";
            this.textBoxDeliveryVoucherID.ReadOnly = true;
            this.textBoxDeliveryVoucherID.Size = new System.Drawing.Size(166, 22);
            this.textBoxDeliveryVoucherID.TabIndex = 31;
            // 
            // textBoxCustomerID
            // 
            this.textBoxCustomerID.Location = new System.Drawing.Point(176, 78);
            this.textBoxCustomerID.Name = "textBoxCustomerID";
            this.textBoxCustomerID.ReadOnly = true;
            this.textBoxCustomerID.Size = new System.Drawing.Size(338, 22);
            this.textBoxCustomerID.TabIndex = 31;
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(176, 123);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.ReadOnly = true;
            this.textBoxCustomerName.Size = new System.Drawing.Size(338, 22);
            this.textBoxCustomerName.TabIndex = 31;
            // 
            // FormDeleteDeliveryVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 775);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormDeleteDeliveryVoucher";
            this.Text = "FormDeleteDeliveryVoucher";
            this.Load += new System.EventHandler(this.FormDeleteDeliveryVoucher_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveryInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelInputVoucherIDNotification;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewDeliveryInfo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.TextBox textBoxCustomerID;
        private System.Windows.Forms.TextBox textBoxDeliveryVoucherID;
    }
}