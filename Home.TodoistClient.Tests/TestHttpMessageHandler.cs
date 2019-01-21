namespace Home.TodoistClient.Tests
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TestHttpMessageHandler : HttpMessageHandler
    {
        internal HttpResponseMessage ExpectedReponse { get; set; }

        internal void SetExpectedResponse(HttpResponseMessage expectedReponse)
        {
            this.ExpectedReponse = expectedReponse;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            ExpectedReponse.RequestMessage = request;
            return ExpectedReponse;
        }
    }
}
