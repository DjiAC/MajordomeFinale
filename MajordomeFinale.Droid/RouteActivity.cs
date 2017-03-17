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
    [Activity(Label = "Route", MainLauncher = false, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class RouteActivity : Activity
    {
        public string loginEntry;
        public string passwordEntry;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "Route" layout resource
            SetContentView(Resource.Layout.Route);

            loginEntry = Intent.GetStringExtra("loginTransmission") ?? "Login not available";
            passwordEntry = Intent.GetStringExtra("passwordTransmission") ?? "Password not available";

            ImageButton linkAccount = FindViewById<ImageButton>(Resource.Id.linkAccount);
            //Login button click action
            linkAccount.Click += BtnlinkAccount_Click;

            ImageButton linkRestaurant = FindViewById<ImageButton>(Resource.Id.linkRestaurant);
            //Login button click action
            linkRestaurant.Click += BtnlinkRestaurant_Click;
        }

        private void BtnlinkAccount_Click(object sender, EventArgs e)
        {

            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to your account !", ToastLength.Short).Show();

            var activityAccount = new Intent(this, typeof(AccountActivity));
            activityAccount.PutExtra("loginTransmission", loginEntry);
            activityAccount.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityAccount);
        }

        private void BtnlinkRestaurant_Click(object sender, EventArgs e)
        {

            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to Restaurants page !", ToastLength.Short).Show();

            var activityRestaurant = new Intent(this, typeof(RestaurantActivity));
            activityRestaurant.PutExtra("loginTransmission", loginEntry);
            activityRestaurant.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityRestaurant);
        }
    }
}