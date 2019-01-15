namespace Home.OAuthClients.Tests
{
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.OAuthClients.Models;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class HttpResult_Tests
    {
        [TestMethod]
        public void InstantiateResult()
        {
            string content = "test_content";
            var httpResult = new HTTPResult(HttpStatusCode.Accepted, content, true);
            Assert.IsNotNull(httpResult);
            Assert.IsTrue(httpResult.Success);
            Assert.AreEqual(content, httpResult.Content);
            Assert.AreEqual(HttpStatusCode.Accepted, httpResult.HttpResponseCode);
        }
    }
}