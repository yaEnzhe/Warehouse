namespace WarehouseApp.Forms
{
    partial class ContractorCheckForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLegalStatus = new System.Windows.Forms.Label();
            this.cmbLegalStatus = new System.Windows.Forms.ComboBox();
            this.lblInn = new System.Windows.Forms.Label();
            this.txtInn = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 45);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(229)))), ((int)(((byte)(190)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Location = new System.Drawing.Point(150, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(630, 45);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Проверка контрагента";
            // 
            // lblLegalStatus
            // 
            this.lblLegalStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblLegalStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.lblLegalStatus.Location = new System.Drawing.Point(30, 127);
            this.lblLegalStatus.Name = "lblLegalStatus";
            this.lblLegalStatus.Size = new System.Drawing.Size(335, 86);
            this.lblLegalStatus.TabIndex = 2;
            this.lblLegalStatus.Text = "Юридический\r\nстатус:";
            this.lblLegalStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLegalStatus
            // 
            this.cmbLegalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLegalStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.cmbLegalStatus.FormattingEnabled = true;
            this.cmbLegalStatus.Items.AddRange(new object[] {
            "ИП",
            "Организация"});
            this.cmbLegalStatus.Location = new System.Drawing.Point(365, 127);
            this.cmbLegalStatus.Name = "cmbLegalStatus";
            this.cmbLegalStatus.Size = new System.Drawing.Size(352, 54);
            this.cmbLegalStatus.TabIndex = 3;
            // 
            // lblInn
            // 
            this.lblInn.BackColor = System.Drawing.Color.LightGray;
            this.lblInn.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.lblInn.Location = new System.Drawing.Point(30, 250);
            this.lblInn.Name = "lblInn";
            this.lblInn.Size = new System.Drawing.Size(335, 67);
            this.lblInn.TabIndex = 4;
            this.lblInn.Text = "ИНН:";
            this.lblInn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInn
            // 
            this.txtInn.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.txtInn.Location = new System.Drawing.Point(365, 250);
            this.txtInn.MaxLength = 12;
            this.txtInn.Name = "txtInn";
            this.txtInn.Size = new System.Drawing.Size(352, 49);
            this.txtInn.TabIndex = 5;
            this.txtInn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInn_KeyPress);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(210)))), ((int)(((byte)(165)))));
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.btnCheck.Location = new System.Drawing.Point(225, 356);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(300, 66);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // ContractorCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtInn);
            this.Controls.Add(this.lblInn);
            this.Controls.Add(this.cmbLegalStatus);
            this.Controls.Add(this.lblLegalStatus);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnBack);
            this.Name = "ContractorCheckForm";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLegalStatus;
        private System.Windows.Forms.ComboBox cmbLegalStatus;
        private System.Windows.Forms.Label lblInn;
        private System.Windows.Forms.TextBox txtInn;
        private System.Windows.Forms.Button btnCheck;
    }
}
