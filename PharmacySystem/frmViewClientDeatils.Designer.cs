namespace PharmacySystem
{
    partial class frmViewClientDetails
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpHi = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grBxItem = new System.Windows.Forms.GroupBox();
            this.phone = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gpRefNum = new System.Windows.Forms.Label();
            this.nextOfKinPhone = new System.Windows.Forms.Label();
            this.nextOfKinName = new System.Windows.Forms.Label();
            this.cardNumber = new System.Windows.Forms.Label();
            this.med_card = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.Label();
            this.Country = new System.Windows.Forms.Label();
            this.county = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.street = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PPS = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button22 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpHi.SuspendLayout();
            this.grBxItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PharmacySystem.Properties.Resources.medex_Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 134);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(618, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 90);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(44, 53);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(68, 16);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "00 : 00 : 00";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(44, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(104, 16);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "01 January 1900";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date: \r\n___________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time: \r\n___________________";
            // 
            // grpHi
            // 
            this.grpHi.Controls.Add(this.lblUserName);
            this.grpHi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHi.ForeColor = System.Drawing.Color.DarkOrange;
            this.grpHi.Location = new System.Drawing.Point(504, 6);
            this.grpHi.Margin = new System.Windows.Forms.Padding(4);
            this.grpHi.Name = "grpHi";
            this.grpHi.Padding = new System.Windows.Forms.Padding(4);
            this.grpHi.Size = new System.Drawing.Size(107, 61);
            this.grpHi.TabIndex = 55;
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
            // grBxItem
            // 
            this.grBxItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grBxItem.Controls.Add(this.phone);
            this.grBxItem.Controls.Add(this.label14);
            this.grBxItem.Controls.Add(this.gpRefNum);
            this.grBxItem.Controls.Add(this.nextOfKinPhone);
            this.grBxItem.Controls.Add(this.nextOfKinName);
            this.grBxItem.Controls.Add(this.cardNumber);
            this.grBxItem.Controls.Add(this.med_card);
            this.grBxItem.Controls.Add(this.label7);
            this.grBxItem.Controls.Add(this.label6);
            this.grBxItem.Controls.Add(this.label5);
            this.grBxItem.Controls.Add(this.label4);
            this.grBxItem.Controls.Add(this.label3);
            this.grBxItem.Controls.Add(this.txtCountry);
            this.grBxItem.Controls.Add(this.Country);
            this.grBxItem.Controls.Add(this.county);
            this.grBxItem.Controls.Add(this.label8);
            this.grBxItem.Controls.Add(this.street);
            this.grBxItem.Controls.Add(this.label9);
            this.grBxItem.Controls.Add(this.lastName);
            this.grBxItem.Controls.Add(this.firstName);
            this.grBxItem.Controls.Add(this.label10);
            this.grBxItem.Controls.Add(this.PPS);
            this.grBxItem.Controls.Add(this.label12);
            this.grBxItem.Controls.Add(this.label13);
            this.grBxItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBxItem.Location = new System.Drawing.Point(12, 166);
            this.grBxItem.Name = "grBxItem";
            this.grBxItem.Size = new System.Drawing.Size(843, 396);
            this.grBxItem.TabIndex = 57;
            this.grBxItem.TabStop = false;
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Location = new System.Drawing.Point(347, 260);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(24, 20);
            this.phone.TabIndex = 18;
            this.phone.Text = "---";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Phone:";
            // 
            // gpRefNum
            // 
            this.gpRefNum.AutoSize = true;
            this.gpRefNum.Location = new System.Drawing.Point(347, 353);
            this.gpRefNum.Name = "gpRefNum";
            this.gpRefNum.Size = new System.Drawing.Size(24, 20);
            this.gpRefNum.TabIndex = 16;
            this.gpRefNum.Text = "---";
            // 
            // nextOfKinPhone
            // 
            this.nextOfKinPhone.AutoSize = true;
            this.nextOfKinPhone.Location = new System.Drawing.Point(347, 321);
            this.nextOfKinPhone.Name = "nextOfKinPhone";
            this.nextOfKinPhone.Size = new System.Drawing.Size(24, 20);
            this.nextOfKinPhone.TabIndex = 15;
            this.nextOfKinPhone.Text = "---";
            // 
            // nextOfKinName
            // 
            this.nextOfKinName.AutoSize = true;
            this.nextOfKinName.Location = new System.Drawing.Point(347, 289);
            this.nextOfKinName.Name = "nextOfKinName";
            this.nextOfKinName.Size = new System.Drawing.Size(24, 20);
            this.nextOfKinName.TabIndex = 14;
            this.nextOfKinName.Text = "---";
            // 
            // cardNumber
            // 
            this.cardNumber.AutoSize = true;
            this.cardNumber.Location = new System.Drawing.Point(347, 224);
            this.cardNumber.Name = "cardNumber";
            this.cardNumber.Size = new System.Drawing.Size(24, 20);
            this.cardNumber.TabIndex = 13;
            this.cardNumber.Text = "---";
            // 
            // med_card
            // 
            this.med_card.AutoSize = true;
            this.med_card.Location = new System.Drawing.Point(347, 195);
            this.med_card.Name = "med_card";
            this.med_card.Size = new System.Drawing.Size(24, 20);
            this.med_card.TabIndex = 12;
            this.med_card.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "GP Ref Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Next Of Kin phone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Next Of Kin name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Card Number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Med-Card:";
            // 
            // txtCountry
            // 
            this.txtCountry.AutoSize = true;
            this.txtCountry.Location = new System.Drawing.Point(347, 166);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(24, 20);
            this.txtCountry.TabIndex = 5;
            this.txtCountry.Text = "---";
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.Location = new System.Drawing.Point(26, 166);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(68, 20);
            this.Country.TabIndex = 6;
            this.Country.Text = "Country:";
            // 
            // county
            // 
            this.county.AutoSize = true;
            this.county.Location = new System.Drawing.Point(347, 139);
            this.county.Name = "county";
            this.county.Size = new System.Drawing.Size(24, 20);
            this.county.TabIndex = 5;
            this.county.Text = "---";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "County:";
            // 
            // street
            // 
            this.street.AutoSize = true;
            this.street.Location = new System.Drawing.Point(347, 112);
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(24, 20);
            this.street.TabIndex = 4;
            this.street.Text = "---";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Street:";
            // 
            // lastName
            // 
            this.lastName.AutoSize = true;
            this.lastName.Location = new System.Drawing.Point(347, 86);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(24, 20);
            this.lastName.TabIndex = 3;
            this.lastName.Text = "---";
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Location = new System.Drawing.Point(347, 57);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(24, 20);
            this.firstName.TabIndex = 1;
            this.firstName.Text = "---";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Last Name:";
            // 
            // PPS
            // 
            this.PPS.AutoSize = true;
            this.PPS.Location = new System.Drawing.Point(347, 31);
            this.PPS.Name = "PPS";
            this.PPS.Size = new System.Drawing.Size(29, 20);
            this.PPS.TabIndex = 0;
            this.PPS.Text = "----";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "First Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "PPS Number";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Image = global::PharmacySystem.Properties.Resources.cross;
            this.button22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button22.Location = new System.Drawing.Point(791, 568);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(64, 29);
            this.button22.TabIndex = 59;
            this.button22.Text = "Exit";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // frmViewClientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 604);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpHi);
            this.Controls.Add(this.grBxItem);
            this.Name = "frmViewClientDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Client Details";
            this.Load += new System.EventHandler(this.frmViewClientDeatils_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpHi.ResumeLayout(false);
            this.grpHi.PerformLayout();
            this.grBxItem.ResumeLayout(false);
            this.grBxItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpHi;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox grBxItem;
        private System.Windows.Forms.Label txtCountry;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.Label county;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label street;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lastName;
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label PPS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label gpRefNum;
        private System.Windows.Forms.Label nextOfKinPhone;
        private System.Windows.Forms.Label nextOfKinName;
        private System.Windows.Forms.Label cardNumber;
        private System.Windows.Forms.Label med_card;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button22;
    }
}