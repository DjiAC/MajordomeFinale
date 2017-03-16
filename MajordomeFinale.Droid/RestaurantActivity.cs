using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MajordomeFinale.Droid
{
    [Activity(Label = "Restaurant", MainLauncher = false, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class RestaurantActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Restaurant" layout resource
            SetContentView(Resource.Layout.Restaurant);
        }
    }
}