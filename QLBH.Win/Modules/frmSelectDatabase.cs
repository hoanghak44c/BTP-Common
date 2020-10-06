using System;
using System.Windows.Forms;
using QLBH.Core.Data;

namespace QLBanHang.Modules
{
    public partial class frmSelectDatabase : DevExpress.XtraEditors.XtraForm
    {
        private bool Ok;

        public frmSelectDatabase()
        {
            InitializeComponent();
        }

        private void cmdDangNhap_Click(object sender, EventArgs e)
        {
            ConnectionUtil.Instance.IsUAT = chkUAT.Checked ? 1 : chkTest1.Checked ? 2 : 3;

            Ok = true;

            this.Close();
        }

        private void frmSelectDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!Ok &&
                
                MessageBox.Show("Bạn chắc chắn không muốn mở ứng dụng nữa?", "Xác nhận", MessageBoxButtons.YesNo,

                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;

                return;
            } 

            if(!Ok) Environment.Exit(100);
        }
    }
}