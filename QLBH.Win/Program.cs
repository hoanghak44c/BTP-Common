using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.HeThong.Infors;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;
using QLBH.Core.Version;

namespace QLBanHang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new QLBanHang.Forms.frmMain());
                //Application.Run(new QLBanHang.Forms.frmLogin());
                CultureInfo ci = new CultureInfo("vi-VN");
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;

                //System.Drawing.Bitmap imgBG = new System.Drawing.Bitmap(@"bg.jpg");

                //if (CheckCDkey())
                //{
                //if (Application.OpenForms.Count > 0) {
                //    Application.Run(Application.OpenForms[0]);
                //}
                //QLBanHang.Forms.frmMain frmMain = new QLBanHang.Forms.frmMain(imgBG);
                //QLBanHang.Forms.frmLogin frm = new QLBanHang.Forms.frmLogin(frmMain);
                //frm.ShowDialog();
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    frmMain.Show();
                //    //Application.Run(new QLBanHang.Forms.frmMain());
                //}

                //if (Process.GetCurrentProcess().MainModule.ModuleName != "QLBanHang.exe")
                //    Environment.Exit(200);

                Application.Run(new frmSelectDatabase());
                //ConnectionUtil.Instance.IsUAT = 3;

                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Application.StartupPath + "\\QLBanHang.exe.config";
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                if (configuration.AppSettings.Settings["PendingProcess"] == null ||
                    configuration.AppSettings.Settings["PendingProcess"].Value != Process.GetCurrentProcess().Id.ToString())
                {
                    try
                    {
                        if (Process.GetProcessById(Convert.ToInt32(configuration.AppSettings.Settings["PendingProcess"].Value)).
                            MainModule.ModuleName == Process.GetCurrentProcess().MainModule.ModuleName)
                        {
                            MessageBox.Show("Hệ thống vẫn đang thiết lập kết nối đến máy chủ, đề nghị bạn hãy vui lòng chờ ít phút nữa.");

                            Environment.Exit(124);
                        }

                        configuration.AppSettings.Settings["PendingProcess"].Value = Process.GetCurrentProcess().Id.ToString();

                        configuration.Save();
                    }
                    catch (Exception ex)
                    {
                        if (ex is ArgumentException || ex is FormatException ||
                            ex is NullReferenceException || ex is Win32Exception)
                        {
                            if (ex is NullReferenceException)
                                configuration.AppSettings.Settings.Add("PendingProcess", Process.GetCurrentProcess().Id.ToString());
                            else
                                configuration.AppSettings.Settings["PendingProcess"].Value =
                                    Process.GetCurrentProcess().Id.ToString();
                            configuration.Save();
                        }
                    }
                }

                int maxApps = CommonProvider.Instance.GetMaxApps();

                try
                {
                    configuration.AppSettings.Settings["PendingProcess"].Value = String.Empty;

                    configuration.Save();
                }
                catch (ConfigurationErrorsException cfgException)
                {
                    if (cfgException.Message == "The configuration file has been changed by another program")
                    {
                        configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                        configuration.AppSettings.Settings["PendingProcess"].Value = String.Empty;

                        configuration.Save();
                    }
                }

                if (String.IsNullOrEmpty(Dns.GetHostName().Trim()))
                {
                    MessageBox.Show("Tên máy tính không hợp lệ, đề nghị thiết lập lại!");
                    Environment.Exit(124);
                }

                //if (Dns.GetHostName().Contains("PosSyncWebsite")) maxApps = 8;

                if (Process.GetProcessesByName("QLBanHang").Length > maxApps)
                {
                    ConnectionUtil.Instance.CloseConnections();

                    MessageBox.Show(
                        String.Format(
                            "Bạn đã mở tối đa {0} cửa sổ ứng dụng!/r/nHãy đóng bớt cửa sổ ứng dụng nếu muốn mở tiếp ứng dụng!",
                            maxApps));

                    Environment.Exit(124);
                }

                string localLogFile = Application.StartupPath + "\\QLBH_Log.txt";

                if (SaleTidVer.Instance.CheckUpdate())
                {
                    Application.Exit();
                }
                else
                {

                    var logFiles = Directory.GetFiles(Application.StartupPath, "QLBH_Log*.txt");

                    foreach (var s in logFiles)
                    {
                        try
                        {
                            string logContent = File.ReadAllText(s);

                            if (!String.IsNullOrEmpty(logContent)) logContent += "\r\nFile: " + s;

                            EventLogProvider.Instance.WriteLog(logContent, "local logs");

                            File.Delete(s);
                        }
                        catch (OutOfMemoryException)
                        {
                            File.Delete(s);

                            EventLogProvider.Instance.WriteLog("Out of memory when read local log file", "local logs");

                            continue;
                        }
                    }

                    File.CreateText(localLogFile);

                    Declare.SYSDATE = CommonProvider.Instance.GetSysDate();
                    Declare.NgayLamViec = DateTime.Now.AddDays(-Declare.SYSDATE.Day + 1);
                    Declare.NgayKhoaSo = Declare.SYSDATE;
                    Declare.NgayDuDau = Declare.SYSDATE;//DateTime.Parse(SqlDateTime.MinValue.ToString());



                    Application.Run(new frmLogin());

                    //Application.Run((Form)QLBHUtils.GetObject("QLBanHang.Modules.HeThong.frmLogin", null));

                    CommonProvider.Instance.LogClientInfo();

                    PrivilegedProvider.Instance.IsSupperUser = ((NguoiDungInfor)Declare.USER_INFOR).SupperUser > 0;

                    PrivilegedProvider.Instance.CurrentPrivileges =
                        ((NguoiDungInfor)Declare.USER_INFOR).ChucNangNguoiDung.ConvertAll(
                            delegate(ChucNangInfor chucNangInfor)
                            {
                                return chucNangInfor.MaChucNang;
                            });

                    LockControl.CleanLockByProcessComputer();

                    if (Declare.LogIn != 0)
                        Application.Run(new QLBanHang.Modules.frmMain());

                    LockControl.CleanLockByProcessComputer();
                }
                //}
                //else
                //{
                //    Application.Run(new QLBanHang.Forms.frmSerialNumber());
                //    Application.Run(new QLBanHang.Forms.frmLogin());
                //    Application.Run(new QLBanHang.Forms.frmMain());
                //}

                ConnectionUtil.Instance.CloseConnections();
                ConnectionUtil.Instance.IsTimeOutApp = true;
            }
            catch (ManagedException ex)
            {
                ConnectionUtil.Instance.CloseConnections();
                MessageBox.Show(ex.Message);
                Environment.Exit(124);
            }
            catch (ConfigurationErrorsException configurationErrorsException)
            {
#if DEBUG
                MessageBox.Show(configurationErrorsException.ToString());
#else
                MessageBox.Show("Lỗi cấu hình hệ thống!" + "\nKiểm tra lại thông tin trên file cấu hình hệ thống", "Lỗi cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                Common.WriteLog(configurationErrorsException.ToString());

                Environment.Exit(124);
            }
            catch (System.UnauthorizedAccessException) 
            {
                MessageBox.Show("Bạn chưa được phân đầy đủ quyền để thực hiện chương trình này");

                Environment.Exit(124);
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("Bạn chưa được phân đầy đủ quyền để thực hiện chương trình này");

                Environment.Exit(124);
            }
            catch (Exception exception)
            {
#if DEBUG
                MessageBox.Show(exception.ToString());
#else
                MessageBox.Show("Kết nối tới CSDL không thành công!" + "\nKiểm tra lại trên file cấu hình và kết nối tới máy chủ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                Common.WriteLog(exception.ToString());

                Environment.Exit(124);
            }
        }

        //static bool CheckCDkey()
        //{
        //    return true;
        //    string sTemp = Common.GetSerialNumber();
        //    string sHDDSerial = "";
        //    if (Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "HDDSerial", null) != null)
        //        sHDDSerial = Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "HDDSerial", null).ToString();
        //    string sCDKey = "";
        //    if (Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "CDKey", null) != null)
        //        sCDKey = Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "CDKey", null).ToString();
        //    if ((sHDDSerial.Trim() != "") && (sHDDSerial.Trim() == sTemp.Trim()) && (sCDKey.Trim() == Password.SetPassword(sTemp.Trim(), "Gt0102280892")))
        //    {
        //        Declare.IsRegister = true;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        
        //}

        
    }

    //[TestClass]
    //public class frmMainTestSystem
    //{
    //    public frmMainTestSystem()
    //    {
    //        //frmLogin frmLogin = new frmLogin();
    //        //frmLogin.TestLogin("quantri", "quantri");
    //    }

    //    [TestMethod]
    //    public void TestView()
    //    {
    //        frmSelectDatabase frmMain = new frmSelectDatabase();
    //        frmMain.ShowDialog();
    //    }
    //}
}