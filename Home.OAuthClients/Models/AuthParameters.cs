namespace Home.OAuthClients.Models
{
    /// <summary>
    /// The <see cref="AuthParameters"/>.
    /// </summary>
    public class AuthParameters
    {

        /// <summary>
        /// Gets or sets the authentication client id.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the authentication client secret.
        /// Note that this is only used for the AuthorizationCode flow.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the authentication redirect uri.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Generates a query string used for OAuth2 code requests
        /// </summary>
        /// <returns>url query string to be appended to base url</returns>
        public virtual string GetQueryString()
        {
            //TODO: Should validate that RedirectUri is a Valid Uri?
            var queryString =
                   $"client_id={this.ClientId}" +
                   $"&response_type=code" +
                   $"&redirect_uri={this.RedirectUri}";

            return queryString;
        }
    }
}