using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CountriesApp.Droid;
using CountriesApp.Models;
using CountriesApp.Services;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthDroid))]
namespace CountriesApp.Droid
{
    public class AuthDroid : IAuth
    {
        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.GetInstance(MainActivity.app).SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool IsUserSign()
        {
            var user = Firebase.Auth.FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            var signedIn = user != null;
            return signedIn;
        }

        public bool LogoutUser()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.GetInstance(MainActivity.app).SignOut();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}