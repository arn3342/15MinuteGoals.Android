using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Android.Support.V4.View;

namespace _15MinuteGoals.Data
{
    public class ViewPagerAdapter : FragmentStatePagerAdapter
    {
        public List<Fragment> FragmentsList = new List<Fragment>();
        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
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