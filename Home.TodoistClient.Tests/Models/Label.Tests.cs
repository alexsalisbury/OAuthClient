namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class Label_Tests
    {
        [TestMethod]
        public void LabelCreate()
        {
            var f = new Label()
            {
                Id = 42,
                Name = "Name",
                Color = 12,
                ItemOrder = 0,
                IsDeleted = false,
                IsFavorite = true
            };
            Assert.IsNotNull(f);
            Assert.AreEqual((uint)42, f.Id);
            Assert.AreEqual(nameof(f.Name), f.Name);
            Assert.AreEqual((uint)0, f.ItemOrder);
            Assert.AreEqual((uint)12, f.Color);
            Assert.IsFalse(f.IsDeleted);
            Assert.IsTrue(f.IsFavorite);
        }
    }
}