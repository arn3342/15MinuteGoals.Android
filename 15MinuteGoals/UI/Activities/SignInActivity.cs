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
using System.Linq;
using System.Text.RegularExpressions;
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
        int FieldCount, FieldsAdded, ButtonWidth;
        bool IsNewAccount;

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
            AuthenticateUser();
        }
        private async void AuthenticateUser()
        {
            //Replace this code block with authentication code
            await Task.Delay(250); 
            if (emailInput.Text == "nabilrashid44@gmail.com")
            {
                IsNewAccount = false;
                AddFields();
            }
            else
            {
                AddFields();
            }
        }
        private async void AddFields()
        {
            await Task.Delay(1000); //Replace await with API authentication code
            if (IsNewAccount)
            {
                //Removing fields if required
                if (FieldsAdded <= 1)
                {
                    loginContainer.RemoveViewAt(1);
                    AddNewField("তোমার নাম", AutoFocus: true);
                    AddNewField("পাসওয়ার্ড", true);
                    AddNewField("কনফাম র্পাসওয়ার্ড", true);
                    FieldsAdded = 3;
                }
                else
                {
                    //Proceed here
                    if(ValidateInput(true))
                    {
                        ProceedNext();
                    }
                }
            }
            else
            {
                if (FieldsAdded > 1)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        loginContainer.RemoveViewAt(i);
                    }
                    AddNewField("পাসওয়ার্ড", true, true);
                    FieldsAdded = 1;
                }
                else
                {
                    //Proceed here
                    if (ValidateInput(false))
                    {
                        ProceedNext();
                    }
                }
            }
        }

        private bool ValidateInput(bool IsNewUser)
        {
            //Code for new user's validation
            if(IsNewUser)
            {
                EditText nameInput = (EditText)loginContainer.GetChildAt(1);
                EditText passwordInput = (EditText)loginContainer.GetChildAt(2);
                EditText confirmPasswordInput = (EditText)loginContainer.GetChildAt(3);

                var numbersOrCharacters = new Regex(@"^[0-9*#+]+$");
                if(!numbersOrCharacters.IsMatch(nameInput.Text) || 
                    !string.IsNullOrEmpty(nameInput.Text) || 
                    !string.IsNullOrWhiteSpace(nameInput.Text))
                {
                    if(!string.IsNullOrEmpty(passwordInput.Text) ||
                       !string.IsNullOrWhiteSpace(passwordInput.Text) ||
                       !string.IsNullOrEmpty(passwordInput.Text) ||
                       !string.IsNullOrWhiteSpace(passwordInput.Text))
                    {

                    }
                }
            }

            //Code for existing user's validation
            else
            {
                EditText passwordInput = (EditText)loginContainer.GetChildAt(1);
                if(passwordInput.Text == "arn3342")
                {
                    return true;
                }
            }
            return false;

        }
        private async void ProceedNext()
        {
            await Task.Delay(1000);

            // Add required fields based on new or existing account
            
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