namespace WarehouseApp
{
    partial class Changes
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelForPanel = new System.Windows.Forms.Label();
            this.labelForPeriod = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.panelForDateTimePicker = new System.Windows.Forms.Panel();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelForDateTimePicker = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelForDateTimePicker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.OliveDrab;
            this.panelTop.Controls.Add(this.labelForPanel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 64);
            this.panelTop.TabIndex = 0;
            // 
            // labelForPanel
            // 
            this.labelForPanel.AutoSize = true;
            this.labelForPanel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForPanel.Location = new System.Drawing.Point(11, 8);
            this.labelForPanel.Name = "labelForPanel";
            this.labelForPanel.Size = new System.Drawing.Size(163, 35);
            this.labelForPanel.TabIndex = 0;
            this.labelForPanel.Text = "Изменения";
            this.labelForPanel.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelForPeriod
            // 
            this.labelForPeriod.AutoSize = true;
            this.labelForPeriod.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelForPeriod.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForPeriod.Location = new System.Drawing.Point(44, 89);
            this.labelForPeriod.Name = "labelForPeriod";
            this.labelForPeriod.Size = new System.Drawing.Size(107, 32);
            this.labelForPeriod.TabIndex = 1;
            this.labelForPeriod.Text = "Период";
            this.labelForPeriod.Click += new System.EventHandler(this.labelForPeriod_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(182, 30);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // panelForDateTimePicker
            // 
            this.panelForDateTimePicker.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelForDateTimePicker.Controls.Add(this.labelForDateTimePicker);
            this.panelForDateTimePicker.Controls.Add(this.dateTimePickerTo);
            this.panelForDateTimePicker.Controls.Add(this.dateTimePickerFrom);
            this.panelForDateTimePicker.Location = new System.Drawing.Point(319, 85);
            this.panelForDateTimePicker.Name = "panelForDateTimePicker";
            this.panelForDateTimePicker.Size = new System.Drawing.Size(428, 45);
            this.panelForDateTimePicker.TabIndex = 3;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(238, 6);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(181, 30);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // labelForDateTimePicker
            // 
            this.labelForDateTimePicker.AutoSize = true;
            this.labelForDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForDateTimePicker.Location = new System.Drawing.Point(200, 6);
            this.labelForDateTimePicker.Name = "labelForDateTimePicker";
            this.labelForDateTimePicker.Size = new System.Drawing.Size(32, 23);
            this.labelForDateTimePicker.TabIndex = 4;
            this.labelForDateTimePicker.Text = "по";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 136);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(800, 314);
            this.dgv.TabIndex = 4;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Changes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panelForDateTimePicker);
            this.Controls.Add(this.labelForPeriod);
            this.Controls.Add(this.panelTop);
            this.Name = "Changes";
            this.Text = "Changes";
            this.Load += new System.EventHandler(this.Changes_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelForDateTimePicker.ResumeLayout(false);
            this.panelForDateTimePicker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelForPanel;
        private System.Windows.Forms.Label labelForPeriod;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Panel panelForDateTimePicker;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelForDateTimePicker;
        private System.Windows.Forms.DataGridView dgv;
    }
}