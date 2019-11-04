using _15MinuteGoals.Utilities;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using Android.Content.Res;
using Android.Graphics;
using System.Collections.Generic;
using Android.Animation;
using Android.Content;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpActivity : AppCompatActivity
    {
        Button ProceedBtn;
        static WebView UserImageBox;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signUp);
            // Create your application here

            ProceedBtn = FindViewById<Button>(Resource.Id.proceedBtn);
            UserImageBox = FindViewById<WebView>(Resource.Id.userImg);

            ProceedBtn.Click += ProceedBtn_Click;

            GIFWebView gifWebView = new GIFWebView();
            UserImageBox = gifWebView.ConfigureWebView(this, UserImageBox, "userDefaultFace.gif", IsRounded: true);

        }

        private void ProceedBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}