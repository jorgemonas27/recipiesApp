﻿using CountriesApp.Models;
using CountriesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AfricaPage : ContentPage
    {
        public AfricaPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }

}