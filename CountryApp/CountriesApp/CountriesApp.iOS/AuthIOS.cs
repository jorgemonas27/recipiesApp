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



        //private static bool hasLoginResult = false;
        //private static bool loginResult = false;
        //private static bool signUpResult = false;
        ////CancellationTokenSource tokenSource = new CancellationTokenSource();
        ////CancellationToken token;
        ////Task task;

        //public bool IsUserSign()
        //{
        //    var user = Auth.DefaultInstance.CurrentUser;
        //    return user != null;
        //}

        //public async Task<bool> LoginUser(string email, string password)
        //{
        //    await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
        //    //token = tokenSource.Token;
        //    //task = Task.Factory.StartNew(async () =>
        //    //{
        //    //    await Task.Delay(4000);
        //    //}, token).Unwrap();
        //    //await task;

        //    return loginResult;
        //}

        //public bool LogoutUser()
        //{
        //    NSError error;
        //    var signedOut = Auth.DefaultInstance.SignOut(out error);

        //    if (signedOut =! true)
        //    {
        //        AuthErrorCode errorCode;
        //        if (IntPtr.Size == 8) // 64 bits devices
        //            errorCode = (AuthErrorCode)((long)error.Code);
        //        else // 32 bits devices
        //            errorCode = (AuthErrorCode)((int)error.Code);

        //        // Posible error codes that SignOut method with credentials could throw
        //        // Visit https://firebase.google.com/docs/auth/ios/errors for more information
        //        switch (errorCode)
        //        {
        //            case AuthErrorCode.KeychainError:
        //            default:
        //                return false;
        //        }
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        public bool IsUserSign()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

        public async Task<FirebaseResponse> LoginUser(string email, string password)
        {
            try
            {
                await Auth.DefaultInstance.SignInAsync(email, password);
                //await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return new FirebaseResponse()
                {
                    IsSuccessfull = true
                };
            }
            catch (Exception e)
            {
                return new FirebaseResponse()
                {
                    IsSuccessfull = false,
                    Message = e.Message
                };
            }
            
            //try
            //{
            //    Auth.DefaultInstance.SignIn(email, password, HandleAuthResultLoginHandler);
            //    token = tokenSource.Token;
            //    t = Task.Factory.StartNew(async () =>
            //    {
            //        await Task.Delay(4000);
            //    }, token).Unwrap();
            //    await t;

            //    return new FirebaseResponse()
            //    {
            //        IsSuccessfull = loginResult
            //    };
            //}
            //catch (Exception e)
            //{
            //    return new FirebaseResponse()
            //    {
            //        IsSuccessfull = false,
            //        Message = e.Message
            //    };
            //}
        }

        private void HandleAuthResultLoginHandler(User user, Foundation.NSError error)
        {
            if (error != null)
            {
                AuthErrorCode errorCode;
                if (IntPtr.Size == 8) // 64 bits devices
                    errorCode = (AuthErrorCode)((long)error.Code);
                else // 32 bits devices
                    errorCode = (AuthErrorCode)((int)error.Code);

                // Posible error codes that SignIn method with email and password could throw
                // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                switch (errorCode)
                {
                    case AuthErrorCode.OperationNotAllowed:
                    case AuthErrorCode.InvalidEmail:
                    case AuthErrorCode.UserDisabled:
                    case AuthErrorCode.WrongPassword:
                    default:
                        loginResult = false;
                        hasLoginResult = true;
                        break;
                }
            }
            else
            {
                // Do your magic to handle authentication result
                loginResult = true;
                hasLoginResult = true;
            }
            tokenSource.Cancel();
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