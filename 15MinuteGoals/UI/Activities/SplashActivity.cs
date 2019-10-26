using _15MinuteGoals.Utilities;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Webkit;
using Android.Widget;
using FFImageLoading;
using System.Threading.Tasks;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppBlueTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]

    public class SplashActivity : AppCompatActivity
    {
        static WebView logoAnim;
        private readonly int interval = 4000;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_splash);
            this.Window.ExitTransition = null;


            ImageView progress = FindViewById<ImageView>(Resource.Id.progressBox);
            logoAnim = FindViewById<WebView>(Resource.Id.appAnimationBox);

            GIFWebView gifWebView = new GIFWebView();
            logoAnim = gifWebView.ConfigureWebView(this, logoAnim, "appLogoAnimation.gif");

            ImageService.Instance.LoadCompiledResource("progressAnimation.gif").Into(progress);
            NextActivity();
        }

        private async void NextActivity()
        {
            await Task.Delay(interval).ConfigureAwait(true);
            Intent intent = new Intent(this, typeof(SignInActivity));
            ActivityOptions options = ActivityOptions.MakeSceneTransitionAnimation(this, logoAnim, ViewCompat.GetTransitionName(logoAnim));
            StartActivity(intent, options.ToBundle());
            Finish();
        }

        
    }
}