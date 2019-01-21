namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class SyncCommand_Tests
    {
        [TestMethod]
        public void SyncCommandCreate()
        {
            var sc = new SyncCommand("Type", 4);
            Assert.IsNotNull(sc);
            Assert.AreEqual(nameof(sc.Type), sc.Type);
            Assert.IsNotNull(sc.UUID);
            Assert.IsNotNull(sc.Args);
            Assert.AreEqual((uint)4, sc.Args.Ids[0]);
            Assert.AreEqual(1, sc.Args.Ids.Length);
        }

        [TestMethod]
        public void SyncCommandCreateArray()
        {
            uint[] ids = { 1, 2, 3 };
            var sc = new SyncCommand("Type", ids);
            Assert.IsNotNull(sc);
            Assert.AreEqual(nameof(sc.Type), sc.Type);
            Assert.IsNotNull(sc.UUID);
            Assert.IsNotNull(sc.Args);
            Assert.AreEqual(ids, sc.Args.Ids);
        }
    }
}