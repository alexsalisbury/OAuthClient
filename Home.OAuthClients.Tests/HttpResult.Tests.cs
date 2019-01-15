﻿namespace Home.OAuthClients.Tests
{
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.OAuthClients.Models;
    using Newtonsoft.Json;

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

        [TestMethod]
        public void IEquatableSupport()
        {
            string content = "test_content";
            var httpResult = new HTTPResult(HttpStatusCode.Accepted, content, true);

            Assert.IsTrue(httpResult.Equals(httpResult));
        }

        [TestMethod]
        public void IEquatableSupport_N_Null()
        {
            string content = "test_content";
            var httpResult = new HTTPResult(HttpStatusCode.Accepted, content, true);

            Assert.IsFalse(httpResult.Equals(null));
        }

        [TestMethod]
        public void IEquatableSupport_N_CodeMismatch()
        {
            string content = "test_content";
            var httpResult = new HTTPResult(HttpStatusCode.Accepted, content, true);
            var httpResult2 = new HTTPResult(HttpStatusCode.AlreadyReported, content, true);

            Assert.IsFalse(httpResult.Equals(httpResult2));
        }

        [TestMethod]
        public void IEquatableSupport_N_ContentMismatch_Null()
        {
            string content = "test_content";
            var httpResult = new HTTPResult(HttpStatusCode.Accepted, content, true);
            var httpResult2 = new HTTPResult(HttpStatusCode.AlreadyReported, null, true);

            Assert.IsFalse(httpResult.Equals(httpResult2));
        }

        [TestMethod]
        public void IEquatableSupport_N_ContentMismatch_Case()
        {
            string content = "test_content";
            var httpResult = new HTTPResult(HttpStatusCode.Accepted, content, true);
            var httpResult2 = new HTTPResult(HttpStatusCode.AlreadyReported, content.ToUpper(), true);

            Assert.IsFalse(httpResult.Equals(httpResult2));
        }

        [TestMethod]
        public void IEquatableSupport_N_SuccessMismatch()
        {
            string content = "test_content";
            var httpResult = new HTTPResult(HttpStatusCode.Accepted, content, true);
            var httpResult2 = new HTTPResult(HttpStatusCode.AlreadyReported, content, false);

            Assert.IsFalse(httpResult.Equals(httpResult2));
        }
    }
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class HttpResult_T_Tests
    {
        [TestMethod]
        public void InstantiateResult()
        {
            string content = "test_content";
            var contentObject = new HTTPResult(HttpStatusCode.Accepted, content, true);
            var serializedResult = JsonConvert.SerializeObject(contentObject);

            var httpResult = new HTTPResult<HTTPResult>(HttpStatusCode.Accepted, serializedResult, true);


            Assert.IsNotNull(httpResult);
            Assert.IsTrue(httpResult.Success);
            Assert.IsTrue(httpResult.ParseSuccess);
            Assert.AreEqual(serializedResult, httpResult.Content);
            Assert.AreEqual(HttpStatusCode.Accepted, httpResult.HttpResponseCode);
            Assert.IsNotNull(httpResult.Result);
            //Assert.IsTrue(contentObject.Equals(httpResult.Result));
            Assert.AreEqual(content, httpResult.Result.Content);
            Assert.AreEqual(true, httpResult.Result.Success);
            //Assert.AreEqual(HttpStatusCode.Accepted, httpResult.Result.HttpResponseCode);
        }
    }
}