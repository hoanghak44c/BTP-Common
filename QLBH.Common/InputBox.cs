using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Modules
{
    public partial class InputBox : Form
    {
        public string TextData;
        public InputBox()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        public InputBox(string title, string message)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.Text = title;
            this.lblCaption.Text = message;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtData.Text))
            {
                this.TextData = txtData.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Nhập vào dữ liệu");
                txtData.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}