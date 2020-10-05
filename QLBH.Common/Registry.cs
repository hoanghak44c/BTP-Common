namespace QLBH.Common
{

    public class Registry
    {
        private string HDDSerial;
        string CDKey;
        string ExpireDay;
        string RemainDay;

        public Registry() 
        { 
        }

        public Registry(string sHDDSerial, string sCDKey, string sExpireDay, string sRemainDay)
        {
            this.HDDSerial = sHDDSerial;
            this.CDKey = sCDKey;
            this.ExpireDay = sExpireDay;
            this.RemainDay = sRemainDay;
        }

        //public static void WriteValue()
        //{
        //    Microsoft.Win32.Registry.SetValue(Declare.RegistryPath, "HDDSerial", HDDSerial);
        //    Microsoft.Win32.Registry.SetValue(Declare.RegistryPath, "CDKey", CDKey);
        //    Microsoft.Win32.Registry.SetValue(Declare.RegistryPath, "ExpireDay", ExpireDay);
        //    Microsoft.Win32.Registry.SetValue(Declare.RegistryPath, "RemainDay", RemainDay);
        //}

        //public static void ReadValue()
        //{
        //    this.HDDSerial=(string)Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "HDDSerial",null);
        //    CDKey =(string)Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "CDKey", null);
        //    ExpireDay =(string)Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "ExpireDay", null);
        //    RemainDay=(string) Microsoft.Win32.Registry.GetValue(Declare.RegistryPath, "RemainDay", null);
        //}

    }
}
