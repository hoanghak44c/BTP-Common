namespace QLBanHang.Modules
{
    partial class frmSelectDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectDatabase));
            this.label2 = new System.Windows.Forms.Label();
            this.chkUAT = new System.Windows.Forms.RadioButton();
            this.chkTest = new System.Windows.Forms.RadioButton();
            this.cmdDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.chkTest1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(28, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Chọn ứng dụng";
            // 
            // chkUAT
            // 
            this.chkUAT.AutoSize = true;
            this.chkUAT.Checked = true;
            this.chkUAT.Location = new System.Drawing.Point(228, 23);
            this.chkUAT.Name = "chkUAT";
            this.chkUAT.Size = new System.Drawing.Size(60, 17);
            this.chkUAT.TabIndex = 66;
            this.chkUAT.TabStop = true;
            this.chkUAT.Text = "Go Live";
            this.chkUAT.UseVisualStyleBackColor = true;
            // 
            // chkTest
            // 
            this.chkTest.AutoSize = true;
            this.chkTest.Location = new System.Drawing.Point(126, 23);
            this.chkTest.Name = "chkTest";
            this.chkTest.Size = new System.Drawing.Size(46, 17);
            this.chkTest.TabIndex = 65;
            this.chkTest.Text = "Test";
            this.chkTest.UseVisualStyleBackColor = true;
            // 
            // cmdDangNhap
            // 
            this.cmdDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("cmdDangNhap.Image")));
            this.cmdDangNhap.Location = new System.Drawing.Point(136, 55);
            this.cmdDangNhap.Name = "cmdDangNhap";
            this.cmdDangNhap.Size = new System.Drawing.Size(86, 25);
            this.cmdDangNhap.TabIndex = 63;
            this.cmdDangNhap.Text = "Chọn";
            this.cmdDangNhap.Click += new System.EventHandler(this.cmdDangNhap_Click);
            // 
            // chkTest1
            // 
            this.chkTest1.AutoSize = true;
            this.chkTest1.Location = new System.Drawing.Point(176, 24);
            this.chkTest1.Name = "chkTest1";
            this.chkTest1.Size = new System.Drawing.Size(52, 17);
            this.chkTest1.TabIndex = 68;
            this.chkTest1.Text = "Test1";
            this.chkTest1.UseVisualStyleBackColor = true;
            // 
            // frmSelectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 102);
            this.Controls.Add(this.chkTest1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkUAT);
            this.Controls.Add(this.chkTest);
            this.Controls.Add(this.cmdDangNhap);
            this.Name = "frmSelectDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ứng dụng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelectDatabase_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton chkUAT;
        private System.Windows.Forms.RadioButton chkTest;
        private DevExpress.XtraEditors.SimpleButton cmdDangNhap;
        private System.Windows.Forms.RadioButton chkTest1;
    }
}