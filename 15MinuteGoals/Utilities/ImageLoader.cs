using _15MinuteGoals.Data.Models;
using Android.Support.V7.Widget;
using Java.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace _15MinuteGoals.Utilities
{
    public class ImageLoader
    {
        RecyclerView.Adapter mAdapter;
        List<object> mContents;
        public ImageLoader(RecyclerView.Adapter adapter, List<object> contents)
        {
            mAdapter = adapter;
            mContents = contents;
        }
        public void LoadImage(string URL, int position)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadDataCompleted += (s, e) => Client_DownloadDataCompleted(s, e, URL, position);
                client.DownloadDataAsync(new Uri(URL));
            }
        }

        public void LoadImage(params string[] URLs)
        {
            try
            {
                Parallel.For(0, URLs.Length, index => StartWebClient(URLs[index], index));
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }

        private void StartWebClient(string URL, int position)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadDataCompleted += (s, e) => Client_DownloadDataCompleted(s, e, URL, position);
                    client.DownloadDataAsync(new Uri(URL));
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e, string url, int position)
        {
            try
            {
                WriteFileToCache(url, e.Result, position);
            }
            catch (Exception ex)
            {
                string e2 = ex.ToString();
            }
        }

        #region Downloading image from URL and saving to cache
        private string GetCacheDirectory()
        {
            try
            {
                string pathToDir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Purnota/";
                if (!Directory.Exists(pathToDir))
                    Directory.CreateDirectory(pathToDir);
                return pathToDir;
            }
            catch (Exception ex)
            {
                string e2 = ex.ToString();
            }
            return null;
        }

        private string GetFileName(string url)
        {
            int index = url.LastIndexOf('/');
            string fileName = url.Substring(index + 1);
            return fileName;
        }

        private void WriteFileToCache(string url, byte[] data, int position)
        {
            byte[] imageData = data;
            using (Java.IO.File file = new Java.IO.File(GetCacheDirectory(), GetFileName(url)))
            {
                if (file.Exists())
                {
                    UpdateRecyclerView(position, file.Path);
                }
                else
                {
                    using (FileOutputStream fos = new FileOutputStream(file.Path))
                    {
                        fos.Write(imageData);
                        UpdateRecyclerView(position, file.Path);
                    }
                }
                
            }

        }
        #endregion

        private void UpdateRecyclerView(int position, string path)
        {
            position += 1; //Increasing position by 1, because the first view is CreatePostView, not PostRegular view
            PostRegular post = mContents[position] as PostRegular;
            post.UserImageUrl = path;
            mAdapter.NotifyItemChanged(position);
        }
    }
}
