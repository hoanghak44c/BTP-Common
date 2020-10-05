using System;

namespace QLBH.Common
{
    public class Password
    {
        public static string SetPassword(string strPass, string sSalt)
        {
            return Encrypt(strPass, sSalt);
        }

        public static bool IsCorrectPassword(string sPassOld, string sPassCompare, string sSalt)
        {
            string passTemp = Encrypt(sPassCompare, sSalt);
            return (sPassOld == passTemp);
        }

        public static string CreateSalt()
        {
            byte[] bytSalt = new byte[9];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytSalt);

            string strSalt = System.Convert.ToBase64String(bytSalt);
            if ((strSalt == null)) strSalt = "";
            return strSalt;
        }

        public static string CreateSystemPassword()
        { 
            return "MMS" + (Common.IntValue(DateTime.Now.Day.ToString()) + 5) + (Common.IntValue(DateTime.Now.Month.ToString()) + 7) + (Common.IntValue(DateTime.Now.Year.ToString()) + 9);
        }

        public static string Encrypt(string value, string sSalt)
        {
            System.Text.Encoding encoding = System.Text.Encoding.Unicode;
            System.Security.Cryptography.SHA1 encodeEngine = System.Security.Cryptography.SHA1.Create();

            byte[] clearBytes = encoding.GetBytes(sSalt.ToLower().Trim() + value.Trim());
            byte[] hashedBytes = encodeEngine.ComputeHash(clearBytes);
            return System.BitConverter.ToString(hashedBytes);
        }

    }
}
