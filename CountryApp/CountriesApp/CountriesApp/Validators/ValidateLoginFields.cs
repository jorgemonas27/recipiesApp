using CountriesApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CountriesApp.Validators
{
    public class ValidateLoginFields
    {
        MessageManager message;

        public ValidateLoginFields()
        {
            message = new MessageManager();
        }

        public bool ValidateEmail(string email)
        {
            if (!this.IsValidEmail(email))
            {
                message.ShowMessage("Error", "The email is not a valid email please check it");
                return false;
            }
            return true;
        }

        public bool ValidateCredentials(string email, string password)
        {
            if (this.IsEmptyField(email, password))
            {
                message.ShowMessage("Error", "The email or password is empty");
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string emailAdress)
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

        private  bool IsEmptyField(string value, string otherValue)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(otherValue))
            {
                return true;
            }
            return false;
        }
    }
}
