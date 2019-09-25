using System.Collections.Generic;
using _15MinuteGoals.Data.ViewModels;
using Android.Content;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;
using _15MinuteGoals.Data;
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
        public static TextView headerDescription {get; set; }

        #region Views declarations
        private TextView _headerTitle { get; set; }
        private ImageView _iconBtn { get; set; }
        #endregion

        public string Title { get; set; }
        public string HeaderDescription { get; set; }
        

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
            header = MainView.FindViewById<TextView>(Resource.Id.headerTitle);
            headerDescription = MainView.FindViewById<TextView>(Resource.Id.headerDesc);
            #region Setting view instances
            _headerTitle = MainView.FindViewById<TextView>(Resource.Id.headerTitle);
            _iconBtn = MainView.FindViewById<ImageView>(Resource.Id.iconbtn);
            #endregion

            AddView(MainView);
            BindProperties();
            //AnimateHeader();
        }

        private void BindProperties()
        {
            bindings.Add(this.SetBinding(() => mainViewModel.Title,
        () => _headerTitle.Text));
            bindings.Add(this.SetBinding(() => mainViewModel.IconSource,
        () => _iconBtn.Drawable));
            bindings.Add(this.SetBinding(() => mainViewModel.HeaderDesc,
        () => _iconBtn.Drawable));
        }

        public void SetPropertyValues()
        {
            mainViewModel.Title = Title;
            mainViewModel.HeaderDesc = HeaderDescription;
            //mainViewModel.IconSource = IconSource;
            //mainViewModel.ButtonText = ButtonText;
            //ImageService.Instance.LoadUrl(UserImgSrc).Into(UserImg);
        }

        public void AnimateHeader()
        {
            //float newSize = ValueConverter.DpToPx(15);
            ValueAnimator valueAnimator = ObjectAnimator.OfFloat(header, "textSize", 5);
            valueAnimator.SetDuration(450);
            valueAnimator.AddListener(new AnimListner());
            valueAnimator.Start();
        }

        private class AnimListner : Java.Lang.Object, Animator.IAnimatorListener
        {
            public void OnAnimationCancel(Animator animation)
            {
            }

            public void OnAnimationEnd(Animator animation)
            {
                headerDescription.Visibility = ViewStates.Visible;
            }

            public void OnAnimationRepeat(Animator animation)
            {
                
            }

            public void OnAnimationStart(Animator animation)
            {
                
            }
        }
    }
}