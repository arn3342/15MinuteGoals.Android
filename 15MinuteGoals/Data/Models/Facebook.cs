namespace _15MinuteGoals.Data.Models
{
    public class FacebookModel
    {
        internal class Data
        {
            public int height { get; set; }
            public bool Is_silhouette { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }
        internal class Picture
        {
            public Data data { get; set; }
        }
        internal class User
        {
            public string name { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
            public string email { get; set; }
            public Picture picture { get; set; }
            public string Id { get; set; }
        }
    }
}