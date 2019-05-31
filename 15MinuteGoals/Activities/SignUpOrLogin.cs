using System;
using _15MinuteGoals.Authentication;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Auth.Api;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.NoActionBar", Icon = "@drawable/main_logo", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpOrLogin : AppCompatActivity, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        private GoogleApiClient mgoogleApiClient;
        //ImageView propic;
        public int SIGN_IN_ID = 9001;
        GoogleAuthentication googleAuth;

        public void OnConnected(Bundle connectionHint)
        {
            //throw new NotImplementedException();
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            //throw new NotImplementedException();
        }

        public void OnConnectionSuspended(int cause)
        {
            //throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signup);
            // Create your application here

            //Binding the events of the login buttons
            FindViewById<Button>(Resource.Id.FacebookLoginBtn).Click += FacebookLogin;
            FindViewById<Button>(Resource.Id.GoogleLoginBtn).Click += GoogleLogIn;

            //propic = FindViewById<ImageView>(Resource.Id.propic);
        }

        #region Signing In
        #region Google Sign In
        private void GoogleLogIn(object sender, EventArgs e)
        {
            googleAuth = new GoogleAuthentication();
            mgoogleApiClient = googleAuth.GoogleLogin(this, this, this, this);
            var signInIntent = Auth.GoogleSignInApi.GetSignInIntent(mgoogleApiClient);
            StartActivityForResult(signInIntent, SIGN_IN_ID);
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == SIGN_IN_ID)
            {
                var result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                //ImageService.Instance.LoadUrl(googleAuth.HandleSignIn(result).ToString()).Into(propic);
            }
        }
        #endregion

        #region Facebook Sign In
        private void FacebookLogin(object sender, EventArgs e)
        {
            FacebookAuthentication facebookAuth = new FacebookAuthentication();
            StartActivity(facebookAuth.InitiateLogin(this));
        }
        #endregion
        #endregion

        #region Saving data to database

        #endregion
        private void LinkedInLogin()
        {

        }
    }
}