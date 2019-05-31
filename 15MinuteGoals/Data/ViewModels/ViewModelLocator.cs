using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _15MinuteGoals.Data;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace _15MinuteGoals.Data.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<Vm_GoalPanel>();
        }
        public Vm_GoalPanel ViewModel_GoalPanel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Vm_GoalPanel>(new Guid().ToString());
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}