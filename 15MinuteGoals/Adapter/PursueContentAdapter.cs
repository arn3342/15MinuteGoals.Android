using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _15MinuteGoals.Data.Models;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.Adapter
{
    public class PursueContentAdapter : RecyclerView.Adapter
    {
        public List<object> contentCollection;
        const int CourseBox = 0; const int ContentVideo = 1; const int ContentArticle = 2;
        public event EventHandler ViewHolderCreated;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public override int GetItemViewType(int position)
        {
            if (contentCollection[position] is Pursue_CourseBox)
            {
                return CourseBox;
            }
            else if (contentCollection[position] is Pursue_ContentVideo)
            {
                return ContentVideo;
            }
            else
            {
                return ContentArticle;
            }
        }

        public PursueContentAdapter(List<object> contents)
        {
            contentCollection = contents;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case CourseBox:
                    CourseBoxViewHolder vh2 = holder as CourseBoxViewHolder;
                    Pursue_CourseBox course = contentCollection[position] as Pursue_CourseBox;
                    vh2.CourseTitle.Text = course.Title;
                    vh2.CourseAuthor.Text = course.Author;
                    break;
                case ContentVideo:
                    PursueContentVideViewHolder vh3 = holder as PursueContentVideViewHolder;
                    Pursue_ContentVideo video = contentCollection[position] as Pursue_ContentVideo;
                    vh3.VideoTitle.Text = video.Title;
                    vh3.VideoDuration.Text = video.Duration;
                    break;
                case ContentArticle:
                    PursueContentArticleViewHolde vh = holder as PursueContentArticleViewHolde;
                    Pursue_ContentArticle article = contentCollection[position] as Pursue_ContentArticle;
                    vh.ArticleTitle.Text = article.Title;
                    vh.ArticleDescription.Text = article.Description;
                    break;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder vh = null;

            switch (viewType)
            {
                case CourseBox:
                    vh = new CourseBoxViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_purse_coursebox, parent, false));
                    break;
                case ContentVideo:
                    vh = new PursueContentVideViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_pursue_contentvideo, parent, false));
                    EventHandler handler = ViewHolderCreated;
                    handler?.Invoke(this, null);
                    break;
                case ContentArticle:
                    vh = new PursueContentArticleViewHolde(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_pursue_contentarticle, parent, false));
                    break;
            }

            return vh;
        }

        #region View holders

        public class CourseBoxViewHolder : RecyclerView.ViewHolder
        {
            public TextView CourseTitle { get; set; }
            public TextView CourseAuthor { get; set; }

            public CourseBoxViewHolder(View itemView) : base(itemView)
            {
                CourseTitle = itemView.FindViewById<TextView>(Resource.Id.course_singlebar_courseTitle);
                CourseAuthor = itemView.FindViewById<TextView>(Resource.Id.course_singlebar_coursePublisher);
            }
        }

        public class PursueContentVideViewHolder : RecyclerView.ViewHolder
        {
            public TextView VideoTitle { get; set; }
            public TextView VideoDuration { get; set; }
            public PursueContentVideViewHolder(View itemView) : base(itemView)
            {
                VideoTitle = itemView.FindViewById<TextView>(Resource.Id.contentVideoTitle);
                VideoDuration = itemView.FindViewById<TextView>(Resource.Id.contentVideoDuration);
            }
        }

        public class PursueContentArticleViewHolde : RecyclerView.ViewHolder
        {
            public TextView ArticleTitle { get; set; }
            public TextView ArticleDescription { get; set; }
            public PursueContentArticleViewHolde(View itemView) : base(itemView)
            {
                ArticleTitle = itemView.FindViewById<TextView>(Resource.Id.contentArticleTitle);
                ArticleDescription = itemView.FindViewById<TextView>(Resource.Id.articleDesc);
            }
        }
        #endregion
    }
}