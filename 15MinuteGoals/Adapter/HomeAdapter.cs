using _15MinuteGoals.Data.Models;
using _15MinuteGoals.UI.AnimationClasses;
using _15MinuteGoals.UI.Dialogs;
using _15MinuteGoals.Utilities;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Google.Android.Flexbox;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class HomeAdapter : RecyclerView.Adapter, IViewAdapter
    {
        public List<object> contentCollection;
        public static Context mContext;
        const int homeTop = 0; const int gradeBox = 1; const int subject = 2; const int banner = 3;
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
            else if (contentCollection[position] is TutorAndGradeBox)
            {
                return gradeBox;
            }
            else if (contentCollection[position] is List<Subject>)
            {
                return subject;
            }
            else if (contentCollection[position] is Banner)
            {
                return banner;
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
                    HomeTopViewHolder vh = holder as HomeTopViewHolder;
                    //vh2.totalInspire.Text = vh2.totalInspire.Text.Replace("xx", contentCollection[position].ToString());
                    break;
                case gradeBox:
                    GradeBoxViewHolder vh2 = holder as GradeBoxViewHolder;
                    break;
                case subject:
                    SubjectViewHolder vh3 = holder as SubjectViewHolder;
                    List<Subject> subjectList = contentCollection[position] as List<Subject>;

                    #region Constructing the subject buttons
                    foreach (Subject subject in subjectList)
                    {
                        Button _subjectBtn = new Button(mContext);
                        var layoutParams = new FlexboxLayout.LayoutParams(0, FlexboxLayout.LayoutParams.WrapContent);
                        layoutParams.TopMargin = ValueConverter.DpToPx(10);
                        layoutParams.FlexBasisPercent = 0.33F;
                        layoutParams.Order = 2;
                        _subjectBtn.LayoutParameters = layoutParams;
                        _subjectBtn.SetPadding(0, ValueConverter.DpToPx(10), 0, 0);
                        _subjectBtn.SetBackgroundColor(Color.Transparent);
                        _subjectBtn.Text = subject.Title;
                        _subjectBtn.SetCompoundDrawablesWithIntrinsicBounds(0, subject.IconId, 0, 0);

                        SubjectClick clickAndFocus = new SubjectClick();
                        _subjectBtn.SetOnClickListener(clickAndFocus);
                        _subjectBtn.OnFocusChangeListener = clickAndFocus;

                        vh3.flexLayout.AddView(_subjectBtn);
                    }
                    #region Adding smart tutor btn
                    //View smartTutorBtn = LayoutInflater.From(mContext).Inflate(Resource.Layout.customview_smartTutorButton, vh3.flexLayout, false);
                    //var smartTutorParams = new FlexboxLayout.LayoutParams(0, FlexboxLayout.LayoutParams.WrapContent);
                    //smartTutorParams.TopMargin = ValueConverter.DpToPx(10);
                    //smartTutorParams.FlexBasisPercent = 0.63F;
                    //smartTutorParams.Order = 2;
                    //smartTutorBtn.LayoutParameters = smartTutorParams;
                    //vh3.flexLayout.AddView(smartTutorBtn);
                    #endregion
                    #endregion
                    break;

                case banner:
                    BannerViewHolder vh4 = holder as BannerViewHolder;
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
                case gradeBox:
                    vh = new GradeBoxViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_gradeButton, parent, false));
                    break;
                case subject:
                    SubjectViewHolder viewHolder = new SubjectViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.container_flexBox, parent, false));
                    vh = viewHolder;
                    break;
                case banner:
                    vh = new BannerViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_banner, parent, false));
                    break;
            }
            return vh;
        }

        internal class SubjectViewHolder : RecyclerView.ViewHolder
        {
            public FlexboxLayout flexLayout { get; set; }

            public SubjectViewHolder(View itemView) : base(itemView)
            {
                flexLayout = itemView.FindViewById<FlexboxLayout>(Resource.Id.flexBoxContainer);
            }

            private void FeedbackButton_Click(object sender, System.EventArgs e)
            {
                FeedbackDialog feedbackDialog = new FeedbackDialog();
                feedbackDialog.Show(mFragmentManager, "Feedback fragment");
            }


        }
        private class SubjectClick : Java.Lang.Object, View.IOnClickListener, View.IOnFocusChangeListener
        {
            bool IsInspired;
            public void OnClick(View v)
            {
                Button view = (Button)v;
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
        internal class HomeTopViewHolder : RecyclerView.ViewHolder
        {
            public TextView totalInspire { get; set; }
            public HomeTopViewHolder(View itemView) : base(itemView)
            {
                //totalInspire = itemView.FindViewById<TextView>(Resource.Id.canInspire);
            }
        }

        internal class GradeBoxViewHolder : RecyclerView.ViewHolder
        {
            public GradeBoxViewHolder(View itemView) : base(itemView)
            {
            }
        }
        internal class BannerViewHolder : RecyclerView.ViewHolder
        {
            public BannerViewHolder(View itemView) : base(itemView)
            {
            }
        }
    }
}