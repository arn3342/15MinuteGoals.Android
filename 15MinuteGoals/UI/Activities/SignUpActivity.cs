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

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Theme = "@style/Theme.AppBlueTheme", WindowSoftInputMode = SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
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

            
            UserImageBox.LoadAnimation(this, "userDefaultFace.gif", IsRounded: true);
            UserImageBox.SetOnTouchListener(new OnTouchListner(this));

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1 && resultCode == Result.Ok && data != null)
            {
                Android.Net.Uri selectedImage = data.Data;
                string[] filePathColumn = { MediaStore.Images.Media.InterfaceConsts.Data };

                ICursor cursor = ContentResolver.Query(selectedImage,
                        filePathColumn, null, null, null);
                cursor.MoveToFirst();

                int columnIndex = cursor.GetColumnIndex(filePathColumn[0]);
                string picturePath = cursor.GetString(columnIndex);
                UserImageBox.LoadImage(picturePath, true);
                cursor.Close();
            }
        }
        private void ProceedBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }

        private class OnTouchListner : Java.Lang.Object, View.IOnTouchListener
        {
            Activity activity;

            public OnTouchListner(Activity act)
            {
                activity = act;
            }
            public bool OnTouch(View v, MotionEvent e)
            {
                Intent intent = new Intent(Intent.ActionPick, MediaStore.Images.Media.ExternalContentUri);
                activity.StartActivityForResult(intent, 1);
                return true;
            }
        }
    }
}