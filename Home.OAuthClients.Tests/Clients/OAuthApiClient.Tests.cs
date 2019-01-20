namespace Home.OAuthClients.Tests.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.OAuthClients.Clients;
    using Home.OAuthClients.Models;
    using Home.OAuthClients.Tests.Helpers;

    [TestClass]
    public class OAuthApiClient_Tests
    {
        Uri testUri = new Uri("http://127.0.0.1");

        [TestMethod]
        public void ValidateTokenBodyGeneration()
        {
            var expectedTokenBody = $"grant_type=authorization_code&code=testCode&redirect_uri={testUri.AbsoluteUri}";

            ExampleOAuthApiClient client = new ExampleOAuthApiClient();

            AuthParameters ap = new AuthParameters()
            {
                ClientId = "TestClientId",
                RedirectUri = testUri
            };

            var tokenBody = client.BuildTokenPostBody(ap, "testCode");
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokenBody));
            Assert.AreEqual(expectedTokenBody, tokenBody);
        }

        [TestMethod]
        public void ValidateTokenRefreshBodyGeneration()
        {
            var rt = Guid.NewGuid().ToString();
            var expectedTokenBody = $"grant_type=refresh_token&refresh_token={rt}";

            ExampleOAuthApiClient client = new ExampleOAuthApiClient();


            var tokenBody = client.BuildRefreshTokenPostBody(null, rt);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokenBody));
            Assert.AreEqual(expectedTokenBody, tokenBody);
        }

        #region Test Helper Function Tests
        [TestMethod]
        public void CompareQueryStringsShouldMapExactMatch()
        {
            var expected = "grant_type=authorization_code&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1";
            var actual = expected;

            Assert.IsTrue(CompareQueryStrings(expected, actual));
        }

        [TestMethod]
        public void CompareQueryStringsShouldMapReorderedMatch()
        {
            var expected = "grant_type=authorization_code&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1";
            var actual = "redirect_uri=http%3A%2F%2F127.0.0.1&client_id=TESTAPP&code=testcode&access_type=offline&refresh_token=&grant_type=authorization_code";

            Assert.IsTrue(CompareQueryStrings(expected, actual));
        }

        [TestMethod]
        public void CompareQueryStringsShouldFailMisMatch()
        {
            //changing only grant type value.
            var expected = "grant_type=authorization_code&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1";
            var actual = "grant_type=authorizationcode&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1";

            Assert.IsFalse(CompareQueryStrings(expected, actual));
        }

        [TestMethod]
        public void CompareQueryStringsShouldFailFinalMismatch()
        {
            //changing only redirect_uri value.
            var expected = "grant_type=authorization_code&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1";
            var actual = "grant_type=authorization_code&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1%2F";

            Assert.IsFalse(CompareQueryStrings(expected, actual));
        }

        [TestMethod]
        public void CompareQueryStringsShouldFailMissingItem()
        {
            //remove empty refresh token pair
            var expected = "grant_type=authorization_code&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1";
            var actual = "grant_type=authorization_code&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1%2F";

            Assert.IsFalse(CompareQueryStrings(expected, actual));
        }

        [TestMethod]
        public void CompareQueryStringsShouldFailExtraItem()
        {
            //adding fail = true to end.
            var expected = "grant_type=authorization_code&refresh_token=&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1";
            var actual = "grant_type=authorization_code&access_type=offline&code=testcode&client_id=TESTAPP&redirect_uri=http%3A%2F%2F127.0.0.1%2F&fail=true";

            Assert.IsFalse(CompareQueryStrings(expected, actual));
        }
        #endregion

        private bool CompareQueryStrings(string expected, string actual)
        {
            var expectedSet = expected.Split('&').ToList();
            foreach (var actualItem in actual.Split('&').ToList())
            {
                if (expectedSet.Contains(actualItem))
                {
                    expectedSet.Remove(actualItem);
                }
                else
                {
                    return false;
                }
            }

            return expectedSet.Count == 0;
        }
    }
}
