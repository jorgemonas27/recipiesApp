using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
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
    public class MySearchBarRenderer : SearchBarRenderer
    {
        public MySearchBarRenderer(Context context)
            : base(context)
        {

        }

        public MySearchBarRenderer()
            : base(null)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            // Get native control (background set in shared code, but can use SetBackgroundColor here)
            SearchView searchView = (base.Control as SearchView);
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);

            //change icon
            searchView.SetIconifiedByDefault(false);
            int searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
            var icon = searchView.FindViewById(searchIconId);
            icon.SetBackgroundColor(Android.Graphics.Color.White);
            (icon as ImageView).SetImageResource(Resource.Drawable.ios23);

            // Access search textview within control
            int textViewId = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
            EditText textView = (searchView.FindViewById(textViewId) as EditText);
            textView.SetTextColor(Android.Graphics.Color.Black);
            textView.SetHintTextColor(Android.Graphics.Color.Rgb(180, 180, 180));
            textView.TextAlignment = Android.Views.TextAlignment.TextStart;

            //add borders to the search bar



            // Customize frame color
            //int frameId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            //Android.Views.View frameView = (searchView.FindViewById(frameId) as Android.Views.View);
            ////frameView.SetBackgroundColor(Android.Graphics.Color.Rgb(255, 255, 255));

            //add borders to the search bar

            if (textView != null)
            {
                var shape = new ShapeDrawable(new RectShape());
                shape.Paint.Color = Android.Graphics.Color.Transparent;
                shape.Paint.StrokeWidth = 0;
                shape.Paint.SetStyle(Paint.Style.Stroke);
                textView.Background = shape;
            }

            var gradient = new GradientDrawable();
            gradient.SetCornerRadius(5.0f);
            gradient.SetStroke((int)this.Context.ToPixels(1.0f), Android.Graphics.Color.Rgb(169, 169, 169));

            this.Control.SetBackground(gradient);



        }
    }
}