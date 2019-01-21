namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;
    using System;

    [TestClass]
    public class Reminder_Tests
    {
        [TestMethod]
        public void ReminderCreate()
        {
            var date = DateTime.UtcNow;
            var r = new Reminder()
            {
                Id = 12,
                NotifyUid = 23,
                ItemId = 34,
                Service = "Service",
                Type = "Type",
                DateString = "Today",
                DateLang = "en",
                DueDateUtc = date.ToString(),
                MmOffset = 15,
                LocationName = "LocationName",
                LocationLatitude = "LocationLatitude",
                LocationLongitude = "LocationLongitude",
                LocationTrigger = "LocationTrigger",
                Radius = 100,
                IsDeleted = false
            };
            Assert.IsNotNull(r);
            Assert.AreEqual((uint)12, r.Id);
            Assert.AreEqual((uint)23, r.NotifyUid);
            Assert.AreEqual((uint)34, r.ItemId);
            Assert.AreEqual(nameof(r.Service), r.Service);
            Assert.AreEqual(nameof(r.Type), r.Type);
            Assert.AreEqual("Today", r.DateString);
            Assert.AreEqual("en", r.DateLang);
            Assert.AreEqual(date.ToString(), r.DueDateUtc);
            Assert.AreEqual((long)15, r.MmOffset);
            Assert.AreEqual(nameof(r.LocationName), r.LocationName);
            Assert.AreEqual(nameof(r.LocationLatitude), r.LocationLatitude);
            Assert.AreEqual(nameof(r.LocationLongitude), r.LocationLongitude);
            Assert.AreEqual(nameof(r.LocationTrigger), r.LocationTrigger);
            Assert.AreEqual((uint)100, r.Radius);
            Assert.IsFalse(r.IsDeleted);
        }
    }
}