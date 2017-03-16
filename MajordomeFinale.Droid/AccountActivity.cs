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
    [Activity(Label = "Account", MainLauncher = false, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class AccountActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Route" layout resource
            SetContentView(Resource.Layout.Restaurant);

            ImageButton linkRoute = FindViewById<ImageButton>(Resource.Id.linkRoute);
            //Login button click action
            linkRoute.Click += BtnlinkRoute_Click;

            ImageButton linkRestaurant = FindViewById<ImageButton>(Resource.Id.linkRestaurant);
            //Login button click action
            linkRestaurant.Click += BtnlinkRestaurant_Click;
        }

        private void BtnlinkRoute_Click(object sender, EventArgs e)
        {

            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to route proposal !", ToastLength.Short).Show();

            var activityRoute = new Intent(this, typeof(RouteActivity));
            StartActivity(activityRoute);
        }

        private void BtnlinkRestaurant_Click(object sender, EventArgs e)
        {

            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to Restaurants page !", ToastLength.Short).Show();

            var activityRestaurant = new Intent(this, typeof(RestaurantActivity));
            StartActivity(activityRestaurant);
        }
    }
}