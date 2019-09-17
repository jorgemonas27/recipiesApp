using CountriesApp.Models;
using CountriesApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CountriesApp.Validators
{
    public class ValidateLoginFields: IValidateFields
    {
        public ValidateLoginFields()
        {
          
        }

        public ResponseValidator ValidateCredentials(string email, string password)
        {
            if (this.IsEmptyField(email, password))
            {
                return new ResponseValidator()
                {
                    IsValid = false,
                    Message = Resources.Resources.EmailPasswordEmpty
                };
            }

            if (!this.IsValidEmail(email))
            {
                return new ResponseValidator()
                {
                    IsValid = false,
                    Message = Resources.Resources.InvalidEmail
                };
            }
            return new ResponseValidator()
            {
                IsValid = true
            };
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
