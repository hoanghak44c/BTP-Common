using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.IO;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using System.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;
using QLBH.Core.Providers;
using QLBH.Core.Version;

namespace QLBH.Common.DAO
{
    internal class CommonDAO : BaseDAO
    {
        private static CommonDAO instance;
        private CommonDAO(){}

        public static CommonDAO Instance
        {
            get { return instance ?? (instance = new CommonDAO()); }
        }

        public double GetVersion()
        {
            ExecuteCommand("sp_GetVersion");
            return Convert.ToDouble(Parameters["p_Version"].Value.ToString());
        }

        public double GetVersionTest()
        {
            ExecuteCommand("sp_GetVersionTest");
            return Convert.ToDouble(Parameters["p_Version"].Value.ToString());
        }

        public int GetMaxApps()
        {
            try
            {
                int maxApps = GetObjectCommand<int>("SP_GETMAXAPPS");
                return maxApps == 0 ? 3 : maxApps;
            }
            catch (Exception)
            {
                return 3;
            }
        }

        public string GetPathTest()
        {
            ExecuteCommand("sp_GetPathTest");
            return Convert.ToString(Parameters["p_Path"].Value);
        }

        public string GetPath()
        {
            ExecuteCommand("sp_GetPath");
            return Convert.ToString(Parameters["p_Path"].Value);
        }

        public DateTime GetSysDate()
        {
            return GetObjectCommand<DateTime>("select sysdate from dual");

            //if(Parameters["p_SysDate"].Value is DateTime)
            //    return Convert.ToDateTime(Parameters["p_SysDate"].Value);
            //if (Parameters["p_SysDate"].Value is Oracle.DataAccess.Types.OracleDate)
            //    return ((Oracle.DataAccess.Types.OracleDate) Parameters["p_SysDate"].Value).Value;

            //return DateTime.MinValue;

        }
        /// <summary>
        /// CHÚ Ý (QUAN TRỌNG): Cần update trạng thái isused trong bảng chỉ mục số phiếu nếu sử dụng số phiếu này!!!!!!!!!!!!!
        /// </summary>
        /// <param name="soPhieuPrefix">Tiền tố của phiếu</param>
        /// <param name="idTrungTam"></param>
        /// <param name="idKho"></param>
        /// <param name="idNhanVien"></param>
        /// <returns>Trả về số phiếu theo định dạng [Tiền tố]-[Mã trung tâm]-[Mã kho]-[Mã nhân viên]-[YYYYMMDD][Số thứ tự:000]</returns>
        internal string GetSoPhieu(string soPhieuPrefix, int idTrungTam, int idKho, int idNhanVien)
        {
            //GtidParameter soPhieuParam = new GtidParameter("p_SoPhieu");
            //soPhieuParam.DbType = DbType.String;
            //soPhieuParam.Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.StoredProcedure,
            //                          "sp_GetSoPhieuTuDong7",
            //                          new GtidParameter("p_Prefix", soPhieuPrefix),
            //                          new GtidParameter("p_IdTrungTam", idTrungTam),
            //                          new GtidParameter("p_IdKho", idKho),
            //                          new GtidParameter("p_IdNhanVien", idNhanVien),
            //                          new GtidParameter("p_AutoGenIfDuplicate", 0),
            //                          soPhieuParam);
            //return Convert.ToString(soPhieuParam.Value);

            //hah: cho người dùng options format số phiếu
            ExecuteCommand("sp_GetSoPhieuTuDong7", soPhieuPrefix, idTrungTam, idKho, idNhanVien);

            return Convert.ToString(Parameters["p_SoPhieu"].Value);
        }

        public string GetSoPhieu(string soPhieuPrefix, int idTrungTam, int idKho, int idNhanVien, bool autoGenIfDuplicate)
        {
            //GtidParameter soPhieuParam = new GtidParameter("p_SoPhieu");
            //soPhieuParam.DbType = DbType.String;
            //soPhieuParam.Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.StoredProcedure,
            //                          "sp_GetSoPhieuTuDong7",
            //                          new GtidParameter("p_Prefix", soPhieuPrefix),
            //                          new GtidParameter("p_IdTrungTam", idTrungTam),
            //                          new GtidParameter("p_IdKho", idKho),
            //                          new GtidParameter("p_IdNhanVien", idNhanVien),
            //                          new GtidParameter("p_AutoGenIfDuplicate", autoGenIfDuplicate ? 1 : 0),
            //                          soPhieuParam);
            //return Convert.ToString(soPhieuParam.Value);

            //hah: cho người dùng options format số phiếu
            ExecuteCommand("sp_GetSoPhieuTuDong7", soPhieuPrefix, idTrungTam, idKho, idNhanVien, autoGenIfDuplicate ? 1 : 0);

            return Convert.ToString(Parameters["p_SoPhieu"].Value);
            
        }

