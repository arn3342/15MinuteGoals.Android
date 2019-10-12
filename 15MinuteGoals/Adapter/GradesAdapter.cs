using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.Adapter
{
    public class GradesAdapter : RecyclerView.Adapter
    {
        public string[] contentCollection;
        public FragmentManager FragmentManager { get; set; }

        public override int ItemCount
        {
            get { return contentCollection.Length; }
        }

        public GradesAdapter(string[] itemList)
        {
            contentCollection = itemList;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            GradeViewHolder vh = holder as GradeViewHolder;
            vh.GradeButton.Text = contentCollection[position];
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Button button = new Button(parent.Context, null, Resource.Style.GrayRoundButton);
            RecyclerView.ViewHolder vh = new GradeViewHolder(button);
            return vh;
        }
        public class GradeViewHolder : RecyclerView.ViewHolder
        {
            public Button GradeButton;
            public GradeViewHolder(View itemView) : base(itemView)
            {
                GradeButton = (Button)itemView;
                GradeButton.Click += GradeButton_Click;
            }

            private void GradeButton_Click(object sender, System.EventArgs e)
            {
                //throw new System.NotImplementedException();
            }
        }
    }
}