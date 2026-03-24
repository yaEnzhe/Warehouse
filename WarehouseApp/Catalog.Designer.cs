namespace WarehouseApp
{
    partial class Catalog
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
            this.dgvForTableOfGoods = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonForBack = new System.Windows.Forms.Button();
            this.buttonToAdd = new System.Windows.Forms.Button();
            this.labelOfCatalogOfGoods = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelOfSearch = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForTableOfGoods)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvForTableOfGoods
            // 
            this.dgvForTableOfGoods.AllowUserToAddRows = false;
            this.dgvForTableOfGoods.AllowUserToDeleteRows = false;
            this.dgvForTableOfGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForTableOfGoods.Location = new System.Drawing.Point(0, 123);
            this.dgvForTableOfGoods.MultiSelect = false;
            this.dgvForTableOfGoods.Name = "dgvForTableOfGoods";
            this.dgvForTableOfGoods.ReadOnly = true;
            this.dgvForTableOfGoods.RowHeadersWidth = 51;
            this.dgvForTableOfGoods.RowTemplate.Height = 24;
            this.dgvForTableOfGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvForTableOfGoods.Size = new System.Drawing.Size(800, 258);
            this.dgvForTableOfGoods.TabIndex = 0;
            this.dgvForTableOfGoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForTableOfGoods_CellContentClick);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panelTop.Controls.Add(this.buttonForBack);
            this.panelTop.Controls.Add(this.buttonToAdd);
            this.panelTop.Controls.Add(this.labelOfCatalogOfGoods);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 56);
            this.panelTop.TabIndex = 1;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // buttonForBack
            // 
            this.buttonForBack.BackColor = System.Drawing.Color.Red;
            this.buttonForBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForBack.ForeColor = System.Drawing.Color.Black;
            this.buttonForBack.Location = new System.Drawing.Point(0, -6);
            this.buttonForBack.Name = "buttonForBack";
            this.buttonForBack.Size = new System.Drawing.Size(148, 62);
            this.buttonForBack.TabIndex = 2;
            this.buttonForBack.Text = "Назад";
            this.buttonForBack.UseVisualStyleBackColor = false;
            this.buttonForBack.Click += new System.EventHandler(this.buttonForBack_Click);
            // 
            // buttonToAdd
            // 
            this.buttonToAdd.AutoSize = true;
            this.buttonToAdd.BackColor = System.Drawing.Color.Green;
            this.buttonToAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonToAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonToAdd.Location = new System.Drawing.Point(520, 0);
            this.buttonToAdd.Name = "buttonToAdd";
            this.buttonToAdd.Size = new System.Drawing.Size(280, 56);
            this.buttonToAdd.TabIndex = 1;
            this.buttonToAdd.Text = "+ Добавить товар ";
            this.buttonToAdd.UseVisualStyleBackColor = false;
            this.buttonToAdd.Click += new System.EventHandler(this.buttonToAdd_Click);
            // 
            // labelOfCatalogOfGoods
            // 
            this.labelOfCatalogOfGoods.AutoSize = true;
            this.labelOfCatalogOfGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfCatalogOfGoods.ForeColor = System.Drawing.Color.Black;
            this.labelOfCatalogOfGoods.Location = new System.Drawing.Point(154, 14);
            this.labelOfCatalogOfGoods.Name = "labelOfCatalogOfGoods";
            this.labelOfCatalogOfGoods.Size = new System.Drawing.Size(219, 29);
            this.labelOfCatalogOfGoods.TabIndex = 0;
            this.labelOfCatalogOfGoods.Text = "Каталог товаров";
            this.labelOfCatalogOfGoods.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.Silver;
            this.panelSearch.Controls.Add(this.textBoxSearch);
            this.panelSearch.Controls.Add(this.labelOfSearch);
            this.panelSearch.Location = new System.Drawing.Point(180, 62);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(469, 40);
            this.panelSearch.TabIndex = 2;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.Silver;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(89, 11);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(370, 21);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelOfSearch
            // 
            this.labelOfSearch.AutoSize = true;
            this.labelOfSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfSearch.Location = new System.Drawing.Point(3, 7);
            this.labelOfSearch.Name = "labelOfSearch";
            this.labelOfSearch.Size = new System.Drawing.Size(80, 25);
            this.labelOfSearch.TabIndex = 0;
            this.labelOfSearch.Text = "Поиск:";
            this.labelOfSearch.Click += new System.EventHandler(this.labelOfSearch_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Location = new System.Drawing.Point(52, 405);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(179, 33);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(543, 405);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 33);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Catalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvForTableOfGoods);
            this.Name = "Catalog";
            this.Load += new System.EventHandler(this.Catalog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForTableOfGoods)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvForTableOfGoods;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelOfCatalogOfGoods;
        private System.Windows.Forms.Button buttonToAdd;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label labelOfSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button buttonForBack;
    }
}