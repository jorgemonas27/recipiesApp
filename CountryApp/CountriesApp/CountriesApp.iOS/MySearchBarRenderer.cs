using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CountriesApp;
using CountriesApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MySearchBar), typeof(MySearchBarRenderer))]
namespace CountriesApp.iOS
{
    public class MySearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            var searchbar = (UISearchBar)Control;

            if (e.NewElement != null)
            {
                Foundation.NSString _searchField = new Foundation.NSString("searchField");
                var textFieldInsideSearchBar = (UITextField)searchbar.ValueForKey(_searchField);
                textFieldInsideSearchBar.BackgroundColor = UIColor.White;
                textFieldInsideSearchBar.TextColor = UIColor.Black;
                textFieldInsideSearchBar.BorderStyle = UITextBorderStyle.None;
                searchbar.BarTintColor = UIColor.LightTextColor;
                searchbar.Layer.CornerRadius = 2.0f;
                searchbar.Layer.BorderWidth = 1.0f;
                searchbar.Layer.BorderColor = UIColor.FromRGB(169, 169, 169).CGColor;
                searchbar.ShowsCancelButton = false;
                searchbar.AutocapitalizationType = UITextAutocapitalizationType.None;

                // Fixing Cancel button
                if (e.NewElement != null)
                {
                    this.Control.TextChanged += (s, ea) =>
                    {
                        this.Control.ShowsCancelButton = false;
                    };

                    this.Control.OnEditingStarted += (s, ea) => //when control receives focus
                    {
                        this.Control.ShowsCancelButton = false;
                    };

                    this.Control.OnEditingStopped += (s, ea) => //when control looses focus 
                    {
                        this.Control.ShowsCancelButton = false;
                    };
                }
            }
        }
    }
    
}