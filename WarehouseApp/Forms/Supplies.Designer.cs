namespace WarehouseApp.Forms
{
    partial class Supplies
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnhistori = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.txtboxcolichestvo = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.txtDate.Text = " ";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelYourRole
            // 
            this.labelYourRole.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelYourRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYourRole.Location = new System.Drawing.Point(513, 9);
            this.labelYourRole.Name = "labelYourRole";
            this.labelYourRole.Size = new System.Drawing.Size(115, 25);
            this.labelYourRole.TabIndex = 19;
            this.labelYourRole.Text = "Ваша роль:";
            // 
            // labelAdmin
            // 
            this.labelAdmin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.labelAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdmin.Location = new System.Drawing.Point(624, 8);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(164, 25);
            this.labelAdmin.TabIndex = 20;
            this.labelAdmin.Text = "Пользователь";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.buttonToBack);
            this.panel1.Controls.Add(this.labelToShipment);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 33);
            this.panel1.TabIndex = 22;
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
            this.buttonToAddInTable.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonToAddInTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToAddInTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToAddInTable.Location = new System.Drawing.Point(30, 105);
            this.buttonToAddInTable.Name = "buttonToAddInTable";
            this.buttonToAddInTable.Size = new System.Drawing.Size(171, 37);
            this.buttonToAddInTable.TabIndex = 23;
            this.buttonToAddInTable.Text = "Новая поставка";
            this.buttonToAddInTable.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(304, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "Импорт из файла";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnhistori
            // 
            this.btnhistori.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnhistori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhistori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnhistori.Location = new System.Drawing.Point(568, 105);
            this.btnhistori.Name = "btnhistori";
            this.btnhistori.Size = new System.Drawing.Size(175, 40);
            this.btnhistori.TabIndex = 25;
            this.btnhistori.Text = "История поставок";
            this.btnhistori.UseVisualStyleBackColor = false;
            this.btnhistori.Click += new System.EventHandler(this.btnhistori_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(88, 329);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(207, 34);
            this.button6.TabIndex = 29;
            this.button6.Text = "Добавить в поставку";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "Товар:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(37, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Количество:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(37, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "Срок годности:";
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(207, 173);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(159, 28);
            this.comboBoxProducts.TabIndex = 33;
            // 
            // lblCat
            // 
            this.lblCat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCat.Location = new System.Drawing.Point(363, 173);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(38, 28);
            this.lblCat.TabIndex = 34;
            this.lblCat.Text = "▼";
            this.lblCat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtboxcolichestvo
            // 
            this.txtboxcolichestvo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtboxcolichestvo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtboxcolichestvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtboxcolichestvo.Location = new System.Drawing.Point(207, 211);
            this.txtboxcolichestvo.Multiline = true;
            this.txtboxcolichestvo.Name = "txtboxcolichestvo";
            this.txtboxcolichestvo.ReadOnly = true;
            this.txtboxcolichestvo.Size = new System.Drawing.Size(194, 33);
            this.txtboxcolichestvo.TabIndex = 35;
            this.txtboxcolichestvo.TabStop = false;
            this.txtboxcolichestvo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(207, 258);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(194, 33);
            this.textBox2.TabIndex = 36;
            this.textBox2.TabStop = false;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgv
            // 
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(407, 173);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(392, 240);
            this.dgv.TabIndex = 37;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(494, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(239, 30);
            this.button3.TabIndex = 38;
            this.button3.Text = "Провести поставку";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Supplies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtboxcolichestvo);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnhistori);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonToAddInTable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelAdmin);
            this.Controls.Add(this.labelYourRole);
            this.Controls.Add(this.txtDate);
            this.Name = "Supplies";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label labelYourRole;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelToShipment;
        private System.Windows.Forms.Button buttonToBack;
        private System.Windows.Forms.Button buttonToAddInTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnhistori;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.TextBox txtboxcolichestvo;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button button3;
    }
}