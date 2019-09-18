using _15MinuteGoals.Data.ViewModels;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using System.Collections.Generic;

namespace _15MinuteGoals.UI.CustomViews
{
    public class GoalPanel : LinearLayout
    {
        private readonly List<Binding> _bindings = new List<Binding>();
        public TextView GoalHeader { get; private set; }
        public TextView GoalTitle { get; private set; }

        // Get view model
        private View MainView;

        #region Constructors
        public GoalPanel(Context context) : base(context)
        {
            Initialize(context);

        }
        public GoalPanel(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }
        public GoalPanel(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }
        #endregion
        private Vm_GoalPanel mainViewModel;

        private void Initialize(Context ctx)
        {
            //Inflating the layout
            //mainViewModel = new Vm_GoalPanel();
            //var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            //MainView = inflatorService.Inflate(Resource.Layout.custom_GoalPanel, this, false);
            //this.AddView(MainView);

            ////Get view(s) instances
            //GoalHeader = MainView.FindViewById<TextView>(Resource.Id.goal_header);
            //BindProperties();
        }

        public void BindProperties()
        {
            _bindings.Add(this.SetBinding(() => mainViewModel.GoalHeader,
        () => GoalHeader.Text));
            _bindings.Add(this.SetBinding(() => mainViewModel.GoalTitle,
        () => GoalTitle.Text));
        }

        public void SetGoalHeader(int goalNo)
        {
            mainViewModel.GoalHeader = "Goal " + goalNo.ToString();
        }
    }
}