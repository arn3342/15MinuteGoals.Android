﻿using _15MinuteGoals.Activities;
using _15MinuteGoals.UI.AnimationClasses;
using _15MinuteGoals.UI.CustomViews;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using FFImageLoading;
using System;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Home : Fragment
    {
        private View myview;
        public static ScrollView mScrollView { get; private set; }
        public static LinearLayout mProfileBox { get; private set; }
        public static int mProfileBoxHeight { get; internal set; }
        public static TopBar topbar { get; private set; }
        public Button pursueButton { get; set; }
        private View AcademicBtn, EntrepreneurBtn;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            myview = inflater.Inflate(Resource.Layout.screen_home, container, false);
            //topbar = myview.FindViewById<TopBar>(Resource.Id.home_topbar);
            //pursueButton = myview.FindViewById<Button>(Resource.Id.pursuebutton);
            //pursueButton.Click += PursueButton_Click;
            //AcademicBtn = myview.FindViewById<View>(Resource.Id.academicBtn);
            //EntrepreneurBtn = myview.FindViewById<View>(Resource.Id.entrepreneurBtn);
            //AcademicBtn.Click += AcademicBtn_Click;
            //EntrepreneurBtn.Click += EntrepreneurBtn_Click;
            //SetTopBar();
            //Fix scaling
            return myview;
        }

        private void EntrepreneurBtn_Click(object sender, EventArgs e)
        {
            AnimateButtonClick(EntrepreneurBtn);
        }

        private void AcademicBtn_Click(object sender, EventArgs e)
        {
            AnimateButtonClick(AcademicBtn);
            Intent intent = new Intent(Activity, typeof(GradeActivity));
            this.StartActivity(intent);
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

            //Getting control instances
            //mScrollView = view.FindViewById<ScrollView>(Resource.Id.HomeScrollView);
            //mProfileBox = view.FindViewById<LinearLayout>(Resource.Id.HomeProfileBox);

            //Setting GaolHeader(s) & Notficaiton bar scaling
            view.ViewTreeObserver.AddOnGlobalLayoutListener(new GlobalLayoutListen());
        }

        public void SetTopBar()
        {
            topbar.Title = "Goals";
            topbar.SetPropertyValues();
        }

        private void SetAnimations(View view)
        {
            //Setting wave animation
            //ImageView waveImage = view.FindViewById<ImageView>(Resource.Id.wave_hand);
            //ImageService.Instance.LoadCompiledResource("wave_hand_animation.gif").Into(waveImage);
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
            profileBoxHeight = Fragment_Home.mProfileBoxHeight;
            scrollView = Fragment_Home.mScrollView;
            profileBox = Fragment_Home.mProfileBox;
        }


        public void OnScrollChanged()
        {
            int scrollY = Math.Min(Math.Max(scrollView.ScrollY, 0), profileBoxHeight);
            // changing position of NotifBar
            profileBox.TranslationY = scrollY / 2;
        }
    }
}