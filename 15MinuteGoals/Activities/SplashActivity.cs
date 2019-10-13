using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using FFImageLoading;
using System.Threading.Tasks;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppBlueTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]

    public class SplashActivity : AppCompatActivity
    {
        private readonly int interval = 4000;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_splash);

            ImageView progress = FindViewById<ImageView>(Resource.Id.progressBox);
            ImageView logoAnim = FindViewById<ImageView>(Resource.Id.appAnimationBox);

            ImageService.Instance.LoadCompiledResource("progressAnimation.gif").Into(progress);
            ImageService.Instance.LoadCompiledResource("appLogoAnimation.gif").Into(logoAnim);
            NextActivity();
        }

        private async void NextActivity()
        {
            await Task.Delay(interval);
            Intent intent = new Intent(this, typeof(SignInActivity));
            this.StartActivity(intent);
            this.Finish();
        }
    }
}