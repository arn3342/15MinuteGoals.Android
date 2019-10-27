using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using _15MinuteGoals.UI.CustomViews;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Messages: Fragment
    {
        private View mainView;

        private TopBar topbar { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_messages, container, false);

            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }
    }
}