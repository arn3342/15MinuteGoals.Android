using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Security;

namespace _15MinuteGoals
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.NoActionBar", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class GenerateHash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            PackageInfo info = this.PackageManager.GetPackageInfo("com.Devarn.x15MinuteGoals", PackageInfoFlags.Signatures);
            foreach(Android.Content.PM.Signature signs in info.Signatures)
            {
                MessageDigest md = MessageDigest.GetInstance("SHA");
                md.Update(signs.ToByteArray());
                string keyhash = Convert.ToBase64String(md.Digest());
                Console.WriteLine("Hash:{0}", keyhash);
            }
        }
    }
}