namespace WarehouseApp.Forms
{
    partial class ContentsOfSupplies
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
            this.buttonToBack = new System.Windows.Forms.Button();
            this.labelToShipment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocNumber = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.buttonToBack);
            this.panel1.Controls.Add(this.labelToShipment);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 33);
            this.panel1.TabIndex = 24;
            // 
            // buttonToBack
            // 
            this.buttonToBack.BackColor = System.Drawing.Color.Brown;
            this.buttonToBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToBack.Location = new System.Drawing.Point(680, 0);
            this.buttonToBack.Name = "buttonToBack";
            this.buttonToBack.Size = new System.Drawing.Size(122, 33);
            this.buttonToBack.TabIndex = 3;
            this.buttonToBack.Text = "Закрыть";
            this.buttonToBack.UseVisualStyleBackColor = false;
            this.buttonToBack.Click += new System.EventHandler(this.buttonToBack_Click);
            // 
            // labelToShipment
            // 
            this.labelToShipment.AutoSize = true;
            this.labelToShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelToShipment.Location = new System.Drawing.Point(12, 3);
            this.labelToShipment.Name = "labelToShipment";
            this.labelToShipment.Size = new System.Drawing.Size(203, 29);
            this.labelToShipment.TabIndex = 2;
            this.labelToShipment.Text = "Состав поставки";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 31;
            this.label1.Text = "Дата:";
            // 
            // txtDocNumber
            // 
            this.txtDocNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDocNumber.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDocNumber.Location = new System.Drawing.Point(514, 77);
            this.txtDocNumber.Multiline = true;
            this.txtDocNumber.Name = "txtDocNumber";
            this.txtDocNumber.ReadOnly = true;
            this.txtDocNumber.Size = new System.Drawing.Size(123, 28);
            this.txtDocNumber.TabIndex = 36;
            this.txtDocNumber.TabStop = false;
            this.txtDocNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDate.Location = new System.Drawing.Point(128, 77);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(121, 28);
            this.txtDate.TabIndex = 37;
            this.txtDate.TabStop = false;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(361, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 28);
            this.label3.TabIndex = 40;
            this.label3.Text = "№ документа:";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(0, 127);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(804, 296);
            this.dgvItems.TabIndex = 41;
            // 
            // ContentsOfSupplies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtDocNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "ContentsOfSupplies";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToBack;
        private System.Windows.Forms.Label labelToShipment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocNumber;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvItems;
    }
}