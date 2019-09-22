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
    public class ProgressBox : ConstraintLayout
    {
        private View MainView;
        private List<Binding> bindings = new List<Binding>();
        public Vm_TopBar mainViewModel;

        #region Views declarations
        private TextView _headerTitle { get; set; }
        private TextView _buttonText { get; set; }
        private ImageView _iconBtn { get; set; }
        private ImageView _userImg { get; set; }
        #endregion

        public string CurrentState { get; set; }
        public string ButtonText { get; set; }
        

        //public TextView HeaderTitle
        //{
        //    get
        //    {
        //        return _headerTitle ?? (_headerTitle = FindViewById<TextView>)
        //    }
        //}

        #region Constructor
        public ProgressBox(Context context) : base(context)
        {
            Initialize(context);
        }

        public ProgressBox(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context);
        }

        public ProgressBox(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }
        #endregion
        private void Initialize(Context ctx)
        {
            //mainViewModel = new Vm_TopBar();
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            MainView = inflatorService.Inflate(Resource.Layout.customview_progressBox, this, false);

            #region Setting view instances

            #endregion

            this.AddView(MainView);
            BindProperties();
            
        }

        private void BindProperties()
        {
        //    bindings.Add(this.SetBinding(() => mainViewModel.Title,
        //() => _headerTitle.Text));
        }

        public void SetPropertyValues()
        {
            //mainViewModel.Title = CurrentState;
            //mainViewModel.IconSource = IconSource;
            //mainViewModel.ButtonText = ButtonText;
            //ImageService.Instance.LoadUrl(UserImgSrc).Into(UserImg);
        }
    }
}