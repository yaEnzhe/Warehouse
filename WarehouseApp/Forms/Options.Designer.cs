namespace WarehouseApp.Forms
{
    partial class Options
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelPar = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblValuta = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblSale = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtPeriod = new System.Windows.Forms.ComboBox();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.lblVal = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblprosent = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LimeGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 46);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPar
            // 
            this.labelPar.BackColor = System.Drawing.Color.LimeGreen;
            this.labelPar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPar.Location = new System.Drawing.Point(38, 38);
            this.labelPar.Name = "labelPar";
            this.labelPar.Size = new System.Drawing.Size(258, 34);
            this.labelPar.TabIndex = 1;
            this.labelPar.Text = "Параметры";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(623, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(165, 55);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblValuta
            // 
            this.lblValuta.BackColor = System.Drawing.Color.DarkGray;
            this.lblValuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblValuta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblValuta.Location = new System.Drawing.Point(102, 142);
            this.lblValuta.Name = "lblValuta";
            this.lblValuta.Size = new System.Drawing.Size(180, 41);
            this.lblValuta.TabIndex = 3;
            this.lblValuta.Text = "  Валюта:";
            this.lblValuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPeriod
            // 
            this.lblPeriod.BackColor = System.Drawing.Color.DarkGray;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPeriod.Location = new System.Drawing.Point(103, 212);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(295, 45);
            this.lblPeriod.TabIndex = 4;
            this.lblPeriod.Text = "Период до истечения срока:";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSale
            // 
            this.lblSale.BackColor = System.Drawing.Color.DarkGray;
            this.lblSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSale.Location = new System.Drawing.Point(104, 293);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(178, 41);
            this.lblSale.TabIndex = 5;
            this.lblSale.Text = " Скидка:";
            this.lblSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(288, 142);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(323, 39);
            this.cmbCurrency.TabIndex = 6;
            // 
            // txtPeriod
            // 
            this.txtPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPeriod.FormattingEnabled = true;
            this.txtPeriod.Location = new System.Drawing.Point(399, 213);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(161, 44);
            this.txtPeriod.TabIndex = 7;
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Location = new System.Drawing.Point(288, 293);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(151, 39);
            this.cmbDiscount.TabIndex = 8;
            // 
            // lblVal
            // 
            this.lblVal.BackColor = System.Drawing.Color.DarkGray;
            this.lblVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblVal.Location = new System.Drawing.Point(617, 142);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(91, 41);
            this.lblVal.TabIndex = 9;
            this.lblVal.Text = "    ▼";
            this.lblVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMonth
            // 
            this.lblMonth.BackColor = System.Drawing.Color.DarkGray;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMonth.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMonth.Location = new System.Drawing.Point(566, 214);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(142, 41);
            this.lblMonth.TabIndex = 10;
            this.lblMonth.Text = "месяц";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblprosent
            // 
            this.lblprosent.BackColor = System.Drawing.Color.DarkGray;
            this.lblprosent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblprosent.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblprosent.Location = new System.Drawing.Point(445, 293);
            this.lblprosent.Name = "lblprosent";
            this.lblprosent.Size = new System.Drawing.Size(263, 41);
            this.lblprosent.TabIndex = 11;
            this.lblprosent.Text = "     %";
            this.lblprosent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(288, 366);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(258, 42);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblprosent);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblVal);
            this.Controls.Add(this.cmbDiscount);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.lblSale);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.lblValuta);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelPar);
            this.Controls.Add(this.label1);
            this.Name = "Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblValuta;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblSale;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.ComboBox txtPeriod;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private System.Windows.Forms.Label lblVal;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblprosent;
        private System.Windows.Forms.Button btnSave;
    }
}