using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.UI.Activities
{
    [Activity(Label = "SubjectsActivity")]
    public class SubjectsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_chooseSubject);
            // Create your application here
        }
    }
}