namespace QLBH.Common.UserControls
{
    partial class UCCodeGenerate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSoPhieu = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(0, 3);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSoPhieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)});
            this.txtSoPhieu.Properties.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(339, 20);
            this.txtSoPhieu.TabIndex = 17;
            // 
            // UCCodeGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSoPhieu);
            this.Name = "UCCodeGenerate";
            this.Size = new System.Drawing.Size(339, 26);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.ButtonEdit txtSoPhieu;
    }
}
