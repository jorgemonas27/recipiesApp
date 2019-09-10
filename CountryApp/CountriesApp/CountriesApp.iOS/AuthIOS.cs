using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountriesApp.iOS;
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
        public async Task<string> LoginFirebaseService(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public Task<bool> LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }

    
}