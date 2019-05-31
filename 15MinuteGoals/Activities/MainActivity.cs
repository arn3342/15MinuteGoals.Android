using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Content.PM;
using Android.Support.Design.Widget;
using _15MinuteGoals.Data;
using _15MinuteGoals.Fragments;
using Android.Support.V4.View;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.NoActionBar", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private ViewPager mViewPager;
        private TabLayout mTabLayout;
        private Frag_Home HomeFragment = new Frag_Home();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Referencing the views, populating the adapter with fragments, calling a method to populate the bottom menu
            mTabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout1);
            mViewPager = FindViewById<ViewPager>(Resource.Id.viewPager1);
            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
            adapter.AddFragment(HomeFragment);
            mViewPager.Adapter = adapter;

            //Populating the TabLayout with icons
            PopulateMainTabIcons();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void PopulateMainTabIcons()
        {
            mTabLayout.SetupWithViewPager(mViewPager);
            int[] Icons = new int[] { Resource.Drawable.user };
            for (int i = 0; i < Icons.Length; i++)
            {
                mTabLayout.GetTabAt(i).SetIcon(Icons[i]);
            }
        }
    }
}