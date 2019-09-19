using _15MinuteGoals.Data.Models;
using _15MinuteGoals.UI.AnimationClasses;
using Android.Animation;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using FFImageLoading;
using Android.Support.V4.App;
using System.Collections.Generic;
using _15MinuteGoals.UI.Dialogs;

namespace _15MinuteGoals.Adapter
{
    public class PostRegularAdapter : RecyclerView.Adapter
    {
        public List<object> contentCollection;
        const int WritePost = 0; const int RegularPost = 1;
        public FragmentManager FragmentManager { get; set; }

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
                    vh2.totalInspire.Text = vh2.totalInspire.Text.Replace("xx", contentCollection[position].ToString());
                    break;
                case RegularPost:
                    PostRegularViewHolder vh3 = holder as PostRegularViewHolder;
                    PostRegular post = contentCollection[position] as PostRegular;
                    vh3.userFullName.Text = post.UserFullName;
                    ImageService.Instance.LoadUrl(post.UserImageUrl).Into(vh3.userImg);
                    vh3.postBody.Text = post.PostBody;
                    vh3.inspireCount.Text = post.InspireCount;
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
                    PostRegularViewHolder viewHolder = new PostRegularViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_postregular, parent, false));
                    viewHolder.fragmentManager = FragmentManager;
                    vh = viewHolder;
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
            public ImageView InspireButton { get; set; }
            public LinearLayout InspireContainer { get; set; }
            public Button FeedbackButton { get; set; }

            public FragmentManager fragmentManager { get; set; }
            public bool IsInspired = false;
            public PostRegularViewHolder(View itemView) : base(itemView)
            {
                userImg = itemView.FindViewById<ImageView>(Resource.Id.feed_user_image);
                userFullName = itemView.FindViewById<TextView>(Resource.Id.username);
                postBody = itemView.FindViewById<TextView>(Resource.Id.postself);
                inspireCount = itemView.FindViewById<TextView>(Resource.Id.inspireCount);
                InspireButton = itemView.FindViewById<ImageView>(Resource.Id.inspireButton);
                InspireContainer = itemView.FindViewById<LinearLayout>(Resource.Id.inspireButtonContainer);
                FeedbackButton = itemView.FindViewById<Button>(Resource.Id.feedbackbtn);

                InspireContainer.Click += InspireButton_Click;
                FeedbackButton.Click += FeedbackButton_Click;
            }

            private void FeedbackButton_Click(object sender, System.EventArgs e)
            {
                FeedbackDialog feedbackDialog = new FeedbackDialog();
                feedbackDialog.Show(fragmentManager, "Feedback fragment");
            }

            private void InspireButton_Click(object sender, System.EventArgs e)
            {
                if (!IsInspired)
                {
                    InspireButton.SetImageResource(Resource.Drawable.bg_inspirebtn_inspired);
                    InspireButton.SetBackgroundResource(Resource.Drawable.bg_user_headerbar_textview_blue);
                    IsInspired = true;
                }
                else
                {
                    InspireButton.SetImageResource(Resource.Drawable.bg_inspirebtn);
                    InspireButton.SetBackgroundResource(Resource.Drawable.bg_user_headerbar_textview);
                    IsInspired = false;
                }

                Context context = InspireButton.Context;
                Animation anim = AnimationUtils.LoadAnimation(context, Resource.Animation.bounceScaleAnimation);
                ScaleBounceInterpolator scaleBounceInterpolator = new ScaleBounceInterpolator(0.2, 20);
                anim.Interpolator = scaleBounceInterpolator;
                InspireButton.StartAnimation(anim);
            }
        }

        public class CreatePostViewHolder : RecyclerView.ViewHolder
        {
            public TextView totalInspire { get; set; }
            public CreatePostViewHolder(View itemView) : base(itemView)
            {
                totalInspire = itemView.FindViewById<TextView>(Resource.Id.canInspire);
            }
        }
    }
}