        internal string GetSoPhieu(string soPhieuPrefix, string tableName, string fieldName, int idNhanVien)
        {
            //GtidParameter soPhieuParam = new GtidParameter("p_SoPhieu");
            //soPhieuParam.DbType = DbType.String;
            //soPhieuParam.Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.StoredProcedure,
            //                          "sp_GetSoPhieuTuDong5",
            //                          new GtidParameter("p_Prefix", soPhieuPrefix),
            //                          new GtidParameter("p_TableName", tableName),
            //                          new GtidParameter("p_FieldName", fieldName),
            //                          new GtidParameter("p_IdNhanVien", idNhanVien),
            //                          soPhieuParam);
            //return Convert.ToString(soPhieuParam.Value);

            //hah: cho người dùng options format số phiếu
           ExecuteCommand("sp_GetSoPhieuTuDong5", soPhieuPrefix, tableName, fieldName, idNhanVien);

            return Convert.ToString(Parameters["p_SoPhieu"].Value);
        }

        public int LogOpenForm(int idNhanVien, int idNguoiDung, string tenMay, string terminal, string chucNang, string tenDangNhap, int processId)
        {
            try
            {
                return GetObjectCommand<int>("sp_NhatKy_NguoiDung_Insert2", idNhanVien, idNguoiDung, tenMay, terminal, chucNang, tenDangNhap, processId);
            }
            catch (Exception ex)
            {
                File.AppendAllText(Application.StartupPath + "\\QLBH_Log.txt", "Description: " + ex.ToString());
                return 0;
            }
        }

        public void LogCloseForm(int idNhatKy)
        {
            try
            {
                ExecuteCommand("sp_NhatKy_NguoiDung_Update", idNhatKy);
            }
            catch (Exception ex)
            {
                File.AppendAllText(Application.StartupPath + "\\QLBH_Log.txt", "Description: " + ex.ToString());
            }
        }
        public bool Lock_ChungTu(ILockInfo lockObject)
        {
            return Lock(lockObject, "tbl_ChungTu", "IdChungTu", "Chứng từ");
        }

        public void UnLock_ChungTu(ILockInfo lockObject)
        {
            UnLock(lockObject, "tbl_ChungTu", "IdChungTu");
        }

        public bool Lock_Tn_YeuCau(ILockInfo lockObject)
        {
            return Lock(lockObject, String.Format("{0}.tbl_tn_yeucau", Declare.CrmSchema), "IdYeuCau", "Yêu cầu");
        }

        public void UnLock_Tn_YeuCau(ILockInfo lockObject)
        {
            UnLock(lockObject, String.Format("{0}.tbl_tn_yeucau", Declare.CrmSchema), "IdYeuCau");
        }

