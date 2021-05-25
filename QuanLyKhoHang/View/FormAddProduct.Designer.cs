
namespace QuanLyKhoHang
{
    partial class FormAddProduct
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxProductType = new System.Windows.Forms.ComboBox();
            this.labelGoodName = new System.Windows.Forms.Label();
            this.comboBoxIDGood = new System.Windows.Forms.ComboBox();
            this.labelNotificationIDGood = new System.Windows.Forms.Label();
            this.buttonAddGood = new System.Windows.Forms.Button();
            this.textBoxGoodUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGoodName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxProductType);
            this.panel1.Controls.Add(this.labelGoodName);
            this.panel1.Controls.Add(this.comboBoxIDGood);
            this.panel1.Controls.Add(this.labelNotificationIDGood);
            this.panel1.Controls.Add(this.buttonAddGood);
            this.panel1.Controls.Add(this.textBoxGoodUnit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxGoodName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(32, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 588);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxProductType
            // 
            this.comboBoxProductType.FormattingEnabled = true;
            this.comboBoxProductType.Location = new System.Drawing.Point(180, 83);
            this.comboBoxProductType.Name = "comboBoxProductType";
            this.comboBoxProductType.Size = new System.Drawing.Size(232, 24);
            this.comboBoxProductType.TabIndex = 6;
            // 
            // labelGoodName
            // 
            this.labelGoodName.AutoSize = true;
            this.labelGoodName.Location = new System.Drawing.Point(460, 268);
            this.labelGoodName.Name = "labelGoodName";
            this.labelGoodName.Size = new System.Drawing.Size(38, 17);
            this.labelGoodName.TabIndex = 5;
            this.labelGoodName.Text = "label";
            // 
            // comboBoxIDGood
            // 
            this.comboBoxIDGood.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxIDGood.FormattingEnabled = true;
            this.comboBoxIDGood.Location = new System.Drawing.Point(180, 186);
            this.comboBoxIDGood.Name = "comboBoxIDGood";
            this.comboBoxIDGood.Size = new System.Drawing.Size(232, 24);
            this.comboBoxIDGood.TabIndex = 1;
            this.comboBoxIDGood.TextUpdate += new System.EventHandler(this.comboBoxIDGood_TextUpdate);
            // 
            // labelNotificationIDGood
            // 
            this.labelNotificationIDGood.AutoSize = true;
            this.labelNotificationIDGood.Location = new System.Drawing.Point(460, 186);
            this.labelNotificationIDGood.Name = "labelNotificationIDGood";
            this.labelNotificationIDGood.Size = new System.Drawing.Size(186, 17);
            this.labelNotificationIDGood.TabIndex = 3;
            this.labelNotificationIDGood.Text = "Nhập mã không quá 30 kí tự";
            // 
            // buttonAddGood
            // 
            this.buttonAddGood.Location = new System.Drawing.Point(273, 481);
            this.buttonAddGood.Name = "buttonAddGood";
            this.buttonAddGood.Size = new System.Drawing.Size(127, 46);
            this.buttonAddGood.TabIndex = 4;
            this.buttonAddGood.Text = "Thêm";
            this.buttonAddGood.UseVisualStyleBackColor = true;
            this.buttonAddGood.Click += new System.EventHandler(this.buttonAddGood_Click);
            // 
            // textBoxGoodUnit
            // 
            this.textBoxGoodUnit.Location = new System.Drawing.Point(180, 365);
            this.textBoxGoodUnit.Name = "textBoxGoodUnit";
            this.textBoxGoodUnit.Size = new System.Drawing.Size(232, 22);
            this.textBoxGoodUnit.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đơn vị";
            // 
            // textBoxGoodName
            // 
            this.textBoxGoodName.Location = new System.Drawing.Point(180, 268);
            this.textBoxGoodName.Name = "textBoxGoodName";
            this.textBoxGoodName.Size = new System.Drawing.Size(232, 22);
            this.textBoxGoodName.TabIndex = 2;
            this.textBoxGoodName.TextChanged += new System.EventHandler(this.textBoxGoodName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên hàng hóa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hàng hóa";
            this.toolTip1.SetToolTip(this.label1, "halosdfa sdad fasdfasdf as");
            // 
            // FormAddProduct
            // 
            this.AcceptButton = this.buttonAddGood;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 696);
            this.Controls.Add(this.panel1);
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin hàng hóa";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddGood;
        private System.Windows.Forms.TextBox textBoxGoodUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGoodName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNotificationIDGood;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBoxIDGood;
        private System.Windows.Forms.ComboBox comboBoxProductType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelGoodName;
    }
}