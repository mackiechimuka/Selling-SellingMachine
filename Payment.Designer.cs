namespace SellingStockingMachine
{
    partial class Payment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewSelectedItems = new System.Windows.Forms.DataGridView();
            this.TotalAmountLbl = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtCname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(118, 121);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // txtCname
            // 
            this.txtCname.Location = new System.Drawing.Point(118, 68);
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(150, 20);
            this.txtCname.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LawnGreen;
            this.label3.Location = new System.Drawing.Point(22, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LawnGreen;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Customer Name:";
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(397, 74);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.Size = new System.Drawing.Size(398, 214);
            this.dataGridViewProduct.TabIndex = 1;
            this.dataGridViewProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellDoubleClick);
            // 
            // dataGridViewSelectedItems
            // 
            this.dataGridViewSelectedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectedItems.Location = new System.Drawing.Point(397, 305);
            this.dataGridViewSelectedItems.Name = "dataGridViewSelectedItems";
            this.dataGridViewSelectedItems.Size = new System.Drawing.Size(398, 214);
            this.dataGridViewSelectedItems.TabIndex = 2;
            // 
            // TotalAmountLbl
            // 
            this.TotalAmountLbl.AutoSize = true;
            this.TotalAmountLbl.ForeColor = System.Drawing.Color.LawnGreen;
            this.TotalAmountLbl.Location = new System.Drawing.Point(48, 353);
            this.TotalAmountLbl.Name = "TotalAmountLbl";
            this.TotalAmountLbl.Size = new System.Drawing.Size(31, 13);
            this.TotalAmountLbl.TabIndex = 3;
            this.TotalAmountLbl.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(118, 350);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(150, 20);
            this.txtTotal.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LawnGreen;
            this.label1.Location = new System.Drawing.Point(48, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Payment";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(118, 418);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(150, 20);
            this.txtPayment.TabIndex = 6;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblChange.Location = new System.Drawing.Point(156, 467);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(47, 13);
            this.lblChange.TabIndex = 7;
            this.lblChange.Text = "Change:";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPay.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPay.Location = new System.Drawing.Point(130, 483);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(101, 36);
            this.btnPay.TabIndex = 8;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(801, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(879, 531);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.TotalAmountLbl);
            this.Controls.Add(this.dataGridViewSelectedItems);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.groupBox1);
            this.Name = "Payment";
            this.Text = "Payment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.DataGridView dataGridViewSelectedItems;
        private System.Windows.Forms.Label TotalAmountLbl;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}