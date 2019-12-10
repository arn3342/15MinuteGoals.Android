using _15MinuteGoals.Utilities;
using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;

namespace _15MinuteGoals.UI.CustomViews
{
    public class SubjectView : ConstraintLayout, ICustomViewAnimated
    {
        #region Constructors & properties

        ConstraintLayout mainLayout;
        ImageView subjectIcon;
        TextView subjectTitle;
        public SubjectView(Context context) : base(context)
        {
            Initialize(context);
        }

        public SubjectView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public SubjectView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }

        protected SubjectView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public long AnimationDelay { get; set; } = 0;
        #endregion

        private void Initialize(Context ctx)
        {
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            var MainView = inflatorService.Inflate(Resource.Layout.customview_subject, this, false);
            AddView(MainView);
            //mainLayout = MainView.FindViewById<ConstraintLayout>(Resource.Id.main_container);
            //subjectIcon = MainView.FindViewById<ImageView>(Resource.Id.subjectIcon);
            //subjectTitle = MainView.FindViewById<TextView>(Resource.Id.subjectName);
        }
    }
}