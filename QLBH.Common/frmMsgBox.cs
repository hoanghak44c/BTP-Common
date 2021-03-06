using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using QLBH.Common;
using QLBH.Common.Objects;
using QLBH.Common.Providers;

namespace QLBanHang.Modules.BanHang
{
    public partial class frmMsgBox : DevExpress.XtraEditors.XtraForm
    {
        private static frmMsgBox instance;
        public static frmMsgBox Instance
        {
            get { return instance ?? (instance = new frmMsgBox()); }
        }

        public frmMsgBox()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_BangGia_ApDung_Load(object sender, EventArgs e)
        {
        }
        public void ShowMessage(string content)
        {
            this.txtComment.Text = content;
            this.ShowDialog();
        }
        public void ShowMessage(string content, string title)
        {
            this.txtComment.Text = content;
            this.Text = title;
            this.ShowDialog();
        }
    }
}