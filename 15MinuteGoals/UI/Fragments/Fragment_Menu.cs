﻿using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace _15MinuteGoals.UI.Fragments
{
    public class Fragment_Menu : Fragment
    {
        private View mainView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mainView = inflater.Inflate(Resource.Layout.screen_menu, container, false);

            return mainView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }
    }
}