namespace Home.TodoistClient.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.Todoist.Models;

    [TestClass]
    public class Item_Tests
    {
        [TestMethod]
        public void ItemCreate()
        {
            var date = DateTimeOffset.Now;
            uint[] labels = { 1, 2, 3 };

            var i = new Item()
            {
                Id = 12,
                UserId = 23,
                ProjectId = 34,
                Content = "Content",
                DateString = "Today",
                DateLang = "en",
                DueDateUtcString = date.ToString(),
                IndentLevel = Item.Indent.Level1,
                PriorityValue = Item.Priority.P1,
                DayOrder = 1,
                Collapsed = false,
                Children = new List<Item>(),
                Parent = null,
                Labels = labels,
                AssignedByUid = 1,
                ResponsibleUid = 1,
                Checked = false,
                InHistory = false,
                IsDeleted = false,
                IsArchived = false,
                SyncId = null,
                DateAdded = date.ToString()
            };

            Assert.IsNotNull(i);
            Assert.AreEqual((uint)12, i.Id);
            Assert.AreEqual((uint)23, i.UserId);
            Assert.AreEqual((uint)34, i.ProjectId);
            Assert.AreEqual(nameof(i.Content), i.Content);
            Assert.AreEqual("Today", i.DateString);
            Assert.AreEqual("en", i.DateLang);
            Assert.AreEqual(date.ToString(), i.DueDateUtcString);
            Assert.AreEqual(Item.Indent.Level1, i.IndentLevel);
            Assert.AreEqual(Item.Priority.P1, i.PriorityValue);
            Assert.AreEqual(1, i.DayOrder);
            Assert.IsFalse(i.Collapsed);
            Assert.IsNotNull(i.Children);
            Assert.AreEqual(0, i.Children.Count);
            Assert.IsNull(i.Parent);
            Assert.AreEqual(labels, i.Labels);
            Assert.AreEqual((uint)1, i.AssignedByUid);
            Assert.AreEqual((uint)1, i.ResponsibleUid);
            Assert.IsFalse(i.Checked);
            Assert.IsFalse(i.InHistory);
            Assert.IsFalse(i.IsDeleted);
            Assert.IsFalse(i.IsArchived);
            Assert.IsNull(i.SyncId);
            Assert.AreEqual(date.ToString(), i.DateAdded);
        }
    }
}