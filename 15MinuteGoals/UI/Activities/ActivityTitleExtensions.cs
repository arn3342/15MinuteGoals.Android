using _15MinuteGoals.Utilities;
using Android.Animation;
using Android.Content.Res;
using Android.Graphics;
using Android.Util;
using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace _15MinuteGoals.UI.Activities
{
    public static class ActivityTitleExtensions
    {
        private static TextView title;
        private static FrameLayout mContainer;

        public static void AnimateTitle(this AppCompatActivity activity, FrameLayout container, string Title)
        {
            title = ConstructTitle(activity, Title);
            mContainer = container;
            container.AddView(title);

            StartAnimation();
        }

        private static void StartAnimation()
        {
            Animations animations = new Animations();
            animations.animatorSet.AnimationEnd += (object sender, EventArgs e) => { EndAnimation(); };
            animations.AnimateObject(title, new string[] { "TranslationY", "Alpha" }, new float[] { 0, 1 }, 300);
        }

        private static void EndAnimation()
        {
            Animations animations = new Animations();
            animations.animatorSet.AnimationEnd += (object sender, EventArgs e) => { RemoveTitle(mContainer); };
            animations.AnimateObject(title, new string[] { "TranslationY", "Alpha" }, new float[] { 50, 0 }, 300, 1500);
        }

        private static TextView ConstructTitle(AppCompatActivity activity, string Title)
        {
            DisplayMetrics metrics = Resources.System.DisplayMetrics;
            var layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Bottom | GravityFlags.Center);
            layoutParams.BottomMargin = ((metrics.HeightPixels / 100) * 10) + ValueConverter.DpToPx(10);
            TextView title = new TextView(activity)
            {
                Text = Title,
                TextSize = TypedValue.ApplyDimension(ComplexUnitType.Dip, 8, metrics),
                TextAlignment = TextAlignment.Center,
                Alpha = 0,
                TranslationY = 50f
            };

            int paddingLeftRight = ValueConverter.DpToPx(20);
            int paddingTopBottom = ValueConverter.DpToPx(10);
            title.SetPadding(paddingLeftRight, paddingTopBottom, paddingLeftRight, paddingTopBottom);
            title.SetBackgroundResource(Resource.Drawable.bg_fragmentTitle);
            title.SetTextColor(Color.White);
            title.LayoutParameters = layoutParams;

            return title;
        }

        private static void RemoveTitle(FrameLayout container, int position = 1)
        {
            container.RemoveViewAt(position);
        }

        private class AnimUpdateListner : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            View mView;
            public AnimUpdateListner(View view)
            {
                mView = view;
            }
            public void OnAnimationUpdate(ValueAnimator animation)
            {
                int value = (int)animation.AnimatedValue;
                ViewGroup.LayoutParams layoutParams = mView.LayoutParameters;
                layoutParams.Height = value;
                mView.LayoutParameters = layoutParams;
            }
        }
    }
}