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
using System.Threading.Tasks;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "Sign in to achieve", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInActivity : AppCompatActivity
    {
        EditText emailInput, passwordInput;
        static Button loginButton;
        static ImageView progressBox;
        static TextView newText, signUpBtn;
        private readonly int interval = 3000;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signIn);
            // Create your application here

            emailInput = this.FindViewById<EditText>(Resource.Id.emailinput);
            passwordInput = this.FindViewById<EditText>(Resource.Id.passwordinput);
            loginButton = this.FindViewById<Button>(Resource.Id.loginbutton);
            progressBox = FindViewById<ImageView>(Resource.Id.progressBox);
            newText = FindViewById<TextView>(Resource.Id.newText);
            signUpBtn = FindViewById<TextView>(Resource.Id.signUpBtn);

            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == "nabilrashid44@gmail.com" && passwordInput.Text == "arn3342")
            {
                loginButton.Visibility = ViewStates.Gone;
                signUpBtn.Visibility = ViewStates.Gone;
                newText.Visibility = ViewStates.Gone;
                progressBox.Visibility = ViewStates.Visible;
                ImageService.Instance.LoadCompiledResource("progressAnimation.gif").Into(progressBox);
                NextActivity();
            }
        }

        private async void NextActivity()
        {
            await Task.Delay(interval);
            Intent intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);
            this.Finish();
        }
    }
}