using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using DevExpress.XtraEditors.Repository;
using QLBH.Common.Providers;
//using System.Linq;
//using DevExpress.Xpo;

namespace QLBH.Common
{
    /// <summary>
    /// Khai báo các phương thức thủ tục chung của hệ thống
    /// </summary>
    public class clsUtils
    {
        #region Variable
        //private static int countTab = 0;
        #endregion

        #region Kiem tra empty của text
        public static Boolean TextEmpty(Control ControlError, String ErrorText, DXErrorProvider ErrorProvider)
        {
            Boolean result;
            if (string.IsNullOrEmpty(ControlError.Text))
            {
                ErrorProvider.SetError(ControlError, ErrorText);
                ControlError.Focus();
                result = false;
            }
            else result = true;
            return result;
        }
        #endregion

        #region kiểm tra ID nhập vào
        public static Boolean TestID(string Value)
        {
            Boolean result = true;
            string[] sTest = Value.Split(' ');
            if (sTest.Length > 1)
                result = false;
            return result;
        }


        #endregion

        //loại bỏ ký co dấu và khoảng chách trống 
        //Nguyễn hải

        #region Method Loai tieng viet
        private static readonly string[] VietnameseSigns = new string[]

        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"

        };

        public static string RemoveSign4VietnameseString(string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return str;

        }

        public static string Ma(string strOld)
        {
            string strNew = RemoveSign4VietnameseString(strOld);
            string kyHieu = "";
            string[] words;
            words = strNew.Split(' ');
            foreach (string word in words)
            {
                kyHieu += word;
            }
            return kyHieu;
        }

        public static string StrSpace(string strOld)
        {
            string strNew = strOld;
            string kyHieu = "";
            string[] words;
            words = strNew.Split(' ');
            foreach (string word in words)
            {
                kyHieu += word;
            }
            return kyHieu.ToUpper();
        }

        public static Boolean CheckPass(string strPass)
        {
            Boolean result = true;
            string parter = "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{7,15}$";
            Regex rx = new Regex(parter, RegexOptions.IgnoreCase);

            if (!rx.IsMatch(strPass))
                result = false;

            return result;
        }

