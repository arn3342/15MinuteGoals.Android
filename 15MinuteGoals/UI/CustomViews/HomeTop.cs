using _15MinuteGoals.Utilities;
using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using System;

namespace _15MinuteGoals.UI.CustomViews
{
    public class HomeTop : ConstraintLayout, ICustomViewAnimated
    {
        #region Constructors & properties
        public HomeTop(Context context) : base(context)
        {
            Initialize(context);
        }

        public HomeTop(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public HomeTop(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }

        protected HomeTop(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public long AnimationDelay { get; set; } = 0;
        #endregion

        private void Initialize(Context ctx)
        {
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            var MainView = inflatorService.Inflate(Resource.Layout.customview_homeTop, this, false);
            AddView(MainView);
        }
    }
}