using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.CustomControls
{
    public class SmallPostPanel : LinearLayout
    {
        public SmallPostPanel(Context context) : base(context)
        {
            Initialize(context);
        }
        public SmallPostPanel(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }
        public SmallPostPanel(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }
        private void Initialize(Context ctx)
        {
            //Inflating the layout
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            View v = inflatorService.Inflate(Resource.Layout.custom_SmallPostPanel, this, false);
            this.AddView(v);
        }

    }
}