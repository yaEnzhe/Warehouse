namespace WarehouseApp.Forms
{
    partial class DeliveryHistory
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
            this.labelYourRole = new System.Windows.Forms.Label();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonToBack = new System.Windows.Forms.Button();
            this.labelToShipment = new System.Windows.Forms.Label();
            this.buttonToAddInTable = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDate.Location = new System.Drawing.Point(12, 12);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(207, 22);
            this.txtDate.TabIndex = 18;
            this.txtDate.TabStop = false;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelYourRole
            // 
            this.labelYourRole.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelYourRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYourRole.Location = new System.Drawing.Point(497, 12);
            this.labelYourRole.Name = "labelYourRole";
            this.labelYourRole.Size = new System.Drawing.Size(140, 25);
            this.labelYourRole.TabIndex = 20;
            this.labelYourRole.Text = "Ваша роль:";
            // 
            // labelAdmin
            // 
            this.labelAdmin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.labelAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdmin.Location = new System.Drawing.Point(643, 12);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(164, 25);
            this.labelAdmin.TabIndex = 21;
            this.labelAdmin.Text = "Пользователь";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.buttonToBack);
            this.panel1.Controls.Add(this.labelToShipment);
            this.panel1.Location = new System.Drawing.Point(5, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 33);
            this.panel1.TabIndex = 23;
            // 
            // buttonToBack
            // 
            this.buttonToBack.BackColor = System.Drawing.Color.Brown;
            this.buttonToBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToBack.Location = new System.Drawing.Point(-10, 0);
            this.buttonToBack.Name = "buttonToBack";
            this.buttonToBack.Size = new System.Drawing.Size(122, 33);
            this.buttonToBack.TabIndex = 3;
            this.buttonToBack.Text = "Назад";
            this.buttonToBack.UseVisualStyleBackColor = false;
            this.buttonToBack.Click += new System.EventHandler(this.buttonToBack_Click);
            // 
            // labelToShipment
            // 
            this.labelToShipment.AutoSize = true;
            this.labelToShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelToShipment.Location = new System.Drawing.Point(202, 5);
            this.labelToShipment.Name = "labelToShipment";
            this.labelToShipment.Size = new System.Drawing.Size(100, 25);
            this.labelToShipment.TabIndex = 2;
            this.labelToShipment.Text = "Поставки";
            // 
            // buttonToAddInTable
            // 
            this.buttonToAddInTable.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonToAddInTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToAddInTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToAddInTable.Location = new System.Drawing.Point(80, 100);
            this.buttonToAddInTable.Name = "buttonToAddInTable";
            this.buttonToAddInTable.Size = new System.Drawing.Size(171, 37);
            this.buttonToAddInTable.TabIndex = 24;
            this.buttonToAddInTable.Text = "Новая поставка";
            this.buttonToAddInTable.UseVisualStyleBackColor = false;
            this.buttonToAddInTable.Click += new System.EventHandler(this.buttonToAddInTable_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.ForestGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(484, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 40);
            this.button2.TabIndex = 26;
            this.button2.Text = "История поставок";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(12, 160);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(127, 40);
            this.panel4.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Поиск:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(136, 160);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(245, 40);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.labelPeriod);
            this.panel2.Location = new System.Drawing.Point(406, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 35);
            this.panel2.TabIndex = 37;
            // 
            // labelPeriod
            // 
            this.labelPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPeriod.Location = new System.Drawing.Point(3, 1);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(79, 22);
            this.labelPeriod.TabIndex = 3;
            this.labelPeriod.Text = "Период:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(494, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 27);
            this.label4.TabIndex = 28;
            this.label4.Text = "с";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(527, 170);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(110, 22);
            this.dtpFrom.TabIndex = 38;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(643, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 27);
            this.label1.TabIndex = 39;
            this.label1.Text = "по";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(677, 170);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(110, 22);
            this.dtpTo.TabIndex = 40;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dgvHistory
            // 
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(5, 219);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.Size = new System.Drawing.Size(793, 219);
            this.dgvHistory.TabIndex = 41;
            this.dgvHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellContentClick);
            // 
            // DeliveryHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonToAddInTable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelAdmin);
            this.Controls.Add(this.labelYourRole);
            this.Controls.Add(this.txtDate);
            this.Name = "DeliveryHistory";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label labelYourRole;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToBack;
        private System.Windows.Forms.Label labelToShipment;
        private System.Windows.Forms.Button buttonToAddInTable;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridView dgvHistory;
    }
}