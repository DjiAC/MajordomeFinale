using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace MajordomeFinale.Droid
{
    [Activity(Label = "Majordome", Icon = "@drawable/Majordome_Logo")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource
            // and attach an event to it
            
        }
                
    }
}

