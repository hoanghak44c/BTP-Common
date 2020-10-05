using QLBH.Core.Form;
namespace QLBanHang.Modules
{
    partial class ExportDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDialog));
            this.chkFormatText = new System.Windows.Forms.CheckBox();
            this.chkFormatDate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFormatDouble = new System.Windows.Forms.CheckBox();
            this.chkFormatInt = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkChon = new System.Windows.Forms.CheckBox();
            this.dgvShop = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAccept = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsClose = new System.Windows.Forms.ToolStripButton();
            this.colApDung = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShop)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkFormatText
            // 
            this.chkFormatText.AutoSize = true;
            this.chkFormatText.Location = new System.Drawing.Point(28, 22);
            this.chkFormatText.Name = "chkFormatText";
            this.chkFormatText.Size = new System.Drawing.Size(410, 17);
            this.chkFormatText.TabIndex = 4;
            this.chkFormatText.Text = "Giữ nguyên định dạng chuỗi số (vd:  Số HĐ: 00123, mặc định chuyển về số 123)";
            this.chkFormatText.UseVisualStyleBackColor = true;
            // 
            // chkFormatDate
            // 
            this.chkFormatDate.AutoSize = true;
            this.chkFormatDate.Location = new System.Drawing.Point(28, 46);
            this.chkFormatDate.Name = "chkFormatDate";
            this.chkFormatDate.Size = new System.Drawing.Size(443, 17);
            this.chkFormatDate.TabIndex = 5;
            this.chkFormatDate.Text = "Hiển thị định dạng ngày tháng đầy đủ (thêm giờ phút giây, mặc định chỉ có ngày th" +
                "áng)";
            this.chkFormatDate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFormatDouble);
            this.groupBox1.Controls.Add(this.chkFormatInt);
            this.groupBox1.Controls.Add(this.chkFormatDate);
            this.groupBox1.Controls.Add(this.chkFormatText);
            this.groupBox1.Location = new System.Drawing.Point(11, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 123);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Định dạng dữ liệu";
            // 
            // chkFormatDouble
            // 
            this.chkFormatDouble.AutoSize = true;
            this.chkFormatDouble.Location = new System.Drawing.Point(28, 94);
            this.chkFormatDouble.Name = "chkFormatDouble";
            this.chkFormatDouble.Size = new System.Drawing.Size(433, 17);
            this.chkFormatDouble.TabIndex = 8;
            this.chkFormatDouble.Text = "Định dạng số thập phân (thêm dấu ngăn cách phần trăm, nghin,..., phần thập phân)";
            this.chkFormatDouble.UseVisualStyleBackColor = true;
            // 
            // chkFormatInt
            // 
            this.chkFormatInt.AutoSize = true;
            this.chkFormatInt.Location = new System.Drawing.Point(28, 70);
            this.chkFormatInt.Name = "chkFormatInt";
            this.chkFormatInt.Size = new System.Drawing.Size(337, 17);
            this.chkFormatInt.TabIndex = 7;
            this.chkFormatInt.Text = "Định dạng số nguyên (thêm dấu ngăn cách phần trăm, nghin,...)";
            this.chkFormatInt.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkChon);
            this.groupBox2.Controls.Add(this.dgvShop);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 274);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn các cột dữ liệu kết xuất báo cáo";
            // 
            // chkChon
            // 
            this.chkChon.AutoSize = true;
            this.chkChon.Location = new System.Drawing.Point(404, 14);
            this.chkChon.Name = "chkChon";
            this.chkChon.Size = new System.Drawing.Size(94, 17);
            this.chkChon.TabIndex = 45;
            this.chkChon.Text = "chọn/bỏ chọn";
            this.chkChon.UseVisualStyleBackColor = true;
            this.chkChon.CheckedChanged += new System.EventHandler(this.chkChon_CheckedChanged);
            // 
            // dgvShop
            // 
            this.dgvShop.AllowUserToAddRows = false;
            this.dgvShop.AllowUserToDeleteRows = false;
            this.dgvShop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colApDung,
            this.colField,
            this.colCaption});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShop.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShop.Location = new System.Drawing.Point(8, 34);
            this.dgvShop.Name = "dgvShop";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShop.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShop.RowHeadersWidth = 20;
            this.dgvShop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShop.Size = new System.Drawing.Size(490, 234);
            this.dgvShop.TabIndex = 86;
            this.dgvShop.Click += new System.EventHandler(this.dgvShop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cột dữ liệu";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAccept,
            this.toolStripSeparator2,
            this.tlsClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(529, 25);
            this.toolStrip1.TabIndex = 64;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAccept
            // 
            this.tsbAccept.Image = ((System.Drawing.Image)(resources.GetObject("tsbAccept.Image")));
            this.tsbAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAccept.Name = "tsbAccept";
            this.tsbAccept.Size = new System.Drawing.Size(108, 22);
            this.tsbAccept.Text = "&Chấp nhận (F2)";
            this.tsbAccept.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsClose
            // 
            this.tlsClose.Image = ((System.Drawing.Image)(resources.GetObject("tlsClose.Image")));
            this.tlsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsClose.Name = "tlsClose";
            this.tlsClose.Size = new System.Drawing.Size(87, 22);
            this.tlsClose.Text = "Thoát (F12)";
            this.tlsClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colApDung
            // 
            this.colApDung.HeaderText = "Áp dụng";
            this.colApDung.Name = "colApDung";
            this.colApDung.Width = 60;
            // 
            // colField
            // 
            this.colField.HeaderText = "Mã cột";
            this.colField.Name = "colField";
            this.colField.ReadOnly = true;
            this.colField.Width = 140;
            // 
            // colCaption
            // 
            this.colCaption.HeaderText = "Tên cột báo cáo";
            this.colCaption.Name = "colCaption";
            this.colCaption.ReadOnly = true;
            this.colCaption.Width = 245;
            // 
            // ExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 444);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lựa chọn kết xuất báo cáo";
            this.Load += new System.EventHandler(this.InputDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShop)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFormatText;
        private System.Windows.Forms.CheckBox chkFormatDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkFormatDouble;
        private System.Windows.Forms.CheckBox chkFormatInt;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkChon;
        private System.Windows.Forms.DataGridView dgvShop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAccept;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlsClose;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colApDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colField;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaption;
    }
}