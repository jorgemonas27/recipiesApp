using CountriesApp.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CountriesApp.Services
{
    public class Login : IAuth
    {
        private MessageManager message;
        private ValidateLoginFields validator;
        private const int Time = 500;
        IAuth auth;

        public Login()
        {
            message = new MessageManager();
            validator = new ValidateLoginFields();
            auth = DependencyService.Get<IAuth>();
        }

        public async Task<string> LoginFirebaseService(string email, string password)
        {
            validator.ValidateCredentials(email, password);
            validator.ValidateEmail(email);

            string token = await auth.LoginFirebaseService(email, password);
            if (string.IsNullOrEmpty(token))
            {
                message.ShowMessage(Resources.Resources.Error, Resources.Resources.AuthenticationFailed, Resources.Resources.OkMessage);
                return string.Empty;
            }
            return token;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            validator.ValidateCredentials(email, password);
            validator.ValidateEmail(email);

            await Task.Delay(Time);

            if (email != Resources.Resources.HardCodedEmail || password != Resources.Resources.HardCodedPass)
            {
                message.ShowMessage(Resources.Resources.Error, Resources.Resources.Errorhardcoded);
                return false;
            }

            return true;
        }

    }
}
