// <summary>
// Mô tả class: Lớp đối tượng khai báo các hàm dùng chung liên quan đến việc cập nhật dữ liệu, load dữ liệu
// </summary>
// <remarks>
// Người tạo: Nguyen Gia Dang
// Ngày tạo: 03/10/2007
// </remarks>

using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.Shared;
using QLBH.Core.Data;

namespace QLBH.Common
{
    public class DBTools
    {
        public static ConnectionUtil objConn;
        public static Exception _LastError;
        public  enum _IsCheck : byte
        {
            _FALSE = 0,
            _TRUE,
            _EXCEPTION
        }

        #region " Enumerations "
        public enum ExecuteMode
        {
            Insert = 0,
            Update = 1
        }
        #endregion

        #region " Properties "
        public Exception GetLastError
        {
            get { return _LastError; }
        }
        #endregion

        #region " Util Function "
        private static string AddParameters(GtidCommand commandObject, GtidParameter[] commandParameters)
        {
            string ReturnValue = string.Empty;
            int i;
            if ((commandParameters != null))
            {
                for (i = 0; i <= commandParameters.Length - 1; i++)
                {
                    commandObject.Parameters.Add(commandParameters[i]);
                    if (commandParameters[i].Direction == ParameterDirection.Output)
                    {
                        ReturnValue = commandParameters[i].ParameterName;
                    }
                }
            }
            return ReturnValue;
        }

        private static void AddParameters(GtidConnection connectionObject, GtidCommand commandObject, object[] parameterValues)
        {
            connectionObject.Open();
            //SqlCommandBuilder.DeriveParameters(CommandObject);
            connectionObject.Close();
            for (int i = 1; i <= commandObject.Parameters.Count - 1; i++)
            {
                commandObject.Parameters[i].Value = parameterValues[i - 1];
            }
        }

        public static DataSet getData(String tblName)
        {
            String strSql;
            //objConn = new Connection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                strSql = "Select * From " + tblName;
                GtidDataAdapter adap = new GtidDataAdapter(strSql, ConnectionUtil.Instance.GetConnection());

                DataSet ds;
                ds = new DataSet();
                try
                {
                    //SqlConn.Open();
                    adap.Fill(ds, tblName);
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //SqlConn.Close();
                }
                return ds;
            //}
        }

        public static DataSet getData(String tblName, string strsql, params object[] paramValues)
        {

            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = Connection.Instance.GetSqlConnection())
            //{
            GtidDataAdapter adap = new GtidDataAdapter(strsql, ConnectionUtil.Instance.GetConnection());
            
            GtidCommandBuilder.Instance.DeriveParameters(adap.SelectCommand, paramValues);

