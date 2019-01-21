namespace Home.TodoistClient.Tests.Models
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

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
}