using _15MinuteGoals.Adapter;
using _15MinuteGoals.Data.Models;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Explore : Fragment
    {
        private View mainView;
        public RecyclerView contentContainer;
        private List<object> contents = new List<object>();
        private PostRegularAdapter postRegularAdapter;
        private bool IsWritePostCreated;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_explore, container, false);
            contentContainer = mainView.FindViewById<RecyclerView>(Resource.Id.explore_feed_maincontainer);

            contentContainer.SetLayoutManager(new LinearLayoutManager(Activity));
            postRegularAdapter = new PostRegularAdapter(contents, FragmentManager);
            contentContainer.SetAdapter(postRegularAdapter);

            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
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
                contents.Add(new PostRegular() { InspireCount = "3k", PostBody = "The harder you work for something, the greater you'll feel when you achieve it.", UserFullName = "Aousaf Rashid", UserImageUrl = "https://www.netfort.com/assets/user.png" });
                contents.Add(new PostRegular() { InspireCount = "1k", PostBody = "Pdush yourself, because no one else is going to do it for you.", UserFullName = "Brian Smith", UserImageUrl = "https://www.netfort.com/assets/user.png" });
                contents.Add(new PostRegular() { InspireCount = "5k", PostBody = "Completed chapter 3 of organic chemistry. I am surprised by how @Mr.Mark explained all the issues so clearly!", UserFullName = "Richard Parsons", UserImageUrl = "https://www.netfort.com/assets/user.png" });
                postRegularAdapter.NotifyItemInserted(contents.Count - 1);
            }
        }
    }
}