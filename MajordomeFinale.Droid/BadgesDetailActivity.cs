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
    [Activity(Label = "BadgesDetail", MainLauncher = false, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class BadgesDetailActivity : Activity
    {
        public string loginEntry;
        public string passwordEntry;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Restaurant" layout resource
            SetContentView(Resource.Layout.BadgesDetail);

            loginEntry = Intent.GetStringExtra("loginTransmission") ?? "Login not available";
            passwordEntry = Intent.GetStringExtra("passwordTransmission") ?? "Password not available";

            ImageButton linkRestaurant = FindViewById<ImageButton>(Resource.Id.linkRestaurant);
            //Restaurant button click action
            linkRestaurant.Click += BtnlinkRestaurant_Click;

            ImageButton linkAccount = FindViewById<ImageButton>(Resource.Id.linkAccount);
            //Account button click action
            linkAccount.Click += BtnlinkAccount_Click;

            ImageButton linkRoute = FindViewById<ImageButton>(Resource.Id.linkRoute);
            //Route button click action
            linkRoute.Click += BtnLinkRoute_Click;
        }

        private void BtnlinkRestaurant_Click(object sender, EventArgs e)
        {
            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to the Restaurant around you !", ToastLength.Short).Show();

            var activityRestaurant = new Intent(this, typeof(AccountActivity));
            activityRestaurant.PutExtra("loginTransmission", loginEntry);
            activityRestaurant.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityRestaurant);
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

        private void BtnLinkRoute_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Heading to route proposal !", ToastLength.Short).Show();

            var activityRoute = new Intent(this, typeof(RestaurantDetailActivity));
            activityRoute.PutExtra("loginTransmission", loginEntry);
            activityRoute.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityRoute);
        }
    }

    
}