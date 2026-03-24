namespace WarehouseApp.Forms
{
    partial class MainMenuStorekeeperForm
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
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtYourRole = new System.Windows.Forms.TextBox();
            this.btnShipment = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtWelcome = new System.Windows.Forms.TextBox();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtDate.Cursor = System.Windows.Forms.Cursors.No;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDate.Location = new System.Drawing.Point(0, 425);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(260, 30);
            this.txtDate.TabIndex = 17;
            // 
            // txtRole
            // 
            this.txtRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRole.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtRole.Cursor = System.Windows.Forms.Cursors.No;
            this.txtRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRole.Location = new System.Drawing.Point(583, 425);
            this.txtRole.Multiline = true;
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(217, 30);
            this.txtRole.TabIndex = 16;
            this.txtRole.Text = "Кладовщик";
            this.txtRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYourRole
            // 
            this.txtYourRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYourRole.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtYourRole.Cursor = System.Windows.Forms.Cursors.No;
            this.txtYourRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtYourRole.Location = new System.Drawing.Point(468, 425);
            this.txtYourRole.Multiline = true;
            this.txtYourRole.Name = "txtYourRole";
            this.txtYourRole.ReadOnly = true;
            this.txtYourRole.Size = new System.Drawing.Size(122, 30);
            this.txtYourRole.TabIndex = 15;
            this.txtYourRole.Text = "Ваша роль:";
            // 
            // btnShipment
            // 
            this.btnShipment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShipment.BackColor = System.Drawing.Color.OliveDrab;
            this.btnShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShipment.Location = new System.Drawing.Point(488, 121);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(167, 55);
            this.btnShipment.TabIndex = 13;
            this.btnShipment.Text = "ОТГРУЗКИ";
            this.btnShipment.UseVisualStyleBackColor = false;
            // 
            // btnProducts
            // 
            this.btnProducts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProducts.BackColor = System.Drawing.Color.OliveDrab;
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProducts.Location = new System.Drawing.Point(135, 121);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(167, 55);
            this.btnProducts.TabIndex = 12;
            this.btnProducts.Text = "ТОВАРЫ";
            this.btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Brown;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(644, -5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(156, 39);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtWelcome
            // 
            this.txtWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtWelcome.BackColor = System.Drawing.Color.OliveDrab;
            this.txtWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtWelcome.Location = new System.Drawing.Point(298, 1);
            this.txtWelcome.Multiline = true;
            this.txtWelcome.Name = "txtWelcome";
            this.txtWelcome.ReadOnly = true;
            this.txtWelcome.Size = new System.Drawing.Size(357, 29);
            this.txtWelcome.TabIndex = 10;
            this.txtWelcome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.BackColor = System.Drawing.Color.OliveDrab;
            this.txtWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtWarehouse.Location = new System.Drawing.Point(0, 1);
            this.txtWarehouse.Multiline = true;
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.ReadOnly = true;
            this.txtWarehouse.Size = new System.Drawing.Size(302, 29);
            this.txtWarehouse.TabIndex = 9;
            this.txtWarehouse.Text = "Складской учёт канцелярии";
            this.txtWarehouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainMenuStorekeeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtYourRole);
            this.Controls.Add(this.btnShipment);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtWelcome);
            this.Controls.Add(this.txtWarehouse);
            this.MaximizeBox = false;
            this.Name = "MainMenuStorekeeperForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtYourRole;
        private System.Windows.Forms.Button btnShipment;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtWelcome;
        private System.Windows.Forms.TextBox txtWarehouse;
    }
}