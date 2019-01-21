namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.Todoist.Models;

    [TestClass]
    public class Note_Tests
    {
        [TestMethod]
        public void NoteCreate()
        {
            uint[] notify = { 1, 2, 3 };
            var n = new Note()
            {
                Id = 12,
                PostedUid = 23,
                ProjectId = 34,
                ItemId = 45,
                Content = "Content",
                FileAttachment = null,
                UidsToNotify = notify,
                IsDeleted = false,
                IsArchived = false,
                Posted = "Posted",
                Reactions = null
            };

            Assert.IsNotNull(n);
            Assert.AreEqual((uint)12, n.Id);
            Assert.AreEqual((uint)23, n.PostedUid);
            Assert.AreEqual((uint)34, n.ProjectId);
            Assert.AreEqual((uint)45, n.ItemId);
            Assert.AreEqual(nameof(n.Content), n.Content);
            Assert.IsNull(n.FileAttachment);
            Assert.AreEqual(notify, n.UidsToNotify);
            Assert.IsFalse(n.IsDeleted);
            Assert.IsFalse(n.IsArchived);
            Assert.AreEqual(nameof(n.Posted), n.Posted);
            Assert.IsNull(n.Reactions);
        }
    }
}