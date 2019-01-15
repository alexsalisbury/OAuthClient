namespace Home.OAuthClients.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Net;

    public class HTTPResult : System.IEquatable<HTTPResult>
    {
        public HttpStatusCode HttpResponseCode { get; private set; }
        public string Content { get; private set; }
        public bool Success { get; private set; }

        public HTTPResult(HttpStatusCode responsecode, string content, bool success)
        {
            this.HttpResponseCode = responsecode;
            this.Content = content;
            this.Success = success;
        }

        public bool Equals(HTTPResult other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Content == other.Content && this.HttpResponseCode == other.HttpResponseCode && this.Success == other.Success;
        }
    }
}