            DataSet ds;
            ds = new DataSet();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                adap.Fill(ds, tblName);
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }
            finally
            {
                //SqlConn.Close();
            }
            return ds;
            //}
        }

        public static DataSet getData(String tblName,string strsql)
        {
           
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = Connection.Instance.GetSqlConnection())
            //{
            GtidDataAdapter adap = new GtidDataAdapter(strsql.ToUpper(), ConnectionUtil.Instance.GetConnection());
            DataSet ds;
            ds = new DataSet();
            try {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                adap.Fill(ds, tblName);
            }
            catch (Exception ex) {
                _LastError = ex;
            }
            finally
            {
                //SqlConn.Close();
            }
            return ds;
            //}
        }

        public static int FillDataTable(DataTable dataTable, string strsql, params object[] paramValues)
        {

            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = Connection.Instance.GetSqlConnection())
            //{
            GtidDataAdapter adap = new GtidDataAdapter(strsql, ConnectionUtil.Instance.GetConnection());

            GtidCommandBuilder.Instance.DeriveParameters(adap.SelectCommand, paramValues);

            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                return adap.Fill(dataTable);
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return 0;
            }
            finally
            {
                //SqlConn.Close();
            }
            //}
        }

        public static int FillDataTable(DataTable dataTable, string strsql)
        {

            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = Connection.Instance.GetSqlConnection())
            //{
            GtidDataAdapter adap = new GtidDataAdapter(strsql, ConnectionUtil.Instance.GetConnection());
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                return adap.Fill(dataTable);
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return 0;
            }
            finally
            {
                //SqlConn.Close();
            }
            //}
        }

        public static DataSet getData(GtidCommand sql, string TableName)
        {

            GtidDataAdapter adap = new GtidDataAdapter();

            adap.SelectCommand = sql;

            DataSet ds;
            ds = new DataSet();
            try
            {
                adap.Fill(ds, TableName);
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }
            return ds;
        }

        public static void getValue(string sProcedureName, params GtidParameter[] outputs)
        {
            try
            {
                GtidCommand SqlComm = new GtidCommand(sProcedureName, ConnectionUtil.Instance.GetConnection());
                SqlComm.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < outputs.Length; i++ )
                {
                    SqlComm.Parameters.Add(outputs[i]);
                }

                SqlComm.ExecuteNonQuery();

                for (int i = 0; i < outputs.Length; i++)
                {
                    outputs[i].Value = SqlComm.Parameters[i].Value;
                }
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }
        }

        public static string getValue(string strsql, CommandType cmdType)
        {
            IDataReader DataReader = null;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = Connection.Instance.GetSqlConnection())
            //{
            try
            {
                GtidCommand SqlComm = new GtidCommand(strsql, ConnectionUtil.Instance.GetConnection());
                SqlComm.CommandType = cmdType;
                //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                DataReader = SqlComm.ExecuteReader();
                string result = String.Empty;
                if (DataReader.Read())
                {
                    result = DataReader[0].ToString();
                }
                DataReader.Close();
                return result;
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }
            return "";
        }

        public static string getValue(string strsql, params object[] paramValues)
        {
            IDataReader DataReader = null;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = Connection.Instance.GetSqlConnection())
            //{
            try
            {
                GtidCommand SqlComm = new GtidCommand(strsql, ConnectionUtil.Instance.GetConnection());
                
                GtidCommandBuilder.Instance.DeriveParameters(SqlComm, paramValues);

                //SqlComm.CommandType = CommandType.Text;
                //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                DataReader = SqlComm.ExecuteReader();
                string result = String.Empty;
                if (DataReader.Read())
                {
                    result = DataReader[0].ToString();
                }
                DataReader.Close();
                return result;
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }
            finally
            {
                //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
            }
            //}
            return "";
        }

        public static string getValue(string strsql)
        {
            IDataReader DataReader = null;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = Connection.Instance.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(strsql, ConnectionUtil.Instance.GetConnection());
                    SqlComm.CommandType = CommandType.Text;
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    DataReader = SqlComm.ExecuteReader();
                    string result = String.Empty;
                    if (DataReader.Read())
                    {
                        result = DataReader[0].ToString();
                    }
                    DataReader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
            return "";
        }

        public static string getValue(string strsql, GtidCommand sqlcmd, GtidConnection sqlCon)
        {
            string rs = "";
            try
            {
                sqlcmd.CommandText = strsql;
                sqlcmd.CommandType = CommandType.Text;
                IDataReader reader = sqlcmd.ExecuteReader();
                if (reader.Read())
                    rs = reader[0].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }

            return rs;
        }

        public static string getValue(string strsql, SqlCommand sqlcmd, SqlConnection sqlCon)
        {
            string rs = "";
            try
            {
                sqlcmd.CommandText = strsql;
                sqlcmd.CommandType = CommandType.Text;
                SqlDataReader reader = sqlcmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                        rs = reader[0].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }
 
            return rs;
        }

        #endregion

        #region " ExecuteQuery Method "
        // <summary>
        // Chức năng: Thi hành một câu truy vấn
        // </summary>
        // <param name="CommandText">Kiểu string, câu sql cần thực hiện</param>
        // <param name="CommandType">Kiểu CommandType, kiểu của câu truy vấn</param>
        // <returns>null nếu thi hành câu truy vấn bị lỗi, ngược lại, trả lại số bản ghi được thực thi</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static object ExecuteQuery(string CommandText, CommandType CommandType)
        {
            object ReturnValue = false;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
            GtidCommand SqlComm = new GtidCommand(CommandText, ConnectionUtil.Instance.GetConnection());
            SqlComm.CommandType = CommandType;

                try
                {
                    //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                    ReturnValue = SqlComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _LastError = ex; 
                    ReturnValue = null;
                }
                finally
                {
                    //SqlConn.Close();
                }
            //}

            return ReturnValue;
        }

        // <summary>
        // Chức năng: Thi hành một câu truy vấn trong một Connection
        // </summary>
        // <param name="CommandText">Kiểu string, câu sql cần thực hiện</param>
        // <param name="CommandType">Kiểu CommandType, kiểu của câu truy vấn</param>
        // <param name="SqlConn">Kiểu SqlConnection, tên của Connection thực thi</param>
        // <returns>null nếu thi hành câu truy vấn bị lỗi, ngược lại, trả lại số bản ghi được thực thi</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static object ExecuteQuery(string CommandText, CommandType CommandType, SqlConnection SqlConn)
        {
            object ReturnValue = null;
                SqlCommand SqlComm = new SqlCommand(CommandText, SqlConn);
                SqlComm.CommandType = CommandType;

                try
                {
                    ReturnValue = SqlComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    SqlConn.Close();
                }

            return ReturnValue;
        }


        public static object ExecuteQuery(string CommandText, object[] ParameterValues)
        {
            object ReturnValue = null;
            //objConn = new Connection();
            GtidConnection SqlConn = ConnectionUtil.Instance.GetConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(CommandText, SqlConn);
                    SqlComm.CommandType = CommandType.StoredProcedure;
                    AddParameters(SqlConn, SqlComm, ParameterValues);
                    //if (SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                    SqlComm.ExecuteNonQuery();
                    ReturnValue = SqlComm.Parameters[0].Value;
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //SqlConn.Close();
                }

            //}
            return ReturnValue;
        }


        public static object ExecuteQuery(string commandText, CommandType commandType, GtidParameter[] commandParameters)
        {
            object ReturnValue = null;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(commandText, ConnectionUtil.Instance.GetConnection());
                    SqlComm.CommandType = commandType;
                    string OutputParameter = AddParameters(SqlComm, commandParameters);
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    ReturnValue = SqlComm.ExecuteNonQuery();
                    if (!(OutputParameter == string.Empty)) ReturnValue = SqlComm.Parameters[OutputParameter].Value;
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
            return ReturnValue;
        }

        #endregion

        #region " ExecuteReader Method "

        public static object[] ExecuteReader(string commandText, CommandType commandType, GtidParameter[] commandParameters, string[] columns)
        {
            object[] ReturnValue = new object[columns.Length];
            IDataReader DataReader = null;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(commandText, ConnectionUtil.Instance.GetConnection());
                    SqlComm.CommandType = commandType;
                    AddParameters(SqlComm, commandParameters);
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    DataReader = SqlComm.ExecuteReader();
                    int index = 0;
                    while (DataReader.Read())
                    {
                        ReturnValue[index] = DataReader[columns[index]];
                        index += 1;
                    }
                    DataReader.Close();
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    if (!DataReader.IsClosed) DataReader.Close();
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
            return ReturnValue;
        }


        public static object ExecuteReader(string CommandText, CommandType CommandType)
        {
            object[] ReturnValue = null;
            IDataReader DataReader = null;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(CommandText, ConnectionUtil.Instance.GetConnection());
                    SqlComm.CommandType = CommandType;
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    DataReader = SqlComm.ExecuteReader();
                    int index = 0;
                    while (DataReader.Read())
                    {
                        ReturnValue[index] = DataReader[0];
                        index += 1;
                    }
                    DataReader.Close();
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    if(!DataReader.IsClosed) DataReader.Close();
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
            return ReturnValue;
        }

        #endregion


        #region " ExecuteDataSource Method "

        public static int ExecuteDataSource(ExecuteMode executeMode, string commandText, CommandType commandType, GtidParameter[] commandParameters, string tableName, DataSet dataset)
        {
            int ReturnValue = 0;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(commandText, ConnectionUtil.Instance.GetConnection());
                    SqlComm.CommandType = commandType;
                    AddParameters(SqlComm, commandParameters);
                    GtidDataAdapter DataAdapter = new GtidDataAdapter();
                    switch (executeMode)
                    {
                        case ExecuteMode.Insert:
                            DataAdapter.InsertCommand = SqlComm;
                            break;
                        case ExecuteMode.Update:
                            DataAdapter.UpdateCommand = SqlComm;
                            break;
                    }
                    ReturnValue = DataAdapter.Update(dataset, tableName);
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }

            //}
            return ReturnValue;
        }

        #endregion

        #region " FillDataSet Method "

        public static DataSet FillDataSet(string commandText, CommandType commandType, GtidParameter[] commandParameters)
        {
            DataSet returnDataSet = new DataSet();
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand sqlComm = new GtidCommand(commandText, ConnectionUtil.Instance.GetConnection());
                    sqlComm.CommandType = commandType;
                    //if (SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                    AddParameters(sqlComm, commandParameters);
                    GtidDataAdapter dataAdapter = new GtidDataAdapter(sqlComm);
                    dataAdapter.Fill(returnDataSet);
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }

            //}
            return returnDataSet;
        }
        #endregion

        #region " FillDataSet Method "

        public static DataSet FillDataSet(string commandText, CommandType commandType)
        {
            DataSet returnDataSet = new DataSet();
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
           // {
                try
                {
                    GtidCommand sqlComm = new GtidCommand(commandText, ConnectionUtil.Instance.GetConnection());
                    sqlComm.CommandType = commandType;
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    GtidDataAdapter dataAdapter = new GtidDataAdapter(sqlComm);
                    dataAdapter.Fill(returnDataSet);
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
            return returnDataSet;
        }
        #endregion


        #region " Exist data "
        // <summary>
        // Chức năng: Kiểm tra 1 giá trị có tồn tại trong CSDL hay không
        // </summary>
        // <param name="TableName">Kiểu string, tên Table trong CSDL</param>
        // <param name="AttName">Kiểu string, tên thuộc tính của TableName</param>
        // <param name="AttType">Kiểu của thuộc tính AttName</param>
        // <param name="AttValue">Kiểu string, giá trị của thuộc tính</param>
        // <returns>true nếu tồn tại, false nếu không</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static bool ExistData(string TableName, string AttName, System.Type AttType, string AttValue)
        {
            string sql;
            bool ReturnValue = false;
            IDataReader DataReader = null;

            if (AttType.Equals(typeof(string)))
            {
                sql = "Select * From " + TableName + " Where " + AttName + " = '" + AttValue + "'";
            }
            else
            {
                sql = "Select * From " + TableName + " Where " + AttName + " = " + AttValue;
            }

            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(sql, ConnectionUtil.Instance.GetConnection());
                    SqlComm.CommandType = CommandType.Text;
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    DataReader = SqlComm.ExecuteReader();
                    ReturnValue = DataReader.Read();
                    if (!DataReader.IsClosed) DataReader.Close();
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    if (!DataReader.IsClosed) DataReader.Close();
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
            return ReturnValue;
        }

        // <summary>
        // Chức năng: Kiểm tra 1 giá trị có tồn tại trong CSDL hay không
        // </summary>
        // <param name="CommandText">Kiểu string, một câu truy vấn có điều kiện kiểm tra</param>
        // <returns>true nếu tồn tại, false nếu không</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static bool ExistData(string CommandText)
        {
            bool ReturnValue = false;
            IDataReader DataReader = null;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    GtidCommand SqlComm = new GtidCommand(CommandText, ConnectionUtil.Instance.GetConnection());
                    SqlComm.CommandType = CommandType.Text;
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    DataReader = SqlComm.ExecuteReader();
                    ReturnValue = DataReader.Read();
                    if (!DataReader.IsClosed) DataReader.Close();
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
            return ReturnValue;

        }

        #endregion

        #region " Fill Datagrid Method "
        public static void Grid_LoadData(DataGridView GridName, string sql, string tableName)
        {
            DataSet ds;
            DataView dv;
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    ds = new DataSet();
                    dv = new DataView();
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    GtidDataAdapter ad = new GtidDataAdapter(sql, ConnectionUtil.Instance.GetConnection());
                    ad.Fill(ds, tableName);
                    dv.Table = ds.Tables[tableName];
                    GridName.DataSource = dv;
                    //SqlConn.Close();
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }

            //}
        }

        public static void Grid_AddData(DataGridView GridName, string CommandText)
        {
            DataTable dt = new DataTable();
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    GtidDataAdapter da = new GtidDataAdapter(CommandText, ConnectionUtil.Instance.GetConnection());
                    da.Fill(dt);
                    GridName.DataSource = dt;
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
        }

        #endregion

        #region " Fill Listbox or Combobox Method "

        // <summary>
        // Chức năng: Load dữ liệu vào một Combobox hoặc Listbox
        // </summary>
        // <param name="lstName">Kiểu ListControl, là tên Listbox hoặc ComboBox cần load dữ liệu </param>
        // <param name="CommandText">Kiểu string, nguồn dữ liệu để đưa vào Listbox hoặc ComboBox </param>
        // <param name="ValueMember">Kiểu string, trường Id để điều khiển ListControl</param>
        // <param name="DisplayMember">Kiểu string, trường hiển thị ra ListControl </param>
        // <param name="addString">Kiểu string, giá trị sẽ được thêm vào đầu ListControl </param>
        // <param name="SelectedId">Kiểu int, giá trị sẽ được chọn mặc định của ListControl</param>
        // <returns></returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static void List_LoadData(System.Windows.Forms.ListControl lstName, string CommandText, string ValueMember, string DisplayMember, string addString, int SelectedId)
        {
            ListItem itemData = new ListItem();
            GtidCommand SqlComm = null;
            IDataReader DataReader = null;

            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    SqlComm = ConnectionUtil.Instance.GetConnection().CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = CommandText;

                    DataReader = SqlComm.ExecuteReader();
                    if (lstName is ComboBox)
                    {
                        ((ComboBox)lstName).Items.Clear();
                        if (addString != "")
                        {
                            ((ComboBox)lstName).Items.Add(new ListItem(0, addString));
                        }

                        while (DataReader.Read())
                        {
                            ((ComboBox)lstName).Items.Add(new ListItem(int.Parse(DataReader[ValueMember].ToString()), DataReader[DisplayMember].ToString()));
                        }

                        if (SelectedId > 0)
                        {
                            ((ComboBox)lstName).SelectedIndex = SelectedId;
                        }
                        else if ((lstName != null))
                        {
                            //CType(lstName, ComboBox).SelectedIndex = 0
                        }
                    }

                    else
                    {
                        ((ListBox)lstName).Items.Clear();
                        if (addString != "")
                        {
                            ((ListBox)lstName).Items.Add(new ListItem(0, addString));
                        }

                        while (DataReader.Read())
                        {
                            ((ListBox)lstName).Items.Add(new ListItem(int.Parse(DataReader[ValueMember].ToString()), DataReader[DisplayMember].ToString()));
                        }

                        if (SelectedId > 0)
                        {
                            ((ListBox)lstName).SelectedIndex = SelectedId;
                        }
                        else
                        {
                            ((ListBox)lstName).SelectedIndex = 0;
                        }
                    }
                    DataReader.Close();
                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    if(!DataReader.IsClosed) DataReader.Close();
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }
            //}
        }

        public static void List_LoadData(System.Windows.Forms.ListControl lstName, string CommandText, string TableName, string ValueMember, string DisplayMember, string addString, int SelectedId)
        {
            DataTable dt;
            dt = DBTools.getData(TableName, CommandText).Tables[TableName];

            if (dt != null)
            {
                DataRow dr;
                //if (strAdd != "")
                //{
                dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = addString;
                dt.Rows.InsertAt(dr, 0);
                //}
                //dt.Constraints.Add("Temp", dt.Columns[ValueMember], true);
                lstName.DataSource = null;
                lstName.DataSource = dt;
                lstName.ValueMember = ValueMember;
                lstName.DisplayMember = DisplayMember;
                if (SelectedId > 0)
                    lstName.SelectedIndex = SelectedId;
                else
                    lstName.SelectedIndex = 0;


            }

        }


        #endregion


        #region " Fill Datagrid Method "

        // <summary>
        // Chức năng: Load dữ liệu vào một DataGridView
        // </summary>
        // <param name="dgv">Kiểu DataGridView, là tên DataGridView cần load dữ liệu </param>
        // <param name="strDataSource">Kiểu string, là một câu sql chứa các trường cần load </param>
        // <param name="blnSTT">Kiểu bool, là một biến có giá trị true/false. Nếu true có thêm cột STT ở đầu grid, false thì không có </param>
        // <returns></returns>
        // <remarks>
        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Lê Thanh Lương 11/10/2007
        // Sửa trong trường hợp blnSTT bằng false
        // </remarks>

        public static void GridView_LoadData(DataGridView dgv, string strDataSource, bool blnSTT)
        {
            int iNumRecord;
            int iNumColumn;
            object[] sArrTemp;
            string strTableName = "TableTemp";
            DataSet ds = new DataSet();
            //objConn = new Connection();
            //SqlConnection SqlConn = Connection.Instance.GetSqlConnection();
            //using (SqlConnection SqlConn = objConn.GetSqlConnection())
            //{
                try
                {
                    //if (!(SqlConn.State == ConnectionState.Open)) SqlConn.Open();
                    GtidDataAdapter da = new GtidDataAdapter(strDataSource, ConnectionUtil.Instance.GetConnection());
                    da.Fill(ds, strTableName);

                    dgv.Rows.Clear();
                    iNumColumn = ds.Tables[strTableName].Columns.Count;

                    for (iNumRecord = 0; iNumRecord <= ds.Tables[strTableName].Rows.Count - 1; iNumRecord++)
                    {
                        sArrTemp = new object[iNumColumn + 1];
                        if (blnSTT)
                        {
                            sArrTemp[0] = iNumRecord + 1;
                            //for (iNumColumn = 0; iNumColumn <= ds.Tables[strTableName].Columns.Count - 1; iNumColumn++)
                            for (int i = 0; i <= iNumColumn - 1; i++)
                            {
                                //sArrTemp = new string[iNumColumn + 1];
                                sArrTemp[i + 1] = ds.Tables[strTableName].Rows[iNumRecord][i];
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= iNumColumn - 1; i++)
                            {
                           //     sArrTemp = new string[iNumColumn + 1];
                                sArrTemp[i] = ds.Tables[strTableName].Rows[iNumRecord][i];
                            }

                        }
                        dgv.Rows.Add(sArrTemp);
                    }
                    ds.Tables.Remove(strTableName);

                }
                catch (Exception ex)
                {
                    _LastError = ex;
                }
                finally
                {
                    //if (!(SqlConn.State == ConnectionState.Closed)) SqlConn.Close();
                }


            //}
        }
        
        public static bool InsertRecord(SqlCommand sqlInsertCommand,SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                sqlInsertCommand.Connection = cnn;
                sqlInsertCommand.Transaction = tran;
                sqlInsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            return true;
        }

        public  static bool InsertRecord(GtidCommand sqlInsertCommand)
        {
            //SqlTransaction sqltran = null;
            //SqlConnection SqlConn=null;
         
            //SqlConn = Connection.Instance.GetSqlConnection();
            try
            {
                //if(SqlConn.State== ConnectionState.Closed) SqlConn.Open();
                //sqltran = SqlConn.BeginTransaction();
                sqlInsertCommand.Connection = ConnectionUtil.Instance.GetConnection();
                //sqlInsertCommand.Transaction = sqltran;
                sqlInsertCommand.ExecuteNonQuery();
                //sqltran.Commit();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                //sqltran.Rollback();
                return false;     
            }
            finally
            {
                //sqltran.Dispose();
                //SqlConn.Dispose();
            }
            return true;    
        }
       
        public static bool UpdateRecord(GtidCommand sqlUpdateCommand)
        {
            //SqlTransaction sqltran = null;
            GtidConnection SqlConn=null;

            SqlConn = ConnectionUtil.Instance.GetConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                //sqltran = SqlConn.BeginTransaction();
                sqlUpdateCommand.Connection = SqlConn;
                sqlUpdateCommand.ExecuteNonQuery();
                //sqltran.Commit();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                //sqltran.Rollback();
                return false;
            }
            finally
            {
                //sqltran.Dispose();
                //SqlConn.Dispose();
            }
            return true;
        }


        public static bool UpdateRecord(GtidCommand sqlUpdateCommand, GtidConnection cnn, GtidTransaction tran)
        {
            try
            {
                sqlUpdateCommand.Connection = cnn;
                sqlUpdateCommand.Transaction = tran;
                sqlUpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }

            return true;
        }

        public static bool UpdateRecord(SqlCommand sqlUpdateCommand,SqlConnection cnn,SqlTransaction tran)
        {
            try
            {
                sqlUpdateCommand.Connection = cnn;
                sqlUpdateCommand.Transaction = tran;
                sqlUpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }

            return true;
        }

        public static bool DeleteRecord(GtidCommand sqlDeleteCommand, GtidConnection cnn, GtidTransaction tran)
        {
            try
            {
                sqlDeleteCommand.Connection = cnn;
                sqlDeleteCommand.Transaction = tran;
                sqlDeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            return true;
        }

        public static bool DeleteRecord(SqlCommand sqlDeleteCommand, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                sqlDeleteCommand.Connection = cnn;
                sqlDeleteCommand.Transaction = tran;
                sqlDeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            return true;
        }

        public static bool DeleteRecord(string  SQLString, SqlConnection cnn, SqlTransaction tran)
        {
            SqlCommand sqlDeleteCommand = new SqlCommand(SQLString);
            try
            {
                sqlDeleteCommand.CommandType = CommandType.Text;
                sqlDeleteCommand.Connection = cnn;
                sqlDeleteCommand.Transaction = tran;
                sqlDeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            return true;
        }
        
        public static bool DeleteRecord(GtidCommand sqlDeleteCommand)
        {
            try
            {
                sqlDeleteCommand.Connection = ConnectionUtil.Instance.GetConnection();
                sqlDeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            return true;
        }

        public static _IsCheck CheckExistsRecord(GtidCommand sqlIsCheckCommand)
        {
            try
            {
                sqlIsCheckCommand.Connection = ConnectionUtil.Instance.GetConnection();
                sqlIsCheckCommand.ExecuteNonQuery();

                if (sqlIsCheckCommand.Parameters[1].Value == null) throw new Exception("Can not check it");
                if (Object.Equals(sqlIsCheckCommand.Parameters[1].Value, 1))
                    return _IsCheck._TRUE;
                else
                    return _IsCheck._FALSE;
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return _IsCheck._EXCEPTION;
            }
            finally
            {
                //SqlConn.Dispose();
            }
        }
        
        // <summary>
        // Chức năng: Load dữ liệu vào một DataGridView
        // </summary>
        // <param name="dgv">Kiểu DataGridView, là tên DataGridView cần load dữ liệu </param>
        // <param name="arrData">Kiểu string, là một câu sql chứa các trường cần load </param>
        // <param name="intRow">Kiểu int, là biến chứa số dòng của mảng </param>
        // <param name="intCol">Kiểu int, là biến chứa số cột của mảng </param>
        // <returns></returns>
        // <remarks>
        // Người tạo: Lê Thanh Lương
        // Ngày tạo: 10/10/2007
        // Người sửa cuối: Lê Thanh Lương
        // </remarks>
        public static void GridView_LoadData(DataGridView dgv, object[] strArrTemp)
        {

            try
            {
                dgv.Rows.Add(strArrTemp);

            }
            catch (Exception ex)
            {
                _LastError = ex;
            }

        }

        // <summary>
        // Chức năng: Sửa dữ liệu của dòng trong DataGridView
        // </summary>
        // <param name="dgv">Kiểu DataGridView, là tên DataGridView cần load dữ liệu </param>
        // <param name="arrData">Kiểu string, là một câu sql chứa các trường cần load </param>
        // <param name="intRow">Kiểu int, là biến chứa số dòng của mảng </param>
        // <param name="intCol">Kiểu int, là biến chứa số cột của mảng </param>
        // <returns></returns>
        // <remarks>
        // Người tạo: Lê Thanh Lương
        // Ngày tạo: 19/10/2007
        // Người sửa cuối: Lê Thanh Lương
        // </remarks>
        public static void GridView_EditData(DataGridView dgv, object[] strArrTemp)
        {
            try
            {
                for (int i = 0; i < strArrTemp.Length; i++)
                {
                    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[i].Value = strArrTemp[i];
                }
            }
            catch (Exception ex)
            {
                _LastError = ex;
            }
          
        }

        public static DataSet GetData(GtidCommand[] sqlSelectCommand, string[] strTableName)
        {
            GtidTransaction sqltran = null;
            GtidConnection SqlConn = null;
            GtidDataAdapter da = new GtidDataAdapter();
            DataSet ds = new DataSet();

            SqlConn = ConnectionUtil.Instance.GetConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                sqltran = ConnectionUtil.Instance.BeginTransaction();
                for (byte i = 0; i <= (byte)sqlSelectCommand.Length - 1; i++)
                {
                    sqlSelectCommand[i].Connection = SqlConn;
                    sqlSelectCommand[i].Transaction = sqltran;
                    da.SelectCommand = sqlSelectCommand[i];
                    da.Fill(ds, strTableName[i]);
                }

                sqltran.Commit();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                sqltran.Rollback();
                return null;
            }
            finally
            {
                sqltran.Dispose();
                //SqlConn.Dispose();
                da.Dispose();
            }
            return ds;
        }

        public static bool _InsertData(DataTable dtBangDuLieu, GtidCommand sqlInsertCommand)
        {
            GtidTransaction sqltran = null;
            GtidConnection SqlConn = null;
            GtidDataAdapter da = new GtidDataAdapter();

            SqlConn = ConnectionUtil.Instance.GetConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                sqltran = SqlConn.BeginTransaction();
                sqlInsertCommand.Connection = SqlConn;
                sqlInsertCommand.Transaction = sqltran;
                da.InsertCommand = sqlInsertCommand ;
                da.Update(dtBangDuLieu);

                sqltran.Commit();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                sqltran.Rollback();
                return false;
            }
            finally
            {
                sqltran.Dispose();
                //SqlConn.Dispose();
                da.Dispose();
            }
            return true;
        }

        public static bool _InsertData(DataTable dtBangDuLieuTra, DataTable dtBangDuLieuCon, string strTenTruong1,
                                       string strTenTruong2, GtidCommand sqlInsertCommandTra, GtidCommand sqlInsertCommandCon)
        {
            GtidTransaction sqltran = null;
            GtidConnection SqlConn = null;
            GtidDataAdapter da = new GtidDataAdapter();

            SqlConn = ConnectionUtil.Instance.GetConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                sqltran = SqlConn.BeginTransaction();
                sqlInsertCommandTra.Connection = SqlConn;
                sqlInsertCommandTra.Transaction = sqltran;
                da.InsertCommand = sqlInsertCommandTra;
                da.Update(dtBangDuLieuTra);

                for (int i = 0; i <= dtBangDuLieuCon.Rows.Count - 1; i++)
                {
                    dtBangDuLieuCon.Rows[i][strTenTruong1] = dtBangDuLieuTra.Rows[0][strTenTruong2];
                }

                sqlInsertCommandCon.Connection = SqlConn;
                sqlInsertCommandCon.Transaction = sqltran;
                da.InsertCommand = sqlInsertCommandCon;
                da.Update(dtBangDuLieuCon);

                sqltran.Commit();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                sqltran.Rollback();
                return false;
            }
            finally
            {
                sqltran.Dispose();
                //SqlConn.Dispose();
                da.Dispose();
            }
            return true;
        }

        public static bool _InsertData(DataTable dtBangDuLieuTra, DataTable dtBangDuLieuCon, string strTenTruong1,
                                       string strTenTruong2, GtidCommand sqlInsertCommandTra, GtidCommand sqlInsertCommandCon,
                                       GtidConnection cnn,GtidTransaction tran)
        {
            GtidDataAdapter da = new GtidDataAdapter();
            try
            {
                sqlInsertCommandTra.Connection = cnn;
                sqlInsertCommandTra.Transaction = tran;
                da.InsertCommand = sqlInsertCommandTra;
                da.Update(dtBangDuLieuTra);

                for (int i = 0; i <= dtBangDuLieuCon.Rows.Count - 1; i++)
                {
                    dtBangDuLieuCon.Rows[i][strTenTruong1] = dtBangDuLieuTra.Rows[0][strTenTruong2];
                }

                sqlInsertCommandCon.Connection = cnn;
                sqlInsertCommandCon.Transaction = tran;
                da.InsertCommand = sqlInsertCommandCon;
                da.Update(dtBangDuLieuCon);

            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            finally
            {
                da.Dispose();
            }
            return true;
        }

        public static bool UpDateTable(GtidCommand sqlUpdateCommand)
        {
            //SqlTransaction sqltran = null;
            GtidConnection SqlConn = null;
            GtidDataAdapter da = new GtidDataAdapter();

            SqlConn = ConnectionUtil.Instance.GetConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                //sqltran = SqlConn.BeginTransaction();
                sqlUpdateCommand.Connection = SqlConn;
                sqlUpdateCommand.ExecuteNonQuery();

                //sqltran.Commit();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                //sqltran.Rollback();
                return false;
            }
            finally
            {
                //sqltran.Dispose();
                //SqlConn.Dispose();
                da.Dispose();
            }
            return true;
        }
        public static bool UpDateTable(GtidCommand sqlUpdateCommandTra, DataTable dtBangDuLieuCon,
                                       GtidCommand sqlInsertCommandCon, GtidCommand sqlDeleteCommandCon, string strParameter1, string strParameter2)
        {
            GtidTransaction sqltran = null;
            GtidConnection SqlConn = null;
            GtidDataAdapter da = new GtidDataAdapter();

            SqlConn = ConnectionUtil.Instance.GetConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                sqltran = SqlConn.BeginTransaction();
                sqlUpdateCommandTra.Connection = SqlConn;
                sqlUpdateCommandTra.Transaction = sqltran;
                sqlUpdateCommandTra.ExecuteNonQuery();

                sqlDeleteCommandCon.Connection = SqlConn;
                sqlDeleteCommandCon.Transaction = sqltran;
                sqlDeleteCommandCon.Parameters[strParameter2].Value = sqlUpdateCommandTra.Parameters[strParameter1].Value;
                sqlDeleteCommandCon.ExecuteNonQuery();

                sqlInsertCommandCon.Connection = SqlConn;
                sqlInsertCommandCon.Transaction = sqltran;
                da.InsertCommand = sqlInsertCommandCon;
                da.Update(dtBangDuLieuCon);

                sqltran.Commit();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                sqltran.Rollback();
                return false;
            }
            finally
            {
                sqltran.Dispose();
                //SqlConn.Dispose();
                da.Dispose();
            }
            return true;
        }

        public static bool UpDateTable(SqlCommand sqlUpdateCommandTra, DataTable dtBangDuLieuCon,
                                      SqlCommand sqlInsertCommandCon, SqlCommand sqlDeleteCommandCon,
                                      string strParameter1, string strParameter2,SqlConnection cnn,SqlTransaction tran)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                sqlUpdateCommandTra.Connection = cnn;
                sqlUpdateCommandTra.Transaction = tran;
                sqlUpdateCommandTra.ExecuteNonQuery();

                sqlDeleteCommandCon.Connection = cnn;
                sqlDeleteCommandCon.Transaction = tran;
                sqlDeleteCommandCon.Parameters[strParameter2].Value = sqlUpdateCommandTra.Parameters[strParameter1].Value;
                sqlDeleteCommandCon.ExecuteNonQuery();

                sqlInsertCommandCon.Connection = cnn;
                sqlInsertCommandCon.Transaction = tran;
                da.InsertCommand = sqlInsertCommandCon;
                da.Update(dtBangDuLieuCon);
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            finally
            {
                da.Dispose();
            }
            return true;
        }

        public static object ExecuteScalar(string strSQl)
        {
            //SqlConnection SqlConn = null;
            GtidCommand sqlCmd = new GtidCommand(strSQl);
            object Return_;
            //SqlConn = Connection.Instance.GetSqlConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                sqlCmd.Connection = ConnectionUtil.Instance.GetConnection();
                Return_ = sqlCmd.ExecuteScalar();
            }
            catch(Exception ex) 
            {
                _LastError = ex;
                Return_ = "";
            }
            return Return_;
        }

        public static object ExecuteScalar(GtidCommand strcmd)
        {
            //SqlConnection SqlConn = null;
            object Return_;
            //SqlConn = Connection.Instance.GetSqlConnection();
            try
            {
                //if(SqlConn.State== ConnectionState.Closed) SqlConn.Open();
                strcmd.Connection = ConnectionUtil.Instance.GetConnection();
                Return_ = strcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                Return_ = "";
            }
            return Return_;
        }

        public static object ExecuteScalar(GtidCommand strcmd,GtidTransaction tran)
        {
            //SqlConnection SqlConn = null;
            object Return_;
            //SqlConn = Connection.Instance.GetSqlConnection();
            try
            {
                //if(SqlConn.State == ConnectionState.Closed) SqlConn.Open();
                strcmd.Connection = ConnectionUtil.Instance.GetConnection();
                strcmd.Transaction = tran;
                Return_ = strcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                Return_ = "";
            }
            return Return_;
        }
