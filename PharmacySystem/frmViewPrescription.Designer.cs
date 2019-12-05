namespace PharmacySystem
{
    partial class frmViewPrescription
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClosePresc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PharmacySystem.Properties.Resources.image428;
            this.pictureBox1.Location = new System.Drawing.Point(11, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(503, 546);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClosePresc
            // 
            this.btnClosePresc.Image = global::PharmacySystem.Properties.Resources.cross;
            this.btnClosePresc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClosePresc.Location = new System.Drawing.Point(217, 578);
            this.btnClosePresc.Margin = new System.Windows.Forms.Padding(2);
            this.btnClosePresc.Name = "btnClosePresc";
            this.btnClosePresc.Size = new System.Drawing.Size(84, 23);
            this.btnClosePresc.TabIndex = 1;
            this.btnClosePresc.Text = "Close";
            this.btnClosePresc.UseVisualStyleBackColor = true;
            this.btnClosePresc.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmViewPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 612);
            this.Controls.Add(this.btnClosePresc);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmViewPrescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedEx PHARMACY MANAGEMNT SYSTEM - VIEW PRESCRIPTION";
            this.Load += new System.EventHandler(this.frmViewPrescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClosePresc;
    }
}