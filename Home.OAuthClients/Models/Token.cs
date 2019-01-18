namespace Home.OAuthClients.Models
{
    using System;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a basic token 
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Generates a basic token, setting the token generated timestamp
        /// </summary>
        public Token()
        {
            this.TokenGenerated = DateTime.UtcNow;
        }

        /// <summary>
        /// The Access Token for the service
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The refresh token to present when the token expires/
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The type of token.
        /// TODO: List out types explicitly
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// How long the token is valid for
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// How long the refresh token is valid for
        /// </summary>
        [JsonProperty("refresh_token_expires_in")]
        public int RefreshExpiresIn { get; set; }

        /// <summary>
        /// The time we generated this object
        /// </summary>
        [JsonProperty("token_generated")]
        public DateTime TokenGenerated { get; private set; }

        /// <summary>
        /// Whether the token is expired
        /// Note that due to lag, the server might not agree.
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => DateTime.UtcNow > this.TokenGenerated.AddSeconds(this.ExpiresIn);

        /// <summary>
        /// Whether the token is expired
        /// Note that due to lag, the server might not agree.
        /// </summary>
        [JsonIgnore]
        public bool IsRefreshExpired => DateTime.UtcNow > this.TokenGenerated.AddSeconds(this.RefreshExpiresIn);

        /// <summary>
        /// Header string for use
        /// </summary>
        [JsonIgnore]
        public string HeaderString =>  $"{this.TokenType} {this.AccessToken}";

        /// <summary>
        /// Auth Header for use
        /// </summary>
        [JsonIgnore]
        public AuthenticationHeaderValue AuthHeader => new AuthenticationHeaderValue(TokenType, AccessToken);
    }
}