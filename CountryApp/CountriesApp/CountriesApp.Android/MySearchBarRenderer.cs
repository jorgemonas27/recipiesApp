using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using CountriesApp;
using CountriesApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MySearchBar), typeof(CountriesApp.Droid.MySearchBarRenderer))]
namespace CountriesApp.Droid
{
    public class MySearchBarRenderer: SearchBarRenderer
    {
        public MySearchBarRenderer(Context context)
            : base(context)
        {

        }

        public MySearchBarRenderer()
            :base(null)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            // Get native control (background set in shared code, but can use SetBackgroundColor here)
            SearchView searchView = (base.Control as SearchView);
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);

            // Access search textview within control
            int textViewId = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
            EditText textView = (searchView.FindViewById(textViewId) as EditText);

            // Set custom colors
            textView.SetBackgroundColor(Android.Graphics.Color.Rgb(225, 225, 225));
            textView.SetTextColor(Android.Graphics.Color.Rgb(32, 32, 32));
            textView.SetHintTextColor(Android.Graphics.Color.Rgb(128, 128, 128));

            // Customize frame color
            int frameId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            Android.Views.View frameView = (searchView.FindViewById(frameId) as Android.Views.View);
            frameView.SetBackgroundColor(Android.Graphics.Color.Rgb(96, 96, 96));
        }

    }
}