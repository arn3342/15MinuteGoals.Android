using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Support.V4.App;

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