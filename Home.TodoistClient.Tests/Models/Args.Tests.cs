namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class Args_Tests
    {
        [TestMethod]
        public void ArgsCreate()
        {
            uint[] ids = { 1, 2, 3 };

            var a = new Args(ids);
            Assert.IsNotNull(a);
            Assert.AreEqual(ids, a.Ids);
        }
    }
}