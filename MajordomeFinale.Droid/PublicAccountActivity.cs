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
using System.Diagnostics;
using Newtonsoft.Json;

namespace MajordomeFinale.Droid
{
    [Activity(Label = "PublicAccount", MainLauncher = false, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class PublicAccountActivity : Activity
    {
        public string loginEntry;
        public string passwordEntry;

        public class JsonResult
        {
            public string code { get; set; }
            public string result { get; set; }
            public string json { get; set; }
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "Route" layout resource
            SetContentView(Resource.Layout.PublicAccount);

            loginEntry = Intent.GetStringExtra("loginTransmission") ?? "Login not available";
            passwordEntry = Intent.GetStringExtra("passwordTransmission") ?? "Password not available";

            var WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "GetPersonnalInfos", "").Result;
            var jsonResult = JsonConvert.DeserializeObject<JsonResult>(WebService);

            System.Diagnostics.Debug.WriteLine(jsonResult.json);

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResult.json);

            TextView accountLogin = FindViewById<TextView>(Resource.Id.accountLogin);
            accountLogin.Text = result["login"];

            TextView accountMail = FindViewById<TextView>(Resource.Id.accountMail);
            accountMail.Text = result["mail"];

            TextView accountBirthdate = FindViewById<TextView>(Resource.Id.accountBirthdate);
            accountBirthdate.Text = result["birthdate"];

            TextView accountBadges = FindViewById<TextView>(Resource.Id.accountBadges);
            accountBadges.Text = result["nbbadges"];

            TextView accountRestaurant = FindViewById<TextView>(Resource.Id.accountRestaurant);
            accountRestaurant.Text = result["nbrestaurants"];

            ImageButton badge2 = FindViewById<ImageButton>(Resource.Id.badge2);
            //Route button click action
            badge2.Click += BtnBadges_Click;

            ImageButton badge4 = FindViewById<ImageButton>(Resource.Id.badge4);
            //Route button click action
            badge4.Click += BtnBadges_Click;

            TextView accountRestaurants = FindViewById<TextView>(Resource.Id.accountRestaurant);
            accountRestaurants.Text = result["nbrestaurants"];

            ImageButton restaurant3 = FindViewById<ImageButton>(Resource.Id.restaurant3);
            //Route button click action
            restaurant3.Click += BtnRestaurant3_Click;

            ImageButton friend1 = FindViewById<ImageButton>(Resource.Id.friend1);
            //Route button click action
            friend1.Click += Btnfriend1_Click;

            ImageButton linkRoute = FindViewById<ImageButton>(Resource.Id.linkRoute);
            //Route button click action
            linkRoute.Click += BtnlinkRoute_Click;

            ImageButton linkRestaurant = FindViewById<ImageButton>(Resource.Id.linkRestaurant);
            //Restaurant button click action
            linkRestaurant.Click += BtnlinkRestaurant_Click;
        }

        private void BtnBadges_Click(object sender, EventArgs e)
        {
            var badgesDetails = new Intent(this, typeof(BadgesDetailActivity));
            badgesDetails.PutExtra("loginTransmission", loginEntry);
            badgesDetails.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(badgesDetails);
        }

        private void BtnRestaurant3_Click(object sender, EventArgs e)
        {
            var restaurantDetail3 = new Intent(this, typeof(RestaurantDetailActivity));
            restaurantDetail3.PutExtra("loginTransmission", loginEntry);
            restaurantDetail3.PutExtra("passwordTransmission", passwordEntry);
            restaurantDetail3.PutExtra("restaurant", "3");
            StartActivity(restaurantDetail3);
        }

        private void Btnfriend1_Click(object sender, EventArgs e)
        {
            var publicAccount = new Intent(this, typeof(PublicAccountActivity));
            publicAccount.PutExtra("loginTransmission", loginEntry);
            publicAccount.PutExtra("passwordTransmission", passwordEntry);
            publicAccount.PutExtra("idFriend", "2");
            StartActivity(publicAccount);
        }

        private void BtnlinkRoute_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Heading to route proposal !", ToastLength.Short).Show();

            var activityRoute = new Intent(this, typeof(RouteActivity));
            activityRoute.PutExtra("loginTransmission", loginEntry);
            activityRoute.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityRoute);
        }

        private void BtnlinkAccount_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Heading to your account !", ToastLength.Short).Show();

            var activityAccount = new Intent(this, typeof(AccountActivity));
            activityAccount.PutExtra("loginTransmission", loginEntry);
            activityAccount.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityAccount);
        }

        private void BtnlinkRestaurant_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Heading to Restaurants page !", ToastLength.Short).Show();

            var activityRestaurant = new Intent(this, typeof(RestaurantActivity));
            activityRestaurant.PutExtra("loginTransmission", loginEntry);
            activityRestaurant.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityRestaurant);
        }
    }
}