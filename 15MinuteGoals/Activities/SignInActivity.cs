using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System.Threading.Tasks;
using Android.Support.V7.App;
using Android.Widget;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "Sign in to achieve", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInActivity : AppCompatActivity
    {
        EditText emailInput, passwordInput;
        Button loginButton;
        private readonly int interval = 3000;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signIn);
            // Create your application here

            emailInput = this.FindViewById<EditText>(Resource.Id.emailinput);
            passwordInput = this.FindViewById<EditText>(Resource.Id.passwordinput);
            loginButton = this.FindViewById<Button>(Resource.Id.loginbutton);

            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == "nabilrashid44@gmail.com" && passwordInput.Text == "arn3342")
            {
                loginButton.Text = "Logging In...";
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