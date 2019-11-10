using System;
using System.IO;
using System.Net;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;

namespace _15MinuteGoals.Extensions
{
    public static class ImageViewExtension
    {
        public static void SetBackgroundFromURL(this ImageView imageView, string URL)
        {
            using (WebClient client = new WebClient())
            {
                byte[] imageData;

                client.DownloadDataCompleted +=
                   async delegate (object sender, DownloadDataCompletedEventArgs e)
                   {
                       imageData = e.Result;
                       MemoryStream ms = new MemoryStream(imageData);

                       Bitmap bitmap = await BitmapFactory.DecodeStreamAsync(ms).ConfigureAwait(false);
                       BitmapDrawable background = new BitmapDrawable(imageView.Context.Resources, bitmap);
                       imageView.Background = background;
                   };
                client.DownloadDataAsync(new Uri(URL));
            }
        }
    }
}