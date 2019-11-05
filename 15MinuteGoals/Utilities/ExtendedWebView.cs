using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Webkit;

namespace _15MinuteGoals.Utilities
{
    public static class ExtendedWebView
    {
        public static void LoadAnimation(this WebView webView, Context context, string GifName, int GifHeight = 100, int GifWidth = 100, bool IsRounded = false)
        {
            if (context != null && webView != null)
            {
                webView.SetBackgroundColor(Color.Transparent);
                webView.SetWebViewClient(new GifWebViewClient());
                string GifSource = GifName;
                string imageWidth = GifWidth.ToString() + "%";
                string imageHeight = GifHeight.ToString() + "%";
                AssetManager assets = context.Assets;
                using (var stream = assets.Open(GifSource))
                using (var options = new BitmapFactory.Options { InJustDecodeBounds = true })
                {
                    BitmapFactory.DecodeStream(stream, null, options);
                }
                var html = "";
                if (IsRounded)
                {
                    html = $"<body><img src=\"{GifSource}\" alt=\"A Gif file\" width=\"{imageWidth}\" height=\"{imageHeight}\" style=\"width: 100%; height: auto; border-radius: 50%\"/></body>";
                }
                else
                {
                    html = $"<body><img src=\"{GifSource}\" alt=\"A Gif file\" width=\"{imageWidth}\" height=\"{imageHeight}\" style=\"width: 100%; height: auto;\"/></body>";
                }
                webView.Settings.AllowFileAccessFromFileURLs = true;
                webView.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "UTF-8", "");
            }
        }

        public static void LoadImage(this WebView webView, string FilePath, bool IsRounded)
        {
            FilePath = "file://" + FilePath;
            var html = "";
            if (IsRounded)
            {
                html = $"<body><img src=\"{FilePath}\" alt=\"https://img.freepik.com/free-photo/wall-wallpaper-concrete-colored-painted-textured-concept_53876-31799.jpg?size=626&ext=jpg\" border-radius: 50%\"/></body>";
            }
            else
            {
                html = $"<body><img src=\"{FilePath}\"/></body>";
            }
            webView.Settings.AllowFileAccessFromFileURLs = true;
            webView.LoadDataWithBaseURL("", html, "text/html", "UTF-8", "");
        }
    }
}