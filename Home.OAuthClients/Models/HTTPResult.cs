namespace Home.OAuthClients.Models
{
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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

    public class HTTPResult<T>
    {
        public HttpStatusCode HttpResponseCode { get; private set; }
        public string Content { get; private set; }
        public bool Success { get; private set; }
        public bool ParseSuccess { get; private set; }
        public T Result { get; private set; }

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

            }
        }
    }
}
