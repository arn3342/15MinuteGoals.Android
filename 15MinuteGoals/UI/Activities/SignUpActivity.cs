using _15MinuteGoals.Utilities;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using Android.Content;
using Android.Provider;
using Android.Runtime;
using Android.Database;
using Java.IO;
using FFImageLoading;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Theme = "@style/Theme.AppBlueTheme", WindowSoftInputMode = SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpActivity : AppCompatActivity
    {
        Button ProceedBtn;
        ImageView UserImageBox;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signUp);
            // Create your application here

            ProceedBtn = FindViewById<Button>(Resource.Id.proceedBtn);
            UserImageBox = FindViewById<ImageView>(Resource.Id.userImg);

            ProceedBtn.Click += ProceedBtn_Click;


            ImageService.Instance.LoadCompiledResource("userDefaultFace.gif").Into(UserImageBox);
            UserImageBox.Click += UserImageBox_Click;

        }

        private void UserImageBox_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionGetContent, MediaStore.Images.Media.ExternalContentUri);
            intent.SetType("image/*");
            StartActivityForResult(Intent.CreateChooser(intent, "Select image"), 1000);
        }

        private void ProceedBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1000 && resultCode == Result.Ok && data != null)
            {
                string path = FileChooser.getPath(this, data.Data);
                ImageService.Instance.LoadFile(path).Into(UserImageBox);
                UserImageBox.SetImageURI(data.Data);
                
            }
        }
    }
}