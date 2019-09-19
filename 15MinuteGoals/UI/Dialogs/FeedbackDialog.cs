using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.UI.Dialogs
{
    public class FeedbackDialog : Android.Support.V4.App.DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.dialog_feedback, container);
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            return view;
        }

        public override void OnResume()
        {
            base.OnResume();
            ViewGroup.LayoutParams parameters = Dialog.Window.Attributes;
            parameters.Height = 250;
            parameters.Width = ViewGroup.LayoutParams.MatchParent;
            Dialog.Window.Attributes = (WindowManagerLayoutParams)parameters;
        }
    }
}