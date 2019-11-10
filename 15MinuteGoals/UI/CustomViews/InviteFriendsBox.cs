using _15MinuteGoals.Utilities;
using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using System;

namespace _15MinuteGoals.UI.CustomViews
{
    public class InviteFriendsBox : ConstraintLayout, ICustomViewAnimated
    {
        #region Constructors & properties
        public InviteFriendsBox(Context context) : base(context)
        {
            Initialize(context);
        }

        public InviteFriendsBox(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public InviteFriendsBox(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }

        protected InviteFriendsBox(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public long AnimationDelay { get; set; } = 0;
        #endregion

        private void Initialize(Context ctx)
        {
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            var MainView = inflatorService.Inflate(Resource.Layout.customview_inviteFriendBox, this, false);
            AddView(MainView);

            #region Animating view on load
            Alpha = 0;

            Animations animations = new Animations();
            animations.AnimateObject(this, "Alpha", 1, 200, AnimationDelay);
            #endregion
        }
    }
}