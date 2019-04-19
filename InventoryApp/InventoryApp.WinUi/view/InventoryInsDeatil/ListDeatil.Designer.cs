namespace InventoryApp.WinUi.view.InventoryInsDeatil
{
    partial class ListDeatil
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
            this.lblType = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lbldDate = new System.Windows.Forms.Label();
            this.lblInventoryTitle = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(794, 17);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "label1";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProducts
            // 
            this.lblProducts.Location = new System.Drawing.Point(12, 202);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(794, 217);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "label1";
            this.lblProducts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbldDate
            // 
            this.lbldDate.Location = new System.Drawing.Point(501, 59);
            this.lbldDate.Name = "lbldDate";
            this.lbldDate.Size = new System.Drawing.Size(305, 22);
            this.lbldDate.TabIndex = 2;
            this.lbldDate.Text = "label2";
            // 
            // lblInventoryTitle
            // 
            this.lblInventoryTitle.Location = new System.Drawing.Point(515, 93);
            this.lblInventoryTitle.Name = "lblInventoryTitle";
            this.lblInventoryTitle.Size = new System.Drawing.Size(291, 26);
            this.lblInventoryTitle.TabIndex = 3;
            this.lblInventoryTitle.Text = "label2";
            // 
            // lblShow
            // 
            this.lblShow.Location = new System.Drawing.Point(12, 165);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(794, 26);
            this.lblShow.TabIndex = 4;
            this.lblShow.Text = "کالا ها";
            this.lblShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListDeatil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 428);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.lblInventoryTitle);
            this.Controls.Add(this.lbldDate);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListDeatil";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ListDeatil_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lbldDate;
        private System.Windows.Forms.Label lblInventoryTitle;
        private System.Windows.Forms.Label lblShow;
    }
}