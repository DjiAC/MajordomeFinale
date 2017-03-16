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

            ImageButton linkAccount = FindViewById<ImageButton>(Resource.Id.linkAccount);
            //Login button click action
            linkAccount.Click += BtnlinkAccount_Click;

            ImageButton linkRoute = FindViewById<ImageButton>(Resource.Id.linkRoute);
            //Login button click action
            linkRoute.Click += BtnLinkRoute_Click;
        }


        private void BtnlinkAccount_Click(object sender, EventArgs e)
        {
            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to your account !", ToastLength.Short).Show();

            var activityAccount = new Intent(this, typeof(AccountActivity));
            StartActivity(activityAccount);
        }

        private void BtnLinkRoute_Click(object sender, EventArgs e)
        {
            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to route proposal !", ToastLength.Short).Show();

            var activityRoute = new Intent(this, typeof(RouteActivity));
            StartActivity(activityRoute);
        }
    }

    
}