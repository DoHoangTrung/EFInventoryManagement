
namespace QuanLyKhoHang
{
    partial class FormAddCustomer
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
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxCustomerID = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelCustomerEmail = new System.Windows.Forms.Label();
            this.textBoxCustomerEmail = new System.Windows.Forms.TextBox();
            this.labelCustomerPhone = new System.Windows.Forms.Label();
            this.textBoxCustomerPhone = new System.Windows.Forms.TextBox();
            this.labelCustomerAddress = new System.Windows.Forms.Label();
            this.textBoxCustomerAddress = new System.Windows.Forms.TextBox();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.labelCustomerEmailNotification = new System.Windows.Forms.Label();
            this.labelCustomerPhoneNotification = new System.Windows.Forms.Label();
            this.labelCustomerAddressNotification = new System.Windows.Forms.Label();
            this.labelCustomerNameNotification = new System.Windows.Forms.Label();
            this.labeCustomerIDNotification = new System.Windows.Forms.Label();
            this.labelCustomerID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(210, -121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(369, 29);
            this.label11.TabIndex = 3;
            this.label11.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxCustomerID);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.labelCustomerEmail);
            this.panel1.Controls.Add(this.textBoxCustomerEmail);
            this.panel1.Controls.Add(this.labelCustomerPhone);
            this.panel1.Controls.Add(this.textBoxCustomerPhone);
            this.panel1.Controls.Add(this.labelCustomerAddress);
            this.panel1.Controls.Add(this.textBoxCustomerAddress);
            this.panel1.Controls.Add(this.labelCustomerName);
            this.panel1.Controls.Add(this.textBoxCustomerName);
            this.panel1.Controls.Add(this.labelCustomerEmailNotification);
            this.panel1.Controls.Add(this.labelCustomerPhoneNotification);
            this.panel1.Controls.Add(this.labelCustomerAddressNotification);
            this.panel1.Controls.Add(this.labelCustomerNameNotification);
            this.panel1.Controls.Add(this.labeCustomerIDNotification);
            this.panel1.Controls.Add(this.labelCustomerID);
            this.panel1.Location = new System.Drawing.Point(191, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 630);
            this.panel1.TabIndex = 10;
            // 
            // comboBoxCustomerID
            // 
            this.comboBoxCustomerID.FormattingEnabled = true;
            this.comboBoxCustomerID.Location = new System.Drawing.Point(261, 55);
            this.comboBoxCustomerID.Name = "comboBoxCustomerID";
            this.comboBoxCustomerID.Size = new System.Drawing.Size(317, 24);
            this.comboBoxCustomerID.TabIndex = 0;
            this.comboBoxCustomerID.TextChanged += new System.EventHandler(this.comboBoxCustomerID_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(450, 520);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Thoát";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(304, 520);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "Đồng ý";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelCustomerEmail
            // 
            this.labelCustomerEmail.AutoSize = true;
            this.labelCustomerEmail.Location = new System.Drawing.Point(140, 428);
            this.labelCustomerEmail.Name = "labelCustomerEmail";
            this.labelCustomerEmail.Size = new System.Drawing.Size(46, 17);
            this.labelCustomerEmail.TabIndex = 10;
            this.labelCustomerEmail.Text = "Email:";
            // 
            // textBoxCustomerEmail
            // 
            this.textBoxCustomerEmail.Location = new System.Drawing.Point(261, 428);
            this.textBoxCustomerEmail.Name = "textBoxCustomerEmail";
            this.textBoxCustomerEmail.Size = new System.Drawing.Size(329, 22);
            this.textBoxCustomerEmail.TabIndex = 4;
            // 
            // labelCustomerPhone
            // 
            this.labelCustomerPhone.AutoSize = true;
            this.labelCustomerPhone.Location = new System.Drawing.Point(140, 322);
            this.labelCustomerPhone.Name = "labelCustomerPhone";
            this.labelCustomerPhone.Size = new System.Drawing.Size(95, 17);
            this.labelCustomerPhone.TabIndex = 10;
            this.labelCustomerPhone.Text = "Số điện thoại:";
            // 
            // textBoxCustomerPhone
            // 
            this.textBoxCustomerPhone.Location = new System.Drawing.Point(261, 322);
            this.textBoxCustomerPhone.Name = "textBoxCustomerPhone";
            this.textBoxCustomerPhone.Size = new System.Drawing.Size(329, 22);
            this.textBoxCustomerPhone.TabIndex = 3;
            // 
            // labelCustomerAddress
            // 
            this.labelCustomerAddress.AutoSize = true;
            this.labelCustomerAddress.Location = new System.Drawing.Point(140, 228);
            this.labelCustomerAddress.Name = "labelCustomerAddress";
            this.labelCustomerAddress.Size = new System.Drawing.Size(55, 17);
            this.labelCustomerAddress.TabIndex = 10;
            this.labelCustomerAddress.Text = "Địa chỉ:";
            // 
            // textBoxCustomerAddress
            // 
            this.textBoxCustomerAddress.Location = new System.Drawing.Point(261, 228);
            this.textBoxCustomerAddress.Name = "textBoxCustomerAddress";
            this.textBoxCustomerAddress.Size = new System.Drawing.Size(329, 22);
            this.textBoxCustomerAddress.TabIndex = 2;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(140, 143);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(37, 17);
            this.labelCustomerName.TabIndex = 10;
            this.labelCustomerName.Text = "Tên:";
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(261, 143);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(329, 22);
            this.textBoxCustomerName.TabIndex = 1;
            this.textBoxCustomerName.TextChanged += new System.EventHandler(this.textBoxCustomerName_TextChanged);
            // 
            // labelCustomerEmailNotification
            // 
            this.labelCustomerEmailNotification.AutoSize = true;
            this.labelCustomerEmailNotification.Location = new System.Drawing.Point(622, 433);
            this.labelCustomerEmailNotification.Name = "labelCustomerEmailNotification";
            this.labelCustomerEmailNotification.Size = new System.Drawing.Size(46, 17);
            this.labelCustomerEmailNotification.TabIndex = 10;
            this.labelCustomerEmailNotification.Text = "label1";
            // 
            // labelCustomerPhoneNotification
            // 
            this.labelCustomerPhoneNotification.AutoSize = true;
            this.labelCustomerPhoneNotification.Location = new System.Drawing.Point(622, 322);
            this.labelCustomerPhoneNotification.Name = "labelCustomerPhoneNotification";
            this.labelCustomerPhoneNotification.Size = new System.Drawing.Size(46, 17);
            this.labelCustomerPhoneNotification.TabIndex = 10;
            this.labelCustomerPhoneNotification.Text = "label1";
            // 
            // labelCustomerAddressNotification
            // 
            this.labelCustomerAddressNotification.AutoSize = true;
            this.labelCustomerAddressNotification.Location = new System.Drawing.Point(622, 231);
            this.labelCustomerAddressNotification.Name = "labelCustomerAddressNotification";
            this.labelCustomerAddressNotification.Size = new System.Drawing.Size(46, 17);
            this.labelCustomerAddressNotification.TabIndex = 10;
            this.labelCustomerAddressNotification.Text = "label1";
            // 
            // labelCustomerNameNotification
            // 
            this.labelCustomerNameNotification.AutoSize = true;
            this.labelCustomerNameNotification.Location = new System.Drawing.Point(622, 146);
            this.labelCustomerNameNotification.Name = "labelCustomerNameNotification";
            this.labelCustomerNameNotification.Size = new System.Drawing.Size(202, 17);
            this.labelCustomerNameNotification.TabIndex = 10;
            this.labelCustomerNameNotification.Text = "Độ dài tên không quá 100 kí tự";
            // 
            // labeCustomerIDNotification
            // 
            this.labeCustomerIDNotification.AutoSize = true;
            this.labeCustomerIDNotification.Location = new System.Drawing.Point(622, 60);
            this.labeCustomerIDNotification.Name = "labeCustomerIDNotification";
            this.labeCustomerIDNotification.Size = new System.Drawing.Size(434, 17);
            this.labeCustomerIDNotification.TabIndex = 10;
            this.labeCustomerIDNotification.Text = "ID không quá 30 kí tự \\nvà KHÔNG trùng lặp với ID trong danh sách";
            // 
            // labelCustomerID
            // 
            this.labelCustomerID.AutoSize = true;
            this.labelCustomerID.Location = new System.Drawing.Point(140, 55);
            this.labelCustomerID.Name = "labelCustomerID";
            this.labelCustomerID.Size = new System.Drawing.Size(25, 17);
            this.labelCustomerID.TabIndex = 10;
            this.labelCustomerID.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(456, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // FormAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "FormAddCustomer";
            this.Text = "Thêm khách hàng";
            this.Load += new System.EventHandler(this.FormAddCustomer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxCustomerID;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelCustomerEmail;
        private System.Windows.Forms.TextBox textBoxCustomerEmail;
        private System.Windows.Forms.Label labelCustomerPhone;
        private System.Windows.Forms.TextBox textBoxCustomerPhone;
        private System.Windows.Forms.Label labelCustomerAddress;
        private System.Windows.Forms.TextBox textBoxCustomerAddress;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.Label labelCustomerEmailNotification;
        private System.Windows.Forms.Label labelCustomerPhoneNotification;
        private System.Windows.Forms.Label labelCustomerAddressNotification;
        private System.Windows.Forms.Label labelCustomerNameNotification;
        private System.Windows.Forms.Label labeCustomerIDNotification;
        private System.Windows.Forms.Label labelCustomerID;
        private System.Windows.Forms.Label label1;
    }
}