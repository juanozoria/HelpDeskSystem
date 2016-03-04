using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk
{
    public class Funciones
    {
        public static string AppCode
        {
            get { return System.Configuration.ConfigurationManager.AppSettings.Get("AppCode").ToString(); }
        }
        public static string LoginUrl
        {
            get { return System.Configuration.ConfigurationManager.AppSettings.Get("LoginUrl").ToString(); }
        }

        public static void MostrarError(Controller C, Exception E)
        {
            C.TempData.Clear();
            C.TempData.Add("Error", E.Message);

        }

        public static void MostrarSuccess(Controller C, string Message)
        {
            C.TempData.Add("Success", Message);
        }

        public static string EncodePassword(string originalPassword)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
    }
}