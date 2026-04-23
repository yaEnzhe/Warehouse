namespace WarehouseApp.Forms
{
    partial class MainMenuAdminForm
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
            this.txtWelcome = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnActionHistory = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.labelHeadline = new System.Windows.Forms.Label();
            this.panelHeadline = new System.Windows.Forms.Panel();
            this.labelYourRole = new System.Windows.Forms.Label();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.btnPostavki = new System.Windows.Forms.Button();
            this.btnParametr = new System.Windows.Forms.Button();
            this.panelHeadline.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWelcome
            // 
            this.txtWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtWelcome.BackColor = System.Drawing.Color.LimeGreen;
            this.txtWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtWelcome.Location = new System.Drawing.Point(368, 0);
            this.txtWelcome.Multiline = true;
            this.txtWelcome.Name = "txtWelcome";
            this.txtWelcome.ReadOnly = true;
            this.txtWelcome.Size = new System.Drawing.Size(345, 32);
            this.txtWelcome.TabIndex = 1;
            this.txtWelcome.TabStop = false;
            this.txtWelcome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Brown;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(705, -4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 39);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProducts.BackColor = System.Drawing.Color.ForestGreen;
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProducts.Location = new System.Drawing.Point(98, 120);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(162, 55);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "ТОВАРЫ";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnActionHistory
            // 
            this.btnActionHistory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnActionHistory.BackColor = System.Drawing.Color.ForestGreen;
            this.btnActionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnActionHistory.Location = new System.Drawing.Point(292, 235);
            this.btnActionHistory.Name = "btnActionHistory";
            this.btnActionHistory.Size = new System.Drawing.Size(199, 59);
            this.btnActionHistory.TabIndex = 5;
            this.btnActionHistory.Text = "ОТЧЁТЫ";
            this.btnActionHistory.UseVisualStyleBackColor = false;
            this.btnActionHistory.Click += new System.EventHandler(this.btnActionHistory_Click);
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDate.Location = new System.Drawing.Point(0, 408);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(260, 30);
            this.txtDate.TabIndex = 9;
            this.txtDate.TabStop = false;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelHeadline
            // 
            this.labelHeadline.AutoSize = true;
            this.labelHeadline.BackColor = System.Drawing.Color.LimeGreen;
            this.labelHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeadline.Location = new System.Drawing.Point(62, 0);
            this.labelHeadline.Name = "labelHeadline";
            this.labelHeadline.Size = new System.Drawing.Size(248, 22);
            this.labelHeadline.TabIndex = 10;
            this.labelHeadline.Text = "Складской учет канцелярии";
            // 
            // panelHeadline
            // 
            this.panelHeadline.BackColor = System.Drawing.Color.LimeGreen;
            this.panelHeadline.Controls.Add(this.labelHeadline);
            this.panelHeadline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelHeadline.Location = new System.Drawing.Point(0, 3);
            this.panelHeadline.Name = "panelHeadline";
            this.panelHeadline.Size = new System.Drawing.Size(371, 29);
            this.panelHeadline.TabIndex = 11;
            // 
            // labelYourRole
            // 
            this.labelYourRole.AutoSize = true;
            this.labelYourRole.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelYourRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYourRole.Location = new System.Drawing.Point(490, 408);
            this.labelYourRole.Name = "labelYourRole";
            this.labelYourRole.Size = new System.Drawing.Size(115, 25);
            this.labelYourRole.TabIndex = 12;
            this.labelYourRole.Text = "Ваша роль:";
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.labelAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdmin.Location = new System.Drawing.Point(611, 408);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(164, 25);
            this.labelAdmin.TabIndex = 13;
            this.labelAdmin.Text = "Администратор";
            // 
            // btnPostavki
            // 
            this.btnPostavki.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPostavki.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPostavki.Location = new System.Drawing.Point(531, 120);
            this.btnPostavki.Name = "btnPostavki";
            this.btnPostavki.Size = new System.Drawing.Size(182, 55);
            this.btnPostavki.TabIndex = 14;
            this.btnPostavki.Text = "ПОСТАВКИ";
            this.btnPostavki.UseVisualStyleBackColor = false;
            this.btnPostavki.Click += new System.EventHandler(this.btnPostavki_Click);
            // 
            // btnParametr
            // 
            this.btnParametr.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnParametr.Location = new System.Drawing.Point(26, 49);
            this.btnParametr.Name = "btnParametr";
            this.btnParametr.Size = new System.Drawing.Size(139, 37);
            this.btnParametr.TabIndex = 15;
            this.btnParametr.Text = "Параметры";
            this.btnParametr.UseVisualStyleBackColor = false;
            this.btnParametr.Click += new System.EventHandler(this.btnParametr_Click);
            // 
            // MainMenuAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnParametr);
            this.Controls.Add(this.btnPostavki);
            this.Controls.Add(this.labelAdmin);
            this.Controls.Add(this.labelYourRole);
            this.Controls.Add(this.panelHeadline);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnActionHistory);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtWelcome);
            this.MaximizeBox = false;
            this.Name = "MainMenuAdminForm";
            this.panelHeadline.ResumeLayout(false);
            this.panelHeadline.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtWelcome;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnActionHistory;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label labelHeadline;
        private System.Windows.Forms.Panel panelHeadline;
        private System.Windows.Forms.Label labelYourRole;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Button btnPostavki;
        private System.Windows.Forms.Button btnParametr;
    }
}