        private bool ProcessLockable(int processId)
        {
            try
            {
                var instanceProcess = Process.GetProcessById(processId);

                return instanceProcess.MainModule.ModuleName == "QLBanHang.exe";
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Lock(ILockInfo lockObject, string tableName, string primaryKey, string normalName)
        {
            var dt = GetDataTableCommand(@"select b.sid, b.process, b.terminal 
                    from v$process a, v$session b 
                    where a.addr = b.paddr 
                    and b.audsid = userenv('sessionid')");

            if (dt != null && dt.Rows.Count > 0)
            {
                var sid = Common.IntValue(dt.Rows[0]["sid"]);
                var process = Common.StringValue(dt.Rows[0]["process"]).Split(':')[0];
                var machine = Common.StringValue(dt.Rows[0]["terminal"]);
                if (String.IsNullOrEmpty(machine))
                    machine = Dns.GetHostName().ToUpper();

                if (!String.IsNullOrEmpty(lockObject.ProcessId))

                    if(lockObject.ProcessId.Contains(":"))
                
                        lockObject.ProcessId = lockObject.ProcessId.Split(':')[0];

                var processLockable = !String.IsNullOrEmpty(lockObject.ProcessId) && 
                    
                    machine == lockObject.LockMachine &&
                    
                    ProcessLockable(Convert.ToInt32(lockObject.ProcessId));

                var affectedResult = 0;
                
                var lockConditions = "LockAccount = :TenDangNhap and LockMachine = :TenMay";
                if (processLockable) lockConditions += " and (ProcessId = :ProcessId or ProcessId like :ProcessId || ':%')";

                if (lockObject.LastUpdatedDate == DateTime.MinValue)
                    affectedResult = ExecuteCommand(
                        String.Format(@"update {0}
                         set LockId      = 1,
                             SessionId   = :SessionId,
                             ProcessId   = :ProcessId,
                             LockAccount = :TenDangNhap,
                             LockMachine = :Tenmay
                     where {1} = :KeyValue
                         and ((nvl(LockId, 0) = 0 and Last_Update_Date is null)or
                             (LockId = 1 and (Last_Update_Date + 2 / 24 < sysdate or
                             ({2}))))", tableName, primaryKey, lockConditions),
                        sid, process, Declare.UserName, machine,
                        Convert.ToInt32(lockObject.GetType().GetProperty(primaryKey).GetValue(lockObject, null)));
                else
                    affectedResult = ExecuteCommand(
                        String.Format(@"update {0}
                         set LockId      = 1,
                             SessionId   = :SessionId,
                             ProcessId   = :ProcessId,
                             LockAccount = :TenDangNhap,
                             LockMachine = :Tenmay
                     where {1} = :KeyValue
                         and ((nvl(LockId, 0) = 0 and Last_Update_Date = :Last_Update_Date)or
                             (LockId = 1 and (Last_Update_Date + 2 / 24 < sysdate or
                             ({2}))))", tableName, primaryKey, lockConditions),
                        sid, process, Declare.UserName, machine,
                        Convert.ToInt32(lockObject.GetType().GetProperty(primaryKey).GetValue(lockObject, null)),
                        lockObject.LastUpdatedDate);

                if (affectedResult == 0)
                {
                    if (lockObject.LockAccount != Declare.UserName || lockObject.LockMachine != machine)

                        throw new ManagedException(

                            String.Format("{0} này đã bị lock bởi người dùng {1} tại máy {2}.", normalName, lockObject.LockAccount,

                                          lockObject.LockMachine));

                    if (lockObject.ProcessId != process)

                        throw new ManagedException(

                            String.Format("{0} này đã bị lock bởi ứng dụng khác.", normalName));

                    throw new ManagedException(String.Format("{0} này đã bị lock.", normalName));
                }

                lockObject.LockMachine = machine;
                lockObject.LockAccount = Declare.UserName;
                lockObject.ProcessId = process;
                lockObject.LockId = 1;

                return true;

            }
            return false;
        }

        public void UnLock(ILockInfo lockObject, string tableName, string primaryKey)
        {
            if (!String.IsNullOrEmpty(lockObject.ProcessId))

                if (lockObject.ProcessId.Contains(":"))

                    lockObject.ProcessId = lockObject.ProcessId.Split(':')[0];

            var processLockable = !String.IsNullOrEmpty(lockObject.ProcessId) && 
                
                lockObject.LockMachine == Dns.GetHostName().ToUpper() &&
                
                ProcessLockable(Convert.ToInt32(lockObject.ProcessId));

            var paras = new List<object>();

            paras.AddRange(new object[]
                               {
                                   Convert.ToInt32(lockObject.GetType().
                                                       GetProperty(primaryKey).GetValue(lockObject, null)),
                                   Declare.UserName,
                                   Dns.GetHostName().ToUpper()
                               });

            var lockConditions = "LockAccount = :TenDangNhap and LockMachine = :TenMay";

            if (processLockable)
            {
                lockConditions += " and (ProcessId = :ProcessId or ProcessId like :ProcessId || ':%')";

                paras.Add(Process.GetCurrentProcess().Id);
            }

            var affectedResult = ExecuteCommand(
                String.Format(
                    @"update {0}
                         set LockId      = 0,
                             SessionId   = null,
                             ProcessId   = null,
                             LockAccount = null,
                             LockMachine = null
                     where {1} = :KeyValue
                         and ((LockId = 1 and Last_Update_Date + 2 / 24 < sysdate) or
                             (LockId = 1 and {2}))",
                    tableName, primaryKey, lockConditions), paras.ToArray());

            if(affectedResult > 0)
            {
                lockObject.LockMachine = String.Empty;
                lockObject.LockAccount = String.Empty;
                lockObject.ProcessId = String.Empty;
                lockObject.LockId = 0;   
            }
        }

//        public bool Lock_ChungTu(ChungTuBaseLockInfo lockObject)
//        {
//            try
//            {
//                var dt = GetDataTableCommand(@"select b.sid, b.process, b.terminal 
//                    from v$process a, v$session b 
//                    where a.addr = b.paddr 
//                    and b.audsid = userenv('sessionid')");

//                if (dt != null && dt.Rows.Count > 0)
//                {
//                    int sid = Common.IntValue(dt.Rows[0]["sid"]);
//                    string process = Common.StringValue(dt.Rows[0]["process"]);
//                    string machine = Common.StringValue(dt.Rows[0]["terminal"]);
//                    if (String.IsNullOrEmpty(machine))
//                        machine = Dns.GetHostName().ToUpper();

//                    int affectedResult = 0;
//                    if (lockObject.LastUpdatedDate == DateTime.MinValue)
//                        affectedResult = ExecuteCommand(
//                            @"update tbl_ChungTu
//                         set LockId      = 1,
//                             SessionId   = :SessionId,
//                             ProcessId   = :ProcessId,
//                             LockAccount = :TenDangNhap,
//                             LockMachine = :Tenmay
//                     where IdChungTu = :IdChungTu
//                         and ((nvl(LockId, 0) = 0 and Last_Update_Date is null)or
//                             (LockId = 1 and (Last_Update_Date + 2 / 24 < sysdate or
//                             (LockAccount = :TenDangNhap and LockMachine = :TenMay))))",
//                            sid, process, Declare.UserName, machine, lockObject.IdChungTu);
//                    else
//                        affectedResult = ExecuteCommand(
//                            @"update tbl_ChungTu
//                         set LockId      = 1,
//                             SessionId   = :SessionId,
//                             ProcessId   = :ProcessId,
//                             LockAccount = :TenDangNhap,
//                             LockMachine = :Tenmay
//                     where IdChungTu = :IdChungTu
//                         and ((nvl(LockId, 0) = 0 and Last_Update_Date = :Last_Update_Date)or
//                             (LockId = 1 and (Last_Update_Date + 2 / 24 < sysdate or
//                             (LockAccount = :TenDangNhap and LockMachine = :TenMay))))",
//                            sid, process, Declare.UserName, machine, lockObject.IdChungTu, lockObject.LastUpdatedDate);

//                    if(affectedResult == 0)
//                    {
//                        dt = GetDataTableCommand("select ProcessId, LockAccount, LockMachine from tbl_chungtu where idchungtu = :IdChungTu",
//                                                 lockObject.IdChungTu);
//                        string processId = dt.Rows[0]["ProcessId"].ToString();
//                        string lockMachine = dt.Rows[0]["LockMachine"].ToString();
//                        string lockAccount = dt.Rows[0]["LockAccount"].ToString();

//                        if(lockAccount != Declare.UserName ||
//                            lockMachine != machine)

//                            throw new ManagedException(String.Format("Chứng từ này đã bị lock bởi người dùng {0} tại máy {1}.", lockAccount, lockMachine));

//                        if(processId != process)

//                            throw new ManagedException("Chứng từ này đã bị lock bởi ứng dụng khác.");

//                        throw new ManagedException("Chứng từ này đã bị lock.");
//                    }

//                    return true;

//                }
//                return false;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public void UnLock_ChungTu(ChungTuBaseLockInfo lockObject)
//        {
//            ExecuteCommand(
//                @"update tbl_ChungTu
//                         set LockId      = 0,
//                             SessionId   = null,
//                             ProcessId   = null,
//                             LockAccount = null,
//                             LockMachine = null
//                     where IdChungTu = :IdChungTu
//                         and ((LockId = 1 and Last_Update_Date + 2 / 24 < sysdate) or
//                             (LockId = 1 and LockAccount = :TenDangNhap and LockMachine = :TenMay))",
//                lockObject.IdChungTu, Declare.UserName, Dns.GetHostName().ToUpper());
//        }

        public bool Lock_Unlock_ChungTu(ChungTuBaseLockInfo lockObject, int lockid)
        {
            try
            {
                string sql = "select b.sid, b.process, b.machine from v$process a, v$session b where a.addr = b.paddr and b.audsid = userenv('sessionid')";
                DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    int sid = Common.IntValue(dt.Rows[0]["sid"]);//int sid = Common.IntValue(DBTools.getValue("select distinct sid from v$mystat"));
                    string process = Common.StringValue(dt.Rows[0]["process"]);
                    string machine = Common.StringValue(dt.Rows[0]["machine"]);
                    if (String.IsNullOrEmpty(machine))
                        machine = Declare.TenMay;

                    ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuBanHangLockEdit, lockObject.IdChungTu, lockid, sid, process, Declare.UserName, machine);

                    if (lockid == 1)
                    {
                        sql = "select sessionid, processid, lockaccount, lockmachine from tbl_chungtu where lockid = 1 and idchungtu = " + lockObject.IdChungTu;

                        dt = DBTools.getData("tmp", sql).Tables["tmp"];
                        if (dt.Rows.Count > 0)
                        {
                            if (sid != Common.IntValue(dt.Rows[0]["sessionid"])) return false;
                            if (process != Common.StringValue(dt.Rows[0]["processid"])) return false;
                            if (machine != Common.StringValue(dt.Rows[0]["lockmachine"])) return false;
                            if (Declare.UserName != Common.StringValue(dt.Rows[0]["lockaccount"])) return false;
                            lockObject.LockMachine = machine;
                            lockObject.LockAccount = Declare.UserName;
                            lockObject.ProcessId = process;
                            lockObject.LockId = lockid;
                        } else return false;
                    }

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Lock_Unlock_ChungTu(int idChungTu, int lockid)
        {
            try
            {
                string sql = "select b.sid, b.process, b.machine from v$process a, v$session b where a.addr = b.paddr and b.audsid = userenv('sessionid')";
                DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    int sid = Common.IntValue(dt.Rows[0]["sid"]);//int sid = Common.IntValue(DBTools.getValue("select distinct sid from v$mystat"));
                    string process = Common.StringValue(dt.Rows[0]["process"]);
                    string machine = Common.StringValue(dt.Rows[0]["machine"]);
                    if (String.IsNullOrEmpty(machine))
                        machine = Declare.TenMay;

                    ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuBanHangLockEdit, idChungTu, lockid, sid, process, Declare.UserName, machine);

                    if(lockid == 1)
                    {
                        sql = "select sessionid, processid, lockaccount, lockmachine from tbl_chungtu where lockid = 1 and idchungtu = " + idChungTu;

                        dt = DBTools.getData("tmp", sql).Tables["tmp"];
                        if (dt.Rows.Count > 0)
                        {
                            if (sid != Common.IntValue(dt.Rows[0]["sessionid"])) return false;
                            if (process != Common.StringValue(dt.Rows[0]["processid"])) return false;
                            if (machine != Common.StringValue(dt.Rows[0]["lockmachine"])) return false;
                            if (Declare.UserName != Common.StringValue(dt.Rows[0]["lockaccount"])) return false;
                        } else return false;
                    }

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Check_Lock_ChungTu(int idChungTu)
        {
            string sql = String.Format("Select SoChungTu, LOCKID, lockaccount, lockmachine, SessionId, ProcessId, Last_Update_Date From tbl_ChungTu Where idchungtu = {0}", idChungTu);
            DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dt != null && dt.Rows.Count > 0)
            {
                int lockid = Common.IntValue(dt.Rows[0]["LockId"]);
                int sid = Common.IntValue(dt.Rows[0]["SessionId"]);
                string process = Common.StringValue(dt.Rows[0]["ProcessId"]);
                string lockaccount = Common.StringValue(dt.Rows[0]["lockaccount"]);
                string lockmachine = Common.StringValue(dt.Rows[0]["lockmachine"]);
                string soChungTu = Common.StringValue(dt.Rows[0]["SoChungTu"]);
                DateTime lockat = Common.DateValue(dt.Rows[0]["Last_Update_Date"]);
                if (lockid == 1)
                {
                    if (lockat.AddHours(2) < CommonProvider.Instance.GetSysDate()) return true;

                    if (lockaccount.ToLower() != Declare.UserName.ToLower())
                    {
                        throw new ManagedException(String.Format("Chứng từ {2} đang bị lock bởi người dùng {0} tại máy {1}", lockaccount, lockmachine, soChungTu));
                    }
                    if (!lockmachine.EndsWith("\\" + Dns.GetHostName().ToUpper()))
                    {
                        throw new ManagedException(String.Format("Chứng từ {2} đang bị lock bởi người dùng {0} tại máy {1}", lockaccount, lockmachine, soChungTu));
                    }

                    process = process.Split(':')[0];
                    
                    if (process != Process.GetCurrentProcess().Id.ToString())
                    {
                        try
                        {
                            Process pr = Process.GetProcessById(Common.IntValue(process));
                            if (pr.MainModule.ModuleName == Process.GetCurrentProcess().MainModule.ModuleName)
                            {
                                throw new ManagedException(String.Format("Chứng từ {2} đang bị lock bởi người dùng {0} tại máy {1}", lockaccount, lockmachine, soChungTu));
                            }
                        }
                        catch (Exception ex)
                        {
                            if(ex is ArgumentException || ex is Win32Exception) return true;
                        }
                    }

                    //if (
                    //    !String.IsNullOrEmpty(
                    //        DBTools.getValue(String.Format("Select sid From v$session where sid={0} and process='{1}'", sid, process))))
                    //{
                    //    return false;
                    //}
                }
                return true;
            }
            return false;
        }

        private class NetworkInfo
        {
            public string MacAddress { get; set; }
            public string IpAddress { get; set; }
        }

        private NetworkInfo GetNetworkInfo()
        {
            var result = new NetworkInfo();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    result.MacAddress = nic.GetPhysicalAddress().ToString();

                    try
                    {
                        result.IpAddress =
                            nic.GetIPProperties().UnicastAddresses[nic.GetIPProperties().UnicastAddresses.Count - 1].
                                Address.ToString();
                    }
                    catch (Exception ex)
                    {
                        EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "LogClientInfo");
                    }
                    break;
                }
            }

            return result;
        }
        
        public void ClearLogClientInfo()
        {
            var networkInfo = GetNetworkInfo();

            ExecuteCommand(@"delete tbl_nhatky_nguoidung where 
                tendangnhap = :tendangnhap
                and thoigian_in < to_date(:currentDate, 'dd/mm/rrrr') - 30", Declare.UserName, Declare.SYSDATE.ToString("dd/MM/yyyy"));

            ExecuteCommand(
                @"delete tbl_clients t
                        where t.macaddress = :macaddress
                        and t.computername = :computername
                        and t.ipaddress = :ipaddress
                        and t.processid = :processid",
                networkInfo.MacAddress, Dns.GetHostName().ToUpper(),
                networkInfo.IpAddress, Process.GetCurrentProcess().Id);
        }

        public void LogClientInfo()
        {
            var networkInfo = GetNetworkInfo();

            ExecuteCommand(
                @"delete tbl_clients t
                     where not exists (select 1
                        from v$session v where v.terminal = t.computername
                        and v.process like t.processid || :surfixProcess
                        and v.program = :program)
                        and t.program = :program",
                ":%", Process.GetCurrentProcess().MainModule.ModuleName);

            string processIds = String.Empty;

            foreach (var process in Process.GetProcessesByName(Process.GetCurrentProcess().MainModule.ModuleName))
            {
                processIds = process.Id + ",";
            }
            
            processIds = processIds.TrimEnd(new char[',']);

            ExecuteCommand(
                @"delete tbl_clients t where processid not in (:processIds) 
                and computername = :computername 
                and macaddress = :macaddress
                and ipaddress = :ipaddress
                and program = :program",
                processIds, Dns.GetHostName().ToUpper(),
                networkInfo.MacAddress, networkInfo.IpAddress,
                Process.GetCurrentProcess().MainModule.ModuleName);

            int resultAffected = ExecuteCommand(
                @"UPDATE tbl_clients
	                 set computername = :computername,
		                 ipaddress    = :ipaddress,
		                 logon        = localtimestamp,
		                 version      = :version,
                         username     = :username
                 where processid = :processid
                    and macaddress = :macaddress
                    and program = :program",
                Dns.GetHostName().ToUpper(), networkInfo.IpAddress, VerBase.CurrentVersion, Declare.UserName,
                Process.GetCurrentProcess().Id, networkInfo.MacAddress,
                Process.GetCurrentProcess().MainModule.ModuleName);

            if (resultAffected == 0)
                ExecuteCommand(
                    @"INSERT INTO tbl_clients
	                    (computername,
	                     ipaddress,
	                     macaddress,
	                     logon,
	                     version,
	                     username,
	                     processid,
                         program)
                    VALUES
	                    (:computername,
	                     :ipaddress,
	                     :macaddress,
	                     localtimestamp,
	                     :version,
	                     :username,
	                     :processid,
                         :program)",
                    Dns.GetHostName().ToUpper(), networkInfo.IpAddress, networkInfo.MacAddress, VerBase.CurrentVersion, Declare.UserName,
                    Process.GetCurrentProcess().Id,
                    Process.GetCurrentProcess().MainModule.ModuleName);

            List<string> macList =
                GetListCommand<string>(
                    @"select cl.macaddress
	                    from v$session v
	                    left join tbl_clients cl
		                    on v.terminal = cl.computername
                     where v.program = :program
	                     and cl.computername = :computername",
                    Process.GetCurrentProcess().MainModule.ModuleName, Dns.GetHostName().ToUpper());

            foreach (string macAddress in macList)
            {
                bool isAnother = true;

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.GetPhysicalAddress().ToString() == macAddress)
                    {
                        isAnother = false;
                        
                        break;
                    }
                }

                if (isAnother)
                {
                    ExecuteCommand(
                        @"delete tbl_clients t
                        where t.macaddress = :macaddress
                        and t.computername = :computername
                        and t.ipaddress = :ipaddress
                        and t.program = :program",
                        networkInfo.MacAddress, Dns.GetHostName().ToUpper(), networkInfo.IpAddress,
                        Process.GetCurrentProcess().MainModule.ModuleName);

                    throw new ManagedException("Tên máy tính đang bị xung đột trong hệ thống, đề nghị hãy thiết lập lại.");
                }
            }

            List<string> computerList =
                GetListCommand<string>(
                    @"select cl.computername from v$session v
                        left join tbl_clients cl
                        on  v.terminal = cl.computername
                        and v.process like cl.processid || :surfixedProcess
                        where v.program = :program
                        and cl.username = :username
                        and v.machine not like :syncWebServer",
                    ":%", Process.GetCurrentProcess().MainModule.ModuleName,
                    Declare.UserName, "%\\POSSYNCWEBSITE");

            foreach (string computerName in computerList)
            {
                if (Declare.UserName != "quantri" &&
                    Declare.UserName != "superuser" && 
                    computerName != Dns.GetHostName().ToUpper() &&
                    Dns.GetHostName().ToUpper() != "POSSYNCWEBSITE")
                {
                    ExecuteCommand(
                        @"delete tbl_clients t
                        where t.macaddress = :macaddress
                        and t.computername = :computername
                        and t.ipaddress = :ipaddress
                        and t.program = :program",
                        networkInfo.MacAddress, Dns.GetHostName().ToUpper(), networkInfo.IpAddress,
                        Process.GetCurrentProcess().MainModule.ModuleName);

                    throw new ManagedException(String.Format("Tài khoản này đang được sử dụng tại máy {0}", computerName));
                }
            }
        }

        public bool IsKhacTinh(int idTrungTam1, int idTrungTam2)
        {
            return Convert.ToInt32(
                ExecuteScalar(@"select decode((select ouid from tbl_dm_trungtam 
                where idtrungtam = :idTrungTam),
                (select ouid from tbl_dm_trungtam 
                where idtrungtam = :idTrungTamHachToan), 0, 1) from dual", idTrungTam1, idTrungTam2)) == 1;
        }

        public bool Lock_KiemKe(ILockInfo lockObject)
        {
            return Lock(lockObject, "tbl_KiemKe", "IdKiemKe", "Phiếu kiểm kê");
        }

        public void UnLock_KiemKe(ILockInfo lockObject)
        {
            UnLock(lockObject, "tbl_KiemKe", "IdKiemKe");
        }
    }
}
