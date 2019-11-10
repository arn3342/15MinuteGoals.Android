using _15MinuteGoals.Data.ViewModels;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace _15MinuteGoals.Data
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<Vm_GoalPanel>();
            SimpleIoc.Default.Register<Vm_TopBar>();
        }
        public Vm_GoalPanel ViewModel_GoalPanel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Vm_GoalPanel>();
            }
        }
        public Vm_TopBar ViewModel_TopBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Vm_TopBar>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}