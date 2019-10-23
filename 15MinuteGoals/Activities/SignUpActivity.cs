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

namespace _15MinuteGoals.Activities
{
    [Activity(Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpActivity : AppCompatActivity
    {
        ImageView GoBack, ProceedBtn;
        static WebView UserImageBox;
        TextView DataBox;
        LinearLayout Container;

        int DataIndex = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signUp);
            // Create your application here

            GoBack = FindViewById<ImageView>(Resource.Id.gobackBtn);
            ProceedBtn = FindViewById<ImageView>(Resource.Id.proceedBtn);
            UserImageBox = FindViewById<WebView>(Resource.Id.userImageBox);
            DataBox = FindViewById<TextView>(Resource.Id.dataBox);
            Container = FindViewById<LinearLayout>(Resource.Id.signUpContainer);

            DataIndex = Container.ChildCount - 1;

            GoBack.Click += GoBack_Click;
            ProceedBtn.Click += ProceedBtn_Click;

            GIFWebView gifWebView = new GIFWebView();
            UserImageBox = gifWebView.ConfigureWebView(this, UserImageBox, "userDefaultFace.gif", IsRounded: true);

        }

        private void ProceedBtn_Click(object sender, EventArgs e)
        {
            if(DataBox.Text.Length != 0)
            {
                TextView data = new TextView(this)
                {
                    Text = DataBox.Text,
                    TextSize = TypedValue.ApplyDimension(ComplexUnitType.Dip, 16, Resources.System.DisplayMetrics),
                    TextAlignment = TextAlignment.Center,
                    Gravity = GravityFlags.Center,
                    Alpha = 0f
                };
                data.LayoutParameters = new ViewGroup.LayoutParams(300, 24);

                Container.AddView(data, DataIndex);

                Animations animations = new Animations();
                animations.AnimateObject(data, new string[] { "Layout_Height", "Alpha" }, new float[] { 125, 1 });

                DataIndex += 1;
                Container.Invalidate();
            }
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}