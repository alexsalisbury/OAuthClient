namespace Home.OAuthClients.Clients
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Home.OAuthClients.Models;

    public abstract class OAuthApiClient : RestApiClient
    {
        protected Token currentToken;
        protected Uri authUri;
        protected Uri tokenUri;

        protected OAuthApiClient(Uri authUri, Uri tokenUri)
        {
            this.authUri = authUri;
            this.tokenUri = tokenUri;
        }

        public abstract string GetRequestAuthUrl(AuthParameters parameters);
        public abstract void SetRequestAuthHeader(Token currentToken);
        public abstract void SetTokenRequestAuthHeader(AuthParameters parameters);

        public virtual string BuildTokenPostBody(AuthParameters authParameters, string code)
        {
            var postData = "grant_type=authorization_code" +
                           $"&code={code}" +
                           $"&redirect_uri={authParameters.RedirectUri}";
            return postData;
        }

        public virtual string BuildRefreshTokenPostBody(AuthParameters authParameters, string refreshToken)
        {
            var postData = "grant_type=refresh_token" +
                           $"&refresh_token={refreshToken}";
            return postData;
        }
    }
}