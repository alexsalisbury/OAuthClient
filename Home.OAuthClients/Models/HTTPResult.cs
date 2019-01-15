namespace Home.OAuthClients.Models
{
    using System.Net;

    public class HTTPResult
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
    }
}
