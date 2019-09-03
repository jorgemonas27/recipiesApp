using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CountriesApp.Validators
{
    public class ValidateLoginFields
    {
        public static bool IsValidEmail(string emailAdress)
        {
            try
            {
                var validAddress = new System.Net.Mail.MailAddress(emailAdress);
                return validAddress.Address == emailAdress;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEmptyField(string value, string otherValue)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(otherValue))
            {
                return true;
            }
            return false;
        }
    }
}
