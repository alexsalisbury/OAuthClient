﻿namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.Todoist.Models;

    [TestClass]
    public class CollaboratorState_Tests
    {
        [TestMethod]
        public void CollaboratorStateCreate()
        {
            var c = new CollaboratorState();
            Assert.IsNotNull(c);
        }
    }
}