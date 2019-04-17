namespace InventoryApp.WinUi.view.Inventory
{
    partial class InventoryReport
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
            this.comboInventory = new System.Windows.Forms.ComboBox();
            this.comoboCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblinfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "انبار : ";
            // 
            // comboInventory
            // 
            this.comboInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInventory.FormattingEnabled = true;
            this.comboInventory.Location = new System.Drawing.Point(12, 26);
            this.comboInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboInventory.Name = "comboInventory";
            this.comboInventory.Size = new System.Drawing.Size(426, 29);
            this.comboInventory.TabIndex = 3;
            // 
            // comoboCategory
            // 
            this.comoboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comoboCategory.FormattingEnabled = true;
            this.comoboCategory.Location = new System.Drawing.Point(12, 63);
            this.comoboCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comoboCategory.Name = "comoboCategory";
            this.comoboCategory.Size = new System.Drawing.Size(426, 29);
            this.comoboCategory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "دسته بندی : ";
            // 
            // lblinfo
            // 
            this.lblinfo.Location = new System.Drawing.Point(12, 118);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(561, 439);
            this.lblinfo.TabIndex = 6;
            this.lblinfo.Text = "label3";
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 566);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comoboCategory);
            this.Controls.Add(this.comboInventory);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InventoryReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryReport";
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboInventory;
        private System.Windows.Forms.ComboBox comoboCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblinfo;
    }
}