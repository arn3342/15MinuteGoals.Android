using _15MinuteGoals.UI.CustomViews;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using FFImageLoading;
using Java.IO;
using Java.Lang;
using Java.Net;
using Javax.Net.Ssl;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static Android.Graphics.BitmapFactory;

namespace _15MinuteGoals.Utilities
{
    public class ImageLoader
    {
        Context mContext;
        ImageView mImageView;
        BitmapDrawable background;

        public ImageLoader(ImageView imageView, Context context)
        {
            mContext = context;
            mImageView = imageView;
        }

        public BitmapDrawable LoadFromURL(string URL)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadDataCompleted += Client_DownloadDataCompleted;
                client.DownloadDataAsync(new Uri(URL));
            }
            return background;
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            byte[] imageData = e.Result;

            var pathToDir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Purnota/";
            Directory.CreateDirectory(pathToDir);
            Random rand = new Random();
            int next = rand.Next(200, 500);
            Java.IO.File file = new Java.IO.File(pathToDir, next.ToString() + ".png");
            FileOutputStream fos = new FileOutputStream(file.Path);
            fos.Write(imageData);
            fos.Close();

            //Setting image to ImageView
            try
            {
                var imagePath = pathToDir + next.ToString() + ".png";
                //ImageService.Instance.LoadFile(imagePath).Into(mImageView);
                mImageView.SetImageURI(Android.Net.Uri.Parse(imagePath));
            }
            catch(Java.Lang.Exception ex)
            {
                Toast.MakeText(mContext, ex.StackTrace, ToastLength.Short);
            }
        }


        //protected override Bitmap RunInBackground(params string[] @params)
        //{
        //    for(int i = 0; i < @params.Length; i++)
        //    {
        //        using (WebClient client = new WebClient())
        //        {
        //            client.DownloadFileAsync(new Uri(@params[i]), "path goes here");
        //        }
        //        //string url = @params[i];
        //        //BitmapFactory.Options ops = new BitmapFactory.Options();
        //        //ops.InJustDecodeBounds = true;

        //        ////                          Find the correct scale value. It should be the power of 2.
        //        //int REQUIRED_SIZE = 70;
        //        //int width_tmp = ops.OutWidth, height_tmp = ops.OutHeight;
        //        //int scale = 1;
        //        //while (true)
        //        //{
        //        //    if (width_tmp / 2 < REQUIRED_SIZE || height_tmp / 2 < REQUIRED_SIZE)
        //        //        break;
        //        //    width_tmp /= 2;
        //        //    height_tmp /= 2;
        //        //    scale *= 2;
        //        //}

        //        //ops.InJustDecodeBounds = false;
        //        //ops.InSampleSize = scale;
        //        //var ss = new URL(url).OpenStream();
        //        //Bitmap bm = BitmapFactory.DecodeStream(ss, null, ops);
        //        //return bm;
        //    }
        //    return null;
        //}
        //protected override void OnPostExecute(Bitmap result)
        //{
        //    base.OnPostExecute(result);
        //    mImageView.SetImageBitmap(result);
        //}

    }
}
