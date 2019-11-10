﻿using _15MinuteGoals.Data.Models;
using _15MinuteGoals.UI.AnimationClasses;
using _15MinuteGoals.UI.CustomViews;
using _15MinuteGoals.UI.Dialogs;
using _15MinuteGoals.Utilities;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Java.Net;
using System;
using System.Collections.Generic;
using System.Net;

namespace _15MinuteGoals.Adapter
{
    public class PostRegularAdapter : RecyclerView.Adapter, IViewAdapter
    {
        public List<object> contentCollection;
        Context mContext;
        const int WritePost = 0; const int RegularPost = 1;
        static FragmentManager mFragmentManager;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public override int GetItemViewType(int position)
        {
            if (contentCollection[position] is int)
            {
                return WritePost;
            }
            else
            {
                return RegularPost;
            }
        }

        public PostRegularAdapter(Context context, List<object> itemList, FragmentManager fragmentManager)
        {
            mContext = context;
            contentCollection = itemList;
            mFragmentManager = fragmentManager;
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case WritePost:
                    CreatePostViewHolder vh2 = holder as CreatePostViewHolder;
                    //vh2.totalInspire.Text = vh2.totalInspire.Text.Replace("xx", contentCollection[position].ToString());
                    break;
                case RegularPost:
                    PostRegularViewHolder vh3 = holder as PostRegularViewHolder;
                    PostRegular post = contentCollection[position] as PostRegular;
                    vh3.userFullName.Text = post.UserFullName;
                    vh3.postBody.Text = post.PostBody;
                    vh3.inspireCount.Text = post.InspireCount;
                    WebClient cl = new WebClient();

                    //cl.DownloadDataCompleted += new DownloadDataCompletedEventHandler((s, e) => ImageDownloaded(s, e, vh3.userImg));//Cl_DownloadDataCompleted;
                    //var image = cl.DownloadData(new Uri(post.UserImageUrl));
                    //Bitmap bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);
                    //vh3.userImg.SetImageDrawable(new BitmapDrawable(mContext.Resources, bitmap));
                    //URL url = new URL(post.UserImageUrl);
                    //Bitmap bitmap = BitmapFactory.DecodeStream(url.OpenConnection().InputStream);
                    ImageLoader loader = new ImageLoader(vh3.userImg, mContext);
                    loader.LoadFromURL(post.UserImageUrl);

                    //BlobCache.LocalMachine.LoadImageFromUrl(post.UserImageUrl).Wait().ToNative();//.ToNative();
                    //IBitmap
                    //using (MemoryStream ms = new MemoryStream(image))
                    //{
                    //    Bitmap bitmap = BitmapFactory.DecodeStream(ms);
                    //    var background = new BitmapDrawable(mContext.Resources, bitmap);
                    //    vh3.userImg.Background = background;
                    //}
                    //ImageService.Instance.Load(post.UserImageUrl).Into(vh3.userImg);

                    #region Setting user's image from URL
                    //WebClient client = new WebClient();
                    //client.DownloadDataCompleted +=
                    //    async delegate (object sender, DownloadDataCompletedEventArgs e)
                    //    {
                    //        byte[] imageData;
                    //        imageData = e.Result;
                    //        MemoryStream ms = new MemoryStream(imageData);
                    //        Bitmap bitmap = await BitmapFactory.DecodeStreamAsync(ms);
                    //        BitmapDrawable background = new BitmapDrawable(mContext.Resources, bitmap);
                    //        vh3.userImg.Background = background;

                    //    };
                    //client.DownloadDataAsync(new Uri(post.UserImageUrl));
                    #endregion
                    break;
            }

        }

        private void ImageDownloaded(object sender, DownloadDataCompletedEventArgs e, ImageView view)
        {
            var image = e.Result;
            Bitmap bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);
            view.SetImageDrawable(new BitmapDrawable(mContext.Resources, bitmap));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder vh = null;
            switch (viewType)
            {
                case WritePost:
                    vh = new CreatePostViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_user_writepostbar, parent, false));
                    break;
                case RegularPost:
                    PostRegularViewHolder viewHolder = new PostRegularViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_postregular, parent, false));
                    vh = viewHolder;
                    break;
            }
            return vh;
        }

        internal class PostRegularViewHolder : RecyclerView.ViewHolder
        {
            public ImageView userImg { get; set; }
            public TextView userFullName { get; set; }
            public TextView postBody { get; set; }
            public TextView inspireCount { get; set; }
            public ImageView InspireButton { get; set; }
            public Button FeedbackButton { get; set; }

            public PostRegularViewHolder(View itemView) : base(itemView)
            {
                userImg = itemView.FindViewById<ImageView>(Resource.Id.feed_user_image);
                userFullName = itemView.FindViewById<TextView>(Resource.Id.username);
                postBody = itemView.FindViewById<TextView>(Resource.Id.postself);
                inspireCount = itemView.FindViewById<TextView>(Resource.Id.inspireCount);
                InspireButton = itemView.FindViewById<ImageView>(Resource.Id.inspireButton);
                FeedbackButton = itemView.FindViewById<Button>(Resource.Id.feedbackbtn);
                InspireButtonClick clickAndFocus = new InspireButtonClick();
                InspireButton.SetOnClickListener(clickAndFocus);
                InspireButton.OnFocusChangeListener = clickAndFocus;
                //FeedbackButton.Click += FeedbackButton_Click;
            }

            private void FeedbackButton_Click(object sender, System.EventArgs e)
            {
                FeedbackDialog feedbackDialog = new FeedbackDialog();
                feedbackDialog.Show(mFragmentManager, "Feedback fragment");
            }

            private class InspireButtonClick : Java.Lang.Object, View.IOnClickListener, View.IOnFocusChangeListener
            {
                bool IsInspired;
                public void OnClick(View v)
                {
                    ImageView view = (ImageView)v;
                    if (!IsInspired)
                    {
                        view.SetImageResource(Resource.Drawable.bg_inspirebtn_inspired);
                        view.SetBackgroundResource(Resource.Drawable.bg_inspireButton_selected);
                        IsInspired = true;
                    }
                    else
                    {
                        view.SetImageResource(Resource.Drawable.bg_inspirebtn);
                        view.SetBackgroundResource(Resource.Drawable.bg_inspireButton);
                        IsInspired = false;
                    }

                    Context context = view.Context;
                    Animation anim = AnimationUtils.LoadAnimation(context, Resource.Animation.bounceScaleAnimation);
                    ScaleBounceInterpolator scaleBounceInterpolator = new ScaleBounceInterpolator(0.2, 20);
                    anim.Interpolator = scaleBounceInterpolator;
                    view.StartAnimation(anim);
                }

                public void OnFocusChange(View v, bool hasFocus)
                {
                    if (v.HasFocus)
                    {
                        OnClick(v);
                    }
                }
            }
        }

        internal class CreatePostViewHolder : RecyclerView.ViewHolder
        {
            public TextView totalInspire { get; set; }
            public CreatePostViewHolder(View itemView) : base(itemView)
            {
                //totalInspire = itemView.FindViewById<TextView>(Resource.Id.canInspire);
            }
        }
    }
}