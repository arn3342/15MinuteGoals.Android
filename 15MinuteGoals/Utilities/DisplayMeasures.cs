using Android.Content.Res;

namespace _15MinuteGoals.Utilities
{
    public class DisplayMeasures
    {
        public static class SetDp
        {
            public static int ToInt(int dp)
            {
                return (int)(dp / Resources.System.DisplayMetrics.Density + 0.5f);
            }
        }
    }
}