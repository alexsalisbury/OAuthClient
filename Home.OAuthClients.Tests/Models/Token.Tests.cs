namespace Home.OAuthClients.Tests.Models
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.OAuthClients.Models;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class Token_Tests
    {
        [TestMethod]
        public void TokenInstatiate()
        {
            var t = new Token();
            Assert.IsTrue(DateTime.UtcNow > t.TokenGenerated);
            Assert.IsTrue(DateTime.UtcNow - t.TokenGenerated < TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void TokenExpires()
        {
            var t = new Token()
            {
                ExpiresIn = 1,
                RefreshExpiresIn = 3
            };

            Assert.IsFalse(t.IsExpired);
            Assert.IsFalse(t.IsRefreshExpired);

            //TODO: Should this get locked down? I prefer this to doing Thread.Sleep in the meantime.
            t.ExpiresIn -= 2;
            t.RefreshExpiresIn -= 2;

            Assert.IsTrue(t.IsExpired);
            Assert.IsFalse(t.IsRefreshExpired);

            t.ExpiresIn -= 2;
            t.RefreshExpiresIn -= 2;

            Assert.IsTrue(t.IsExpired);
            Assert.IsTrue(t.IsRefreshExpired);
        }

        [TestMethod]
        public void TokenHeaders()
        {
            var expected = "Basic TestValue";
            var t = new Token()
            {
                TokenType = "Basic",
                AccessToken = "TestValue"
            };

            Assert.AreEqual(expected, t.HeaderString);

            var authHeader = t.AuthHeader;

            Assert.IsNotNull(authHeader);
            Assert.AreEqual("Basic", authHeader.Scheme);
            Assert.AreEqual("TestValue", authHeader.Parameter);
        }
    }
}