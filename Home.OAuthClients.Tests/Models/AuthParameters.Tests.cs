namespace Home.OAuthClients.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.OAuthClients.Models;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class AuthParameters_Tests
    {
        [TestMethod]
        public void AuthParams_ClientString()
        {
            var result = $"client_id=Test&response_type=code&redirect_uri=localhost";
            var ap = new AuthParameters()
            {
                ClientId = "Test",
                ClientSecret = "Secret",
                RedirectUri = "localhost"
            };

            var url = ap.GetQueryString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(url));
        }
    }
}