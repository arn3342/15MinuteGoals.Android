using _15MinuteGoals.Data;
using _15MinuteGoals.UI.Fragments;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private ViewPager mViewPager;
        private TabLayout mTabLayout;
        private Fragment_Home HomeFragment = new Fragment_Home();
        private Fragment_Explore ExploreFragment = new Fragment_Explore();
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
                                      Resource.Drawable.explore_blue_icon };
            for (int i = 0; i < Icons.Length; i++)
            {
                mTabLayout.GetTabAt(i).SetIcon(Icons[i]);
            }
        }
    }
}