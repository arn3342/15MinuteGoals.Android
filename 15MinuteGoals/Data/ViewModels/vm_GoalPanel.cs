using GalaSoft.MvvmLight;

namespace _15MinuteGoals.Data.ViewModels
{
    public class Vm_GoalPanel : ViewModelBase
    {
        private string _goaltitle = "No goals have been set!";
        private string _goalheader = "Goal 0";
        public string GoalTitle
        {
            get { return _goaltitle; }
            set { Set(ref _goaltitle, value); }
        }
        public string GoalHeader
        {
            get { return _goalheader; }
            set { Set(ref _goalheader, value); }
        }
    }
}