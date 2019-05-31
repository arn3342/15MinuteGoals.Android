using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _15MinuteGoals.Data.Models;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Auth;

namespace _15MinuteGoals.Authentication
{
    public class FacebookAuthentication
    {
        public Intent InitiateLogin(Context parent)
        {
            var auth = new OAuth2Authenticator
            (
                clientId: "365038010784654",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"),
                isUsingNativeUI: false
            );
            auth.Completed += AuthCompleted;
            var ui = auth.GetUI(parent);
            return ui;
        }
        private async void AuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request
                    (
                        "GET",
                        new Uri("https://graph.facebook.com/me?fields=name,email,picture"),
                        null,
                        e.Account
                    );
                var fbresponse = await request.GetResponseAsync();
                string json = fbresponse.GetResponseText();
                Facebook.User FacebookUser = JsonConvert.DeserializeObject<Facebook.User>(json);
            }
            else
            {

            }
        }
    }
}