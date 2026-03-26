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
            this.btnShipment = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtWelcome = new System.Windows.Forms.TextBox();
            this.panelHeadline = new System.Windows.Forms.Panel();
            this.labelHeadline = new System.Windows.Forms.Label();
            this.labelYourRole = new System.Windows.Forms.Label();
            this.labelStorekeeper = new System.Windows.Forms.Label();
            this.panelHeadline.SuspendLayout();
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
            this.txtDate.TabStop = false;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnShipment
            // 
            this.btnShipment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShipment.BackColor = System.Drawing.Color.ForestGreen;
            this.btnShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShipment.Location = new System.Drawing.Point(488, 121);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(167, 55);
            this.btnShipment.TabIndex = 13;
            this.btnShipment.Text = "ОТГРУЗКИ";
            this.btnShipment.UseVisualStyleBackColor = false;
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProducts.BackColor = System.Drawing.Color.ForestGreen;
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProducts.Location = new System.Drawing.Point(135, 121);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(167, 55);
            this.btnProducts.TabIndex = 12;
            this.btnProducts.Text = "ТОВАРЫ";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Brown;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(695, -5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 39);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtWelcome
            // 
            this.txtWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtWelcome.BackColor = System.Drawing.Color.LimeGreen;
            this.txtWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtWelcome.Location = new System.Drawing.Point(360, -5);
            this.txtWelcome.Multiline = true;
            this.txtWelcome.Name = "txtWelcome";
            this.txtWelcome.ReadOnly = true;
            this.txtWelcome.Size = new System.Drawing.Size(340, 35);
            this.txtWelcome.TabIndex = 10;
            this.txtWelcome.TabStop = false;
            this.txtWelcome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelHeadline
            // 
            this.panelHeadline.BackColor = System.Drawing.Color.LimeGreen;
            this.panelHeadline.Controls.Add(this.labelHeadline);
            this.panelHeadline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelHeadline.Location = new System.Drawing.Point(0, 1);
            this.panelHeadline.Name = "panelHeadline";
            this.panelHeadline.Size = new System.Drawing.Size(371, 29);
            this.panelHeadline.TabIndex = 18;
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
            // labelYourRole
            // 
            this.labelYourRole.AutoSize = true;
            this.labelYourRole.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelYourRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYourRole.Location = new System.Drawing.Point(550, 424);
            this.labelYourRole.Name = "labelYourRole";
            this.labelYourRole.Size = new System.Drawing.Size(115, 25);
            this.labelYourRole.TabIndex = 19;
            this.labelYourRole.Text = "Ваша роль:";
            // 
            // labelStorekeeper
            // 
            this.labelStorekeeper.AutoSize = true;
            this.labelStorekeeper.BackColor = System.Drawing.Color.LightSeaGreen;
            this.labelStorekeeper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStorekeeper.Location = new System.Drawing.Point(671, 424);
            this.labelStorekeeper.Name = "labelStorekeeper";
            this.labelStorekeeper.Size = new System.Drawing.Size(117, 25);
            this.labelStorekeeper.TabIndex = 20;
            this.labelStorekeeper.Text = "Кладовщик";
            // 
            // MainMenuStorekeeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelStorekeeper);
            this.Controls.Add(this.labelYourRole);
            this.Controls.Add(this.panelHeadline);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnShipment);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtWelcome);
            this.MaximizeBox = false;
            this.Name = "MainMenuStorekeeperForm";
            this.panelHeadline.ResumeLayout(false);
            this.panelHeadline.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnShipment;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtWelcome;
        private System.Windows.Forms.Panel panelHeadline;
        private System.Windows.Forms.Label labelHeadline;
        private System.Windows.Forms.Label labelYourRole;
        private System.Windows.Forms.Label labelStorekeeper;
    }
}