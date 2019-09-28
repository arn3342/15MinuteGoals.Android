using System.Collections.Generic;
using _15MinuteGoals.Data.ViewModels;
using Android.Content;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Android.Animation;
using System;

namespace _15MinuteGoals.UI.CustomViews
{
    public class TopBar : ConstraintLayout
    {
        private View MainView;
        private List<Binding> bindings = new List<Binding>();
        public Vm_TopBar mainViewModel;
        public TextView header;
        public static ImageView WritePostBtn { get; set; }
        public static TextView headerDescription {get; set; }

        #region Views declarations
        private TextView _headerTitle { get; set; }
        private ImageView _iconBtn { get; set; }
        #endregion

        public string Title { get; set; }
        public string HeaderDescription { get; set; }
        private int WritePostBtnWidth = 0;

        //public TextView HeaderTitle
        //{
        //    get
        //    {
        //        return _headerTitle ?? (_headerTitle = FindViewById<TextView>)
        //    }
        //}

        #region Constructor
        public TopBar(Context context) : base(context)
        {
            Initialize(context);
        }

        public TopBar(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public TopBar(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }
        #endregion
        private void Initialize(Context ctx)
        {
            mainViewModel = new Vm_TopBar();
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            MainView = inflatorService.Inflate(Resource.Layout.customview_topbar, this, false);
            WritePostBtn = MainView.FindViewById<ImageView>(Resource.Id.writepostBtn);
            //header = MainView.FindViewById<TextView>(Resource.Id.headerTitle);
            //headerDescription = MainView.FindViewById<TextView>(Resource.Id.headerDesc);
            #region Setting view instances
            //_headerTitle = MainView.FindViewById<TextView>(Resource.Id.headerTitle);
            //_iconBtn = MainView.FindViewById<ImageView>(Resource.Id.iconbtn);
            #endregion

            AddView(MainView);
            BindProperties();
            //AnimateHeader();
        }

        private void BindProperties()
        {
        //    bindings.Add(this.SetBinding(() => mainViewModel.Title,
        //() => _headerTitle.Text));
        //    bindings.Add(this.SetBinding(() => mainViewModel.IconSource,
        //() => _iconBtn.Drawable));
        //    bindings.Add(this.SetBinding(() => mainViewModel.HeaderDesc,
        //() => _iconBtn.Drawable));
        }

        public void SetPropertyValues()
        {
            //mainViewModel.Title = Title;
            //mainViewModel.HeaderDesc = HeaderDescription;
            //mainViewModel.IconSource = IconSource;
            //mainViewModel.ButtonText = ButtonText;
            //ImageService.Instance.LoadUrl(UserImgSrc).Into(UserImg);
        }

        public void AnimateSearch(int PropertyValue, bool HideView)
        {
            ValueAnimator Animator = ValueAnimator.OfInt(WritePostBtn.MeasuredWidth, PropertyValue);
            Animator.AddUpdateListener(new AnimUpdateListner());
            Animator.AddListener(new AnimListner(HideView));
            Animator.SetDuration(250);
            Animator.Start();
        }

        private class AnimUpdateListner : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            public void OnAnimationUpdate(ValueAnimator animation)
            {
                int value = (int)animation.AnimatedValue;
                ViewGroup.LayoutParams layoutParams = WritePostBtn.LayoutParameters;
                layoutParams.Width = value;
                WritePostBtn.LayoutParameters = layoutParams;
            }


        }

        public void ExpandSearch()
        {
            if (WritePostBtnWidth == 0)
            {
                WritePostBtnWidth = WritePostBtn.Width;
                AnimateSearch(1, true);
            }            
        }
        public void ShrinkSearch()
        {
            if (WritePostBtnWidth != 0)
            {
                AnimateSearch(WritePostBtnWidth, false);
                WritePostBtnWidth = 0;
            }
        }

        private class AnimListner : Java.Lang.Object, Animator.IAnimatorListener
        {
            bool hideOnEnd;
            public AnimListner(bool HideViewOnEnd)
            {
                hideOnEnd = HideViewOnEnd;
            }
            public void OnAnimationCancel(Animator animation)
            {
               
            }

            public void OnAnimationEnd(Animator animation)
            {
                if (hideOnEnd)
                {
                    WritePostBtn.Visibility = ViewStates.Gone;
                }
            }

            public void OnAnimationRepeat(Animator animation)
            {
                
            }

            public void OnAnimationStart(Animator animation)
            {
                if (!hideOnEnd)
                {
                    WritePostBtn.Visibility = ViewStates.Visible;
                }
            }
        }
    }
}