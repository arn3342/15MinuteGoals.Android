using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace _15MinuteGoals.Utilities
{
    public class GifWebViewClient : WebViewClient
    {
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.SetBackgroundColor(Color.Transparent);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Base11) view.SetLayerType(LayerType.Software, null);

        }
    }
}