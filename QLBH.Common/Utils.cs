using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using QLBH.Core.Data;

namespace QLBH.Common
{
    public class Element
    {
        string _key;
        string _value;
        public Element(string key, string value)
        {
            _key = key;
            _value = value;
        }
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
    public class Utils
    {
        public static int SoKhuyenMaiTT;
        #region Thao tac CSDL
        public int ExecuteSQL(string SQL)
        {
            int ID;
            //Connection conn = new Connection();
            //SqlConnection objConnection = Connection.Instance.GetSqlConnection();
            //objConnection.Open();
            IDbCommand Cmd = new GtidCommand(SQL, ConnectionUtil.Instance.GetConnection());
            ID = Common.IntValue(Cmd.ExecuteScalar());
            Cmd.Dispose();
            //objConnection.Close();
            return ID;

        }

        public DataSet getDataSet(string SQL)
        {

            //Connection conn = new Connection();
            //SqlConnection objConnection = Connection.Instance.GetSqlConnection();
            //objConnection.Open();
            GtidDataAdapter Ad = new GtidDataAdapter(new GtidCommand(SQL, ConnectionUtil.Instance.GetConnection()));
            //SqlDataAdapter Ad = new SqlDataAdapter(SQL, Connection.Instance.GetSqlConnection());
            DataSet Ds = new DataSet();
            try
            {
                Ad.Fill(Ds);
                return Ds;
            }
            finally
            {
                Ad.SelectCommand.Dispose();
                Ad.Dispose();
                //objConnection.Close();
            }

        }
        public DataSet getDataSet(string SQL, string TableName)
        {

            //Connection conn = new Connection();
            //SqlConnection objConnection = Connection.Instance.GetSqlConnection();
            //objConnection.Open();
            GtidDataAdapter Ad = new GtidDataAdapter(SQL, ConnectionUtil.Instance.GetConnection());
            DataSet Ds = new DataSet();
            try
            {
                Ad.Fill(Ds, TableName);
                return Ds;
            }
            finally
            {
                Ad.Dispose();
                //objConnection.Close();
            }

        }
        public DataTable getDataTable(string SQL)
        {
            DataSet ds = getDataSet(SQL);
            return ds.Tables[0];
        }
        public int fGetID_sql(string sql)
        {
            DataSet ds = getDataSet(sql);
            System.Data.DataTable tb = null;
            int ID = 0;
            tb = ds.Tables[0];
            if (tb.Rows.Count > 0)
                ID = getInt(tb.Rows[0][0]);
            ds.Dispose();
            return ID;
        }  
        #endregion

        public void CreateStrInsert(ref string ListField, ref string ListValue, string fieldName, string Value, bool CoNhay)
        {
            ListField = ListField + "," + fieldName;
            if (CoNhay == true)
                ListValue = ListValue + ",N'" + Value + "'";
            else
                ListValue = ListValue + "," + Value;
        }
        public void CreateStrInsert1(ref string ListField, ref string ListValue, string fieldName, string Value, bool CoNhay)
        {
            ListField = ListField + "," + fieldName;
            if (CoNhay == true)
                ListValue = ListValue + ",'" + Value + "'";
            else
                ListValue = ListValue + "," + Value;
        }
        public void CreateStrUpdate(ref string st, string fieldName, string Value, bool CoNhay)
        {
            if (CoNhay == true)
                st = st + string.Format(",{0}=N'{1}'", fieldName, Value);
            else
                st = st + string.Format(",{0}={1}", fieldName, Value);
        }
        public void CreateStrUpdate1(ref string st, string fieldName, string Value, bool CoNhay)
        {
            if (CoNhay == true)
                st = st + string.Format(",{0}='{1}'", fieldName, Value);
            else
                st = st + string.Format(",{0}={1}", fieldName, Value);
        }
        #region Cac ham kiem tra
        public bool isNumeric(object bt)
        {
            if (bt == null) return false;
            double rs;
            return double.TryParse(bt.ToString(), out rs);
        }
        public bool isStringNotEmpty(object bt)
        {
            if (bt == null) return false;
            return (bt.ToString().Trim() != "");
        }

