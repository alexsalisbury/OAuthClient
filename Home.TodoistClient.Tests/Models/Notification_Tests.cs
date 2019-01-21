namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.Todoist.Models;

    [TestClass]
    public class Notification_Tests
    {
        [TestMethod]
        public void NotificationCreate()
        {
            dynamic n = new Notification()
            {
                Id = 12,
                Created = 23,
                FromUid = 34,
                NotificationKey = "NotificationKey",
                NotificationType = "NotificationType",
                SeqNo = 45,
                IsUnread = true
            };

            n.Custom = "test";

            Assert.IsNotNull(n);
            Assert.AreEqual((uint)12, n.Id);
            Assert.AreEqual((uint)23, n.Created);
            Assert.AreEqual((uint)34, n.FromUid);
            Assert.AreEqual(nameof(n.NotificationKey), n.NotificationKey);
            Assert.AreEqual(nameof(n.NotificationType), n.NotificationType);
            Assert.AreEqual((ulong)45, n.SeqNo);
            Assert.AreEqual("test", n.Custom);
            Assert.IsTrue(n.IsUnread);
        }
    }
}