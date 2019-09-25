
using _15MinuteGoals.Adapter;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views.Animations;
using System.Collections.Generic;
using System.Threading.Tasks;
using _15MinuteGoals.Data.Models;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Support.Constraints;
using System;
using Android.Widget;
using _15MinuteGoals.UI.CustomViews;

namespace _15MinuteGoals.Activities
{
    [Activity(Label = "Pursue your goal", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class PursueActivity : Activity
    {
        public static RecyclerView recyclerView { get; private set; }
        private PursueContentAdapter pursueAdapter;
        public static NestedScrollView scrollView { get; private set; }
        private List<object> contents = new List<object>();
        private ImageView BackButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_pursue);
            pursueAdapter = new PursueContentAdapter(contents);
            BackButton = FindViewById<ImageView>(Resource.Id.gobackBtn);
            BackButton.Click += BackButton_Click;

            scrollView = FindViewById<NestedScrollView>(Resource.Id.pursueScroller);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.pursueContainer);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.SetAdapter(pursueAdapter);

            PopulateContents();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            base.OnBackPressed();
        }

        private async void PopulateContents()
        {        
            await Task.Delay(800);
            Context context = recyclerView.Context;
            LayoutAnimationController controller = AnimationUtils.LoadLayoutAnimation(context, Resource.Animation.layout_animation_fall_down);
            recyclerView.LayoutAnimation = controller;
            contents.Add(new Pursue_CourseBox() { Title = "C# Master class- Learn it all", Author = "Aousaf Rashid" });
            contents.Add(new Pursue_ContentVideo() { Title = "Ep 1: Understanding OOP", Duration = "8:00" });
            contents.Add(new Pursue_ContentVideo() { Title = "Ep 2: A Hello World App", Duration = "7:00" });
            contents.Add(new Pursue_ContentVideo() { Title = "Ep 3: Conditionals", Duration = "5:30" });
            contents.Add(new Pursue_ContentVideo() { Title = "Ep 4: Arrays and Lists", Duration = "6:20" });
            contents.Add(new Pursue_ContentVideo() { Title = "Ep 5: For Loops", Duration = "4:50" });
            contents.Add(new Pursue_ContentVideo() { Title = "Ep 6: For vs Foreach", Duration = "7:40" });
            contents.Add(new Pursue_ContentArticle() { Title = "Ep 7: Classes", Description = "This article offers a guided tour about the class concept of the C# programming language."});
            contents.Add(new Pursue_ContentArticle() { Title = "Ep 8: Methods and Functions", Description = "Methods in C# are portions of a larger program that perform specific tasks." });
            

            pursueAdapter.NotifyItemInserted(contents.Count - 1);
            pursueAdapter.ViewHolderCreated += PursueAdapter_ViewHolderCreated;

        }

        private void PursueAdapter_ViewHolderCreated(object sender, EventArgs e)
        {
            RecyclerView.ViewHolder vh = recyclerView.FindViewHolderForAdapterPosition(0);
            ProgressBox layout = this.FindViewById<ProgressBox>(Resource.Id.pursueprogress);
            scrollView.ViewTreeObserver.AddOnScrollChangedListener(new ScrollPositionObserver(layout.Height, scrollView, layout));
        }

        private class ScrollPositionObserver : Java.Lang.Object, ViewTreeObserver.IOnScrollChangedListener
        {
            private int layoutHeight;
            private NestedScrollView scrollView;
            private ConstraintLayout child;

            public ScrollPositionObserver(int LayoutHeight, NestedScrollView ScrollView, ConstraintLayout Child)
            {
                this.layoutHeight = LayoutHeight;
                scrollView = ScrollView;
                child = Child;
            }


            public void OnScrollChanged()
            {
                //int scrollY = Math.Min(Math.Max(scrollView.ScrollY, 0), layoutHeight);
                //// changing position of NotifBar
                //var test = scrollView.ScrollY;
                //child.Alpha = 0.5F;
                if(scrollView.ScrollY <=100)
                {
                    decimal alpha = Convert.ToDecimal(scrollView.ScrollY) / 100m;
                    child.Alpha = (float)alpha;
                }
                else if(scrollView.ScrollY > 100)
                { child.Alpha = 1F; }
            }
        }
    }
}