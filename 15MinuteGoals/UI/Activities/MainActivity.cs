using _15MinuteGoals.Adapter;
using _15MinuteGoals.Data.Models;
using _15MinuteGoals.UI.Fragments;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
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
        RecyclerView homeContainer;
        private HomeAdapter homeAdapter;
        private List<object> contents = new List<object>();


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

            homeContainer = FindViewById<RecyclerView>(Resource.Id.homeContainer);
            homeContainer.AddOnScrollListener(new RecyclerViewScrollListner());
            homeContainer.SetLayoutManager(new LinearLayoutManager(this));
            homeAdapter = new HomeAdapter(this, contents, SupportFragmentManager);

            homeContainer.SetAdapter(homeAdapter);

            PopulateHome();
            Window.SetBackgroundDrawableResource(Resource.Drawable.full_white);
        }

        private void PopulateHome()
        {
            if (contents.Count == 0)
            {

                contents.Add(new Home() { Greeting = "শুভ সন্ধ্যা", FirstName = "Aousaf" });
                contents.Add(new TutorAndGradeBox());
                List<Subject> subjects = new List<Subject>() {
                    new Subject() { Title = "পদার্থবিজ্ঞ্যান", IconId = Resource.Drawable.icon_physics },
                    new Subject() { Title = "উচ্চতর গণিত", IconId = Resource.Drawable.icon_math },
                    new Subject() { Title = "রষায়ন", IconId = Resource.Drawable.icon_chemistry },
                    new Subject() { Title = "জীববিজ্ঞ্যান", IconId = Resource.Drawable.icon_biology }
                };

                contents.Add(subjects);
                contents.Add(new Banner());
                homeAdapter.NotifyItemInserted(contents.Count - 1);
                #region Adding user's photo to post
                //ImageLoader imageLoader = new ImageLoader(postRegularAdapter, contents);
                //imageLoader.LoadImage("https://i.ibb.co/12BTPz9/model3.jpg", "https://i.ibb.co/GtNDwtL/model2.jpg", "https://i.ibb.co/m98tpJW/model1.jpg");
                #endregion
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private class RecyclerViewScrollListner : RecyclerView.OnScrollListener
        {
            public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
            {
                base.OnScrolled(recyclerView, dx, dy);
                var c = dy;
            }
        }
    }
}