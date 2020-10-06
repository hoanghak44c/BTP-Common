using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using QLBanHang.Forms;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using QLBanHang.Modules.HeThong;

namespace QLBanHang
{
    [RunInstaller(true)]
    public partial class QLBanHangInstaller : Installer
    {
        public QLBanHangInstaller()
        {
            InitializeComponent();
        }
        [System.Security.Permissions.SecurityPermission(SecurityAction.Demand)]
        public override void Commit(System.Collections.IDictionary savedState)
        {
            //Process ngenProcess = new Process();

            //string runtimeStr = RuntimeEnvironment.GetRuntimeDirectory();

            //string ngenStr = Path.Combine(runtimeStr, "ngen.exe");

            //ngenProcess.StartInfo.UseShellExecute = false;

            //ngenProcess.StartInfo.FileName = ngenStr;

            //string[] files = Directory.GetFiles(Context.Parameters["SrcDir"], "QLB*.dll");

            //foreach (string file in files)
            //{
            //    ngenProcess.StartInfo.Arguments = string.Format("install \"{0}\"", file);

            //    if (Environment.OSVersion.Version.Major >= 6)
            //    {
            //        ngenProcess.StartInfo.Verb = "runas";
            //    }

            //    ngenProcess.Start();

            //    ngenProcess.WaitForExit();

            //}

            //ngenProcess.StartInfo.Arguments = string.Format("install \"{0}\"", Context.Parameters["SrcDir"] + "QLBanHang.exe");

            //if (Environment.OSVersion.Version.Major >= 6)
            //{
            //    ngenProcess.StartInfo.Verb = "runas";
            //}

            //ngenProcess.Start();

            //ngenProcess.WaitForExit();


            base.Commit(savedState);
        }

        [System.Security.Permissions.SecurityPermission(SecurityAction.Demand)]
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        [System.Security.Permissions.SecurityPermission(SecurityAction.Demand)]
        protected override void OnBeforeInstall(System.Collections.IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            //ProcessStartInfo processStartInfo =
            //    new ProcessStartInfo(String.Format(@"{0}OracleClient\setup.exe", this.Context.Parameters["SrcDir"]),
            // String.Format(
            //     @"-silent -force ORACLE_HOME=""C:\Oracle\product\11.2.0\client_1"" ORACLE_BASE=""C:\Oracle"" ORACLE_HOME_NAME=""OraClient11g_QLBH"" FROM_LOCATION=""{0}OracleClient\stage\products.xml"" -nowelcome -responseFile {0}OracleClient\install_oracle11.rsp",
            //     this.Context.Parameters["SrcDir"]));

            //if (System.Environment.OSVersion.Version.Major >= 6)
            //{
            //    processStartInfo.Verb = "runas";
            //}
            //Process.Start(processStartInfo);

            //if (!Directory.Exists(@"C:\Oracle\product\11.2.0\client_1\Network\Admin\"))
            //    Directory.CreateDirectory(@"C:\Oracle\product\11.2.0\client_1\Network\Admin\");

            //File.Copy(String.Format(@"{0}OracleClient\tnsnames.ora", this.Context.Parameters["SrcDir"]),
            //          @"C:\Oracle\product\11.2.0\client_1\Network\Admin\tnsnames.ora", true);

            //if (!this.Context.Parameters.ContainsKey("servername"))
            //    this.Context.Parameters.Add("servername", String.Empty);
            //if (!this.Context.Parameters.ContainsKey("authentication"))
            //    this.Context.Parameters.Add("authentication", "Windows Authentication");
            //if (!this.Context.Parameters.ContainsKey("username"))
            //    this.Context.Parameters.Add("username", String.Empty);
            //if (!this.Context.Parameters.ContainsKey("pwd"))
            //    this.Context.Parameters.Add("pwd", String.Empty);
            //Form frm = new ConfigInstallerSetting(this.Context.Parameters);
            //if (frm.ShowDialog() == DialogResult.Cancel) {
            //    this.Rollback(savedState);
            //    return;
            //}
        }

        [System.Security.Permissions.SecurityPermission(SecurityAction.Demand)]
        protected override void OnAfterInstall(System.Collections.IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            
            //string hostName = System.Environment.MachineName;

            //string account = "Users";

            //FileInfo fileInfo = new FileInfo(this.Context.Parameters["assemblypath"]);

            //DirectoryInfo directoryInfo = new DirectoryInfo(fileInfo.DirectoryName);

            //DirectorySecurity myDirectorySecurity = directoryInfo.GetAccessControl();

            //myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(account, FileSystemRights.Modify, AccessControlType.Allow));

            //directoryInfo.SetAccessControl(myDirectorySecurity);

            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = this.Context.Parameters["servername"];
            //builder.InitialCatalog = "QLBanHang";
            //builder.IntegratedSecurity = String.Equals(this.Context.Parameters["authentication"], "Windows Authentication");
            //if (!builder.IntegratedSecurity) {
            //    builder.UserID = this.Context.Parameters["username"];
            //    builder.Password = this.Context.Parameters["pwd"];
            //}
            //builder.PersistSecurityInfo = true;
            //string fileConfig = String.Format("{0}.config", this.Context.Parameters["assemblypath"]);
            //if (File.Exists(fileConfig)) {
            //    string content = File.ReadAllText(fileConfig, Encoding.UTF8);
            //    content = content.Replace(Properties.Settings.Default.QLBanHangConnectionString, builder.ConnectionString);
            //    File.WriteAllText(fileConfig, content);
            //}

            //Form frm = new frmThietLapKetNoi(this.Context.Parameters["assemblypath"]);
            //if (frm.ShowDialog() == DialogResult.Cancel) {
            //    this.Rollback(savedState);
            //    return;
            //}
            //frm = new frmThietLapKetNoiWS(this.Context.Parameters["assemblypath"]);
            //if (frm.ShowDialog() == DialogResult.Cancel) {
            //    this.Rollback(savedState);
            //}
        }

        private void ShowContext(string where)
        {
            StringBuilder sb = new StringBuilder();
            StringDictionary myStringDictionary = this.Context.Parameters;
            sb.Append("From " + where + "\n");
            if (this.Context.Parameters.Count > 0) {
                foreach (string myString in this.Context.Parameters.Keys) {
                    sb.AppendFormat("String={0} Value= {1}\n", myString,
                    this.Context.Parameters[myString]);
                }
            }
            MessageBox.Show(sb.ToString());
        }
    }
}