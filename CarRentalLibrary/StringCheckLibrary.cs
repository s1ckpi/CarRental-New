using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRentalLibrary
{
    public class StringCheckLibrary
    {
        public bool LoginCorrect(string login, string pattern)
        {
            Regex regex = new Regex(pattern);
            bool success = regex.Match(login).Success;

            return success;
        }

        public bool PasswordCorrect(string password, string pattern)
        {
            Regex regex = new Regex(pattern);
            bool success = regex.Match(password).Success;

            return success;
        }

        public bool EmailCorrect(string email, string pattern)
        {
            Regex regex = new Regex(pattern);
            bool success = regex.Match(email).Success;

            return success;
        }

        public bool PhoneCorrect(string phone, string pattern)
        {
            Regex regex = new Regex(pattern);
            bool success = regex.Match(phone).Success;

            return success;
        }
    }
}