        public bool isInStr(string bt, string MauTim)//Tim dang a%bc%d co trong bt
        {
            MauTim = MauTim.Trim();
            //Doan kt ki chuoi dau, chuoi cuoi
            //int k1=MauTim.IndexOf('%');
            //if (k1 == -1)//Tim chinh xac
            //    return (bt == MauTim);
            //if (k1 >= 1)//co chuoi o dau
            //{
            //    string chuoidau = MauTim.Substring(0, k1);
            //    if (bt.IndexOf(chuoidau) != 0) return false;
            //}
            //int k2 = MauTim.LastIndexOf('%');
            //if (k2 < MauTim.Length-1)//co chuoi o cuoi
            //{
            //    string chuoicuoi = MauTim.Substring(k2+1);
            //    if (bt.LastIndexOf(chuoicuoi) != bt.Length-chuoicuoi.Length) return false;
            //}
            //if (k1>0)
            //    MauTim = MauTim.Substring(k1, k2+1-k1);

            while (MauTim.IndexOf("%%") >= 0)
                MauTim = MauTim.Replace("%%", "%");
            MauTim = MauTim.Trim('%');
            string[] arr = MauTim.Split('%');
            int vt, vt1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                vt = bt.IndexOf(arr[i], vt1);
                if (vt < 0) return false;
                vt1 = vt+1;
            }
            return true;
        }


        #endregion

        #region Cac ham lay gia tri
        public int getInt(object bt)
        {
            int rs = 0;
            if (bt != null)
                int.TryParse(bt.ToString(), out rs);
            return rs;
            //try
            //{
            //    if (bt != null)
            //    {
            //        rs = Convert.ToInt32(bt);
            //    }
            //}
            //catch (Exception e)
            //{
            //}
        }
        public string getString(object bt)
        {
            if (bt != null)
                return bt.ToString().Trim();
            else
                return "";
        }
        public float getFloat(object bt)
        {
            float rs = 0;
            if (bt != null)
                float.TryParse(bt.ToString().Trim(), out rs);
            return rs;
        }
        public double getDouble(object bt)
        {
            double rs = 0;
            if (bt != null)
                double.TryParse(bt.ToString().Trim(), out rs);
            return rs;
        }
        public double getDouble1(object bt)
        {
            double rs = 0;
            if (bt != null)
            {
                string str = bt.ToString().Trim().Replace(",", ".");
                //double.TryParse(str.Replace(".", ""), out rs);
                double.TryParse(str, out rs);
            }
            return rs;
        }
        public double getDoubleInt(object bt)
        {
            double rs = 0;
            if (bt != null)
                double.TryParse(bt.ToString().Trim(), out rs);
            return Common.Round(rs);
        }
        public double getDoubleInt1(object bt)
        {
            double rs = 0;
            if (bt != null)
            {
                string str = bt.ToString().Trim().Replace(",","");
                double.TryParse(str.Replace(".",""), out rs);
            }
            return Common.Round(rs);
        }
        public bool isDate(object bt)
        {
            if (bt == null) return false;
            DateTime rs;
            return DateTime.TryParse(bt.ToString().Trim(), out rs);
        }
        public DateTime getDate(object bt)
        {
            DateTime rs;
            if (bt != null)
            {
                if (DateTime.TryParse(bt.ToString().Trim(), out rs))
                    return rs;
                else
                    return DateTime.Parse("1/1/2000");
            }
            return DateTime.Parse("1/1/2000");
        }
        public bool getBool(object bt)
        {
            bool rs;
            if (bt != null)
            {
                if (bool.TryParse(bt.ToString().Trim(), out rs))
                    return rs;
                else
                    return false;
            }
            return false;
        }
        public string DateToString(DateTime d)
        {
            return string.Format("{0}/{1}/{2}", d.Month.ToString(), d.Day.ToString(), d.Year.ToString());
        }
        public string DateToStringLong(DateTime d)
        {
            return string.Format("{0}/{1}/{2} {3}:{4}", d.Month.ToString(), d.Day.ToString(), d.Year.ToString(), d.Hour.ToString(), d.Minute.ToString());
        }
        public string DateTimeToString(DateTime d)
        {
            return d.ToString(new CultureInfo("en-US"));
        }
        public string DateToShortString(DateTime d)
        {
            return string.Format("{0}/{1}/{2}", d.Day.ToString(), d.Month.ToString(), d.Year.ToString());
        }     
        #endregion

