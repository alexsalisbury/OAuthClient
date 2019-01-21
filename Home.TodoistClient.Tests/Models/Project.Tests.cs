namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class Project_Tests
    {
        [TestMethod]
        public void ProjectCreate()
        {
            var p = new Project()
            {
                Id = 12,
                Name = "Name",
                Color = 4,
                Indent = Project.IndentLevel.Level1,
                ItemOrder = 1,
                Collapsed = false,
                Shared = false,
                IsDeleted = false,
                IsArchived = false,
                IsFavorite = true,
                InboxProject = false,
                TeamInbox = false,
            };

            Assert.IsNotNull(p);
            Assert.AreEqual((uint)12, p.Id);
            Assert.AreEqual(nameof(p.Name), p.Name);
            Assert.AreEqual((uint)4, p.Color);
            Assert.AreEqual(Project.IndentLevel.Level1, p.Indent);
            Assert.AreEqual((uint)1, p.ItemOrder);
            Assert.IsFalse(p.Collapsed);
            Assert.IsFalse(p.Shared);
            Assert.IsFalse(p.IsDeleted);
            Assert.IsFalse(p.IsArchived);
            Assert.IsTrue(p.IsFavorite);
            Assert.IsFalse(p.InboxProject);
            Assert.IsFalse(p.TeamInbox);
        }
    }
}