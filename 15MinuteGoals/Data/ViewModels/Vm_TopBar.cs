﻿using GalaSoft.MvvmLight;

namespace _15MinuteGoals.Data.ViewModels
{
    public class Vm_TopBar : ViewModelBase
    {
        private string _title = "Title";
        private int _iconsrc;
        private string _headerDesc = "None";
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

        public string HeaderDesc
        {
            get { return _headerDesc; }
            set { Set(ref _headerDesc, value); }
        }
    }
}