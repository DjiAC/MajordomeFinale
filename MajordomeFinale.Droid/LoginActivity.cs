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
    [Activity(Label = "Login", MainLauncher = true, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            //Initializing button from layout
            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);

            //Login button click action
            loginButton.Click += (object sender, EventArgs e) => {
                // TBD
            };
        }
    }
}