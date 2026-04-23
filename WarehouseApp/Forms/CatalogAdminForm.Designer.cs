namespace WarehouseApp.Forms
{
    partial class CatalogAdminForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTop = new System.Windows.Forms.Label();
            this.buttonForBack = new System.Windows.Forms.Button();
            this.buttonToAddGood = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.buttonForDelete = new System.Windows.Forms.Button();
            this.buttonForEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblStat = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LimeGreen;
            this.panelTop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTop.Location = new System.Drawing.Point(181, 31);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(386, 30);
            this.panelTop.TabIndex = 0;
            // 
            // labelTop
            // 
            this.labelTop.AutoSize = true;
            this.labelTop.BackColor = System.Drawing.Color.LimeGreen;
            this.labelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTop.ForeColor = System.Drawing.Color.Black;
            this.labelTop.Location = new System.Drawing.Point(188, 33);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(167, 25);
            this.labelTop.TabIndex = 0;
            this.labelTop.Text = "Каталог товаров";
            // 
            // buttonForBack
            // 
            this.buttonForBack.BackColor = System.Drawing.Color.Brown;
            this.buttonForBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForBack.Location = new System.Drawing.Point(-4, 31);
            this.buttonForBack.Name = "buttonForBack";
            this.buttonForBack.Size = new System.Drawing.Size(186, 30);
            this.buttonForBack.TabIndex = 1;
            this.buttonForBack.Text = "Назад";
            this.buttonForBack.UseVisualStyleBackColor = false;
            this.buttonForBack.Click += new System.EventHandler(this.buttonForBack_Click);
            // 
            // buttonToAddGood
            // 
            this.buttonToAddGood.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonToAddGood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToAddGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToAddGood.Location = new System.Drawing.Point(558, 31);
            this.buttonToAddGood.Name = "buttonToAddGood";
            this.buttonToAddGood.Size = new System.Drawing.Size(247, 30);
            this.buttonToAddGood.TabIndex = 2;
            this.buttonToAddGood.Text = "+ Добавить товар";
            this.buttonToAddGood.UseVisualStyleBackColor = false;
            this.buttonToAddGood.Click += new System.EventHandler(this.buttonToAddGood_Click);
            // 
            // dgv
            // 
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(1, 162);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(804, 249);
            this.dgv.TabIndex = 3;
            // 
            // buttonForDelete
            // 
            this.buttonForDelete.BackColor = System.Drawing.Color.Brown;
            this.buttonForDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonForDelete.Location = new System.Drawing.Point(514, 417);
            this.buttonForDelete.Name = "buttonForDelete";
            this.buttonForDelete.Size = new System.Drawing.Size(197, 30);
            this.buttonForDelete.TabIndex = 4;
            this.buttonForDelete.Text = "Удалить";
            this.buttonForDelete.UseVisualStyleBackColor = false;
            this.buttonForDelete.Click += new System.EventHandler(this.buttonForDelete_Click);
            // 
            // buttonForEdit
            // 
            this.buttonForEdit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonForEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForEdit.Location = new System.Drawing.Point(106, 417);
            this.buttonForEdit.Name = "buttonForEdit";
            this.buttonForEdit.Size = new System.Drawing.Size(217, 30);
            this.buttonForEdit.TabIndex = 5;
            this.buttonForEdit.Text = "Редактировать";
            this.buttonForEdit.UseVisualStyleBackColor = false;
            this.buttonForEdit.Click += new System.EventHandler(this.buttonForEdit_Click);
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
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCategory.Location = new System.Drawing.Point(671, 66);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(134, 38);
            this.btnAddCategory.TabIndex = 8;
            this.btnAddCategory.Text = "+ Категория";
            this.btnAddCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCategoria.Location = new System.Drawing.Point(58, 122);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(124, 27);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Категория";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Location = new System.Drawing.Point(181, 122);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(174, 28);
            this.cmbFilterCategory.TabIndex = 10;
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategory_SelectedIndexChanged);
            // 
            // lblCat
            // 
            this.lblCat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCat.Location = new System.Drawing.Point(352, 122);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(59, 28);
            this.lblCat.TabIndex = 11;
            this.lblCat.Text = "▼";
            this.lblCat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblStatus.Location = new System.Drawing.Point(434, 122);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(117, 27);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Статус";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(548, 122);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(174, 28);
            this.cmbFilterStatus.TabIndex = 13;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);
            // 
            // lblStat
            // 
            this.lblStat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStat.Location = new System.Drawing.Point(721, 122);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(52, 28);
            this.lblStat.TabIndex = 14;
            this.lblStat.Text = "▼";
            this.lblStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserRole
            // 
            this.lblUserRole.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUserRole.Location = new System.Drawing.Point(473, 3);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(315, 25);
            this.lblUserRole.TabIndex = 16;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDate.Location = new System.Drawing.Point(12, 3);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(207, 22);
            this.txtDate.TabIndex = 17;
            this.txtDate.TabStop = false;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CatalogAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblUserRole);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.cmbFilterStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonForEdit);
            this.Controls.Add(this.buttonForDelete);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.buttonToAddGood);
            this.Controls.Add(this.buttonForBack);
            this.Controls.Add(this.panelTop);
            this.MaximizeBox = false;
            this.Name = "CatalogAdminForm";
            this.Load += new System.EventHandler(this.Catalog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Button buttonForBack;
        private System.Windows.Forms.Button buttonToAddGood;
        private System.Windows.Forms.DataGridView dgv;
        public System.Windows.Forms.Button buttonForDelete;
        private System.Windows.Forms.Button buttonForEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.TextBox txtDate;
    }
}