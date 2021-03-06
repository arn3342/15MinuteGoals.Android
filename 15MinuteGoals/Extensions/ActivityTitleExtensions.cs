﻿using _15MinuteGoals.Utilities;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;

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

        public static TextView ConstructTitle(Context context, string Title, LinearLayout container = null, int Background = Resource.Drawable.bg_fragmentTitle, string TextColorCode = "#ffffff")
        {
            DisplayMetrics metrics = Resources.System.DisplayMetrics;
            var layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            if (container == null)
            {
                var Parameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Bottom | GravityFlags.Center);
                Parameters.BottomMargin = ((metrics.HeightPixels / 100) * 10) + ValueConverter.DpToPx(10);
                layoutParams = Parameters;
            }
            else
            {
                var Parameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                layoutParams = Parameters;
            }
            TextView title = new TextView(context)
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
            title.SetBackgroundResource(Background);
            title.SetTextColor(Color.ParseColor(TextColorCode));
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