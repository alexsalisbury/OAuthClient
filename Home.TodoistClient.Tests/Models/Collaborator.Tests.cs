﻿namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

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
}