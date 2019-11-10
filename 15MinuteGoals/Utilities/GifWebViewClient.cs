using Android;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Webkit;

namespace _15MinuteGoals.Utilities
{
    public class GifWebViewClient : WebViewClient
    {
        Activity activity;
        public GifWebViewClient(Activity mActivity)
        {
            activity = mActivity;
        }
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.SetBackgroundColor(Color.Transparent);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Base11)
            {
                view.SetLayerType(LayerType.Software, null);
                var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                activity.RequestPermissions(permissions, 1);
            }
        }
    }
}