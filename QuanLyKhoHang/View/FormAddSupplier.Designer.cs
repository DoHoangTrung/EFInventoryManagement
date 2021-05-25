
namespace QuanLyKhoHang
{
    partial class FormAddSupplier
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxSupplierID = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelSupplierEmail = new System.Windows.Forms.Label();
            this.textBoxSupplierEmail = new System.Windows.Forms.TextBox();
            this.labelSupplierPhone = new System.Windows.Forms.Label();
            this.textBoxSupplierPhone = new System.Windows.Forms.TextBox();
            this.labelSupplierAddress = new System.Windows.Forms.Label();
            this.textBoxSupplierAddress = new System.Windows.Forms.TextBox();
            this.labelSupplierName = new System.Windows.Forms.Label();
            this.textBoxSupplierName = new System.Windows.Forms.TextBox();
            this.labelSupplierNameNotification = new System.Windows.Forms.Label();
            this.labelSupplierIDNotification = new System.Windows.Forms.Label();
            this.labelSupplierID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxSupplierID);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.labelSupplierEmail);
            this.panel1.Controls.Add(this.textBoxSupplierEmail);
            this.panel1.Controls.Add(this.labelSupplierPhone);
            this.panel1.Controls.Add(this.textBoxSupplierPhone);
            this.panel1.Controls.Add(this.labelSupplierAddress);
            this.panel1.Controls.Add(this.textBoxSupplierAddress);
            this.panel1.Controls.Add(this.labelSupplierName);
            this.panel1.Controls.Add(this.textBoxSupplierName);
            this.panel1.Controls.Add(this.labelSupplierNameNotification);
            this.panel1.Controls.Add(this.labelSupplierIDNotification);
            this.panel1.Controls.Add(this.labelSupplierID);
            this.panel1.Location = new System.Drawing.Point(30, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 630);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxSupplierID
            // 
            this.comboBoxSupplierID.FormattingEnabled = true;
            this.comboBoxSupplierID.Location = new System.Drawing.Point(261, 55);
            this.comboBoxSupplierID.Name = "comboBoxSupplierID";
            this.comboBoxSupplierID.Size = new System.Drawing.Size(317, 24);
            this.comboBoxSupplierID.TabIndex = 0;
            this.comboBoxSupplierID.TextChanged += new System.EventHandler(this.comboBoxSupplierID_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(450, 520);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(304, 520);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelSupplierEmail
            // 
            this.labelSupplierEmail.AutoSize = true;
            this.labelSupplierEmail.Location = new System.Drawing.Point(140, 428);
            this.labelSupplierEmail.Name = "labelSupplierEmail";
            this.labelSupplierEmail.Size = new System.Drawing.Size(46, 17);
            this.labelSupplierEmail.TabIndex = 11;
            this.labelSupplierEmail.Text = "Email:";
            // 
            // textBoxSupplierEmail
            // 
            this.textBoxSupplierEmail.Location = new System.Drawing.Point(261, 428);
            this.textBoxSupplierEmail.Name = "textBoxSupplierEmail";
            this.textBoxSupplierEmail.Size = new System.Drawing.Size(329, 22);
            this.textBoxSupplierEmail.TabIndex = 4;
            // 
            // labelSupplierPhone
            // 
            this.labelSupplierPhone.AutoSize = true;
            this.labelSupplierPhone.Location = new System.Drawing.Point(140, 322);
            this.labelSupplierPhone.Name = "labelSupplierPhone";
            this.labelSupplierPhone.Size = new System.Drawing.Size(95, 17);
            this.labelSupplierPhone.TabIndex = 11;
            this.labelSupplierPhone.Text = "Số điện thoại:";
            // 
            // textBoxSupplierPhone
            // 
            this.textBoxSupplierPhone.Location = new System.Drawing.Point(261, 322);
            this.textBoxSupplierPhone.Name = "textBoxSupplierPhone";
            this.textBoxSupplierPhone.Size = new System.Drawing.Size(329, 22);
            this.textBoxSupplierPhone.TabIndex = 3;
            // 
            // labelSupplierAddress
            // 
            this.labelSupplierAddress.AutoSize = true;
            this.labelSupplierAddress.Location = new System.Drawing.Point(140, 228);
            this.labelSupplierAddress.Name = "labelSupplierAddress";
            this.labelSupplierAddress.Size = new System.Drawing.Size(55, 17);
            this.labelSupplierAddress.TabIndex = 11;
            this.labelSupplierAddress.Text = "Địa chỉ:";
            // 
            // textBoxSupplierAddress
            // 
            this.textBoxSupplierAddress.Location = new System.Drawing.Point(261, 228);
            this.textBoxSupplierAddress.Name = "textBoxSupplierAddress";
            this.textBoxSupplierAddress.Size = new System.Drawing.Size(329, 22);
            this.textBoxSupplierAddress.TabIndex = 2;
            // 
            // labelSupplierName
            // 
            this.labelSupplierName.AutoSize = true;
            this.labelSupplierName.Location = new System.Drawing.Point(140, 143);
            this.labelSupplierName.Name = "labelSupplierName";
            this.labelSupplierName.Size = new System.Drawing.Size(37, 17);
            this.labelSupplierName.TabIndex = 11;
            this.labelSupplierName.Text = "Tên:";
            // 
            // textBoxSupplierName
            // 
            this.textBoxSupplierName.Location = new System.Drawing.Point(261, 143);
            this.textBoxSupplierName.Name = "textBoxSupplierName";
            this.textBoxSupplierName.Size = new System.Drawing.Size(329, 22);
            this.textBoxSupplierName.TabIndex = 1;
            this.textBoxSupplierName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // labelSupplierNameNotification
            // 
            this.labelSupplierNameNotification.AutoSize = true;
            this.labelSupplierNameNotification.Location = new System.Drawing.Point(622, 146);
            this.labelSupplierNameNotification.Name = "labelSupplierNameNotification";
            this.labelSupplierNameNotification.Size = new System.Drawing.Size(253, 17);
            this.labelSupplierNameNotification.TabIndex = 11;
            this.labelSupplierNameNotification.Text = "Hãy nhập tên không vượt quá 100 kí tự";
            // 
            // labelSupplierIDNotification
            // 
            this.labelSupplierIDNotification.AutoSize = true;
            this.labelSupplierIDNotification.Location = new System.Drawing.Point(622, 60);
            this.labelSupplierIDNotification.Name = "labelSupplierIDNotification";
            this.labelSupplierIDNotification.Size = new System.Drawing.Size(500, 17);
            this.labelSupplierIDNotification.TabIndex = 11;
            this.labelSupplierIDNotification.Text = "Hãy nhập ID không quá 30 kí tự\\nKHÔNG TRÙNG LẶP với ID trong danh sách";
            // 
            // labelSupplierID
            // 
            this.labelSupplierID.AutoSize = true;
            this.labelSupplierID.Location = new System.Drawing.Point(140, 55);
            this.labelSupplierID.Name = "labelSupplierID";
            this.labelSupplierID.Size = new System.Drawing.Size(25, 17);
            this.labelSupplierID.TabIndex = 11;
            this.labelSupplierID.Text = "ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(295, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(369, 29);
            this.label11.TabIndex = 1;
            this.label11.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // FormAddSupplier
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(994, 776);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Name = "FormAddSupplier";
            this.Text = "Thêm nhà cung cấp";
            this.Load += new System.EventHandler(this.FormAddSupplier_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelSupplierEmail;
        private System.Windows.Forms.TextBox textBoxSupplierEmail;
        private System.Windows.Forms.Label labelSupplierPhone;
        private System.Windows.Forms.TextBox textBoxSupplierPhone;
        private System.Windows.Forms.Label labelSupplierAddress;
        private System.Windows.Forms.TextBox textBoxSupplierAddress;
        private System.Windows.Forms.Label labelSupplierName;
        private System.Windows.Forms.TextBox textBoxSupplierName;
        private System.Windows.Forms.Label labelSupplierNameNotification;
        private System.Windows.Forms.Label labelSupplierIDNotification;
        private System.Windows.Forms.Label labelSupplierID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxSupplierID;
    }
}