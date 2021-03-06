﻿using _15MinuteGoals.UI.AnimationClasses;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Home : Fragment
    {
        private View myview;
        public LinearLayout homeContainer;
        public static ScrollView mScrollView { get; private set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            myview = inflater.Inflate(Resource.Layout.screen_home, container, false);
            homeContainer = myview.FindViewById<LinearLayout>(Resource.Id.homeContainer);
            return myview;
        }

        void AnimateButtonClick(View view)
        {
            Context context = view.Context;
            Animation anim = AnimationUtils.LoadAnimation(context, Resource.Animation.bounceScaleAnimation);
            ScaleBounceInterpolator scaleBounceInterpolator = new ScaleBounceInterpolator(0.2, 5);
            anim.Interpolator = scaleBounceInterpolator;
            view.StartAnimation(anim);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);


            view.ViewTreeObserver.AddOnGlobalLayoutListener(new GlobalLayoutListen());
        }

    }

    internal class GlobalLayoutListen : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        public void OnGlobalLayout()
        {
            //Fragment_Home.mProfileBoxHeight = Fragment_Home.mProfileBox.Height;
            //Fragment_Home.mScrollView.ViewTreeObserver.AddOnScrollChangedListener(new ScrollPositionObserver());
        }
    }

    internal class ScrollPositionObserver : Java.Lang.Object, ViewTreeObserver.IOnScrollChangedListener
    {
        private int profileBoxHeight;
        private ScrollView scrollView;
        private LinearLayout profileBox;

        public ScrollPositionObserver()
        {
            //profileBoxHeight = Fragment_Home.mProfileBoxHeight;
            //scrollView = Fragment_Home.mScrollView;
            //profileBox = Fragment_Home.mProfileBox;
        }


        public void OnScrollChanged()
        {
            int scrollY = Math.Min(Math.Max(scrollView.ScrollY, 0), profileBoxHeight);
            // changing position of NotifBar
            profileBox.TranslationY = scrollY / 2;
        }
    }
}