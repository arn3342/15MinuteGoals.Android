using GalaSoft.MvvmLight;

namespace _15MinuteGoals.Data.ViewModels
{
    public class Vm_TopBar : ViewModelBase
    {
        private string _title = "Tot;e";
        private string _buttontext = "None";
        private int _iconsrc;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(propertyName: nameof(Title));
            }
        }
        public int IconSource
        {
            get { return _iconsrc; }
            set { Set(ref _iconsrc, value); }
        }
        public string ButtonText
        {
            get { return _buttontext; }
            set { Set(ref _buttontext, value); }
        }
    }
}