using CountriesApp.Models;
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
        private const int Time = 500;
        IAuth auth;

        public Login()
        {
            auth = DependencyService.Get<IAuth>();
        }

        public Login(IAuth mock)
        {
            auth = mock;
            auth = DependencyService.Get<IAuth>();
        }

        public async Task<bool> SignInFirebase(string email, string password)
        {
            return await auth.LoginUser(email, password);
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            await Task.Delay(Time);

            if (email != Resources.Resources.HardCodedEmail || password != Resources.Resources.HardCodedPass)
            {
                return false;
            }

            return true;
        }

        public bool IsUserSign()
        {
            return auth.IsUserSign();
        }

        public bool LogoutUser()
        {
            return auth.LogoutUser();
        }
    }
}
