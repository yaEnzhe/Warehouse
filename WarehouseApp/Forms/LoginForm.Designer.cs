namespace WarehouseApp
{
    partial class LoginForm
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
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtWarehouseHeadline = new System.Windows.Forms.TextBox();
            this.txtLoginHeadline = new System.Windows.Forms.TextBox();
            this.txtPasswordHeadline = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLogin.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLogin.Location = new System.Drawing.Point(267, 148);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(257, 38);
            this.txtLogin.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPassword.Location = new System.Drawing.Point(267, 248);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(257, 38);
            this.txtPassword.TabIndex = 1;
            // 
            // txtWarehouseHeadline
            // 
            this.txtWarehouseHeadline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarehouseHeadline.BackColor = System.Drawing.Color.LimeGreen;
            this.txtWarehouseHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtWarehouseHeadline.ForeColor = System.Drawing.SystemColors.Window;
            this.txtWarehouseHeadline.Location = new System.Drawing.Point(96, 12);
            this.txtWarehouseHeadline.Multiline = true;
            this.txtWarehouseHeadline.Name = "txtWarehouseHeadline";
            this.txtWarehouseHeadline.ReadOnly = true;
            this.txtWarehouseHeadline.Size = new System.Drawing.Size(595, 32);
            this.txtWarehouseHeadline.TabIndex = 2;
            this.txtWarehouseHeadline.TabStop = false;
            this.txtWarehouseHeadline.Text = "СКЛАДСКОЙ УЧЕТ КАНЦЕЛЯРИИ";
            this.txtWarehouseHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWarehouseHeadline.TextChanged += new System.EventHandler(this.txtWarehouseHeadline_TextChanged);
            this.txtWarehouseHeadline.Enter += new System.EventHandler(this.txtWarehouseHeadline_Enter);
            // 
            // txtLoginHeadline
            // 
            this.txtLoginHeadline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLoginHeadline.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtLoginHeadline.Location = new System.Drawing.Point(287, 120);
            this.txtLoginHeadline.Name = "txtLoginHeadline";
            this.txtLoginHeadline.ReadOnly = true;
            this.txtLoginHeadline.Size = new System.Drawing.Size(209, 22);
            this.txtLoginHeadline.TabIndex = 3;
            this.txtLoginHeadline.TabStop = false;
            this.txtLoginHeadline.Text = "Введите логин";
            this.txtLoginHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLoginHeadline.Enter += new System.EventHandler(this.txtLoginHeadline_Enter);
            // 
            // txtPasswordHeadline
            // 
            this.txtPasswordHeadline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPasswordHeadline.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPasswordHeadline.Location = new System.Drawing.Point(287, 220);
            this.txtPasswordHeadline.Name = "txtPasswordHeadline";
            this.txtPasswordHeadline.ReadOnly = true;
            this.txtPasswordHeadline.Size = new System.Drawing.Size(209, 22);
            this.txtPasswordHeadline.TabIndex = 4;
            this.txtPasswordHeadline.TabStop = false;
            this.txtPasswordHeadline.Text = "Введите пароль";
            this.txtPasswordHeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPasswordHeadline.Enter += new System.EventHandler(this.txtPasswordHeadline_Enter);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogin.Location = new System.Drawing.Point(43, 389);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(161, 40);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "ВОЙТИ";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegistration
            // 
            this.btnRegistration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRegistration.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRegistration.Location = new System.Drawing.Point(604, 389);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(161, 40);
            this.btnRegistration.TabIndex = 6;
            this.btnRegistration.Text = "РЕГИСТРАЦИЯ";
            this.btnRegistration.UseVisualStyleBackColor = false;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPasswordHeadline);
            this.Controls.Add(this.txtLoginHeadline);
            this.Controls.Add(this.txtWarehouseHeadline);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtWarehouseHeadline;
        private System.Windows.Forms.TextBox txtLoginHeadline;
        private System.Windows.Forms.TextBox txtPasswordHeadline;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegistration;
    }
}