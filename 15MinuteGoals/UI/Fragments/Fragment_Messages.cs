using _15MinuteGoals.Adapter;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Messages : Fragment
    {
        private View mainView;
        public RecyclerView contentContainer;
        private MessagesAdapter messagesAdapter;
        bool MessagePopulated { get; set; }
        private List<object> contents = new List<object>();
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_messages, container, false);

            contentContainer = mainView.FindViewById<RecyclerView>(Resource.Id.message_maincontainer);

            contentContainer.SetLayoutManager(new LinearLayoutManager(Activity));
            messagesAdapter = new MessagesAdapter(contents, FragmentManager);
            contentContainer.SetAdapter(messagesAdapter);
            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            PopulateMessages();
        }

        public async void PopulateMessages()
        {
            await Task.Delay(700);
            if (!MessagePopulated)
            {
                for (int i = 0; i < 10; i++)
                {
                    contents.Add(null);
                }
                messagesAdapter.NotifyItemInserted(contents.Count - 1);
                MessagePopulated = true;
            }
        }
    }
}