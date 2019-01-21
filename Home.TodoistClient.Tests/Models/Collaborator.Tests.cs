namespace Home.TodoistClient.Tests.Models
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.Todoist.Models;

    [TestClass]
    public class Collaborator_Tests
    {
        [TestMethod]
        public void CollaboratorCreate()
        {
            var c = new Collaborator();
            Assert.IsNotNull(c);
        }
    }

    [TestClass]
    public class CommandResult_Tests
    {
        [TestMethod]
        public void CommandResultCreate()
        {
            var cr = new CommandResult()
            {
                SyncStatus = new Dictionary<string, SyncDetails>(),
                FullSync = true,
                SyncToken = "SyncToken",
                TempIdMapping = null
            };
            Assert.IsNotNull(cr);
            Assert.IsTrue(cr.FullSync);
            Assert.IsNull(cr.TempIdMapping);
            Assert.IsNotNull(cr.SyncStatus);
            Assert.AreEqual(nameof(cr.SyncToken), cr.SyncToken);

        }
    }

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