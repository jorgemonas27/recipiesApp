using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CountriesApp.iOS;
using CountriesApp.Models;
using CountriesApp.Services;
using Firebase.Auth;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthIOS))]
namespace CountriesApp.iOS
{
    public class AuthIOS : IAuth
    {
        public static String KEY_AUTH = "auth";
        private static bool hasLoginResult = false;
        private static bool loginResult = false;
        private static bool signUpResult = false;
        CancellationTokenSource tokenSource;
        CancellationToken token;
        Task t;

        public bool IsUserSign()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool LogoutUser()
        {
            NSError error;
            var signedOut = Auth.DefaultInstance.SignOut(out error);

            if (!signedOut)
            {
                return false;
            }
            return true;
        }
    }
}