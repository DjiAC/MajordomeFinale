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
    [Activity(Label = "Account", MainLauncher = false, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class AccountActivity : Activity
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
            SetContentView(Resource.Layout.Account);

            loginEntry = Intent.GetStringExtra("loginTransmission") ?? "Login not available";
            passwordEntry = Intent.GetStringExtra("passwordTransmission") ?? "Password not available";

            var WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "GetPersonnalInfos", "").Result;
            var jsonResult = JsonConvert.DeserializeObject<JsonResult>(WebService);
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResult.json);

            TextView accountLogin = FindViewById<TextView>(Resource.Id.accountLogin);
            accountLogin.Text = result["login"];

            TextView accountMail = FindViewById<TextView>(Resource.Id.accountMail);
            accountMail.Text = result["mail"];

            TextView accountPassword = FindViewById<TextView>(Resource.Id.accountPassword);
            accountPassword.Text = result["password"];

            TextView accountBirthdate = FindViewById<TextView>(Resource.Id.accountBirthdate);
            accountBirthdate.Text = result["birthdate"];

            TextView accountBadges = FindViewById<TextView>(Resource.Id.accountBadges);
            accountBadges.Text = result["nbbadges"];

            TextView accountRestaurant = FindViewById<TextView>(Resource.Id.accountRestaurant);
            accountRestaurant.Text = result["nbrestaurants"];

            ImageButton badge1 = FindViewById<ImageButton>(Resource.Id.badge1);
            //Route button click action
            badge1.Click += BtnBadges_Click;

            ImageButton badge2 = FindViewById<ImageButton>(Resource.Id.badge2);
            //Route button click action
            badge2.Click += BtnBadges_Click;

            ImageButton badge3 = FindViewById<ImageButton>(Resource.Id.badge3);
            //Route button click action
            badge3.Click += BtnBadges_Click;

            ImageButton badge4 = FindViewById<ImageButton>(Resource.Id.badge4);
            //Route button click action
            badge4.Click += BtnBadges_Click;

            TextView accountRestaurants = FindViewById<TextView>(Resource.Id.accountRestaurant);
            accountRestaurants.Text = result["nbrestaurants"];

            ImageButton restaurant1 = FindViewById<ImageButton>(Resource.Id.restaurant1);
            //Route button click action
            restaurant1.Click += BtnRestaurant1_Click;

            ImageButton restaurant2 = FindViewById<ImageButton>(Resource.Id.restaurant2);
            //Route button click action
            restaurant2.Click += BtnRestaurant2_Click;

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
            badgesDetails.PutExtra("restaurant", "3");
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

        private void BtnRestaurant2_Click(object sender, EventArgs e)
        {
            var restaurantDetail2 = new Intent(this, typeof(RestaurantDetailActivity));
            restaurantDetail2.PutExtra("loginTransmission", loginEntry);
            restaurantDetail2.PutExtra("passwordTransmission", passwordEntry);
            restaurantDetail2.PutExtra("restaurant", "2");
            StartActivity(restaurantDetail2);
        }

        private void BtnRestaurant1_Click(object sender, EventArgs e)
        {
            var restaurantDetail1 = new Intent(this, typeof(RestaurantDetailActivity));
            restaurantDetail1.PutExtra("loginTransmission", loginEntry);
            restaurantDetail1.PutExtra("passwordTransmission", passwordEntry);
            restaurantDetail1.PutExtra("restaurant", "1");
            StartActivity(restaurantDetail1);
        }

        private void Btnfriend1_Click(object sender, EventArgs e)
        {
            var publicAccount = new Intent(this, typeof(PublicAccountActivity));
            publicAccount.PutExtra("loginTransmission", loginEntry);
            publicAccount.PutExtra("passwordTransmission", passwordEntry);
            publicAccount.PutExtra("idFriend", "1");
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