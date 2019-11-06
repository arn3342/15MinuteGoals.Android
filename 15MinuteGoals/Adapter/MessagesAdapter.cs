using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class MessagesAdapter : RecyclerView.Adapter, IViewAdapter
    {
        List<object> contentCollection { get; set; }
        static FragmentManager mFragmentManager;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public MessagesAdapter(List<object> itemList, FragmentManager fragmentManager)
        {
            contentCollection = itemList;
            mFragmentManager = fragmentManager;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder vh = new MessagesViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.customview_messageBox, parent, false));
            return vh;
        }
        internal class MessagesViewHolder : RecyclerView.ViewHolder
        {

            public MessagesViewHolder(View itemView) : base(itemView)
            {
            }
        }
    }
}