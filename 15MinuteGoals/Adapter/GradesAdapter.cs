using _15MinuteGoals.UI.Dialogs;
using _15MinuteGoals.Utilities;
using Android.Graphics;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class GradesAdapter : RecyclerView.Adapter, IViewAdapter
    {
        List<object> contentCollection { get; set; }
        static FragmentManager mFragmentManager;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public GradesAdapter(List<object> itemList, FragmentManager fragmentManager)
        {
            contentCollection = itemList;
            mFragmentManager = fragmentManager;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            GradeViewHolder vh = holder as GradeViewHolder;
            vh.GradeButton.Text = contentCollection[position].ToString();
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Button button = new Button(parent.Context);
            #region Designing the button
            var layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ValueConverter.DpToPx(33));
            layoutParams.TopMargin = ValueConverter.DpToPx(10);
            layoutParams.LeftMargin = ValueConverter.DpToPx(10);

            button.LayoutParameters = layoutParams;
            button.SetAllCaps(false);
            button.Typeface = Typeface.Create("sans-serif", TypefaceStyle.Normal);
            button.SetPadding(ValueConverter.DpToPx(20), 0, ValueConverter.DpToPx(20), 0);
            button.SetBackgroundResource(Resource.Drawable.bg_roundedGray);
            #endregion

            RecyclerView.ViewHolder vh = new GradeViewHolder(button);
            return vh;
        }
        internal class GradeViewHolder : RecyclerView.ViewHolder
        {
            internal Button GradeButton;

            public GradeViewHolder(View itemView) : base(itemView)
            {
                GradeButton = (Button)itemView;
                GradeButton.Click += GradeButton_Click;
            }

            private void GradeButton_Click(object sender, System.EventArgs e)
            {
                ClassSelectionDialog classSelectionDialog = new ClassSelectionDialog();
                classSelectionDialog.Show(mFragmentManager, "Class selection fragment");
            }
        }
    }
}