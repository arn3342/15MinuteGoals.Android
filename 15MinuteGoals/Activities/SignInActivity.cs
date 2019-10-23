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
    [Activity(Label = "Sign in to achieve", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInActivity : AppCompatActivity
    {
        EditText emailInput, passwordInput;
        static Button loginButton, signUpBtn;
        static ImageView progressBox;
        private readonly int interval = 3500;
        private LinearLayout buttonContainer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signIn);
            // Create your application here

            emailInput = this.FindViewById<EditText>(Resource.Id.emailinput);
            passwordInput = this.FindViewById<EditText>(Resource.Id.passwordinput);
            loginButton = this.FindViewById<Button>(Resource.Id.loginbutton);
            progressBox = FindViewById<ImageView>(Resource.Id.progressBox);
            signUpBtn = FindViewById<Button>(Resource.Id.signupbutton);
            buttonContainer = FindViewById<LinearLayout>(Resource.Id.buttonContainer);

            loginButton.Click += LoginButton_Click;
            signUpBtn.Click += SignUpBtn_Click;
        }

       

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == "nabilrashid44@gmail.com" && passwordInput.Text == "arn3342")
            {
                progressBox.Visibility = ViewStates.Visible;
                ImageService.Instance.LoadCompiledResource("progressAnimation.gif").Into(progressBox);

                AnimateObject(buttonContainer, new string[] { "TranslationY", "Alpha" }, new float[] { 100, 0 });
                AnimateObject(progressBox, new string[] { "TranslationY", "Alpha" }, new float[] { 0, 1 });
                NextActivity();
            }
        }

        private void AnimateObject(View sender, string[] PropertyNames, float[] Values, long Duration = 200)
        {
            List<Animator> animations = new List<Animator>();
            for(int i = 0; i < PropertyNames.Length; i++)
            {
                ObjectAnimator objectAnimator = ObjectAnimator.OfFloat(sender, PropertyNames[i], Values[i]);
                animations.Add(objectAnimator);
            }

            AnimatorSet animatorSet = new AnimatorSet();
            animatorSet.PlayTogether(animations.ToArray());
            animatorSet.SetDuration(Duration);

            animatorSet.Start();
        }

        private async void NextActivity()
        {
            await Task.Delay(interval);
            Intent intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);
            this.Finish();
        }
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignUpActivity));
            StartActivity(intent);
            Finish();
        }
    }
}