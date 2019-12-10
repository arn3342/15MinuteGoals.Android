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
    public class Subject
    {
        public string Title { get; set; }
        public int IconId { get; set; }
        public int BackgroundId { get; set; }
    }
}