using _15MinuteGoals.Data.Models;
using _15MinuteGoals.UI.AnimationClasses;
using _15MinuteGoals.UI.CustomViews;
using _15MinuteGoals.UI.Dialogs;
using Android.Content;
using Android.Support.Constraints;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class HomeAdapter : RecyclerView.Adapter, IViewAdapter
    {
        public List<object> contentCollection;
        Context mContext;
        const int homeTop = 0; const int subject = 1;
        static FragmentManager mFragmentManager;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public override int GetItemViewType(int position)
        {
            if (contentCollection[position] is Home)
            {
                return homeTop;
            }
            else if(contentCollection[position] is Subject)
            {
                return subject;
            }
            return contentCollection.Count;
        }

        public HomeAdapter(Context context, List<object> itemList, FragmentManager fragmentManager)
        {
            mContext = context;
            contentCollection = itemList;
            mFragmentManager = fragmentManager;
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case homeTop:
                    HomeTopViewHolder vh2 = holder as HomeTopViewHolder;
                    //vh2.totalInspire.Text = vh2.totalInspire.Text.Replace("xx", contentCollection[position].ToString());
                    break;
                case subject:
                    SubjectViewHolder vh3 = holder as SubjectViewHolder;
                    Subject _subject = contentCollection[position] as Subject;
                    vh3.subjectTitle.Text = _subject.Title;
                    vh3.subjectIcon.SetImageResource(_subject.IconId);
                    vh3.subjectContainer.SetBackgroundResource(_subject.BackgroundId);
                    break;
            }

        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder vh = null;
            switch (viewType)
            {
                case homeTop:
                    vh = new HomeTopViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_homeTop, parent, false));
                    break;
                case subject:
                    SubjectViewHolder viewHolder = new SubjectViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_subject, parent, false));
                    vh = viewHolder;
                    break;
            }
            return vh;
        }

        internal class SubjectViewHolder : RecyclerView.ViewHolder
        {
            public ImageView subjectIcon { get; set; }
            public TextView subjectTitle { get; set; }
            public ConstraintLayout subjectContainer { get; set; }
            public int backgroundId { get; set; }

            public SubjectViewHolder(View itemView) : base(itemView)
            {
                subjectIcon = itemView.FindViewById<ImageView>(Resource.Id.subjectIcon);
                subjectTitle = itemView.FindViewById<TextView>(Resource.Id.subjectName);

                subjectContainer = itemView.FindViewById<ConstraintLayout>(Resource.Id.subject_container);
                //postBody = itemView.FindViewById<TextView>(Resource.Id.postself);
                //inspireCount = itemView.FindViewById<TextView>(Resource.Id.inspireCount);
                //InspireButton = itemView.FindViewById<ImageView>(Resource.Id.inspireButton);
                //FeedbackButton = itemView.FindViewById<Button>(Resource.Id.feedbackbtn);
                SubjectClick clickAndFocus = new SubjectClick();
                subjectContainer.SetOnClickListener(clickAndFocus);
                subjectContainer.OnFocusChangeListener = clickAndFocus;
            }

            private void FeedbackButton_Click(object sender, System.EventArgs e)
            {
                FeedbackDialog feedbackDialog = new FeedbackDialog();
                feedbackDialog.Show(mFragmentManager, "Feedback fragment");
            }

            private class SubjectClick : Java.Lang.Object, View.IOnClickListener, View.IOnFocusChangeListener
            {
                bool IsInspired;
                public void OnClick(View v)
                {
                    ConstraintLayout view = (ConstraintLayout)v;
                    Context context = view.Context;
                    Animation anim = AnimationUtils.LoadAnimation(context, Resource.Animation.bounceScaleAnimation);
                    ScaleBounceInterpolator scaleBounceInterpolator = new ScaleBounceInterpolator(0.1, 10);
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

        internal class HomeTopViewHolder : RecyclerView.ViewHolder
        {
            public TextView totalInspire { get; set; }
            public HomeTopViewHolder(View itemView) : base(itemView)
            {
                //totalInspire = itemView.FindViewById<TextView>(Resource.Id.canInspire);
            }
        }
    }
}