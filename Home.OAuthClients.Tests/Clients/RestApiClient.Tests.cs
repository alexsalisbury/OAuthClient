namespace Home.OAuthClients.Tests.Clients
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Home.OAuthClients.Clients;
    using Home.OAuthClients.Tests.Helpers;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class RestApiClient_Tests
    {
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

        internal class TestRestApiClient : RestApiClient
        {
            private TestHttpMessageHandler handler;

            internal TestRestApiClient()
            {
                this.handler = new TestHttpMessageHandler();
                RestApiClient.Client = new HttpClient(handler);
            }

            internal void SetExpectedResponse(HttpResponseMessage expectedReponse)
            {
                this.handler.SetExpectedResponse(expectedReponse);
            }
        }

        public HttpResponseMessage GenerateResponse(HttpStatusCode statusCode)
        {
            return new HttpResponseMessage()
            {
                StatusCode = statusCode
            };
        }

        public HttpResponseMessage GenerateResponse(HttpStatusCode statusCode, string content)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(content),
                StatusCode = statusCode
            };
        }

        public HttpResponseMessage GenerateResponse<T>(HttpStatusCode statusCode, T content)
        {
            var json = JsonConvert.SerializeObject(content);

            return new HttpResponseMessage()
            {
                Content = new StringContent(json),
                StatusCode = statusCode
            };
        }

        [TestMethod]
        public async Task Get_Basic()
        {
            var client = new TestRestApiClient();
            var dataObject = ExampleDataObject.Generate();
            client.SetExpectedResponse(GenerateResponse<ExampleDataObject>(HttpStatusCode.OK, dataObject));

            var result = await TestRestApiClient.GetAsync<ExampleDataObject>("http://localhost");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.ParseSuccess);
            Assert.IsTrue(dataObject.Equals(result.Result));
            Assert.AreEqual(HttpStatusCode.OK, result.HttpResponseCode);
        }

        [TestMethod]
        public async Task Post_Basic()
        {
            var client = new TestRestApiClient();
            var dataObject = ExampleDataObject.Generate();
            client.SetExpectedResponse(GenerateResponse<ExampleDataObject>(HttpStatusCode.Created, dataObject));
            
            var result = await TestRestApiClient.PostAsync<ExampleDataObject>("http://localhost", dataObject.GenerateBody());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.ParseSuccess);
            Assert.IsTrue(dataObject.Equals(result.Result));
            Assert.AreEqual(HttpStatusCode.Created, result.HttpResponseCode);
        }

        [TestMethod]
        public async Task Put_Basic()
        {
            var client = new TestRestApiClient();
            var dataObject = ExampleDataObject.Generate();
            client.SetExpectedResponse(GenerateResponse<ExampleDataObject>(HttpStatusCode.NoContent, dataObject));

            var result = await TestRestApiClient.PostAsync<ExampleDataObject>("http://localhost", dataObject.GenerateBody());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.ParseSuccess);
            Assert.IsTrue(dataObject.Equals(result.Result));
            Assert.AreEqual(HttpStatusCode.NoContent, result.HttpResponseCode);
        }

        [TestMethod]
        public async Task Delete_Basic()
        {
            var client = new TestRestApiClient();
            client.SetExpectedResponse(GenerateResponse(HttpStatusCode.Accepted));

            var result = await TestRestApiClient.DeleteAsync("http://localhost");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(HttpStatusCode.Accepted, result.HttpResponseCode);
        }
    }
}