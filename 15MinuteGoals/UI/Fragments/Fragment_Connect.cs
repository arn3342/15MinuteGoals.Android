using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using _15MinuteGoals.UI.CustomViews;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Connect : Fragment
    {
        private View mainView;

        private TopBar topbar { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_connect, container, false);
            //topbar = mainView.FindViewById<TopBar>(Resource.Id.connect_topbar);
            //SetTopBar();

            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }

        public void SetTopBar()
        {
            topbar.Title = "Connect with your friends";
            topbar.SetPropertyValues();
        }
    }
}