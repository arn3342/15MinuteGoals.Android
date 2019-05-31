using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace _15MinuteGoals.Authentication
{
    public class GoogleAuthentication
    {
        public GoogleApiClient GoogleLogin(Context context, FragmentActivity fragmentActivity, GoogleApiClient.IOnConnectionFailedListener onConnectionFailedListener, GoogleApiClient.IConnectionCallbacks onconnectionCallbacks)
        {
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestEmail()
                .Build();
            GoogleApiClient mgoogleApiClient = new GoogleApiClient.Builder(context)
                                                    .EnableAutoManage(fragmentActivity, onConnectionFailedListener)
                                                    .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                                                    .AddConnectionCallbacks(onconnectionCallbacks)
                                                    .Build();
            return mgoogleApiClient;
        }
        public void HandleSignIn(GoogleSignInResult result)
        {
            GoogleSignInAccount account = null;
            if (result.IsSuccess)
            {
                account = result.SignInAccount;
            }
        }
    }
}