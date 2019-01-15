namespace Home.OAuthClients.Models
{
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the result from an HTTP call using the RestClient
    /// </summary>
    public class HTTPResult : System.IEquatable<HTTPResult>
    {
        /// <summary>
        /// The HTTP Response Code from the server.
        /// </summary>
        public HttpStatusCode HttpResponseCode { get; }

        /// <summary>
        /// The content of the response. May be populated in error scenarios.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Memoizes the response's IsSuccessStatusCode 
        /// </summary>
        public bool Success { get;  }

        /// <summary>
        /// Creates an HTTP Response with the given parameters
        /// </summary>
        /// <param name="responsecode">The HTTP Response Code from the server</param>
        /// <param name="content">The content of the response</param>
        /// <param name="success">The response's IsSuccessStatusCode</param>
        public HTTPResult(HttpStatusCode responsecode, string content, bool success)
        {
            this.HttpResponseCode = responsecode;
            this.Content = content;
            this.Success = success;
        }

        /// <summary>
        /// Deep compare of properties to check if responses are equivalent.
        /// </summary>
        /// <param name="other">the object to compare this item to.</param>
        /// <returns>Whether all properties match. Case sensitive check on content (for now)</returns>
        public bool Equals(HTTPResult other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Content == other.Content && this.HttpResponseCode == other.HttpResponseCode && this.Success == other.Success;
        }
    }

    /// <summary>
    /// Represents a typed result from an HTTP call using the RestClient
    /// </summary>
    public class HTTPResult<T>
    {
        /// <summary>
        /// The HTTP Response Code from the server.
        /// </summary>
        public HttpStatusCode HttpResponseCode { get; }

        /// <summary>
        /// The content of the response. May be populated in error scenarios.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Memoizes the response's IsSuccessStatusCode 
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Indicates whether the object could be deserialized from the content. 
        /// </summary>
        public bool ParseSuccess { get; private set; }

        /// <summary>
        /// The deserialized object
        /// </summary>
        public T Result { get; private set; }

        /// <summary>
        /// Creates an HTTP Response with the given parameters
        /// </summary>
        /// <param name="responsecode">The HTTP Response Code from the server</param>
        /// <param name="content">The content of the response</param>
        /// <param name="success">The response's IsSuccessStatusCode</param>
        public HTTPResult(HttpStatusCode responsecode, string content, bool success)
        {
            this.HttpResponseCode = responsecode;
            this.Content = content;
            this.Success = success;
            this.ParseSuccess = false;
            try
            {
                if (success)
                {
                    this.Result = JsonConvert.DeserializeObject<T>(content);
                    this.ParseSuccess = true;
                }
            }
            catch
            {
                // I'm fine swallowing this, but I'd prefer to log it in the future.
            }
        }
    }
}