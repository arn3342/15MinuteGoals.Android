
using _15MinuteGoals.Adapter;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using System.Threading.Tasks;
using System;
using Android.Widget;
namespace _15MinuteGoals.Activities
{
    [Activity(Label = "Pursue your goal", Theme = "@style/Theme.AppBlueTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class GradeActivity : Activity
    {
        public static RecyclerView recyclerView { get; private set; }
        private string[] Grades { get; set; }
        private GradesAdapter gradeAdapter;
        private ImageView BackButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_pursue);
            gradeAdapter = new GradesAdapter(Grades);
            BackButton = FindViewById<ImageView>(Resource.Id.gobackBtn);
            BackButton.Click += BackButton_Click;


            recyclerView = FindViewById<RecyclerView>(Resource.Id.pursueContainer);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.SetAdapter(gradeAdapter);

            PopulateGrades();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            base.OnBackPressed();
        }

        private async void PopulateGrades()
        {        
            await Task.Delay(800);

            Grades = new string[] { "Class 9-10" };
            
            gradeAdapter.NotifyItemInserted(Grades.Length - 1);
            

        }
    }
}