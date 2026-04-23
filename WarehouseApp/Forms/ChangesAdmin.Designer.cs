namespace WarehouseApp.Forms
{
    partial class ChangesAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonForBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.TextBox();
            this.labelYourRole = new System.Windows.Forms.Label();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPoisk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 32);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(203, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Отчёты";
            // 
            // buttonForBack
            // 
            this.buttonForBack.BackColor = System.Drawing.Color.Brown;
            this.buttonForBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForBack.Location = new System.Drawing.Point(-3, 41);
            this.buttonForBack.Name = "buttonForBack";
            this.buttonForBack.Size = new System.Drawing.Size(197, 32);
            this.buttonForBack.TabIndex = 1;
            this.buttonForBack.Text = "Назад";
            this.buttonForBack.UseVisualStyleBackColor = false;
            this.buttonForBack.Click += new System.EventHandler(this.buttonForBack_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.labelPeriod);
            this.panel2.Location = new System.Drawing.Point(74, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 35);
            this.panel2.TabIndex = 1;
            // 
            // labelPeriod
            // 
            this.labelPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPeriod.Location = new System.Drawing.Point(3, 1);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(122, 27);
            this.labelPeriod.TabIndex = 3;
            this.labelPeriod.Text = "Период:";
            // 
            // dgvHistory
            // 
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(-3, 169);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.Size = new System.Drawing.Size(804, 238);
            this.dgvHistory.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(290, 129);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(152, 22);
            this.dtpFrom.TabIndex = 3;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.DatePickers_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(491, 129);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(169, 22);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.ValueChanged += new System.EventHandler(this.DatePickers_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(12, 12);
            this.lblDate.Multiline = true;
            this.lblDate.Name = "lblDate";
            this.lblDate.ReadOnly = true;
            this.lblDate.Size = new System.Drawing.Size(207, 22);
            this.lblDate.TabIndex = 18;
            this.lblDate.TabStop = false;
            this.lblDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelYourRole
            // 
            this.labelYourRole.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelYourRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYourRole.Location = new System.Drawing.Point(435, 9);
            this.labelYourRole.Name = "labelYourRole";
            this.labelYourRole.Size = new System.Drawing.Size(137, 25);
            this.labelYourRole.TabIndex = 19;
            this.labelYourRole.Text = "Ваша роль:";
            // 
            // labelAdmin
            // 
            this.labelAdmin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.labelAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdmin.Location = new System.Drawing.Point(578, 9);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(195, 25);
            this.labelAdmin.TabIndex = 20;
            this.labelAdmin.Text = "Администратор";
            // 
            // lblCategoria
            // 
            this.lblCategoria.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCategoria.Location = new System.Drawing.Point(448, 76);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(124, 27);
            this.lblCategoria.TabIndex = 21;
            this.lblCategoria.Text = "Категория";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(568, 75);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(174, 28);
            this.cmbCategory.TabIndex = 22;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.Filters_SelectedIndexChanged);
            // 
            // lblCat
            // 
            this.lblCat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCat.Location = new System.Drawing.Point(742, 75);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(46, 28);
            this.lblCat.TabIndex = 23;
            this.lblCat.Text = "▼";
            this.lblCat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(57, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 27);
            this.label2.TabIndex = 24;
            this.label2.Text = "Покупатель";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(178, 77);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(174, 28);
            this.cmbCustomer.TabIndex = 25;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.Filters_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(349, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 28);
            this.label3.TabIndex = 26;
            this.label3.Text = "▼";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(254, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 27);
            this.label4.TabIndex = 27;
            this.label4.Text = "с";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(448, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 27);
            this.label5.TabIndex = 28;
            this.label5.Text = "по";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPoisk
            // 
            this.btnPoisk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPoisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPoisk.Location = new System.Drawing.Point(674, 125);
            this.btnPoisk.Name = "btnPoisk";
            this.btnPoisk.Size = new System.Drawing.Size(114, 30);
            this.btnPoisk.TabIndex = 29;
            this.btnPoisk.Text = "Найти";
            this.btnPoisk.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(312, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 30);
            this.button1.TabIndex = 30;
            this.button1.Text = "Экспорт";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ChangesAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPoisk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.labelAdmin);
            this.Controls.Add(this.labelYourRole);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.buttonForBack);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ChangesAdmin";
            this.Load += new System.EventHandler(this.Changes_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonForBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.TextBox lblDate;
        private System.Windows.Forms.Label labelYourRole;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPoisk;
        private System.Windows.Forms.Button button1;
    }
}