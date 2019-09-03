using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.Data.Models
{
    public class PostRegular
    {
        public string UserFullName { get; set; }
        public string UserImageUrl { get; set; }
        public string PostBody { get; set; }
        public string InspireCount { get; set; }
    }
}