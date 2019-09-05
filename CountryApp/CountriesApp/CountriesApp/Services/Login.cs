using CountriesApp.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class Login : ILogin
    {
        private MessageManager message;

        public Login()
        {
            message = new MessageManager();
        }

        public async Task<bool> LoginUser(string email, string password, bool isRunning, bool isEnabled)
        {
            if (ValidateLoginFields.IsEmptyField(email, password))
            {
                message.ShowMessage("Error", "The email or password is empty");
                return false;
            }

            if (!ValidateLoginFields.IsValidEmail(email))
            {
                message.ShowMessage("Error", "The email is not a valid email please check it");
                return false;
            }

            isRunning = true;
            isEnabled = false;
            await Task.Delay(3000);


            if (email != "jorgehmg17@gmail.com" || password != "1234")
            {
                isRunning = false;
                isEnabled = true;
                message.ShowMessage("Error", "The credentials are not valid please check the email and password");
                return false;
            }

            isRunning = false;
            isEnabled = true;
            return true;
        }

    }
}
