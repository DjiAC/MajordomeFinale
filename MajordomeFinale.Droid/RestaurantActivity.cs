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
        public string loginEntry;
        public string passwordEntry;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Restaurant" layout resource
            SetContentView(Resource.Layout.Restaurant);

            loginEntry = Intent.GetStringExtra("loginTransmission") ?? "Login not available";
            passwordEntry = Intent.GetStringExtra("passwordTransmission") ?? "Password not available";

            ImageButton linkAccount = FindViewById<ImageButton>(Resource.Id.linkAccount);
            //Login button click action
            linkAccount.Click += BtnlinkAccount_Click;

            ImageButton linkRoute = FindViewById<ImageButton>(Resource.Id.linkRoute);
            //Login button click action
            linkRoute.Click += BtnLinkRoute_Click;

            ImageButton epicurien = FindViewById<ImageButton>(Resource.Id.epicurien);
            epicurien.Click += BtnEpicurien_Click;

            Button buttonEpicurien = FindViewById<Button>(Resource.Id.buttonEpicurien);
            buttonEpicurien.Click += BtnEpicurien_Click;

            ImageButton cedre = FindViewById<ImageButton>(Resource.Id.cedre);
            cedre.Click += BtnCedre_Click;

            Button buttonCedre = FindViewById<Button>(Resource.Id.buttonCedre);
            buttonCedre.Click += BtnCedre_Click;

            ImageButton tacos = FindViewById<ImageButton>(Resource.Id.tacos);
            tacos.Click += BtnTacos_Click;

            Button buttonTacos = FindViewById<Button>(Resource.Id.buttonTacos);
            buttonTacos.Click += BtnTacos_Click;
        }

        private void BtnEpicurien_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Heading to L'Epicurien's Page !", ToastLength.Short).Show();

            var activityRestaurantDetail = new Intent(this, typeof(RestaurantDetailActivity));
            activityRestaurantDetail.PutExtra("loginTransmission", loginEntry);
            activityRestaurantDetail.PutExtra("passwordTransmission", passwordEntry);
            activityRestaurantDetail.PutExtra("idRestaurant", "5");
            StartActivity(activityRestaurantDetail);
        }

        private void BtnCedre_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Heading to Le Cedre Page !", ToastLength.Short).Show();

            var activityRestaurantDetail = new Intent(this, typeof(RestaurantDetailActivity));
            activityRestaurantDetail.PutExtra("loginTransmission", loginEntry);
            activityRestaurantDetail.PutExtra("passwordTransmission", passwordEntry);
            activityRestaurantDetail.PutExtra("idRestaurant", "7");
            StartActivity(activityRestaurantDetail);
        }

        private void BtnTacos_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Heading to Tacos de Grenoble Page !", ToastLength.Short).Show();

            var activityRestaurantDetail = new Intent(this, typeof(RestaurantDetailActivity));
            activityRestaurantDetail.PutExtra("loginTransmission", loginEntry);
            activityRestaurantDetail.PutExtra("passwordTransmission", passwordEntry);
            activityRestaurantDetail.PutExtra("idRestaurant", "10");
            StartActivity(activityRestaurantDetail);
        }


        private void BtnlinkAccount_Click(object sender, EventArgs e)
        {

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