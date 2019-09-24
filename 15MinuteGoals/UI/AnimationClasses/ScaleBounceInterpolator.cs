using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.UI.AnimationClasses
{
    public class ScaleBounceInterpolator : Java.Lang.Object, Android.Views.Animations.IInterpolator
    {
        private double Amplitude = 1;
        private double Frequency = 1;

        public ScaleBounceInterpolator(double amplitude, double frequency)
        {
            Amplitude = amplitude;
            Frequency = frequency;
        }
        public float GetInterpolation(float time)
        {
            return (float)(-1 * Math.Pow(Math.E, -time / Amplitude) * Math.Cos(Frequency * time) + 1);
        }
    }
}