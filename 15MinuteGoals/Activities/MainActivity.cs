using System;
using _15MinuteGoals.Data;
using _15MinuteGoals.UI.Fragments;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using static Android.Support.Design.Widget.TabLayout;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "@string/app_name", WindowSoftInputMode = Android.Views.SoftInput.AdjustResize, Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private ViewPager mViewPager;
        private TabLayout mTabLayout;
        private Fragment_Home HomeFragment = new Fragment_Home();
        private Fragment_Explore ExploreFragment = new Fragment_Explore();
        private Fragment_Connect ConnectFragment = new Fragment_Connect();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Referencing the views, populating the adapter with fragments, calling a method to populate the bottom menu
            mTabLayout = FindViewById<TabLayout>(Resource.Id.maintablayout);
            mViewPager = FindViewById<ViewPager>(Resource.Id.mainviewpager);
            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
            adapter.AddFragment(HomeFragment);
            adapter.AddFragment(ExploreFragment);
            adapter.AddFragment(ConnectFragment);

            mViewPager.Adapter = adapter;
            ////Populating the TabLayout with icons
            PopulateMainTabIcons();

            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void PopulateMainTabIcons()
        {
            mTabLayout.SetupWithViewPager(mViewPager);
            int[] Icons = new int[] { Resource.Drawable.goal_blue_icon,
                                      Resource.Drawable.explore_blue_icon,
                                      Resource.Drawable.connect_page_icon };
            string[] Titles = new string[] { "Goals", "Explore", "Connect" };

            for (int i = 0; i < mTabLayout.TabCount; i++)
            {
                //mTabLayout.GetTabAt(i).SetIcon(Icons[i]);

                ConstraintLayout tab = (ConstraintLayout)LayoutInflater.Inflate(Resource.Layout.customview_tabLayoutDesign, null);
                TextView TabTitle = tab.FindViewById<TextView>(Resource.Id.tabTitle);
                ImageView TabIcon = tab.FindViewById<ImageView>(Resource.Id.tabIco);

                TabTitle.Text = Titles[i];
                TabIcon.SetImageResource(Icons[i]);

                if(i==0)
                {
                    TabTitle.SetTextColor(Color.ParseColor("#00aeff"));
                }

                mTabLayout.GetTabAt(i).SetCustomView(tab);
            }

            mTabLayout.AddOnTabSelectedListener(new TabChangeListner(ExploreFragment));
        }

        public class TabChangeListner : Java.Lang.Object, IOnTabSelectedListener
        {
            public Android.Support.V4.App.Fragment RequiredFragment;

            public TabChangeListner(Android.Support.V4.App.Fragment fragment)
            {
                RequiredFragment = fragment;
            }
            public new void Dispose()
            {
                //throw new NotImplementedException();
            }

            public void OnTabReselected(Tab tab)
            {
                //throw new NotImplementedException();
            }

            public void OnTabSelected(Tab tab)
            {
                TextView tabTitle = tab.CustomView.FindViewById<TextView>(Resource.Id.tabTitle);
                tabTitle.SetTextColor(Color.ParseColor("#00aeff"));
                if (tab.Position == 1)
                {
                    Fragment_Explore fragment_Explore = (Fragment_Explore)RequiredFragment;
                    fragment_Explore.PopulateWithPosts();
                }
            }

            public void OnTabUnselected(Tab tab)
            {
                TextView tabTitle = tab.CustomView.FindViewById<TextView>(Resource.Id.tabTitle);
                tabTitle.SetTextColor(Color.ParseColor("#757575"));
            }
        }
    }
}