namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class Filter_Tests
    {
        [TestMethod]
        public void FilterCreate()
        {
            var f = new Filter()
            {
                Id = 42,
                Name = "Name",
                Query = "Query",
                Color = 12,
                IsDeleted = false,
                IsFavorite = true
            };
            Assert.IsNotNull(f);
            Assert.AreEqual((uint)42, f.Id);
            Assert.AreEqual(nameof(f.Name), f.Name);
            Assert.AreEqual(nameof(f.Query), f.Query);
            Assert.AreEqual((uint)12, f.Color);
            Assert.IsFalse(f.IsDeleted);
            Assert.IsTrue(f.IsFavorite);
        }
    }
}