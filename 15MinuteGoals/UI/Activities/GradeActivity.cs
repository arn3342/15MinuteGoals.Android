
using _15MinuteGoals.Adapter;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "Pursue your goal", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class GradeActivity : AppCompatActivity
    {
        public static RecyclerView recyclerView { get; private set; }
        private List<object> Grades = new List<object>();
        private GradesAdapter gradeAdapter;
        private ImageView BackButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_chooseGrade);
            BackButton = FindViewById<ImageView>(Resource.Id.gobackBtn);
            BackButton.Click += BackButton_Click;


            recyclerView = FindViewById<RecyclerView>(Resource.Id.gradeContainer);

            gradeAdapter = new GradesAdapter(Grades, SupportFragmentManager);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.SetAdapter(gradeAdapter);

            PopulateGrades();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            OnBackPressed();
        }

        private async void PopulateGrades()
        {
            await Task.Delay(800);
            Grades.Add("Class 9-10");
            gradeAdapter.NotifyItemInserted(Grades.Count - 1);


        }
    }
}