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
    [Activity(Label = "Sign in to achieve", Theme = "@style/Theme.AppBlueTheme", WindowSoftInputMode = SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInActivity : AppCompatActivity
    {
        static EditText emailInput;
        static Button loginButton;
        static ProgressBar progressBox;
        private readonly int interval = 2000;
        static LinearLayout loginContainer;
        int FieldCount, FieldsAdded, ButtonWidth;
        bool IsNewAccount;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signIn);
            // Create your application here
            this.Window.EnterTransition = null;
            emailInput = this.FindViewById<EditText>(Resource.Id.emailinput);
            emailInput.FocusChange += RemoveFields;
            loginButton = this.FindViewById<Button>(Resource.Id.loginbutton);
            progressBox = FindViewById<ProgressBar>(Resource.Id.progressBox);
            loginContainer = FindViewById<LinearLayout>(Resource.Id.loginContainer);
            FieldCount = loginContainer.ChildCount - 2;
            loginButton.Click += LoginButton_Click;
        }

        private void RemoveFields(object sender, View.FocusChangeEventArgs e)
        {
            if (emailInput.HasFocus)
            {
                emailInput.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(emailInput, ShowFlags.Implicit);
                if (FieldsAdded == 1)
                {
                    loginContainer.RemoveViewAt(1);
                    FieldsAdded = 0;
                    FieldCount -= 1;
                }
                else if (FieldsAdded > 1)
                {
                    loginContainer.RemoveViews(1, 3);
                    FieldsAdded = 0;
                    FieldCount = 1;
                }
            }
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            ButtonWidth = loginButton.Width;
            loginButton.Text = "";
            loginButton.SetCompoundDrawablesWithIntrinsicBounds(0, 0, 0, 0);
            AuthenticateUser();
        }
        private async void AuthenticateUser()
        {
            AnimateLoginButton();
            //Replace this code block with authentication code
            await Task.Delay(250);
            if (emailInput.Text == "nabilrashid44@gmail.com")
            {
                IsNewAccount = false;
                AddFieldsAndValidate();
            }
            else
            {
                IsNewAccount = true;
                AddFieldsAndValidate();
            }
        }
        private async void AddFieldsAndValidate()
        {
            await Task.Delay(1000); //Replace await with API authentication code
            if (IsNewAccount)
            {
                //Removing fields if required

                if (FieldsAdded == 0)
                {
                    AddNewField("তোমার নাম", AutoFocus: true, GoNextOnDone: true);
                    AddNewField("পাসওয়ার্ড", true);
                    AddNewField("কনফাম র্পাসওয়ার্ড", true);
                    FieldsAdded = 3;
                    AnimateLoginButton(true);
                }
                else
                {
                    //Proceed here
                    if (ValidateInput())
                    {
                        ProceedNext();
                    }
                }
            }
            else
            {

                if (FieldsAdded == 0)
                {
                    AddNewField("পাসওয়ার্ড", true, true);
                    FieldsAdded = 1;
                    AnimateLoginButton(true);
                }
                else if (FieldsAdded > 0)
                {
                    //Proceed here
                    if (ValidateInput())
                    {
                        ProceedNext();
                    }
                }
            }
        }
        private bool ValidateInput()
        {
            //Code for new user's validation
            if (IsNewAccount)
            {
                EditText nameInput = (EditText)loginContainer.GetChildAt(1);
                EditText passwordInput = (EditText)loginContainer.GetChildAt(2);
                EditText confirmPasswordInput = (EditText)loginContainer.GetChildAt(3);
                string fullName = nameInput.Text; string password = passwordInput.Text; string rePassword = confirmPasswordInput.Text;

                if (fullName.StringIsAlpha() && new string[] { password, rePassword }.StringsAreAlphaNumeric(true))
                {
                    return true;
                }
            }

            //Code for existing user's validation
            else
            {
                EditText passwordInput = (EditText)loginContainer.GetChildAt(1);
                if (passwordInput.Text == "arn3342")
                {
                    return true;
                }
            }
            return false;
        }
        private async void ProceedNext()
        {
            AnimateLoginButton();
            if (IsNewAccount)
            {
                NextActivity();
            }
            else
            {
                NextActivity();
            }
        }
        private void AddNewField(string hint, bool IsPasswordBox = false, bool AutoFocus = false, bool GoNextOnDone = false)
        {
            var layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            layoutParams.TopMargin = ValueConverter.DpToPx(10);
            EditText field = new EditText(this)
            {
                Hint = hint,
                TextSize = 16f
            };
            if (GoNextOnDone)
            {
                field.ImeOptions = ImeAction.Next;
            }
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
                InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
                imm.ShowSoftInput(field, ShowFlags.Implicit);
            }
        }
        private async void NextActivity()
        {
            await Task.Delay(interval);
            Intent intent = new Intent(this, typeof(MainActivity));
            if (IsNewAccount)
            {
                intent = new Intent(this, typeof(SignUpActivity));
            }
            this.StartActivity(intent);
            this.Finish();
        }
        private void AnimateLoginButton(bool AnimateBackwards = false)
        {
            ValueAnimator Animator = ValueAnimator.OfInt(loginButton.MeasuredWidth, ButtonWidth);
            if (!AnimateBackwards)
            {
                Animator = ValueAnimator.OfInt(loginButton.MeasuredWidth, ValueConverter.DpToPx(40));
            }
            Animator.AddListener(new AnimationListner(AnimateBackwards));
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
        private class AnimationListner : Java.Lang.Object, Animator.IAnimatorListener
        {
            bool AnimateBackwards;
            internal AnimationListner(bool animateBackwards = false)
            {
                AnimateBackwards = animateBackwards;
            }
            public void OnAnimationCancel(Animator animation)
            {

            }

            public void OnAnimationEnd(Animator animation)
            {
                if (!AnimateBackwards)
                {
                    loginButton.Visibility = ViewStates.Gone;
                    progressBox.Visibility = ViewStates.Visible;
                }
                else
                {
                    loginButton.Text = "Next";
                    loginButton.SetCompoundDrawablesWithIntrinsicBounds(0, 0, Resource.Drawable.bg_button_icon_right, 0);
                }
            }

            public void OnAnimationRepeat(Animator animation)
            {

            }

            public void OnAnimationStart(Animator animation)
            {
                if (AnimateBackwards)
                {
                    loginButton.Visibility = ViewStates.Visible;
                    progressBox.Visibility = ViewStates.Gone;
                }
            }
        }
    }
}