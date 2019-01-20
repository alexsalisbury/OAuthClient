namespace Home.OAuthClients.Tests.Models
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.OAuthClients.Models;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class AuthParameters_Tests
    {
        [TestMethod]
        public void AuthParams_ClientString()
        {
            Uri testUri = new Uri("http://127.0.0.1");

            var result = $"client_id=Test&response_type=code&redirect_uri=localhost";
            var ap = new AuthParameters()
            {
                ClientId = "Test",
                ClientSecret = "Secret",
                RedirectUri = testUri
            };

            var url = ap.GetQueryString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(url));
        }
    }
}