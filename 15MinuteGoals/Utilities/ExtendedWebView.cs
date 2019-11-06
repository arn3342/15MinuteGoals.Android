using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Provider;
using Android.Util;
using Android.Webkit;
using Java.IO;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _15MinuteGoals.Utilities
{
    public static class ExtendedWebView
    {
        public static void LoadAnimation(this WebView webView, Activity activity, string GifName, int GifHeight = 100, int GifWidth = 100, bool IsRounded = false)
        {
            if (activity != null && webView != null)
            {
                webView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                webView.SetWebViewClient(new GifWebViewClient(activity));
                string GifSource = GifName;
                string imageWidth = GifWidth.ToString() + "%";
                string imageHeight = GifHeight.ToString() + "%";
                AssetManager assets = activity.Assets;
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

        public static void LoadImage(this WebView webView, Activity activity, string FilePath, bool IsRounded)
        {
            webView.SetBackgroundColor(Color.Transparent);
            webView.SetWebViewClient(new GifWebViewClient(activity));

            FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            byte[] imageRaw;

            //var options = new BitmapFactory.Options();
            //options.InJustDecodeBounds = true;
            //options.InSampleSize = CalculateInSampleSize(options, 250, 250);
            //Bitmap reducedImage = BitmapFactory.DecodeStream(stream, null, options);
            //ByteArrayOutputStream bytestream = new ByteArrayOutputStream();
            //reducedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            //imageRaw = bytestream.ToByteArray();

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    int read;
            //    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            //    {
            //        ms.Write(buffer, 0, read);
            //    }
            //    imageRaw = ms.ToArray();
            //}

            //MemoryStream output = new MemoryStream();
            //using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            //{
            //    dstream.Write(imageRaw, 0, imageRaw.Length);
            //}
            //imageRaw = output.ToArray();


            // Desired Bitmap and the html code, where you want to place it
            Bitmap bitmap = null;
            //Java.IO.File f = new Java.IO.File(FilePath);
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InPreferredConfig = Bitmap.Config.Argb8888;

            bitmap = BitmapFactory.DecodeStream(stream, null, options);
            string html = "<html><body><img src='{IMAGE_PLACEHOLDER}' /></body></html>";

            // Convert bitmap to Base64 encoded image for web
            MemoryStream byteArrayOutputStream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, byteArrayOutputStream);
            byte[] byteArray = byteArrayOutputStream.ToArray();
            string image64 = Base64.EncodeToString(byteArray, Base64.Default);
            string image = "data:image/png;base64," + image64;

            // Use image for the img src parameter in your html and load to webview
            html = html.Replace("{IMAGE_PLACEHOLDER}", image);

            //var html = "";
            //if (IsRounded)
            //{
            //    html = $"<body><img src=\"data:image/jpeg;base64," + image64 + "\" alt=\"A Gif file\" width=\"100%\" height=\"100%\" style=\"width: 100%; height: auto; border-radius: 50%\"/></body>";
            //}
            //else
            //{
            //    html = $"<body><img src=\"data:image/jpeg;base64," + image64 + "\" alt=\"A Gif file\" width=\"100%\" height=\"100%\" style=\"width: 100%; height: auto;\"/></body>";
            //}
            webView.Settings.AllowFileAccess = true;
            webView.LoadData(image64, "image/jpeg", "base64");
        }

        public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            // Raw height and width of image
            int height = options.OutHeight;
            int width = options.OutWidth;
            int inSampleSize = 1;

            if (height > reqHeight || width > reqWidth)
            {

                int halfHeight = height / 2;
                int halfWidth = width / 2;

                // Calculate the largest inSampleSize value that is a power of 2 and keeps both
                // height and width larger than the requested height and width.
                while ((halfHeight / inSampleSize) >= reqHeight
                        && (halfWidth / inSampleSize) >= reqWidth)
                {
                    inSampleSize *= 2;
                }
            }

            return inSampleSize;
        }
    }
}