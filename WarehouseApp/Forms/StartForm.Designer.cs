namespace WarehouseApp
{
    partial class StartForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.labelHeadline = new System.Windows.Forms.Label();
            this.panelHeadline = new System.Windows.Forms.Panel();
            this.panelHeadline.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnStart.Location = new System.Drawing.Point(242, 209);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(294, 110);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "НАЧАТЬ РАБОТУ";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelHeadline
            // 
            this.labelHeadline.AutoSize = true;
            this.labelHeadline.BackColor = System.Drawing.Color.LimeGreen;
            this.labelHeadline.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeadline.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHeadline.Location = new System.Drawing.Point(196, 10);
            this.labelHeadline.Name = "labelHeadline";
            this.labelHeadline.Size = new System.Drawing.Size(415, 29);
            this.labelHeadline.TabIndex = 3;
            this.labelHeadline.Text = "СКЛАДСКОЙ УЧЕТ КАНЦЕЛЯРИИ";
            this.labelHeadline.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelHeadline
            // 
            this.panelHeadline.BackColor = System.Drawing.Color.LimeGreen;
            this.panelHeadline.Controls.Add(this.labelHeadline);
            this.panelHeadline.Location = new System.Drawing.Point(-4, -1);
            this.panelHeadline.Name = "panelHeadline";
            this.panelHeadline.Size = new System.Drawing.Size(806, 44);
            this.panelHeadline.TabIndex = 4;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelHeadline);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.panelHeadline.ResumeLayout(false);
            this.panelHeadline.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelHeadline;
        private System.Windows.Forms.Panel panelHeadline;
    }
}

