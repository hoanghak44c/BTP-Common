using System;
using System.Windows.Forms;
using DevExpress.Utils;
using QLBH.Common.Providers;

namespace QLBH.Common.UserControls
{
    [ToolboxTabName("QLBH Controls")]
    public partial class UCCodeGenerate : UserControl
    {
        private bool isProgrammaticSet;

        public UCCodeGenerate()
        {
            InitializeComponent();
            txtSoPhieu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtSoPhieu_ButtonClick);
            txtSoPhieu.KeyDown += new KeyEventHandler(txtSoPhieu_KeyDown);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            txtSoPhieu.Width = this.Width - 2;
        }

        void txtSoPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !isProgrammaticSet)
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(Prefix, TableName, FieldName);
        }

        void txtSoPhieu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(!isProgrammaticSet)
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(Prefix, TableName, FieldName);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.DesignMode && !String.IsNullOrEmpty(Prefix))
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(Prefix, TableName, FieldName);
        }

        public new string Text
        {
            get { return txtSoPhieu.Text; }
            set
            {
                txtSoPhieu.Text = value;
                isProgrammaticSet = true;
            }
        }

        public void ReSet()
        {
            txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(Prefix, TableName, FieldName);
            isProgrammaticSet = false;
        }

        public string Prefix { get; set; }

        public string TableName { get; set; }

        public string FieldName { get; set; }
    }
}
