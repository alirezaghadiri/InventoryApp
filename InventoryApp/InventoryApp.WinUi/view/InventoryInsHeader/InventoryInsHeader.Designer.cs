namespace InventoryApp.WinUi.view.InventoryOutsHeader
{
    partial class InventoryOutsHeader
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboInventory = new System.Windows.Forms.ComboBox();
            this.combotype = new System.Windows.Forms.ComboBox();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtdsc = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnchose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.PanelProducts = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comoboCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1017, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "انبار : ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(980, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "نوع رسید : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1007, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "عنوان : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(980, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "توضیحات : ";
            // 
            // comboInventory
            // 
            this.comboInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInventory.FormattingEnabled = true;
            this.comboInventory.Location = new System.Drawing.Point(622, 54);
            this.comboInventory.Name = "comboInventory";
            this.comboInventory.Size = new System.Drawing.Size(321, 29);
            this.comboInventory.TabIndex = 4;
            // 
            // combotype
            // 
            this.combotype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotype.FormattingEnabled = true;
            this.combotype.Location = new System.Drawing.Point(622, 127);
            this.combotype.Name = "combotype";
            this.combotype.Size = new System.Drawing.Size(321, 29);
            this.combotype.TabIndex = 5;
            // 
            // txttitle
            // 
            this.txttitle.Location = new System.Drawing.Point(622, 162);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(321, 28);
            this.txttitle.TabIndex = 6;
            // 
            // txtdsc
            // 
            this.txtdsc.Location = new System.Drawing.Point(622, 264);
            this.txtdsc.Multiline = true;
            this.txtdsc.Name = "txtdsc";
            this.txtdsc.Size = new System.Drawing.Size(321, 142);
            this.txtdsc.TabIndex = 7;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(14, 15);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(84, 31);
            this.btnadd.TabIndex = 9;
            this.btnadd.Text = "افزودن";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(105, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 31);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "صرفنظر";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(520, 135);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(69, 30);
            this.btnAddToList.TabIndex = 11;
            this.btnAddToList.Text = "->";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnchose
            // 
            this.btnchose.Enabled = false;
            this.btnchose.Location = new System.Drawing.Point(622, 194);
            this.btnchose.Name = "btnchose";
            this.btnchose.Size = new System.Drawing.Size(45, 30);
            this.btnchose.TabIndex = 12;
            this.btnchose.Text = "...";
            this.btnchose.UseVisualStyleBackColor = true;
            this.btnchose.Click += new System.EventHandler(this.btnchose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "لیست محصولات : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1009, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "مقدار : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(998, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "نام کالا : ";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(622, 230);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(321, 28);
            this.txtamount.TabIndex = 17;
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(673, 196);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(270, 28);
            this.txtProduct.TabIndex = 18;
            // 
            // PanelProducts
            // 
            this.PanelProducts.Location = new System.Drawing.Point(14, 40);
            this.PanelProducts.Name = "PanelProducts";
            this.PanelProducts.Size = new System.Drawing.Size(500, 479);
            this.PanelProducts.TabIndex = 19;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(14, 526);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 31);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "حذف از لیست";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 567);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 61);
            this.panel1.TabIndex = 20;
            // 
            // comoboCategory
            // 
            this.comoboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comoboCategory.FormattingEnabled = true;
            this.comoboCategory.Location = new System.Drawing.Point(622, 92);
            this.comoboCategory.Name = "comoboCategory";
            this.comoboCategory.Size = new System.Drawing.Size(321, 29);
            this.comoboCategory.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(965, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "دسته بندی : ";
            // 
            // InventoryInsHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 628);
            this.Controls.Add(this.comoboCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.PanelProducts);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnchose);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.txtdsc);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.combotype);
            this.Controls.Add(this.comboInventory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InventoryInsHeader";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.InventoryInsHeader_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboInventory;
        private System.Windows.Forms.ComboBox combotype;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtdsc;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnchose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Panel PanelProducts;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comoboCategory;
        private System.Windows.Forms.Label label6;
    }
}