        #region Cac ham thao tac combo box
        public void LoadComboBox(ComboBox cbo, string sql)//Lay value cot 0, display cot 1
        {
            DataTable dt = getDataTable(sql);
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;
        }
        public void LoadComboBox(ComboBox cbo, DataTable dt)//Lay value cot 0, display cot 1
        {
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;
        }
        public void LoadComboBox1(ComboBox cbo, string sql)//Lay value cot 0, display cot 1
        {
            DataTable dt = getDataTable(sql);
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
                cbo.SelectedIndex = 0;
        }
        public void LoadComboBox1(ComboBox cbo, DataTable dt)//Lay value cot 0, display cot 1
        {
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
                cbo.SelectedIndex = 0;
        }
        public void SetValueForComboBox(ComboBox cbo, string Value)
        {
            cbo.SelectedValue=Value;
        }
        public void LoadComboBox(ComboBox cbo, string sql, int InsertItemValue, string InsertItemDisplay)//Lay value cot 0, display cot 1
        {
            DataTable dt = getDataTable(sql);
            DataRow r = dt.NewRow();
            r[0] = InsertItemValue;
            r[1] = InsertItemDisplay;
            dt.Rows.InsertAt(r, 0);
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;
        }
        public void LoadComboBox(ComboBox cbo, string sql, string DefaultValue)//Lay value cot 0, display cot 1, gan default
        {
            LoadComboBox(cbo, sql);
            SetValueForComboBox(cbo, DefaultValue);
        }
        public void LoadComboBox(ComboBox cbo, DataTable dt, int InsertItemValue, string InsertItemDisplay)//Lay value cot 0, display cot 1
        {
            DataRow r = dt.NewRow();
            r[0] = InsertItemValue;
            r[1] = InsertItemDisplay;
            dt.Rows.InsertAt(r, 0);
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.DataSource = dt;
        }
        public void LoadComboBox(ComboBox cbo, DataTable dt, string DefaultValue)//Lay value cot 0, display cot 1, gan default
        {
            LoadComboBox(cbo, dt);
            SetValueForComboBox(cbo, DefaultValue);
        }
        public object getValueComboBox(ComboBox cbo)
        {
            if (cbo.SelectedIndex < 0)
                return "";
            else
                return cbo.SelectedValue;
        }
        public int SetSelectRows(DataGridView gv, string colName, string value)
        {
            gv.ClearSelection();
            for (int i = 0; i < gv.Rows.Count; i++)
                if (gv.Rows[i].Cells[colName].Value.ToString() == value)
                {
                    gv.Rows[i].Selected = true;
                    return i;
                }
            return -1;
        }

        #endregion
        public string LayKyHieuThamSo(string MaThamSo)
        {
            DataSet Ds = getDataSet(string.Format("SELECT KyHieu FROM tbl_ThamSo WHERE Code=N'{0}'", MaThamSo));
            string KH = "";
            if (Ds.Tables[0].Rows.Count > 0)
                KH = Ds.Tables[0].Rows[0][0].ToString() + Declare.IdKho;
            Ds.Dispose();
            return KH;
        }
        
    #region Thao tac Report
		public void SetParameterReport(ParameterFields myParams,string ParamName,object ParamValue)
        {
            ParameterField myParam = new ParameterField();
            ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();
              // Add trung tam
            myParam.Name = ParamName;
            myDiscreteValue.Value = ParamValue;
            myParam.CurrentValues.Add(myDiscreteValue);
            myParams.Add(myParam);

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
            return sCurrentDay + "/" + sCurrentMonth + "/" + sCurrentYear;
        }

    }
}