        #endregion
        //******************TUANNA********************
        //Bat cac phim tat
        public void EscKeyDown(object sender, KeyEventArgs e)
        {
            MethodInfo myMethodInfo;
            string methodName = "";
            if (e.Control == true)
            {
                //switch (e.KeyCode)
                //{
                //    case Keys.C:
                //        MessageBox.Show("You have pressed ctrl-C!");
                //        return;
                //        break;
                //    case Keys.X:
                //        MessageBox.Show("You have pressed ctrl-X!");
                //        return;
                //}
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        //Phim tat danh cho Help
                        break;
                    case Keys.F2:
                        methodName = "btnSave_Click";
                        break;
                    case Keys.F3:
                        if (sender.GetType().Name == "frmDMDauNhonTau" || sender.GetType().Name == "frmDMNhienLieuTau" || sender.GetType().Name == "frmDMPhuTungTau" || sender.GetType().Name == "frmDMVatTuTau")
                        {
                            methodName = "btnSaoChep_Click";
                        }
                        else
                        {
                            methodName = "btnAdd_Click";
                        }

                        break;
                    case Keys.F4:
                        methodName = "btnEdit_Click";
                        break;
                    case Keys.F5:
                        break;
                    case Keys.F6:
                        break;
                    case Keys.F7:
                        break;
                    case Keys.F8:
                        methodName = "btnDelete_Click";
                        break;
                    case Keys.F9:
                        methodName = "btnTimkiem_Click";
                        break;
                    case Keys.F10:
                        break;
                    case Keys.F11:
                        break;
                    case Keys.F12:
                        break;
                    case Keys.Escape:
                        sender.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, sender, null);
                        break;
                    case Keys.Enter:
                        if (!(sender.GetType().Name.Substring(0, 8) == "frmDanhM" || sender.GetType().Name.Substring(0, 5) == "frmDM"))
                        {
                            SendKeys.Send("{TAB}");
                            e.Handled = true;
                            return;
                        }
                        else if (sender.GetType().Name.Substring(0, 8) == "frmDanhM" || sender.GetType().Name.Substring(0, 5) == "frmDM")
                        {
                            SendKeys.Send("{F9}");
                            e.Handled = true;
                            return;
                        }
                        break;
                    //case Keys.ControlKey:
                    //    bool flag;
                    //    if (e.KeyCode == Keys.C)
                    //    {
                    //        sender.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, sender, null);
                    //    }
                    //    break;
                }
                try
                {
                    myMethodInfo = sender.GetType().GetMethod(methodName, new Type[] { typeof(object), typeof(EventArgs) });
                    myMethodInfo.Invoke(sender, new object[] { sender, e });
                }
                catch
                { }

            }

        }
        //Cac Message chung
        public static void MsgCanhBao(string strMessage)
        {
            MessageBox.Show(strMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MsgThongBao(string strMessage)
        {
            MessageBox.Show(strMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult MsgXoa(string strMessage)
        {
            return (MessageBox.Show(strMessage, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
        }
        ////
        //**********************************************
        #region

        public static void FixDesign(TreeList treelist, ControlNavigator controlNavigator, DevExpress.XtraEditors.HScrollBar hScrollBar)
        {
            treelist.Controls.Add(hScrollBar);
            treelist.Controls.Add(controlNavigator);

            //hScrollBar
            hScrollBar.Top = 357;
            hScrollBar.Left = controlNavigator.Width;
            hScrollBar.Width = treelist.Width - controlNavigator.Width - 2;


            //Navigator

            controlNavigator.Top = 357;
            controlNavigator.Left = 2;
        }

        #endregion

        /// <summary>
        /// Lấy về ngày hiện tại
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDate()
        {
            string sCurrentDay = System.DateTime.Now.Day.ToString();
            string sCurrentMonth = System.DateTime.Now.Month.ToString();
            string sCurrentYear = System.DateTime.Now.Year.ToString();

            if (sCurrentDay.Length < 2)
                sCurrentDay = "0" + sCurrentDay;
            if (sCurrentMonth.Length < 2)
                sCurrentMonth = "0" + sCurrentMonth;
            while (sCurrentYear.Length < 4)
                sCurrentYear = "0" + sCurrentYear;
            return sCurrentMonth + "/" + sCurrentDay + "/" + sCurrentYear;
        }

        public static int IntValue(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return System.Int32.Parse(str);
            }
            return 0;
        }
        public static int IntValue(object obj)
        {
            try
            {
                if ((obj != null) && (obj.ToString() != ""))
                {
                    return System.Int32.Parse(obj.ToString());
                }
            }
            catch (Exception ex) { return 0; }
            return 0;
        }

        public static object DateValue(DateTime obj)
        {
            if (obj.Equals((DateTime)SqlDateTime.Null) || obj.Equals(DateTime.MinValue))
                return DBNull.Value;
            return obj;
        }

        public static object NowValue(DateTime obj)
        {
            if (obj.Equals((DateTime)SqlDateTime.Null) || obj.Equals(DateTime.MinValue))
                return CommonProvider.Instance.GetSysDate();
            return obj;
        }

        public static void NullColumnDateTimeGrid(RepositoryItemDateEdit DateTimeControl)
        {
            DateTimeControl.MinValue = new DateTime();
            DateTimeControl.NullDate = DateTime.MinValue;
            DateTimeControl.NullText = string.Empty;
        }

        //pham ngoc minh 
        //12/01/2012
        //Thêm đơn vị tiền tệ
        #region Moneys
        public static string[] Moneys = {"VND","AFA","ALL","AON","ARS","AMD","AUD","EUR","DZD","AZM","BSD","BHD","BDT",
"BYR",
"BZD",
"BMD",
"BTN",
"BOB",
"BAD",
"BWP",
"BRL",
"BND",
"BGL",
"BIF",
"KHR",
"CAD",
"CLP",
"CNY",
"COP",
"CRC",
"HRK",
"CUP",
"CYP",
"CZK",
"DKK",
"DJF",
"DOP",
"ECS",
"EGP",
"SVC",
"ERN",
"EEK",
"ETB",
"FJD",
"GMD",
"GEL",
"GTQ",
"GNS",
"GYD",
"HTG",
"HNL",
"HKD",
"HUF",
"ISK",
"INR",
"IDR",
"IRR",
"IQD",
"ILS",
"JMD",
"JPY",
"JOD",
"KZT",
"KES",
"KPW",
"KWD",
"KGS",
"LAK",
"LVL",
"LTL",
"LBP",
"LSL",
"LRD",
"LYD",
"MOP",
"MKD",
"MWK",
"MYR",
"MVR",
"MTL",
"MRO",
"MUR",
"MXN",
"MDL",
"MNT",
"MAD",
"MZM",
"MMK",
"NAD",
"NPR",
"NZD",
"NIO",
"NGN",
"NOK",
"OMR",
"PKR",
"PAB",
"PYG",
"PEN",
"PHP",
"PLN",
"EUR",
"QAR",
"RON",
"RUB",
"RWF",
"XCD",
"SAR",
"SCR",
"SLL",
"SGD",
"SIT",
"SOS",
"ZAR",
"LKR",
"SDD",
"SRG",
"SZL",
"SEK",
"CHF",
"SYP",
"TWD",
"TJR",
"TZS",
"THB",
"TOP",
"TTD",
"TND",
"TRY",
"TMM",
"AED",
"UGX",
"UAH",
"GBP",
"USD",
"UYU",
"UZS",
"VEB",
"YER",
"YUD",
"ZMK",
"ZWD" };
        #endregion

        public static void ResetAllText(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Name.Contains("txt"))
                    c.Text = string.Empty;
                else if (c.Name.Contains("grc"))
                    ((GridControl)c).DataSource = null;
                else if (c.Name.Contains("dte"))
                {
                    ((DateEdit)c).EditValue = null;
                }
                else if (c.Name.Contains("lue"))
                    ((LookUpEdit)c).EditValue = null;
                if (c.Controls.Count > 0)
                {
                    ResetAllText(c);
                }
            }
        }
        public static void DisableConTrol(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.Enabled = false;
            }
        }
    }
}

    
  

