using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CountriesApp.Database;
using CountriesApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace CountriesApp.iOS
{
    public class DatabaseService: IDatabaseService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.MyDocuments),
            "..",
            "Library",
            "countriesDB");
        }
    }
}