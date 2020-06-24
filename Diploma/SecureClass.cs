using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Diploma
{
    public class SecureClass
    {
        Regex regexpas;
        Regex regexlog;
        public SecureClass()
        {
            regexpas = new Regex(@"^((?=.*[a-z])(?=.*[\d])(?=.*[A-Z])\w{8,16})$");
            regexlog = new Regex(@"^[a-zA-Z0-9]{4,16}$");
        }
        public bool LoginCheck(string str, string str2)
        {
            bool f = false;
            if (regexlog.IsMatch(str) && regexpas.IsMatch(str2))
            {
                f = true;
            }    
            return f;
        }

        public bool RegistrationCheck(string str, string str2, string str3)
        {
            bool f = false;
            if (regexlog.IsMatch(str) && regexpas.IsMatch(str2) && str2 == str3)
            {
                f = true;
            }
            return f;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public string HashFunc(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var sha1data = new SHA1Managed().ComputeHash(data);
            string str = String.Empty;
            foreach (var t in sha1data)
            {
                str += t.ToString("X2");
            }
            return str;
        }
    }
}
