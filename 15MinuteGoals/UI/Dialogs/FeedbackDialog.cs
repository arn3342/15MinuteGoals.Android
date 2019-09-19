using System;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Views.InputMethods;

namespace _15MinuteGoals.UI.Dialogs
{
    public class FeedbackDialog : DialogFragment
    {
        private ImageView CloseButton { get; set; }
        private AppCompatEditText FeedbackBox { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.dialog_feedback, container);
            CloseButton = view.FindViewById<ImageView>(Resource.Id.closeFeedbackBtn);
            CloseButton.Click += CloseButton_Click;
            return view;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Dismiss();
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetStyle(StyleNoTitle, Resource.Style.dialog_no_border);
            //Dialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
        }
        public override void OnResume()
        {
            base.OnResume();
            Dialog.Window.SetSoftInputMode(SoftInput.AdjustResize);

            ViewGroup.LayoutParams parameters = Dialog.Window.Attributes;
            int scale = Context.Resources.DisplayMetrics.HeightPixels;
            parameters.Height = scale / 2;
            parameters.Width = ViewGroup.LayoutParams.MatchParent;
            Dialog.Window.Attributes = (WindowManagerLayoutParams)parameters;
            Dialog.Window.SetGravity(GravityFlags.Bottom | GravityFlags.CenterHorizontal);
        }
    }
}