using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _15MinuteGoals.Activities
{
    [Activity(Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signUp);
            // Create your application here


        }
    }
}