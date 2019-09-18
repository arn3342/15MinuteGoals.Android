using _15MinuteGoals.Data.ViewModels;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;

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
        public static Vm_GoalPanel ViewModel_GoalPanel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Vm_GoalPanel>(new Guid().ToString());
            }
        }
        public static Vm_TopBar ViewModel_TopBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Vm_TopBar>(new Guid().ToString());
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}