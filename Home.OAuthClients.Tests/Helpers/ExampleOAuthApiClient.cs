namespace Home.OAuthClients.Tests.Helpers
{
    using Home.OAuthClients.Clients;
    using Home.OAuthClients.Models;
    using System;

    internal class ExampleOAuthApiClient : OAuthApiClient
    {
        private static readonly Uri ExampleAuthUri = new Uri("http://localhost/auth");
        private static readonly Uri ExampleTokenUri = new Uri("http://localhost/token");

        public ExampleOAuthApiClient():base (ExampleAuthUri, ExampleTokenUri)
        {
        }

        public override string GetRequestAuthUrl(AuthParameters parameters)
        {
            UriBuilder u = new UriBuilder(this.authUri);
            u.Query = parameters.GetQueryString();
            return u.ToString();
        }

        public override void SetRequestAuthHeader(Token currentToken)
        {

        }

        public override void SetTokenRequestAuthHeader(AuthParameters parameters)
        {
            Client.DefaultRequestHeaders.Authorization = currentToken.AuthHeader;
        }
    }
}