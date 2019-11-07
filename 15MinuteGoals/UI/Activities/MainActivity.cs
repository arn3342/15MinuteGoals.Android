using _15MinuteGoals.Data;
using _15MinuteGoals.UI.Fragments;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using FFImageLoading;
using System.Collections.Generic;
using static Android.Support.Design.Widget.TabLayout;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppBlueTheme", WindowSoftInputMode = Android.Views.SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private ViewPager mViewPager;
        private TabLayout mTabLayout;
        static List<Android.Support.V4.App.Fragment> fragments;
        ImageView smartTutorBtn;

        Fragment_Home HomeFragment = new Fragment_Home();
        Fragment_WhatsNew WhatsNewFragment = new Fragment_WhatsNew();
        Fragment_Explore ExploreFragment = new Fragment_Explore();
        Fragment_Messages MessagesFragment = new Fragment_Messages();
        Fragment_Menu MenuFragment = new Fragment_Menu();

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
            smartTutorBtn = FindViewById<ImageView>(Resource.Id.smartTutorBtn);

            smartTutorBtn.Click += SmartTutorBtn_Click;

            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
            fragments = new List<Android.Support.V4.App.Fragment>() { HomeFragment, WhatsNewFragment, ExploreFragment, MessagesFragment, MenuFragment };

            adapter.FragmentList = fragments;

            mViewPager.Adapter = adapter;
            ////Populating the TabLayout with icons
            PopulateMainTabIcons();

            Window.SetBackgroundDrawableResource(Resource.Drawable.full_white);
            ImageService.Instance.LoadCompiledResource("smartTutorButtonAnimation.gif").Into(smartTutorBtn);
        }

        private void SmartTutorBtn_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SmartTutorActivity));
            StartActivity(intent);
            OverridePendingTransition(0, 0);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

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

            for (int i = 0; i < mTabLayout.TabCount; i++)
            {
                mTabLayout.GetTabAt(i).SetIcon(Icons[i]);
            }
            mTabLayout.GetTabAt(0).SetIcon(IconsSelected[0]);

            mTabLayout.AddOnTabSelectedListener(new TabChangeListner());
        }

        internal class TabChangeListner : Java.Lang.Object, IOnTabSelectedListener
        {

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

                    case 1:

                    case 2:
                        var explore = fragments[2] as Fragment_Explore;
                        explore.PopulateWithPosts();
                        break;

                    case 3:
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