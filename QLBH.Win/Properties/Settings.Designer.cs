﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3643
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanHang.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool F {
            get {
                return ((bool)(this["F"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public string phuong {
            get {
                return ((string)(this["phuong"]));
            }
            set {
                this["phuong"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.168.50.31/main.asmx")]
        public string QLBanHang_WebReference_Main {
            get {
                return ((string)(this["QLBanHang_WebReference_Main"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("06:00:00")]
        public global::System.TimeSpan Time {
            get {
                return ((global::System.TimeSpan)(this["Time"]));
            }
            set {
                this["Time"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.gmail.com")]
        public string smtpserver {
            get {
                return ((string)(this["smtpserver"]));
            }
            set {
                this["smtpserver"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string useraccount {
            get {
                return ((string)(this["useraccount"]));
            }
            set {
                this["useraccount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string passaccount {
            get {
                return ((string)(this["passaccount"]));
            }
            set {
                this["passaccount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ssl {
            get {
                return ((bool)(this["ssl"]));
            }
            set {
                this["ssl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public int port {
            get {
                return ((int)(this["port"]));
            }
            set {
                this["port"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=QLBH;Persist Security Info=True;User ID=QLBH;Password=qlbh;Max Pool S" +
            "ize=500")]
        public string QLBanHangOracleConnectionString {
            get {
                return ((string)(this["QLBanHangOracleConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=HAH;Initial Catalog=QLBH_TA;Persist Security Info=True;User ID=sa;Pas" +
            "sword=12345;MultipleActiveResultSets=True")]
        public string QLBanHangConnectionString {
            get {
                return ((string)(this["QLBanHangConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 8.25pt")]
        public global::System.Drawing.Font GridViewFont {
            get {
                return ((global::System.Drawing.Font)(this["GridViewFont"]));
            }
            set {
                this["GridViewFont"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://sync.trananh.com.vn/Service.asmx")]
        public string QLBanHang_Modules_DongBoERP_syncWebSite_SyncWeb {
            get {
                return ((string)(this["QLBanHang_Modules_DongBoERP_syncWebSite_SyncWeb"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://pos.trananh.com.vn:8083/SyncWebSite/WebSync.asmx")]
        public string QLBanHang_Modules_DongBoERP_qlbh_syncWebSite_WebSync {
            get {
                return ((string)(this["QLBanHang_Modules_DongBoERP_qlbh_syncWebSite_WebSync"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.168.8.12:8082/main.asmx")]
        public string QLBanHang_Modules_DongBoERP_qlbh_sync_Main {
            get {
                return ((string)(this["QLBanHang_Modules_DongBoERP_qlbh_sync_Main"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://pos.trananh.com.vn:8083/main.asmx")]
        public string QLBanHang_Modules_DongBoERP_qlbh_syncGoLive_Main {
            get {
                return ((string)(this["QLBanHang_Modules_DongBoERP_qlbh_syncGoLive_Main"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:2445/Main.asmx")]
        public string QLBanHang_Modules_DongBoERP_localhost_Main {
            get {
                return ((string)(this["QLBanHang_Modules_DongBoERP_localhost_Main"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.168.50.31:8082/main.asmx")]
        public string QLBanHang_Modules_DongBoERP_qlbh_synch_Main {
            get {
                return ((string)(this["QLBanHang_Modules_DongBoERP_qlbh_synch_Main"]));
            }
        }
    }
}