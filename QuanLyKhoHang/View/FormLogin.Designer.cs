
namespace QuanLyKhoHang
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.lbNotification = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picUserName = new System.Windows.Forms.PictureBox();
            this.picPassWord = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassWord)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNotification
            // 
            this.lbNotification.AutoSize = true;
            this.lbNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotification.ForeColor = System.Drawing.Color.DarkRed;
            this.lbNotification.Location = new System.Drawing.Point(11, 589);
            this.lbNotification.Name = "lbNotification";
            this.lbNotification.Size = new System.Drawing.Size(462, 58);
            this.lbNotification.TabIndex = 12;
            this.lbNotification.Text = "Tài khoản hoặc mật khẩu không chính xác.\r\nVui lòng nhập lại";
            this.lbNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(128)))), ((int)(((byte)(215)))));
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonRegister.Location = new System.Drawing.Point(48, 454);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(386, 41);
            this.buttonRegister.TabIndex = 3;
            this.buttonRegister.Text = "Đăng kí";
            this.buttonRegister.UseVisualStyleBackColor = false;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(82)))));
            this.buttonSignIn.FlatAppearance.BorderSize = 0;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.buttonSignIn.Location = new System.Drawing.Point(47, 394);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(386, 41);
            this.buttonSignIn.TabIndex = 0;
            this.buttonSignIn.Text = "Đăng nhập";
            this.buttonSignIn.UseVisualStyleBackColor = false;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(128)))), ((int)(((byte)(215)))));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxPassword.HideSelection = false;
            this.textBoxPassword.Location = new System.Drawing.Point(122, 335);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(311, 25);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.Text = "Mật khẩu";
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(128)))), ((int)(((byte)(215)))));
            this.textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxUserName.HideSelection = false;
            this.textBoxUserName.Location = new System.Drawing.Point(122, 273);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(311, 25);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.Text = "Tài khoản";
            this.textBoxUserName.Enter += new System.EventHandler(this.textBoxUserName_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(157, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // picUserName
            // 
            this.picUserName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picUserName.BackgroundImage")));
            this.picUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picUserName.Location = new System.Drawing.Point(47, 255);
            this.picUserName.Name = "picUserName";
            this.picUserName.Size = new System.Drawing.Size(51, 43);
            this.picUserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserName.TabIndex = 13;
            this.picUserName.TabStop = false;
            // 
            // picPassWord
            // 
            this.picPassWord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPassWord.BackgroundImage")));
            this.picPassWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPassWord.Location = new System.Drawing.Point(47, 317);
            this.picPassWord.Name = "picPassWord";
            this.picPassWord.Size = new System.Drawing.Size(51, 43);
            this.picPassWord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPassWord.TabIndex = 13;
            this.picPassWord.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(48, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 1);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(48, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 1);
            this.panel2.TabIndex = 14;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.buttonSignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(128)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(478, 672);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picPassWord);
            this.Controls.Add(this.picUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbNotification);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý kho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNotification;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picUserName;
        private System.Windows.Forms.PictureBox picPassWord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

