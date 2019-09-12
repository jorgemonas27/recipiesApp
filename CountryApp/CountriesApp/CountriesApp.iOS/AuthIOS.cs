using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private static bool hasLoginResult = false;
        private static bool loginResult = false;
        private static bool signUpResult = false;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token;
        Task task;

        public bool IsUserSign()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
            token = tokenSource.Token;
            task = Task.Factory.StartNew(async () =>
            {
                await Task.Delay(4000);
            }, token).Unwrap();
            await task;

            return loginResult;
        }

        public bool LogoutUser()
        {
            NSError error;
            var signedOut = Auth.DefaultInstance.SignOut(out error);

            if (signedOut =! true)
            {
                AuthErrorCode errorCode;
                if (IntPtr.Size == 8) // 64 bits devices
                    errorCode = (AuthErrorCode)((long)error.Code);
                else // 32 bits devices
                    errorCode = (AuthErrorCode)((int)error.Code);

                // Posible error codes that SignOut method with credentials could throw
                // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                switch (errorCode)
                {
                    case AuthErrorCode.KeychainError:
                    default:
                        return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}