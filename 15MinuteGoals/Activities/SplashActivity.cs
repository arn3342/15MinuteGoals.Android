using _15MinuteGoals.Utilities;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Transitions;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using FFImageLoading;
using System.Net.Http;
using System.Threading.Tasks;

namespace _15MinuteGoals.Activities
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

            Fade fade = new Fade();
            View decor = Window.DecorView;
            fade.ExcludeTarget(decor.FindViewById(Resource.Id.action_bar_container), true);
            fade.ExcludeTarget(decor.FindViewById(Android.Resource.Id.StatusBarBackground), true);
            fade.ExcludeTarget(decor.FindViewById(Android.Resource.Id.NavigationBarBackground), true);

            ImageView progress = FindViewById<ImageView>(Resource.Id.progressBox);
            logoAnim = FindViewById<WebView>(Resource.Id.appAnimationBox);

            GIFWebView gifWebView = new GIFWebView();
            logoAnim = gifWebView.ConfigureWebView(this, logoAnim, "appLogoAnimation.gif");

            //logoAnim.SetBackgroundColor(Color.Transparent);
            //logoAnim.SetWebViewClient(new GifWebViewClient());

            //string GifSource = "appLogoAnimation.gif";
            //string imageWidth = "100%";
            //string imageHeight = "100%";
            //using (var stream = Assets.Open(GifSource))
            //using (var options = new BitmapFactory.Options { InJustDecodeBounds = true })
            //{
            //    BitmapFactory.DecodeStream(stream, null, options);
            //}
            //var html = $"<body><img src=\"{GifSource}\" alt=\"A Gif file\" width=\"{imageWidth}\" height=\"{imageHeight}\" style=\"width: 100%; height: auto;\"/></body>";
            //logoAnim.Settings.AllowFileAccessFromFileURLs = true;
            //logoAnim.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "UTF-8", "");

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