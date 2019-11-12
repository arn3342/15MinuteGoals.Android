using _15MinuteGoals.Data.Models;
using Android.Support.V7.Widget;
using Java.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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
        public async void LoadImage(params string[] URLs)
        {
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(10)
            };

            var taskList = new List<Task<string>>();

            int position = 0;
            for (position = 0; position < URLs.Length; position++)
            {
                // by virtue of not awaiting each call, you've already acheived parallelism
                taskList.Add(GetResponseAsync(URLs[position], position));
            }

            try
            {
                // asynchronously wait until all tasks are complete
                await Task.WhenAll(taskList.ToArray());
            }
            catch (Exception ex)
            {
            }

            async Task<string> GetResponseAsync(string ImageURL, int position)
            {
                // no Task.Run here!
                var response = await httpClient.GetAsync(new Uri(ImageURL));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var imageData = await response.Content.ReadAsByteArrayAsync();
                    WriteFileToCache(ImageURL, imageData, position);
                }
                return null;
            }
        }

        #region Downloading image from URL and saving to cache
        private string GetCacheDirectory()
        {
            string pathToDir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Purnota/";
            if (!Directory.Exists(pathToDir))
                Directory.CreateDirectory(pathToDir);
            return pathToDir;
        }

        private string GetFileName(string url)
        {
            int index = url.LastIndexOf('/');
            string fileName = url.Substring(index + 1);
            return fileName;
        }

        private async void WriteFileToCache(string url, byte[] data, int position)
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
                        await fos.WriteAsync(imageData);
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
