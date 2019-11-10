using Android.App;
using Android.OS;
using Android.Views.Animations;
using Android.Views.InputMethods;
using Android.Widget;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "SmartTutorActivity")]
    public class SmartTutorActivity : Activity
    {
        ImageView MicButton;
        EditText SearchBox;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_smartTutor);
            MicButton = FindViewById<ImageView>(Resource.Id.micButton);
            SearchBox = FindViewById<EditText>(Resource.Id.searchBox);
            AnimateMic();
            FocusSearchBox();
        }

        private void FocusSearchBox()
        {
            SearchBox.RequestFocus();
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.ShowSoftInput(SearchBox, ShowFlags.Implicit);
        }

        private void AnimateMic()
        {
            Animation anim = AnimationUtils.LoadAnimation(this, Resource.Animation.scale_up);
            MicButton.RequestLayout();
            MicButton.StartAnimation(anim);
        }
    }
}