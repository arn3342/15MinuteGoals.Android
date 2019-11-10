using _15MinuteGoals.UI.Activities;
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
    public class StartJourney : ConstraintLayout, ICustomViewAnimated
    {
        #region Constructors & properties
        public StartJourney(Context context) : base(context)
        {
            Initialize(context);
        }

        public StartJourney(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public StartJourney(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }

        protected StartJourney(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public long AnimationDelay { get; set; } = 0;
        #endregion

        private void Initialize(Context ctx)
        {
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            var MainView = inflatorService.Inflate(Resource.Layout.customview_startJourney, this, false);
            AddView(MainView);

            Button startJourney = FindViewById<Button>(Resource.Id.startJourneyBtn);
            startJourney.Click += StartJourney_Click;

            #region Animating view on load
            Alpha = 0;

            Animations animations = new Animations();
            animations.AnimateObject(this, "Alpha", 1, 200, AnimationDelay);
            #endregion
        }

        private void StartJourney_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(GradeActivity));
            Context.StartActivity(intent);
        }
    }
}