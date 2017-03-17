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
using Newtonsoft.Json;

namespace MajordomeFinale.Droid
{
    [Activity(Label = "RestaurantDetail", MainLauncher = false, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class RestaurantDetailActivity : Activity
    {
        public string loginEntry;
        public string passwordEntry;
        public string idRestaurant;

        public class JsonResult
        {
            public string code { get; set; }
            public string result { get; set; }
            public string json { get; set; }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Restaurant" layout resource
            SetContentView(Resource.Layout.RestaurantDetail);

            loginEntry = Intent.GetStringExtra("loginTransmission") ?? "Login not available";
            passwordEntry = Intent.GetStringExtra("passwordTransmission") ?? "Password not available";
            idRestaurant = Intent.GetStringExtra("idRestaurant") ?? "id not available";

            var WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "GetInfosRestaurant", "{\"id_restaurant\":\""+ idRestaurant + "\"}").Result;
            var jsonResult = JsonConvert.DeserializeObject<JsonResult>(WebService);
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResult.json);

            TextView nameRestaurant = FindViewById<TextView>(Resource.Id.restaurantName);
            nameRestaurant.Text = result["name"];

            TextView cookType = FindViewById<TextView>(Resource.Id.cookType);
            cookType.Text = result["cook_type"];

            TextView budget = FindViewById<TextView>(Resource.Id.budget);
            budget.Text = result["budget"];

            TextView phone = FindViewById<TextView>(Resource.Id.phone);
            phone.Text = result["phone"];

            TextView grade = FindViewById<TextView>(Resource.Id.grade);
            grade.Text = result["grade"];

            TextView schedule = FindViewById<TextView>(Resource.Id.schedule);
            schedule.Text = result["schedule"];            

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.nb_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            

            ImageButton linkRestaurant = FindViewById<ImageButton>(Resource.Id.linkRestaurant);
            //Login button click action
            linkRestaurant.Click += BtnlinkRestaurant_Click;

            ImageButton linkAccount = FindViewById<ImageButton>(Resource.Id.linkAccount);
            //Login button click action
            linkAccount.Click += BtnlinkAccount_Click;

            ImageButton linkRoute = FindViewById<ImageButton>(Resource.Id.linkRoute);
            //Login button click action
            linkRoute.Click += BtnLinkRoute_Click;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("Your reservation is confirmed", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void BtnlinkRestaurant_Click(object sender, EventArgs e)
        {
            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to the Restaurant around you !", ToastLength.Short).Show();

            var activityRestaurant = new Intent(this, typeof(RestaurantActivity));
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
            // String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            Toast.MakeText(this, "Heading to route proposal !", ToastLength.Short).Show();

            var activityRoute = new Intent(this, typeof(RouteActivity));
            activityRoute.PutExtra("loginTransmission", loginEntry);
            activityRoute.PutExtra("passwordTransmission", passwordEntry);
            StartActivity(activityRoute);
        }
    }

    
}