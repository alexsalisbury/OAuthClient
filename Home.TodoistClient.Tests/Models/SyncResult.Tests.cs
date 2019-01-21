namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class SyncResult_Tests
    {
        [TestMethod]
        public void SyncResultCreate()
        {
            var data = new SyncData();
            var sr = new SyncResult(SyncResult.APIKeyStatus.Invalid);
            Assert.IsNotNull(sr);
            Assert.IsNull(sr.Data);
            Assert.IsNull(sr.Result);
            Assert.AreEqual(SyncResult.APIKeyStatus.Invalid, sr.KeyStatus);
        }
        [TestMethod]
        public void SyncResultCreateWithData()
        {
            var data = new SyncData();
            var sr = new SyncResult(SyncResult.APIKeyStatus.Valid, data);
            Assert.IsNotNull(sr);
            Assert.IsNotNull(sr.Data);
            Assert.IsNull(sr.Result);
            Assert.AreEqual(SyncResult.APIKeyStatus.Valid, sr.KeyStatus);
        }
        [TestMethod]
        public void SyncResultCreateWithCommand()
        {
            var cmd = new CommandResult();
            var sr = new SyncResult(SyncResult.APIKeyStatus.Valid, cmd);
            Assert.IsNotNull(sr);
            Assert.IsNull(sr.Data);
            Assert.IsNotNull(sr.Result);
            Assert.AreEqual(SyncResult.APIKeyStatus.Valid, sr.KeyStatus);
        }
    }
}