using _15MinuteGoals.Data.Models;
using Android.Content.Res;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using FFImageLoading;

namespace _15MinuteGoals.Adapter
{
    public class PostRegularAdapter : RecyclerView.Adapter
    {
        public List<PostRegular> postCollection;
        public override int ItemCount
        {
            get { return postCollection.Count; }
        }

        public PostRegularAdapter(List<PostRegular> postList)
        {
            postCollection = postList;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PostRegularViewHolder vh = holder as PostRegularViewHolder;
            vh.userFullName.Text = postCollection[position].UserFullName;
            ImageService.Instance.LoadUrl(postCollection[position].UserImageUrl).Into(vh.userImg);
            vh.postBody.Text = postCollection[position].PostBody;
            //vh.inspireCount.Text = postCollection[position].InspireCount;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View mainView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_postregular, parent, false);
            RecyclerView.ViewHolder vh = new PostRegularViewHolder(mainView);
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
                //inspireCount = itemView.FindViewById<TextView>(Resource.Id.totalinspired);
            }
        }
    }
}