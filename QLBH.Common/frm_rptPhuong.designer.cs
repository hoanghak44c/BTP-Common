namespace QLBH.Common
{
    partial class frm_rptPhuong
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
            this.crtView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtView
            // 
            this.crtView.ActiveViewIndex = -1;
            this.crtView.AutoSize = true;
            this.crtView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.crtView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtView.DisplayGroupTree = false;
            this.crtView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtView.Location = new System.Drawing.Point(0, 0);
            this.crtView.Name = "crtView";
            this.crtView.SelectionFormula = "";
            this.crtView.Size = new System.Drawing.Size(648, 381);
            this.crtView.TabIndex = 0;
            this.crtView.ViewTimeSelectionFormula = "";
            // 
            // frm_rptPhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 381);
            this.Controls.Add(this.crtView);
            this.Name = "frm_rptPhuong";
            this.Text = "frm_rpt";
            this.Load += new System.EventHandler(this.frm_rpt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crtView;
    }
}