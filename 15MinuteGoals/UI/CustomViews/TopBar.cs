using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _15MinuteGoals.Data.ViewModels;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
        public Vm_TopBar mainViewModel = new Vm_TopBar();

        private TextView HeaderTitle { get; set; }
        private TextView ButtonText { get; set; }
        private ImageView IconBtn { get; set; }
        private ImageView UserImg { get; set; }

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
            var inflatorService = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
            MainView = inflatorService.Inflate(Resource.Layout.customview_topbar, this, false);
            this.AddView(MainView);
            BindProperties();
        }

        private void BindProperties()
        {
            bindings.Add(this.SetBinding(() => mainViewModel.Title,
        () => HeaderTitle.Text));
            bindings.Add(this.SetBinding(() => mainViewModel.IconSource,
        () => IconBtn.Drawable));
            bindings.Add(this.SetBinding(() => mainViewModel.ButtonText,
        () => ButtonText.Text));
        }

        public void SetPropertyValues(string Title = "", int IconSource = 0, string ButtonText = "", string UserImgSrc = "")
        {
            mainViewModel.Title = Title;
            mainViewModel.IconSource = IconSource;
            mainViewModel.ButtonText = ButtonText;
            ImageService.Instance.LoadUrl(UserImgSrc).Into(UserImg);
        }
    }
}