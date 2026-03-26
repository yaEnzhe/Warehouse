namespace WarehouseApp.Forms
{
    partial class ShipmentFormAdmin
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelToShipment = new System.Windows.Forms.Label();
            this.buttonToHold = new System.Windows.Forms.Button();
            this.buttonToBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.buttonToAddInTable = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.warehouseDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.warehouseDataSet1 = new WarehouseApp.warehouseDataSet1();
            this.buttonToDeleteShipment = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.labelToShipment);
            this.panel1.Controls.Add(this.buttonToHold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 33);
            this.panel1.TabIndex = 0;
            // 
            // labelToShipment
            // 
            this.labelToShipment.AutoSize = true;
            this.labelToShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelToShipment.Location = new System.Drawing.Point(131, 5);
            this.labelToShipment.Name = "labelToShipment";
            this.labelToShipment.Size = new System.Drawing.Size(86, 22);
            this.labelToShipment.TabIndex = 2;
            this.labelToShipment.Text = "Отгрузка";
            // 
            // buttonToHold
            // 
            this.buttonToHold.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonToHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToHold.Location = new System.Drawing.Point(662, 0);
            this.buttonToHold.Name = "buttonToHold";
            this.buttonToHold.Size = new System.Drawing.Size(140, 33);
            this.buttonToHold.TabIndex = 1;
            this.buttonToHold.Text = "Провести";
            this.buttonToHold.UseVisualStyleBackColor = false;
            this.buttonToHold.Click += new System.EventHandler(this.buttonToHold_Click);
            // 
            // buttonToBack
            // 
            this.buttonToBack.BackColor = System.Drawing.Color.Brown;
            this.buttonToBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToBack.Location = new System.Drawing.Point(0, 0);
            this.buttonToBack.Name = "buttonToBack";
            this.buttonToBack.Size = new System.Drawing.Size(125, 33);
            this.buttonToBack.TabIndex = 2;
            this.buttonToBack.Text = "Назад";
            this.buttonToBack.UseVisualStyleBackColor = false;
            this.buttonToBack.Click += new System.EventHandler(this.buttonToBack_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.datePicker);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 50);
            this.panel2.TabIndex = 3;
            // 
            // datePicker
            // 
            this.datePicker.CalendarMonthBackground = System.Drawing.Color.DarkGray;
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(112, 11);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(156, 28);
            this.datePicker.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Дата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 22);
            this.label1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.txtCustomer);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(406, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 50);
            this.panel3.TabIndex = 4;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.DarkGray;
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomer.Location = new System.Drawing.Point(84, 14);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(259, 28);
            this.txtCustomer.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Кому";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Добавить товар:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Поиск";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Кол-во:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(12, 169);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(217, 37);
            this.panel4.TabIndex = 9;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.DarkGray;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(77, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(127, 22);
            this.txtSearch.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel5.Controls.Add(this.txtQuantity);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(287, 169);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 37);
            this.panel5.TabIndex = 10;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.DarkGray;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Location = new System.Drawing.Point(82, 8);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(127, 22);
            this.txtQuantity.TabIndex = 9;
            // 
            // buttonToAddInTable
            // 
            this.buttonToAddInTable.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonToAddInTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToAddInTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToAddInTable.Location = new System.Drawing.Point(546, 169);
            this.buttonToAddInTable.Name = "buttonToAddInTable";
            this.buttonToAddInTable.Size = new System.Drawing.Size(218, 36);
            this.buttonToAddInTable.TabIndex = 11;
            this.buttonToAddInTable.Text = "Добавить в список";
            this.buttonToAddInTable.UseVisualStyleBackColor = false;
            this.buttonToAddInTable.Click += new System.EventHandler(this.buttonToAddInTable_Click);
            // 
            // dgv
            // 
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.DataSource = this.warehouseDataSet1BindingSource;
            this.dgv.Location = new System.Drawing.Point(0, 225);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(801, 170);
            this.dgv.TabIndex = 12;
            // 
            // warehouseDataSet1BindingSource
            // 
            this.warehouseDataSet1BindingSource.DataSource = this.warehouseDataSet1;
            this.warehouseDataSet1BindingSource.Position = 0;
            // 
            // warehouseDataSet1
            // 
            this.warehouseDataSet1.DataSetName = "warehouseDataSet1";
            this.warehouseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonToDeleteShipment
            // 
            this.buttonToDeleteShipment.BackColor = System.Drawing.Color.Brown;
            this.buttonToDeleteShipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToDeleteShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToDeleteShipment.Location = new System.Drawing.Point(561, 401);
            this.buttonToDeleteShipment.Name = "buttonToDeleteShipment";
            this.buttonToDeleteShipment.Size = new System.Drawing.Size(203, 41);
            this.buttonToDeleteShipment.TabIndex = 13;
            this.buttonToDeleteShipment.Text = "Удалить отгрузку";
            this.buttonToDeleteShipment.UseVisualStyleBackColor = false;
            this.buttonToDeleteShipment.Click += new System.EventHandler(this.buttonToDeleteShipment_Click);
            // 
            // ShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonToDeleteShipment);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.buttonToAddInTable);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonToBack);
            this.Controls.Add(this.panel1);
            this.Name = "ShipmentForm";
            this.Load += new System.EventHandler(this.Shipment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToHold;
        private System.Windows.Forms.Button buttonToBack;
        private System.Windows.Forms.Label labelToShipment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonToAddInTable;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.BindingSource warehouseDataSet1BindingSource;
        private warehouseDataSet1 warehouseDataSet1;
        private System.Windows.Forms.Button buttonToDeleteShipment;
    }
}