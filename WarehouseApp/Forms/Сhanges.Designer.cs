namespace WarehouseApp.Forms
{
    partial class Сhanges
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
            this.buttonToHold = new System.Windows.Forms.Button();
            this.buttonToBack = new System.Windows.Forms.Button();
            this.labelToShipment = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 40);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(392, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 40);
            this.panel3.TabIndex = 4;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Кому";
            // 
            // Сhanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonToBack);
            this.Controls.Add(this.panel1);
            this.Name = "Сhanges";
            this.Load += new System.EventHandler(this.Сhanges_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

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
    }
}