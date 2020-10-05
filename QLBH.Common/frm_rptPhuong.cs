using System;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace QLBH.Common
{
    public partial class frm_rptPhuong : Form
    {
        object rpt;
        ParameterFields Params=null;
        public frm_rptPhuong()
        {
            InitializeComponent();
        }
        public frm_rptPhuong(object pRpt)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = pRpt;
        }
        public frm_rptPhuong(object pRpt,ParameterFields pParams)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = pRpt;
            Params = pParams;

        }
        private void frm_rpt_Load(object sender, EventArgs e)
        {
            if (Params != null) crtView.ParameterFieldInfo = Params;
            crtView.ReportSource = rpt;
        }
    }
}