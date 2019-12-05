namespace PharmacySystem
{
    partial class frmViewRoster
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
            this.cmboWeekNum = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpHi = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstSunday = new System.Windows.Forms.ListView();
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExit = new System.Windows.Forms.Button();
            this.lstSaturday = new System.Windows.Forms.ListView();
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstFriday = new System.Windows.Forms.ListView();
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstTuesday = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstThursday = new System.Windows.Forms.ListView();
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstMonday = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstWednesday = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpHi.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PharmacySystem.Properties.Resources.medex_Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 134);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // cmboWeekNum
            // 
            this.cmboWeekNum.FormattingEnabled = true;
            this.cmboWeekNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52"});
            this.cmboWeekNum.Location = new System.Drawing.Point(323, 45);
            this.cmboWeekNum.Name = "cmboWeekNum";
            this.cmboWeekNum.Size = new System.Drawing.Size(179, 21);
            this.cmboWeekNum.TabIndex = 43;
            this.cmboWeekNum.Text = "Select Week...";
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Image = global::PharmacySystem.Properties.Resources.gear;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(519, 45);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 28);
            this.btnLoad.TabIndex = 44;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // grpHi
            // 
            this.grpHi.Controls.Add(this.lblUserName);
            this.grpHi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHi.ForeColor = System.Drawing.Color.DarkOrange;
            this.grpHi.Location = new System.Drawing.Point(605, 12);
            this.grpHi.Name = "grpHi";
            this.grpHi.Size = new System.Drawing.Size(146, 90);
            this.grpHi.TabIndex = 45;
            this.grpHi.TabStop = false;
            this.grpHi.Text = "Hi";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUserName.Location = new System.Drawing.Point(1, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(68, 16);
            this.lblUserName.TabIndex = 28;
            this.lblUserName.Text = "username";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTime);
            this.groupBox3.Controls.Add(this.lblDate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(757, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 90);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stats";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date: \r\n___________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(8, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time: \r\n___________________";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 461);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roster";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Roster";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstSunday);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.lstSaturday);
            this.groupBox2.Controls.Add(this.lstFriday);
            this.groupBox2.Controls.Add(this.lstTuesday);
            this.groupBox2.Controls.Add(this.lstThursday);
            this.groupBox2.Controls.Add(this.lstMonday);
            this.groupBox2.Controls.Add(this.lstWednesday);
            this.groupBox2.Location = new System.Drawing.Point(13, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(901, 331);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lstSunday
            // 
            this.lstSunday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader43});
            this.lstSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSunday.GridLines = true;
            this.lstSunday.Location = new System.Drawing.Point(751, 22);
            this.lstSunday.Margin = new System.Windows.Forms.Padding(4);
            this.lstSunday.Name = "lstSunday";
            this.lstSunday.Size = new System.Drawing.Size(116, 218);
            this.lstSunday.TabIndex = 7;
            this.lstSunday.UseCompatibleStateImageBehavior = false;
            this.lstSunday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "Sunday";
            this.columnHeader43.Width = 112;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::PharmacySystem.Properties.Resources.cross;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(351, 266);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 29);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstSaturday
            // 
            this.lstSaturday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader42});
            this.lstSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSaturday.GridLines = true;
            this.lstSaturday.Location = new System.Drawing.Point(627, 22);
            this.lstSaturday.Margin = new System.Windows.Forms.Padding(4);
            this.lstSaturday.Name = "lstSaturday";
            this.lstSaturday.Size = new System.Drawing.Size(116, 218);
            this.lstSaturday.TabIndex = 6;
            this.lstSaturday.UseCompatibleStateImageBehavior = false;
            this.lstSaturday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Saturday";
            this.columnHeader42.Width = 112;
            // 
            // lstFriday
            // 
            this.lstFriday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader35});
            this.lstFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFriday.GridLines = true;
            this.lstFriday.Location = new System.Drawing.Point(503, 22);
            this.lstFriday.Margin = new System.Windows.Forms.Padding(4);
            this.lstFriday.Name = "lstFriday";
            this.lstFriday.Size = new System.Drawing.Size(116, 218);
            this.lstFriday.TabIndex = 5;
            this.lstFriday.UseCompatibleStateImageBehavior = false;
            this.lstFriday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "Friday";
            this.columnHeader35.Width = 112;
            // 
            // lstTuesday
            // 
            this.lstTuesday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTuesday.GridLines = true;
            this.lstTuesday.Location = new System.Drawing.Point(131, 21);
            this.lstTuesday.Margin = new System.Windows.Forms.Padding(4);
            this.lstTuesday.Name = "lstTuesday";
            this.lstTuesday.Size = new System.Drawing.Size(116, 218);
            this.lstTuesday.TabIndex = 4;
            this.lstTuesday.UseCompatibleStateImageBehavior = false;
            this.lstTuesday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tuesday";
            this.columnHeader2.Width = 112;
            // 
            // lstThursday
            // 
            this.lstThursday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28});
            this.lstThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstThursday.GridLines = true;
            this.lstThursday.Location = new System.Drawing.Point(379, 21);
            this.lstThursday.Margin = new System.Windows.Forms.Padding(4);
            this.lstThursday.Name = "lstThursday";
            this.lstThursday.Size = new System.Drawing.Size(116, 218);
            this.lstThursday.TabIndex = 4;
            this.lstThursday.UseCompatibleStateImageBehavior = false;
            this.lstThursday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Thursday";
            this.columnHeader28.Width = 112;
            // 
            // lstMonday
            // 
            this.lstMonday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMonday.GridLines = true;
            this.lstMonday.Location = new System.Drawing.Point(7, 21);
            this.lstMonday.Margin = new System.Windows.Forms.Padding(4);
            this.lstMonday.Name = "lstMonday";
            this.lstMonday.Size = new System.Drawing.Size(116, 219);
            this.lstMonday.TabIndex = 3;
            this.lstMonday.UseCompatibleStateImageBehavior = false;
            this.lstMonday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Monday";
            this.columnHeader1.Width = 112;
            // 
            // lstWednesday
            // 
            this.lstWednesday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21});
            this.lstWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWednesday.GridLines = true;
            this.lstWednesday.Location = new System.Drawing.Point(255, 21);
            this.lstWednesday.Margin = new System.Windows.Forms.Padding(4);
            this.lstWednesday.Name = "lstWednesday";
            this.lstWednesday.Size = new System.Drawing.Size(116, 218);
            this.lstWednesday.TabIndex = 3;
            this.lstWednesday.UseCompatibleStateImageBehavior = false;
            this.lstWednesday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Wednesday";
            this.columnHeader21.Width = 112;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // frmViewRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpHi);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cmboWeekNum);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmViewRoster";
            this.Text = "frmViewRoster";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpHi.ResumeLayout(false);
            this.grpHi.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmboWeekNum;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox grpHi;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstSunday;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView lstSaturday;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ListView lstFriday;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ListView lstTuesday;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lstThursday;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ListView lstMonday;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstWednesday;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.Timer timer1;
    }
}