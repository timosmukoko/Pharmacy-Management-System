namespace PharmacySystem
{
    partial class frmViewStockItemDetails
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpHi = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grBxItem = new System.Windows.Forms.GroupBox();
            this.txtSale = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPurchaseUnit = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button22 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpHi.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grBxItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PharmacySystem.Properties.Resources.medex_Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(10, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 134);
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // grpHi
            // 
            this.grpHi.Controls.Add(this.lblUserName);
            this.grpHi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHi.ForeColor = System.Drawing.Color.DarkOrange;
            this.grpHi.Location = new System.Drawing.Point(538, 11);
            this.grpHi.Margin = new System.Windows.Forms.Padding(4);
            this.grpHi.Name = "grpHi";
            this.grpHi.Padding = new System.Windows.Forms.Padding(4);
            this.grpHi.Size = new System.Drawing.Size(107, 61);
            this.grpHi.TabIndex = 56;
            this.grpHi.TabStop = false;
            this.grpHi.Text = "Hi";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUserName.Location = new System.Drawing.Point(2, 22);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(68, 16);
            this.lblUserName.TabIndex = 28;
            this.lblUserName.Text = "username";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(675, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 90);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(45, 53);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(68, 16);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "00 : 00 : 00";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(45, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(104, 16);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "01 January 1900";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date: \r\n___________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time: \r\n___________________";
            // 
            // grBxItem
            // 
            this.grBxItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grBxItem.Controls.Add(this.txtSale);
            this.grBxItem.Controls.Add(this.label3);
            this.grBxItem.Controls.Add(this.txtDescription);
            this.grBxItem.Controls.Add(this.label7);
            this.grBxItem.Controls.Add(this.txtVendor);
            this.grBxItem.Controls.Add(this.label8);
            this.grBxItem.Controls.Add(this.txtPurchaseUnit);
            this.grBxItem.Controls.Add(this.label9);
            this.grBxItem.Controls.Add(this.txtQuantity);
            this.grBxItem.Controls.Add(this.txtName);
            this.grBxItem.Controls.Add(this.label10);
            this.grBxItem.Controls.Add(this.txtItemID);
            this.grBxItem.Controls.Add(this.label12);
            this.grBxItem.Controls.Add(this.label13);
            this.grBxItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBxItem.Location = new System.Drawing.Point(10, 207);
            this.grBxItem.Name = "grBxItem";
            this.grBxItem.Size = new System.Drawing.Size(819, 228);
            this.grBxItem.TabIndex = 58;
            this.grBxItem.TabStop = false;
            // 
            // txtSale
            // 
            this.txtSale.AutoSize = true;
            this.txtSale.Location = new System.Drawing.Point(347, 196);
            this.txtSale.Name = "txtSale";
            this.txtSale.Size = new System.Drawing.Size(93, 20);
            this.txtSale.TabIndex = 8;
            this.txtSale.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sale Unit:";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(347, 166);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(65, 20);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "txtEmail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description:";
            // 
            // txtVendor
            // 
            this.txtVendor.AutoSize = true;
            this.txtVendor.Location = new System.Drawing.Point(347, 139);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(72, 20);
            this.txtVendor.TabIndex = 5;
            this.txtVendor.Text = "txtPhone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Vendor:";
            // 
            // txtPurchaseUnit
            // 
            this.txtPurchaseUnit.AutoSize = true;
            this.txtPurchaseUnit.Location = new System.Drawing.Point(347, 112);
            this.txtPurchaseUnit.Name = "txtPurchaseUnit";
            this.txtPurchaseUnit.Size = new System.Drawing.Size(85, 20);
            this.txtPurchaseUnit.TabIndex = 4;
            this.txtPurchaseUnit.Text = "txtAddress";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Purchase Unit:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoSize = true;
            this.txtQuantity.Location = new System.Drawing.Point(347, 86);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(57, 20);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.Text = "txtLast";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(347, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(57, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "txtFirst";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Quantity:";
            // 
            // txtItemID
            // 
            this.txtItemID.AutoSize = true;
            this.txtItemID.Location = new System.Drawing.Point(347, 31);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(74, 20);
            this.txtItemID.TabIndex = 0;
            this.txtItemID.Text = "txtGpRef";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Item Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Item ID:";
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Image = global::PharmacySystem.Properties.Resources.cross;
            this.button22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button22.Location = new System.Drawing.Point(765, 441);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(64, 29);
            this.button22.TabIndex = 60;
            this.button22.Text = "Exit";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmViewStockItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 474);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.grBxItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpHi);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmViewStockItemDetails";
            this.Text = "frmViewStockItemDetails";
            this.Load += new System.EventHandler(this.frmViewStockItemDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpHi.ResumeLayout(false);
            this.grpHi.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grBxItem.ResumeLayout(false);
            this.grBxItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpHi;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grBxItem;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtVendor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtPurchaseUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtQuantity;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtItemID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtSale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Timer timer1;
    }
}