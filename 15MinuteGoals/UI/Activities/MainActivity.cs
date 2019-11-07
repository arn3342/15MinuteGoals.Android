using _15MinuteGoals.Data;
using _15MinuteGoals.UI.Fragments;
using _15MinuteGoals.Utilities;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using FFImageLoading;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Android.Support.Design.Widget.TabLayout;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppBlueTheme", WindowSoftInputMode = Android.Views.SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private ViewPager mViewPager;
        private TabLayout mTabLayout;
        static List<Android.Support.V4.App.Fragment> fragments;
        ConstraintLayout smartTutorBtn;
        ImageView smartSwipeDown;
        float SmartTutorTranslationY;

        Fragment_Home HomeFragment = new Fragment_Home();
        Fragment_WhatsNew WhatsNewFragment = new Fragment_WhatsNew();
        Fragment_Explore ExploreFragment = new Fragment_Explore();
        Fragment_Messages MessagesFragment = new Fragment_Messages();
        Fragment_Menu MenuFragment = new Fragment_Menu();

        static FrameLayout mainContainer;
        static int[] Icons, IconsSelected;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //Referencing the views, populating the adapter with fragments, calling a method to populate the bottom menu
            mTabLayout = FindViewById<TabLayout>(Resource.Id.maintablayout);
            mViewPager = FindViewById<ViewPager>(Resource.Id.mainviewpager);
            mainContainer = FindViewById<FrameLayout>(Resource.Id.activity_main_container);

            #region Getting the smart tutor elements
            smartTutorBtn = FindViewById<ConstraintLayout>(Resource.Id.smartTutorBtn);
            smartSwipeDown = FindViewById<ImageView>(Resource.Id.smart_swipeDown);

            //ImageService.Instance.LoadCompiledResource("gif name").Into(smartSwipeDown);
            smartTutorBtn.Click += SmartTutorBtn_Click;
            #endregion

            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
            fragments = new List<Android.Support.V4.App.Fragment>() { HomeFragment, WhatsNewFragment, ExploreFragment, MessagesFragment, MenuFragment };

            adapter.FragmentList = fragments;

            mViewPager.Adapter = adapter;
            ////Populating the TabLayout with icons
            PopulateMainTabIcons();

            Window.SetBackgroundDrawableResource(Resource.Drawable.full_white);
            AnimateTopBar(true);
        }

        private void SmartTutorBtn_Click(object sender, System.EventArgs e)
        {
            //Intent intent = new Intent(this, typeof(SmartTutorActivity));
            //StartActivity(intent);
            //OverridePendingTransition(0, 0);
            AnimateTopBar();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #region Animating the topbar
        private async void AnimateTopBar(bool DelayAnimation = false)
        {
            SmartTutorTranslationY = smartTutorBtn.TranslationY;
            if (DelayAnimation)
            {
                await Task.Delay(800);
            }
            //Animating the topbar to show it
            TransitionDrawable transition = (TransitionDrawable)smartTutorBtn.Background;
            Animations animation = new Animations();
            animation.AnimateObject(smartTutorBtn, "TranslationY", 0 , 150);
            transition.StartTransition(150);
            ReverseAnimateTopBar();
        }
        private async void ReverseAnimateTopBar()
        {
            await Task.Delay(2150);
            TransitionDrawable transition = (TransitionDrawable)smartTutorBtn.Background;
            Animations animation = new Animations();
            animation.AnimateObject(smartTutorBtn, "TranslationY", SmartTutorTranslationY, 150);
            transition.ReverseTransition(150);
        }
        #endregion

        private void PopulateMainTabIcons()
        {
            mTabLayout.SetupWithViewPager(mViewPager);
            Icons = new int[] { Resource.Drawable.home_icon,
                                      Resource.Drawable.whatsNew_icon,
                                      Resource.Drawable.explore_icon,
                                      Resource.Drawable.message_icon,
                                      Resource.Drawable.menu_icon};

            IconsSelected = new int[] { Resource.Drawable.home_icon_selected,
                                      Resource.Drawable.whatsNew_icon_selected,
                                      Resource.Drawable.explore_icon_selected,
                                      Resource.Drawable.message_icon_selected,
                                      Resource.Drawable.menu_icon_selected};
            //string[] Titles = new string[] { "Your goals", "Explore", "Messages", "Notifications" };

            for (int i = 0; i < mTabLayout.TabCount; i++)
            {
                mTabLayout.GetTabAt(i).SetIcon(Icons[i]);
            }
            mTabLayout.GetTabAt(0).SetIcon(IconsSelected[0]);

            mTabLayout.AddOnTabSelectedListener(new TabChangeListner(this));
        }

        internal class TabChangeListner : Java.Lang.Object, IOnTabSelectedListener
        {
            List<int> TitlesShown = new List<int> { 0, 1, 2, 3 };
            AppCompatActivity activity;

            public TabChangeListner(AppCompatActivity mActivity)
            {
                activity = mActivity;
            }
            public new void Dispose()
            {

            }

            public void OnTabReselected(Tab tab)
            {

            }

            public void OnTabSelected(Tab tab)
            {
                tab.SetIcon(IconsSelected[tab.Position]);
                switch (tab.Position)
                {

                    case 0:
                        if (TitlesShown.Contains(0))
                        {
                            activity.AnimateTitle(mainContainer, "Your goals");
                            TitlesShown.Remove(0);
                        }
                        break;

                    case 1:
                        if (TitlesShown.Contains(1))
                        {
                            activity.AnimateTitle(mainContainer, "What's new");
                            TitlesShown.Remove(1);
                        }
                        break;

                    case 2:
                        if (TitlesShown.Contains(2))
                        {
                            activity.AnimateTitle(mainContainer, "Explore feed");
                            TitlesShown.Remove(2);
                        }
                        var explore = fragments[2] as Fragment_Explore;
                        explore.PopulateWithPosts();
                        break;

                    case 3:
                        if (TitlesShown.Contains(3))
                        {
                            activity.AnimateTitle(mainContainer, "Messages");
                            TitlesShown.Remove(3);
                        }
                        break;
                }
            }

            public void OnTabUnselected(Tab tab)
            {
                int position = tab.Position;
                tab.SetIcon(Icons[position]);
            }
        }
    }
}