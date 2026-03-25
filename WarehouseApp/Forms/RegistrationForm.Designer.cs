namespace WarehouseApp
{
    partial class RegistrationForm
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
            this.txtLoginHeadline = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.txtNameHeadline = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurnameHeadline = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtPatronymicHeadline = new System.Windows.Forms.TextBox();
            this.txtPatronymic = new System.Windows.Forms.TextBox();
            this.txtPasswordHeadline = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLoginHeadline
            // 
            this.txtLoginHeadline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLoginHeadline.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtLoginHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLoginHeadline.Location = new System.Drawing.Point(291, 234);
            this.txtLoginHeadline.Name = "txtLoginHeadline";
            this.txtLoginHeadline.ReadOnly = true;
            this.txtLoginHeadline.Size = new System.Drawing.Size(209, 22);
            this.txtLoginHeadline.TabIndex = 4;
            this.txtLoginHeadline.Text = "Введите логин";
            this.txtLoginHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLogin.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtLogin.Location = new System.Drawing.Point(272, 262);
            this.txtLogin.Multiline = true;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(257, 27);
            this.txtLogin.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPassword.Location = new System.Drawing.Point(272, 337);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(257, 28);
            this.txtPassword.TabIndex = 7;
            // 
            // btnRegistration
            // 
            this.btnRegistration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRegistration.BackColor = System.Drawing.Color.OliveDrab;
            this.btnRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRegistration.Location = new System.Drawing.Point(291, 386);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(199, 52);
            this.btnRegistration.TabIndex = 8;
            this.btnRegistration.Text = "Зарегистрироваться";
            this.btnRegistration.UseVisualStyleBackColor = false;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // txtNameHeadline
            // 
            this.txtNameHeadline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNameHeadline.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNameHeadline.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNameHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNameHeadline.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNameHeadline.Location = new System.Drawing.Point(291, 12);
            this.txtNameHeadline.Name = "txtNameHeadline";
            this.txtNameHeadline.ReadOnly = true;
            this.txtNameHeadline.Size = new System.Drawing.Size(209, 22);
            this.txtNameHeadline.TabIndex = 9;
            this.txtNameHeadline.Text = "Введите имя";
            this.txtNameHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtName.Location = new System.Drawing.Point(272, 40);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(257, 27);
            this.txtName.TabIndex = 10;
            // 
            // txtSurnameHeadline
            // 
            this.txtSurnameHeadline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSurnameHeadline.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSurnameHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSurnameHeadline.Location = new System.Drawing.Point(291, 88);
            this.txtSurnameHeadline.Name = "txtSurnameHeadline";
            this.txtSurnameHeadline.ReadOnly = true;
            this.txtSurnameHeadline.Size = new System.Drawing.Size(209, 22);
            this.txtSurnameHeadline.TabIndex = 11;
            this.txtSurnameHeadline.Text = "Введите фамилию";
            this.txtSurnameHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSurname
            // 
            this.txtSurname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSurname.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtSurname.Location = new System.Drawing.Point(272, 116);
            this.txtSurname.Multiline = true;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(257, 27);
            this.txtSurname.TabIndex = 12;
            // 
            // txtPatronymicHeadline
            // 
            this.txtPatronymicHeadline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPatronymicHeadline.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPatronymicHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPatronymicHeadline.Location = new System.Drawing.Point(291, 162);
            this.txtPatronymicHeadline.Name = "txtPatronymicHeadline";
            this.txtPatronymicHeadline.ReadOnly = true;
            this.txtPatronymicHeadline.Size = new System.Drawing.Size(209, 22);
            this.txtPatronymicHeadline.TabIndex = 13;
            this.txtPatronymicHeadline.Text = "Введите отчество";
            this.txtPatronymicHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPatronymic
            // 
            this.txtPatronymic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPatronymic.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtPatronymic.Location = new System.Drawing.Point(272, 190);
            this.txtPatronymic.Multiline = true;
            this.txtPatronymic.Name = "txtPatronymic";
            this.txtPatronymic.Size = new System.Drawing.Size(257, 27);
            this.txtPatronymic.TabIndex = 14;
            // 
            // txtPasswordHeadline
            // 
            this.txtPasswordHeadline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPasswordHeadline.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPasswordHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPasswordHeadline.Location = new System.Drawing.Point(291, 309);
            this.txtPasswordHeadline.Name = "txtPasswordHeadline";
            this.txtPasswordHeadline.ReadOnly = true;
            this.txtPasswordHeadline.Size = new System.Drawing.Size(209, 22);
            this.txtPasswordHeadline.TabIndex = 15;
            this.txtPasswordHeadline.Text = "Введите пароль";
            this.txtPasswordHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Firebrick;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(0, 1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 32);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtPasswordHeadline);
            this.Controls.Add(this.txtPatronymic);
            this.Controls.Add(this.txtPatronymicHeadline);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtSurnameHeadline);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNameHeadline);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtLoginHeadline);
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoginHeadline;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.TextBox txtNameHeadline;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurnameHeadline;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtPatronymicHeadline;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.TextBox txtPasswordHeadline;
        private System.Windows.Forms.Button btnBack;
    }
}