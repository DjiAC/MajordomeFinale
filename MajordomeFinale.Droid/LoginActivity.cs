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
using Android.Views.InputMethods;

namespace MajordomeFinale.Droid
{
    [Activity(Label = "Login", MainLauncher = true, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class LoginActivity : Activity
    {
        public string loginEntry;
        public string passwordEntry;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);            

            // Set our view from the "Login" layout resource
            SetContentView(Resource.Layout.Login);

            //Initializing button from layout
            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);

            //Login button click action
            loginButton.Click += BtnLogin_Click;            

            var varloginEntry = FindViewById<EditText>(Resource.Id.LoginEntry);
            varloginEntry.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                loginEntry = e.Text.ToString();
            };

            var varpasswordEntry = FindViewById<EditText>(Resource.Id.PasswordEntry);
            varpasswordEntry.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                passwordEntry = e.Text.ToString();
            };
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {   
            String WebService = CallWebService.CallWebServiceMajordome(loginEntry, passwordEntry, "Login", "").Result;

            if (WebService == "{\"result\":\"OK\",\"code\":\"0\"}")
            {
                Toast.MakeText(this, "Login succesful !", ToastLength.Short).Show();

                var activityRestaurant = new Intent(this, typeof(RestaurantActivity));
                activityRestaurant.PutExtra("loginTransmission", loginEntry);
                activityRestaurant.PutExtra("passwordTransmission", passwordEntry);
                StartActivity(activityRestaurant);
            }
            else
            {
                Toast.MakeText(this, "Wrong Login/Password combinaison !", ToastLength.Long).Show();
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            EditText loginEdit = FindViewById<EditText>(Resource.Id.LoginEntry);
            EditText passwordEdit = FindViewById<EditText>(Resource.Id.PasswordEntry);

            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(loginEdit.WindowToken, 0);
            imm.HideSoftInputFromWindow(passwordEdit.WindowToken, 0);
            return base.OnTouchEvent(e);
        }
    }
}