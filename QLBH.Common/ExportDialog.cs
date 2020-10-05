using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using QLBH.Common;

namespace QLBanHang.Modules
{
    public partial class ExportDialog : DevExpress.XtraEditors.XtraForm
    {
        private bool showAll = false;
        private GridView dataSource = null;

        public bool FormatText = false;
        public bool FormatDate = false;
        public bool FormatInt = false;
        public bool FormatDouble = false;

        public List<string> ListCaptionSelected = new List<string>();
        public List<string> ListFiledSelected = new List<string>();

        public ExportDialog()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public ExportDialog(GridView dataSource, bool showAll)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.dataSource = dataSource;
            this.showAll = showAll;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            FormatText = chkFormatText.Checked;
            FormatDate = chkFormatDate.Checked;
            FormatInt = chkFormatInt.Checked;
            FormatDouble = chkFormatDouble.Checked;

            ListCaptionSelected = new List<string>();
            ListFiledSelected = new List<string>();
            if (dataSource != null)
            {
                foreach (DataGridViewRow row in dgvShop.Rows)
                {
                    if (Common.BoolValue(row.Cells["colApDung"].Value))
                    {
                        ListCaptionSelected.Add(row.Cells["colCaption"].Value.ToString());
                        ListFiledSelected.Add(row.Cells["colField"].Value.ToString());
                    }
                }

                if (ListFiledSelected.Count == 0)
                {
                    MessageBox.Show("Chưa cột nào được chọn!\nVui lòng chọn ít nhất một cột để kết xuất báo cáo");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void LoadDuLieu()
        {
            dgvShop.Rows.Clear();
            if (dataSource == null) return;
            int count = 0;
            for (int i = 0; i < dataSource.Columns.Count; i++)
            {
                if ((dataSource.Columns[i].Visible || showAll) && !String.IsNullOrEmpty(dataSource.Columns[i].Caption) &&
                    !dataSource.Columns[i].FieldName.ToLower().Equals("checkmarkselection"))
                {
                    int show = dataSource.Columns[i].Visible ? 1 : 0;
                    object[] arr = {show, dataSource.Columns[i].FieldName, dataSource.Columns[i].Caption};
                    dgvShop.Rows.Add(arr);
                    count++;
                }
            }
            chkChon.Checked = count > 0 ? true : false;
            label2.Text = String.Format("Cột dữ liệu ({0})", count);
        }

        private void chkChon_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvShop.Rows)
            {
                row.Cells["colApDung"].Value = chkChon.Checked;
            }
            UpdateInfor();
        }

        private void UpdateInfor()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvShop.Rows)
            {
                if (Common.BoolValue(row.Cells["colApDung"].Value))
                {
                    count++;
                }
            }

            label2.Text = String.Format("Cột dữ liệu ({0})", count);            
        }

        private void dgvShop_Click(object sender, EventArgs e)
        {
            UpdateInfor();
        }
    }
}