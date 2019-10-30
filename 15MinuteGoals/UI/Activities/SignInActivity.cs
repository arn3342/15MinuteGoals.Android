using _15MinuteGoals.Utilities;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using System;
using System.Threading.Tasks;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "Sign in to achieve", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInActivity : AppCompatActivity
    {
        static EditText emailInput;
        static Button loginButton;
        static ProgressBar progressBox;
        private readonly int interval = 3500;
        static LinearLayout loginContainer;
        int FieldCount = 0;
        int ButtonWidth = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signIn);
            // Create your application here
            this.Window.EnterTransition = null;
            emailInput = this.FindViewById<EditText>(Resource.Id.emailinput);
            loginButton = this.FindViewById<Button>(Resource.Id.loginbutton);
            progressBox = FindViewById<ProgressBar>(Resource.Id.progressBox);
            loginContainer = FindViewById<LinearLayout>(Resource.Id.loginContainer);
            FieldCount = loginContainer.ChildCount - 2;
            loginButton.Click += LoginButton_Click;
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            ButtonWidth = loginButton.Width;
            loginButton.Text = "";
            loginButton.SetCompoundDrawablesWithIntrinsicBounds(0, 0, 0, 0);
            AnimateLoginButton();
            await Task.Delay(250);
            if (emailInput.Text == "nabilrashid44@gmail.com")
            {
                ProceedNext();
            }
            else
            {
                ProceedNext(true);
            }
        }
        private async void ProceedNext(bool IsNewAccount = false)
        {
            await Task.Delay(1000);

            // Add required fields based on new or existing account
            if (IsNewAccount)
            {
                AddNewField("তোমার নাম", AutoFocus: true);
                AddNewField("পাসওয়ার্ড", true);
                AddNewField("কনফাম র্পাসওয়ার্ড", true);
            }
            else
            {
                AddNewField("পাসওয়ার্ড", true, true);
            }
            if(loginContainer.ChildCount > 5)
            {

            }
            if (NameField != null)
            {
                if (!string.IsNullOrEmpty(NameField.Text) &&
                    !string.IsNullOrEmpty(PasswordField.Text) &&
                    !string.IsNullOrEmpty(ConfirmPasswordField.Text) &&
                    (PasswordField.Text == ConfirmPasswordField.Text))
                {
                    AnimateLoginButton();
                    NextActivity();
                }
            }
            else if (!string.IsNullOrEmpty(PasswordField.Text) && PasswordField.Text == "arn3342")
            {
                AnimateLoginButton();
                NextActivity();
            }
            else
            {
                AnimateLoginButton(true);
                loginButton.Visibility = ViewStates.Visible;
                progressBox.Visibility = ViewStates.Gone;
                //Waiting for animation to end
                await Task.Delay(250);
                loginButton.Text = "Next";
                loginButton.SetCompoundDrawablesWithIntrinsicBounds(0, 0, Resource.Drawable.bg_button_icon_right, 0);
            }
        }
        private EditText AddNewField(string hint, bool IsPasswordBox = false, bool AutoFocus = false)
        {
            var layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            layoutParams.TopMargin = ValueConverter.DpToPx(10);
            EditText field = new EditText(this)
            {
                Hint = hint,
                TextSize = 16f
            };
            if (IsPasswordBox)
            {
                field.InputType = InputTypes.ClassText | InputTypes.TextVariationPassword;
                field.Typeface = Typeface.Create("sans-serif", TypefaceStyle.Normal);
            }
            else
            {
                field.SetSingleLine(true);
            }
            int paddingLeftRight = ValueConverter.DpToPx(15);
            int paddingTopBottom = ValueConverter.DpToPx(10);
            field.SetPadding(paddingLeftRight, paddingTopBottom, paddingLeftRight, paddingTopBottom);
            field.SetBackgroundResource(Resource.Drawable.bg_roundedTextBox);
            field.LayoutParameters = layoutParams;
            loginContainer.AddView(field, FieldCount);
            FieldCount += 1;

            if (AutoFocus)
            {
                field.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(field, ShowFlags.Implicit);
            }
            return field;
        }
        private async void NextActivity()
        {
            await Task.Delay(interval);
            Intent intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);
            this.Finish();
        }
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignUpActivity));
            StartActivity(intent);
        }
        private void AnimateLoginButton(bool AnimateBackwards = false)
        {
            ValueAnimator Animator = ValueAnimator.OfInt(loginButton.MeasuredWidth, ButtonWidth);
            if (!AnimateBackwards)
            {
                Animator = ValueAnimator.OfInt(loginButton.MeasuredWidth, ValueConverter.DpToPx(40));
                Animator.AddListener(new AnimListner());
            }
            Animator.AddUpdateListener(new AnimUpdateListner(loginButton));
            Animator.SetDuration(250);
            Animator.Start();
        }
        private class AnimUpdateListner : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            View mView;
            public AnimUpdateListner(View view)
            {
                mView = view;
            }
            public void OnAnimationUpdate(ValueAnimator animation)
            {
                int value = (int)animation.AnimatedValue;
                ViewGroup.LayoutParams layoutParams = mView.LayoutParameters;
                layoutParams.Width = value;
                mView.LayoutParameters = layoutParams;
            }
        }
        private class AnimListner : Java.Lang.Object, Animator.IAnimatorListener
        {
            public void OnAnimationCancel(Animator animation)
            {

            }

            public void OnAnimationEnd(Animator animation)
            {
                loginButton.Visibility = ViewStates.Gone;
                progressBox.Visibility = ViewStates.Visible;
            }

            public void OnAnimationRepeat(Animator animation)
            {

            }

            public void OnAnimationStart(Animator animation)
            {

            }
        }
    }
}