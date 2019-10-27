using Android.Graphics;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using _15MinuteGoals.UI.Activities;
using System.Collections.Generic;

namespace _15MinuteGoals.Adapter
{
    public class NotificationAdapter : RecyclerView.Adapter, IViewAdapter
    {
        List<object> contentCollection { get; set; }
        static FragmentManager mFragmentManager;

        public override int ItemCount
        {
            get { return contentCollection.Count; }
        }

        public NotificationAdapter(List<object> itemList, FragmentManager fragmentManager)
        {
            contentCollection = itemList;
            mFragmentManager = fragmentManager;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            TextView view = ActivityTitleExtensions.ConstructTitle(parent.Context, "Nothing new so far!", new LinearLayout(parent.Context), Resource.Color.colorWhite, "#a4a4a4");

            RecyclerView.ViewHolder vh = new NoNotifisViewHolder(view);
            return vh;
        }
        internal class NoNotifisViewHolder : RecyclerView.ViewHolder
        {
            static TextView NoNotifs;
            public NoNotifisViewHolder(View itemView) : base(itemView)
            {
                NoNotifs = (TextView)itemView;
            }
        }
    }
}