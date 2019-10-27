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
using Com.Google.Android.Flexbox;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Explore : Fragment
    {
        private View mainView;
        public RecyclerView contentContainer;
        private List<object> contents = new List<object>();
        private PostRegularAdapter postRegularAdapter;
        private bool IsWritePostCreated;

        private TopBar topbar { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_explore, container, false);
            contentContainer = mainView.FindViewById<RecyclerView>(Resource.Id.explore_feed_maincontainer);
            //topbar = mainView.FindViewById<TopBar>(Resource.Id.explore_topbar);
            //SetTopBar();
            //FlexboxLayoutManager layoutManager = new FlexboxLayoutManager(Activity);
            //layoutManager.FlexDirection = FlexDirection.Column;
            //layoutManager.JustifyContent = JustifyContent.FlexEnd;

            contentContainer.SetLayoutManager(new LinearLayoutManager(Activity));
            postRegularAdapter = new PostRegularAdapter(contents, FragmentManager);
            contentContainer.SetAdapter(postRegularAdapter);

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
            await Task.Delay(700);
            if (contents.Count == 0)
            {        
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