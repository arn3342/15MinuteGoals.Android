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

namespace _15MinuteGoals.Activities
{
    [Activity(Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpActivity : AppCompatActivity
    {
        ImageView GoBack, ProceedBtn;
        static WebView UserImageBox;
        static TextView DataBox;
        LinearLayout Container;

        List<string> dataHints = new List<string> { "ইমেইল বা ফোন নম্বর", "অবসর সময়ের শখ", "জীবনের লক্ষ্য", "" };

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
                    TextSize = TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Resources.System.DisplayMetrics),
                    TextAlignment = TextAlignment.Center,
                    Gravity = GravityFlags.Center,
                    Alpha = 0f,
                    TranslationY = -50
                };
                data.SetHeight(ValueConverter.DpToPx(32));
                data.SetTextColor(Color.ParseColor("#868686"));

                Container.AddView(data, DataIndex);

                Animations animations = new Animations();
                animations.AnimateObject(data, new string[] { "TranslationY", "Alpha" }, new float[] { 0, 1 }, 200);

                DataIndex += 1;
                DataBox.Text = string.Empty;

                DataBox.Hint = dataHints[0];
                dataHints.RemoveAt(0);

                if(string.IsNullOrEmpty(dataHints[0]))
                {
                    DataBox.Enabled = false;
                    DataBox.Alpha = 0;
                    AnimateDataBox();
                }
            }
        }

        private void AnimateDataBox()
        {
            ValueAnimator Animator = ValueAnimator.OfInt(DataBox.MeasuredWidth, ValueConverter.DpToPx(44));
            Animator.AddUpdateListener(new AnimUpdateListner(DataBox));
            Animator.SetDuration(250);
            Animator.Start();
        }
        private class AnimUpdateListner : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            View mView;
            public AnimUpdateListner(View view)
            {
                mView = view;
            }
            public void OnAnimationUpdate(ValueAnimator animation)
            {
                int value = (int)animation.AnimatedValue;
                ViewGroup.LayoutParams layoutParams = mView.LayoutParameters;
                layoutParams.Width = value;
                mView.LayoutParameters = layoutParams;
            }
        }
        private void GoBack_Click(object sender, EventArgs e)
        {
            this.OnBackPressed();
        }
    }
}