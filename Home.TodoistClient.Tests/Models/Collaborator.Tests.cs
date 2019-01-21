namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.Todoist.Models;
    using System;

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
    public class TemporaryResourceIdMapping_Tests
    {
        [TestMethod]
        public void TemporaryResourceIdMappingCreate()
        {
            var g = Guid.NewGuid();
            var u = Guid.NewGuid();
            var args = new TemporaryResourceIdMapping.Args()
            {
                Name = "Name",
                Content = "Content",
                ProjectId = null
            };

            var tsr = new TemporaryResourceIdMapping()
            {
                Arguments = args,
                Type = "Type",
                TempId = g,
                Uuid = u
            };
            Assert.IsNotNull(tsr);
            Assert.AreEqual(args, tsr.Arguments);
            Assert.AreEqual(nameof(Type), tsr.Type);
            Assert.AreEqual(g, tsr.TempId);
            Assert.AreEqual(u, tsr.Uuid);
        }
    }
}