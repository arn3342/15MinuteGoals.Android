using Android.Runtime;
using Android.Support.V4.App;
using System;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class ViewPagerAdapter : FragmentStatePagerAdapter
    {
        public List<Fragment> FragmentsList = new List<Fragment>();
        public ViewPagerAdapter(FragmentManager fm) : base(fm)
        {
        }
        public ViewPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        public override int Count
        {
            get { return FragmentsList.Count; }
        }
        public override Fragment GetItem(int position)
        {
            return FragmentsList[position];
        }
        public void AddFragment(Fragment fragment)
        {
            FragmentsList.Add(fragment);
        }
    }
}