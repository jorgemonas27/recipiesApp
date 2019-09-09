using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Services
{
    public static class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string Username
        {
            get => AppSettings.GetValueOrDefault(nameof(Username), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Username), value);
        }

        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }
    }
}
