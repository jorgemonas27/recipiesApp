using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CountriesApp.Database;
using CountriesApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace CountriesApp.Droid
{
    class DatabaseService: IDatabaseService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
            "countriesDB");
        }
    }
}