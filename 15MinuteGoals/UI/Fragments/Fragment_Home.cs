using _15MinuteGoals.UI.CustomViews;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            myview = inflater.Inflate(Resource.Layout.screen_home, container, false);
            topbar = myview.FindViewById<TopBar>(Resource.Id.home_topbar);
            SetTopBar();
            //Fix scaling
            return myview;
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
            topbar.Title = "Home";
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