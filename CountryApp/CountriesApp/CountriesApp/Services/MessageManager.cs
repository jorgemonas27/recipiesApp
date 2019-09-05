using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Services
{
    public class MessageManager: IMessageManager
    {
        public async void ShowMessage(string title, string message, string confirm = "Ok")
        {
            await App.Current.MainPage.DisplayAlert(title, message, confirm);
        }
    }
}
