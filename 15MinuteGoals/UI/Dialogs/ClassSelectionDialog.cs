using _15MinuteGoals.Utilities;
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
    public class ClassSelectionDialog : DialogFragment
    {
        private ImageView CloseButton { get; set; }
        RadioButton scienceBtn, commerceBtn, artsBtn;
        static RadioGroup groupContainer1, groupContainer2, examSelectionContainer;
        private AppCompatEditText FeedbackBox { get; set; }

        static bool ClassSelected { get; set; }
        static Button proceedbtn;
        View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.dialog_classSelection, container);
            CloseButton = view.FindViewById<ImageView>(Resource.Id.closeFeedbackBtn);
            scienceBtn = view.FindViewById<RadioButton>(Resource.Id.scienceBtn);
            commerceBtn = view.FindViewById<RadioButton>(Resource.Id.commerceBtn);
            artsBtn = view.FindViewById<RadioButton>(Resource.Id.artsBtn);
            groupContainer1 = view.FindViewById<RadioGroup>(Resource.Id.groupSelectionContainer);
            groupContainer2 = view.FindViewById<RadioGroup>(Resource.Id.groupSelectionContainer2);
            examSelectionContainer = view.FindViewById<RadioGroup>(Resource.Id.examSelectionContainer);
            proceedbtn = view.FindViewById<Button>(Resource.Id.proceedBtn);

            groupContainer1.SetOnCheckedChangeListener(new CheckChangedListner());
            groupContainer2.SetOnCheckedChangeListener(new CheckChangedListner());
            examSelectionContainer.SetOnCheckedChangeListener(new CheckChangedListner());

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
            int scale = Context.Resources.DisplayMetrics.HeightPixels / 2;
            int MinHeight = ValueConverter.DpToPx(325);
            if (scale >= MinHeight)
            {
                parameters.Height = scale;
            }
            else
            {
                parameters.Height = MinHeight;
            }

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

        private class CheckChangedListner : Java.Lang.Object, RadioGroup.IOnCheckedChangeListener
        {
            public IntPtr Handle;

            public void Dispose()
            {
            }

            public void OnCheckedChanged(RadioGroup group, int checkedId)
            {
                if (group.CheckedRadioButtonId == -1)
                {
                    // no radio buttons are checked
                }
                else
                {
                    // one of the radio buttons is checked
                    if (group == groupContainer1)
                    {
                        groupContainer2.ClearCheck();
                        groupContainer1.Check(checkedId);
                        ClassSelected = true;
                    }
                    else if(group == groupContainer2)
                    {
                        groupContainer1.ClearCheck();
                        groupContainer2.Check(checkedId);
                        ClassSelected = true;
                    }

                    if (examSelectionContainer.CheckedRadioButtonId != -1 && ClassSelected)
                    {
                        proceedbtn.Enabled = true;
                        proceedbtn.SetTextColor(Color.White);
                        proceedbtn.SetBackgroundResource(Resource.Drawable.selector_bg_user_headerbar_textview_blue_nonRound);
                    }
                }
            }
        }
    }
}