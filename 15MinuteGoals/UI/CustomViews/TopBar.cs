using System.Collections.Generic;
using _15MinuteGoals.Data;
using _15MinuteGoals.Data.ViewModels;
using Android.Content;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using GalaSoft.MvvmLight.Helpers;

namespace _15MinuteGoals.UI.CustomViews
{
    public class TopBar : ConstraintLayout
    {
        private View MainView;
        private List<Binding> bindings = new List<Binding>();
        public Vm_TopBar mainViewModel;

        #region Views declarations
        private TextView _headerTitle { get; set; }
        private ImageView _iconBtn { get; set; }
        #endregion

        public string Title { get; set; }
        public string ButtonText { get; set; }
        

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

            #region Setting view instances
            _headerTitle = MainView.FindViewById<TextView>(Resource.Id.headerTitle);
            _iconBtn = MainView.FindViewById<ImageView>(Resource.Id.iconbtn);
            #endregion

            this.AddView(MainView);
            BindProperties();
            
        }

        private void BindProperties()
        {
            bindings.Add(this.SetBinding(() => mainViewModel.Title,
        () => _headerTitle.Text));
            bindings.Add(this.SetBinding(() => mainViewModel.IconSource,
        () => _iconBtn.Drawable));
        }

        public void SetPropertyValues()
        {
            mainViewModel.Title = Title;
            //mainViewModel.IconSource = IconSource;
            //mainViewModel.ButtonText = ButtonText;
            //ImageService.Instance.LoadUrl(UserImgSrc).Into(UserImg);
        }
    }
}