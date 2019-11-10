using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using System;

namespace _15MinuteGoals.UI.CustomViews
{
    public class GradientTextView : TextView
    {
        public GradientTextView(Context context) : base(context)
        {
        }

        public GradientTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public GradientTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public GradientTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected GradientTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
            if (changed)
            {
                Paint.SetShader(new LinearGradient(0,
                             0,
                             Width,
                             Height,
                             Color.ParseColor("#0078ff"),
                             Color.ParseColor("#2bcaff"),
                             Shader.TileMode.Clamp));
            }
        }
    }
}