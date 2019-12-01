using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;

namespace _15MinuteGoals.UI.CustomViews
{
    public class TabLayout : ConstraintLayout, ICustomViewAnimated
    {
        #region Constructors & properties
        int[] DefaultIcons, SelectedIcons;
        public delegate void TabSelected(string tabTitle);
        public event TabSelected OnTabSelected;
        public TabLayout(Context context) : base(context)
        {
            Initialize(context);
        }

        public TabLayout(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public TabLayout(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }

        protected TabLayout(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public long AnimationDelay { get; set; } = 0;
        #endregion

        private void Initialize(Context ctx)
        {
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            var MainView = inflatorService.Inflate(Resource.Layout.customview_tabLayout, this, false);
            LinearLayout mainLayout = MainView.FindViewById<LinearLayout>(Resource.Id.tabContainer);
            BindToClicks(mainLayout);
            AddView(MainView);

            DefaultIcons = new int[]
            {
                Resource.Drawable.home_icon,
                Resource.Drawable.explore_icon,
                Resource.Drawable.whatsNew_icon,
                Resource.Drawable.profile_icon
            };
            SelectedIcons = new int[]
            {
                Resource.Drawable.home_icon_selected,
                Resource.Drawable.explore_icon_selected,
                Resource.Drawable.whatsNew_icon_selected,
                Resource.Drawable.profile_icon_selected
            };
        }

        private void BindToClicks(LinearLayout layout)
        {
;            for (int i = 0; i < layout.ChildCount; i++)
            {
                int index = i;
                View tab = layout.GetChildAt(index);
                tab.Click += ((object sender, EventArgs e) => Tab_Selected(tab, e, index, layout));
            }
        }
        private void Tab_Selected(object sender, EventArgs e, int i, LinearLayout parent)
        {
            for (int index = 0; index < parent.ChildCount - index; index++)
            {
                ImageView tab = (ImageView)parent.GetChildAt(index);
                tab.SetImageResource(DefaultIcons[index]);
            }

            ImageView view = sender as ImageView;
            view.SetImageResource(SelectedIcons[i]);
            switch (i)
            {
                case 0:
                    OnTabSelected?.Invoke("Home");
                    break;
                case 1:
                    OnTabSelected?.Invoke("Explore");
                    break;
                case 2:
                    OnTabSelected?.Invoke("Notifications");
                    break;
                case 3:
                    OnTabSelected?.Invoke("Profile");
                    break;
            }
        }
    }
}
