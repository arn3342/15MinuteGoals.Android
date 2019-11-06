using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

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
            Dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            Dialog.Window.SetGravity(GravityFlags.Bottom | GravityFlags.CenterHorizontal);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.DialogAnimation;
        }
    }
}