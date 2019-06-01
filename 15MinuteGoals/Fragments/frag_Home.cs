using System.Collections.Generic;
using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using _15MinuteGoals.UI.CustomViews;
using Java.Lang;

namespace _15MinuteGoals.Fragments
{
    public class Frag_Home : Fragment
    {
        private View myview;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            myview = inflater.Inflate(Resource.Layout.screen_Home, container, false);

            //Fix scaling
            return myview;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            //Setting GaolHeader(s)
            
            PopulateGoalsList(view);
        }
        private void PopulateGoalsList(View view)
        {
            LinearLayout GoalContainer = view.FindViewById<LinearLayout>(Resource.Id.GoalContainer);
            int i = 1;
            for (int childno = 0; childno < GoalContainer.ChildCount; childno++ )
            {
                GoalPanel goalpanel = (GoalPanel)GoalContainer.GetChildAt(childno);
                goalpanel.SetGoalHeader(i);
                i++;
            }
        }
    }
}