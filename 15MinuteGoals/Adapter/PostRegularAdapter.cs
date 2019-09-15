using _15MinuteGoals.Data.Models;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class PostRegularAdapter : RecyclerView.Adapter
    {
        public List<PostRegular> postCollection;
        public string UserFirstName;
        public override int ItemCount
        {
            get
            {
                if (postCollection != null)
                {
                    return postCollection.Count;
                }
                return 1;
            }
        }

        public PostRegularAdapter(List<PostRegular> postList = null, string userFirstName = null)
        {
            if (postList != null)
            {
                postCollection = postList;
            }
            UserFirstName = userFirstName;
        }
        public override int GetItemViewType(int position)
        {
            return position % 2 * 2;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (postCollection == null)
            {
                #region Creating posts
                CreatePostViewHolder vh2 = holder as CreatePostViewHolder;
                vh2.userFirstName.Text = UserFirstName + ", share something inspiring!";
                #endregion
            }
            #region Create 'writing-post' bar
            else
            {
                PostRegularViewHolder vh = holder as PostRegularViewHolder;
                vh.userFullName.Text = postCollection[position].UserFullName;
                ImageService.Instance.LoadUrl(postCollection[position].UserImageUrl).Into(vh.userImg);
                vh.postBody.Text = postCollection[position].PostBody;
                vh.inspireCount.Text = postCollection[position].InspireCount;
            }
            #endregion
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (postCollection == null)
            {
                RecyclerView.ViewHolder vh = new CreatePostViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_user_writepostbar, parent, false));
                return vh;
            }
            else
            {
                RecyclerView.ViewHolder vh2 = new PostRegularViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_postregular, parent, false));
                return vh2;
            }
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