#endregion

        #region "Report functions "
        public static void LoadReportFile(string rptFilePath, string sql, CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer)
        {
            if (!System.IO.File.Exists(rptFilePath))
            {
                //MessageBox.Show(new Exception(" Đường dẫn file: " + rptFilePath + " không đúng. Hãy kiểm tra lại!"),Declare.titleError,MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw (new Exception(" Đường dẫn file: " + rptFilePath + " không đúng. Hãy kiểm tra lại!"));
            }
            else
            {
                //Connection objConn = new Connection();
                GtidDataAdapter da = new GtidDataAdapter(sql, ConnectionUtil.Instance.GetConnection());
                DataSet ds = new DataSet();
                da.Fill(ds);
                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rptDocument.Load(rptFilePath);
                rptDocument.SetDataSource(ds.Tables[0]);
                rptViewer.ShowCloseButton = false;
                rptViewer.ShowRefreshButton = false;
                rptViewer.ShowGroupTreeButton = false;
                rptViewer.DisplayGroupTree = false;
                rptViewer.DisplayToolbar = true;
                rptViewer.ReportSource = rptDocument;
            }
        }

        public static void LoadReportFile(string rptFilePath, DataSet ds, CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer)
        {
            if (!System.IO.File.Exists(rptFilePath))
            {
                //MessageBox.Show(new Exception(" Đường dẫn file: " + rptFilePath + " không đúng. Hãy kiểm tra lại!"),Declare.titleError,MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw (new Exception(" Đường dẫn file: " + rptFilePath + " không đúng. Hãy kiểm tra lại!"));
            }
            else
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rptDocument.Load(rptFilePath);
                rptDocument.SetDataSource(ds);
                rptViewer.ShowCloseButton = false;
                rptViewer.ShowRefreshButton = false;
                rptViewer.ShowGroupTreeButton = false;
                rptViewer.DisplayGroupTree = false;
                rptViewer.DisplayToolbar = true;
                rptViewer.ReportSource = rptDocument;
            }
        }

        public static void LoadReportFile(string rptFilePath, string sql, CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer, CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument)
        {
            if (!System.IO.File.Exists(rptFilePath))
            {
                //MessageBox.Show(new Exception(" Đường dẫn file: " + rptFilePath + " không đúng. Hãy kiểm tra lại!"),Declare.titleError,MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw (new Exception(" Đường dẫn file: " + rptFilePath + " không đúng. Hãy kiểm tra lại!"));
            }
            else
            {
                //Connection objConn = new Connection();
                GtidDataAdapter da = new GtidDataAdapter(sql, ConnectionUtil.Instance.GetConnection());
                DataSet ds = new DataSet();
                da.Fill(ds);
                rptDocument.Load(rptFilePath);
                rptDocument.SetDataSource(ds.Tables[0]);
                rptViewer.ReportSource = rptDocument;
            }
        }

        public static void LoadReportFile(string rptFilePath, string sql, CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer, string[] ParaName, string[] ParaValue)
        {
            if (!System.IO.File.Exists(rptFilePath))
            {
                throw (new Exception(" Đường dẫn file: " + rptFilePath + " không đúng. Hãy kiểm tra lại!"));
            }
            else
            {
                //Connection objConn = new Connection();
                GtidDataAdapter da = new GtidDataAdapter(sql, ConnectionUtil.Instance.GetConnection());
                DataSet ds = new DataSet();
                da.Fill(ds);
                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rptDocument.Load(rptFilePath);
                rptDocument.SetDataSource(ds.Tables[0]);

                ParameterFields paramFields = new ParameterFields();
                ParameterField paramField;
                ParameterDiscreteValue discreteValue;
                for (int i = 0; i <= ParaName.Length - 1; i++)
                {
                    paramField = new ParameterField();
                    paramField.Name = ParaName[i];
                    discreteValue = new ParameterDiscreteValue();
                    discreteValue.Value = ParaValue[i];
                    paramField.CurrentValues.Add(discreteValue);
                    paramFields.Add(paramField);

                }
                rptViewer.ShowCloseButton = false;
                rptViewer.ShowRefreshButton = false;
                rptViewer.ShowGroupTreeButton = false;
                rptViewer.ReportSource = rptDocument;
                rptViewer.ParameterFieldInfo = paramFields;
            }

        }
        #endregion

        #region "Load Danh muc"
        public static bool IsModified(string tableName)
        {
            string str = getValue(String.Format("Select Modified From tbl_Check_LoadDM Where UserName='{0}' and IdKho={1} and Computer='{2}' and TableName='{3}'", Declare.UserName, Declare.IdKho, Common.GetComputerName(), tableName));
            if (str == "" || str.Equals("True"))
                return true;
            else
                return false;
        }

        public static DataTable getDataFromTextFile(string path, string[] fields, string[] typeNames)
        {
            DataTable dt = null;
            if (File.Exists(path))
            {
                dt = new DataTable();
                for (int i = 0; i < fields.Length; i++)
                {
                    dt.Columns.Add(fields[i], Type.GetType(typeNames[i]));
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    while (true)
                    {

                        string line = sr.ReadLine();
                        if (line == null) break;

                        string[] st = line.Trim().Split(Declare.SAPARATOR.ToCharArray());
                        
                        if (st.Length > 0)
                        {
                            DataRow row = dt.NewRow();
                            for (int i = 0; i < st.Length; i++)
                                row[i] = st[i];
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// Ghi danh sach giao dich ra file text
        /// </summary>
        /// <param name="lstTransaction"></param>
        /// <param name="sFileName"></param>
        /// <param name="isEncode"></param>
        public static void putDataToTextFile(DataTable dt, string path, string[] fields, string table)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                //ghi vao file text
                foreach (DataRow row in dt.Rows)
                {
                    string data="";
                    for (int i = 0; i < fields.Length; i++)
                    {
                        string tmp = row[fields[i]] != DBNull.Value ? row[fields[i]].ToString().Replace(Declare.SAPARATOR, "") : "";
                        data += tmp + Declare.SAPARATOR;
                    }
                    sw.WriteLine(data.Substring(0,(data.Length-Declare.SAPARATOR.Length)));
                }
                //danh dau trong CSDL
                string computer = Common.GetComputerName();
                try
                {
                    GtidConnection sqlCon = ConnectionUtil.Instance.GetConnection();
                    GtidTransaction sqlTran = ConnectionUtil.Instance.BeginTransaction();
                    GtidCommand sqlCmd = new GtidCommand("", sqlCon, sqlTran);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = String.Format("Delete From tbl_Check_LoadDM Where Username='{0}' and IdKho={1} and Computer='{2}' and TableName='{3}'",
                                            Declare.UserName, Declare.IdKho, computer, table);
                    if (!DeleteRecord(sqlCmd, sqlCon, sqlTran))
                        throw DBTools._LastError;


                    sqlCmd.CommandText = String.Format("Insert Into tbl_Check_LoadDM Values('{0}','{1}','{2}','{3}',0)",
                                            Declare.UserName, Declare.IdKho, computer, table);
                    if (!InsertRecord(sqlCmd, sqlCon, sqlTran))
                        throw DBTools._LastError;

                    ConnectionUtil.Instance.CommitTransaction();
                }
                catch (Exception ex)
                {
                    ConnectionUtil.Instance.RollbackTransaction();
                }
            }
        }
        public static DataTable LoadDanhMuc(string sql, string tableName, string[] fieldNames, string[] typeNames)
        {
            DataTable dt = null;

            try
            {
                string fileName = String.Format("{0}_{1}_{2}.dat", Declare.UserName, Declare.IdKho, tableName);
                string path = Declare.TempDirectory + "\\" + fileName;
                if (!Directory.Exists(Declare.TempDirectory))
                    Directory.CreateDirectory(Declare.TempDirectory);
                if (IsModified(tableName) || !File.Exists(path))
                {
                    dt = DBTools.getData(tableName, sql).Tables[tableName];
                    putDataToTextFile(dt, path, fieldNames, tableName);
                }
                else
                {
                    dt = getDataFromTextFile(path, fieldNames, typeNames);
                }
            } catch {}
            return dt;
        }
        #endregion

        public static bool InsertRecord(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            try
            {
                sqlcmd.Connection = sqlCon;
                sqlcmd.Transaction = sqlTran;
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _LastError = ex;
                return false;
            }
            return true;
        }
    }
}
