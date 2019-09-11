using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using _15MinuteGoals.Adapter;
using System.Collections.Generic;
using _15MinuteGoals.Data.Models;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Explore : Fragment
    {
        private View mainView;
        private RecyclerView recyclerView;
        private List<PostRegular> posts = new List<PostRegular>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_explore, container, false);
            recyclerView = mainView.FindViewById<RecyclerView>(Resource.Id.explore_feed_maincontainer);
            recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));

            //adding mock data
            posts.Add(new PostRegular() { InspireCount = "3k", PostBody = "A new post 1", UserFullName = "Aousaf", UserImageUrl = "https://www.netfort.com/assets/user.png" });
            posts.Add(new PostRegular() { InspireCount = "1k", PostBody = "A new post 2", UserFullName = "Aousaf Rashid", UserImageUrl = "https://www.netfort.com/assets/user.png" });
            posts.Add(new PostRegular() { InspireCount = "5k", PostBody = "A new post 3", UserFullName = "Aousaf Rahman", UserImageUrl = "https://www.netfort.com/assets/user.png" });

            PostRegularAdapter postRegularAdapter = new PostRegularAdapter(posts);
            recyclerView.SetAdapter(postRegularAdapter);
            recyclerView.SetItemAnimator(new DefaultItemAnimator());
            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }
    }
}