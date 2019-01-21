namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class Location_Tests
    {
        [TestMethod]
        public void LocationCreate()
        {
            var l = new Location();
            Assert.IsNotNull(l);
        }
    }
}