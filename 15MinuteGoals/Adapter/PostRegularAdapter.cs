﻿using _15MinuteGoals.Data.Models;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class PostRegularAdapter : RecyclerView.Adapter
    {
        public List<object> contentCollection;
        const int WritePost = 0; const int RegularPost = 1;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public override int GetItemViewType(int position)
        {
            if (contentCollection[position] is string)
            {
                return WritePost;
            }
            else
            {
                return RegularPost;
            }
        }

        public PostRegularAdapter(List<object> itemList)
        {
            contentCollection = itemList;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch(holder.ItemViewType)
            {
                case WritePost:
                    CreatePostViewHolder vh2 = holder as CreatePostViewHolder;
                    vh2.userFirstName.Text = contentCollection[position] + ", share something inspiring!";
                    break;

                case RegularPost:
                    PostRegularViewHolder vh = holder as PostRegularViewHolder;
                    PostRegular post = contentCollection[position] as PostRegular;
                    vh.userFullName.Text = post.UserFullName;
                    ImageService.Instance.LoadUrl(post.UserImageUrl).Into(vh.userImg);
                    vh.postBody.Text = post.PostBody;
                    vh.inspireCount.Text = post.InspireCount;
                    break;
            }

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
                    vh = new PostRegularViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_postregular, parent, false));
                    break;
            }
            return vh;
        }

        public class PostRegularViewHolder : RecyclerView.ViewHolder
        {
            public ImageView userImg { get; set; }
            public TextView userFullName { get; set; }
            public TextView postBody { get; set; }
            public TextView inspireCount { get; set; }

            public PostRegularViewHolder(View itemView) : base(itemView)
            {
                userImg = itemView.FindViewById<ImageView>(Resource.Id.feed_user_image);
                userFullName = itemView.FindViewById<TextView>(Resource.Id.username);
                postBody = itemView.FindViewById<TextView>(Resource.Id.postself);
                inspireCount = itemView.FindViewById<TextView>(Resource.Id.inspireCount);
            }
        }
        public class CreatePostViewHolder : RecyclerView.ViewHolder
        {
            public ImageView userImg { get; set; }
            public TextView userFirstName { get; set; }
            public CreatePostViewHolder(View itemView) : base(itemView)
            {
                userImg = itemView.FindViewById<ImageView>(Resource.Id.topBar_user_image);
                userFirstName = itemView.FindViewById<TextView>(Resource.Id.user_headerbar_title);
            }
        }
    }
}