
using _15MinuteGoals.Adapter;
using _15MinuteGoals.UI.Dialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Google.Android.Flexbox;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "Pursue your goal", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class GradeActivity : AppCompatActivity
    {
        private ImageView BackButton;
        private FlexboxLayout gradeContainer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_chooseGrade);
            BackButton = FindViewById<ImageView>(Resource.Id.gobackBtn);
            gradeContainer = FindViewById<FlexboxLayout>(Resource.Id.gradeContainer);
            BackButton.Click += BackButton_Click;

            for (int i = 0; i < gradeContainer.ChildCount; i++)
            {
                View gradeBtn = gradeContainer.GetChildAt(i);
                gradeBtn.Click += GradeBtn_Click;
            }
        }

        private void GradeBtn_Click(object sender, EventArgs e)
        {
            ClassSelectionDialog classSelectionDialog = new ClassSelectionDialog();
            classSelectionDialog.Show(SupportFragmentManager, "Class selection fragment");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            OnBackPressed();
            Finish();
        }
    }
}