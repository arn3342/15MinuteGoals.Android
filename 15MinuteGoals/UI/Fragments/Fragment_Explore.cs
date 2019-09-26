using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using _15MinuteGoals.Adapter;
using System.Collections.Generic;
using _15MinuteGoals.Data.Models;
using System.Threading.Tasks;
using _15MinuteGoals.UI.CustomViews;
using Android.Content;
using Android.Views.Animations;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Explore : Fragment
    {
        private View mainView;
        private RecyclerView recyclerView;
        private List<object> contents = new List<object>();
        private PostRegularAdapter postRegularAdapter;
        private bool IsWritePostCreated;

        private TopBar topbar { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_explore, container, false);
            recyclerView = mainView.FindViewById<RecyclerView>(Resource.Id.explore_feed_maincontainer);
            //topbar = mainView.FindViewById<TopBar>(Resource.Id.explore_topbar);
            //SetTopBar();

            recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            postRegularAdapter = new PostRegularAdapter(contents);
            recyclerView.SetAdapter(postRegularAdapter);

            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }

        public void SetTopBar()
        {
            topbar.Title = "Explore";
            topbar.SetPropertyValues();
        }

        public async void PopulateWithPosts()
        {
            if (contents.Count == 0)
            {
                postRegularAdapter.FragmentManager = FragmentManager;
                Context context = recyclerView.Context;
                LayoutAnimationController controller = AnimationUtils.LoadLayoutAnimation(context, Resource.Animation.layout_animation_fall_down);
                recyclerView.LayoutAnimation = controller;
                await Task.Delay(300);
                if (!IsWritePostCreated)
                {
                    contents.Add(350);
                    IsWritePostCreated = true;
                }           
                contents.Add(new PostRegular() { InspireCount = "3k", PostBody = "A new post 1", UserFullName = "Aousaf", UserImageUrl = "https://www.netfort.com/assets/user.png" });
                contents.Add(new PostRegular() { InspireCount = "1k", PostBody = "A new post 2", UserFullName = "Aousaf Rashid", UserImageUrl = "https://www.netfort.com/assets/user.png" });
                contents.Add(new PostRegular() { InspireCount = "5k", PostBody = "A new post 3", UserFullName = "Aousaf Rahman", UserImageUrl = "https://www.netfort.com/assets/user.png" });
                postRegularAdapter.NotifyItemInserted(contents.Count - 1);
            }
        }
    }
}