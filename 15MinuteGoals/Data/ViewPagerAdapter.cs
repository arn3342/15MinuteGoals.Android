using Android.Runtime;
using Android.Support.V4.App;
using System;
using System.Collections.Generic;

namespace _15MinuteGoals.Data
{
    public class ViewPagerAdapter : FragmentStatePagerAdapter
    {
        public List<Fragment> FragmentList = new List<Fragment>();

        public ViewPagerAdapter(FragmentManager fm) : base(fm)
        {

        }
        public override int Count
        {
            get { return FragmentList.Count; }
        }

        public override Fragment GetItem(int position)
        {
            return FragmentList[position];
        }
        public ViewPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public void AddFragment(Fragment fragment)
        {
            FragmentList.Add(fragment);
        }
    }
}