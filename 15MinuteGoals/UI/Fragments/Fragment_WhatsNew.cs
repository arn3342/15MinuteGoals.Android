using _15MinuteGoals.Adapter;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_WhatsNew : Fragment
    {
        private View mainView;
        public RecyclerView contentContainer;
        private NotificationAdapter whatsNewAdapter;
        private List<object> contents = new List<object>();
        bool WhatsNewPopulated { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_whatsNew, container, false);

            //contentContainer = mainView.FindViewById<RecyclerView>(Resource.Id.whatsNew_maincontainer);

            //contentContainer.SetLayoutManager(new LinearLayoutManager(Activity));
            //whatsNewAdapter = new NotificationAdapter(contents, FragmentManager);
            //contentContainer.SetAdapter(whatsNewAdapter);
            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            //PopulateWhatsNew();
        }

        public async void PopulateWhatsNew()
        {
            await Task.Delay(700);
            if (!WhatsNewPopulated)
            {
                contents.Add(null);
                whatsNewAdapter.NotifyItemInserted(contents.Count - 1);
                WhatsNewPopulated = true;
            }
        }
    }
}