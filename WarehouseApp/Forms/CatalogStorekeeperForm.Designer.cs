namespace WarehouseApp.Forms
{
    partial class CatalogStorekeeperForm
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
            this.labelTop = new System.Windows.Forms.Label();
            this.buttonForBack = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LimeGreen;
            this.panelTop.Controls.Add(this.labelTop);
            this.panelTop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTop.Location = new System.Drawing.Point(173, -5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(631, 47);
            this.panelTop.TabIndex = 0;
            // 
            // labelTop
            // 
            this.labelTop.AutoSize = true;
            this.labelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTop.ForeColor = System.Drawing.Color.Black;
            this.labelTop.Location = new System.Drawing.Point(15, 14);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(167, 25);
            this.labelTop.TabIndex = 0;
            this.labelTop.Text = "Каталог товаров";
            // 
            // buttonForBack
            // 
            this.buttonForBack.BackColor = System.Drawing.Color.Brown;
            this.buttonForBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForBack.Location = new System.Drawing.Point(-4, -2);
            this.buttonForBack.Name = "buttonForBack";
            this.buttonForBack.Size = new System.Drawing.Size(186, 44);
            this.buttonForBack.TabIndex = 1;
            this.buttonForBack.Text = "Назад";
            this.buttonForBack.UseVisualStyleBackColor = false;
            this.buttonForBack.Click += new System.EventHandler(this.buttonForBack_Click);
            // 
            // dgv
            // 
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(0, 119);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(804, 278);
            this.dgv.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.labelSearch);
            this.panel1.Location = new System.Drawing.Point(162, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 35);
            this.panel1.TabIndex = 6;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Location = new System.Drawing.Point(88, 7);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(384, 22);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSearch.Location = new System.Drawing.Point(14, 4);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(68, 25);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Text = "Поиск";
            this.labelSearch.Click += new System.EventHandler(this.labelSearch_Click);
            // 
            // CatalogStorekeeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.buttonForBack);
            this.Controls.Add(this.panelTop);
            this.MaximizeBox = false;
            this.Name = "CatalogStorekeeperForm";
            this.Load += new System.EventHandler(this.CatalogStorekeeperForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Button buttonForBack;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}