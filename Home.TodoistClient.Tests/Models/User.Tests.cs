namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;
    using System;

    [TestClass]
    public class User_Tests
    {
        [TestMethod]
        public void UserCreate()
        {
            Uri testUri = new Uri("http://127.0.0.1");
            var date = DateTime.UtcNow;

            var tzinfo = new TzInfo()
            {
                GmtString = "GmtString",
                Hours = 0,
                IsDst = true,
                Minutes =0,
                Timezone = "Timezone"
            };

            var features = new Features()
            {
                Beta = 0,
                Restriction = 0,
                HasPushReminders = false,
            };

            var u = new User()
            {
                Id = 12,
                Token = "Token",
                Email = "Email",
                FullName = "FullName",
                InboxProject = 1,
                TzInfo = tzinfo,
                StartPage = "StartPage",
                StartDay = User.DoistDayOfWeek.Friday,
                NextWeek = User.DoistDayOfWeek.Monday,
                DateFormat = 0,
                TimeFormat = 0,
                SortOrder = 0,
                DefaultReminder = null,
                AutoReminder = 0,
                MobileHost = null,
                MobileNumber = null,
                CompletedCount = 1,
                CompletedToday = 1,
                Karma = 1000,
                KarmaTrend = "up",
                IsPremium = true,
                PremiumUntil = date,
                IsBizAdmin = false,
                BusinessAccountId = null,
                ImageId = "ImageId",
                AvatarSmall = testUri,
                AvatarMedium = testUri,
                AvatarBig = testUri,
                AvatarS640 = testUri,
                Theme = 0,
                Features = features,
                JoinDate = date.ToString()
            };

            Assert.IsNotNull(u);
            Assert.AreEqual((uint)12, u.Id);
            Assert.AreEqual(nameof(u.Token), u.Token);
            Assert.AreEqual(nameof(u.Email), u.Email);
            Assert.AreEqual(nameof(u.FullName), u.FullName);
            Assert.AreEqual((uint)1, u.InboxProject);
            Assert.AreEqual(tzinfo, u.TzInfo);
            Assert.AreEqual(nameof(u.StartPage), u.StartPage);
            Assert.AreEqual(User.DoistDayOfWeek.Friday, u.StartDay);
            Assert.AreEqual(User.DoistDayOfWeek.Monday, u.NextWeek);
            Assert.AreEqual((uint)0, u.DateFormat);
            Assert.AreEqual((uint)0, u.TimeFormat);
            Assert.AreEqual((uint)0, u.SortOrder);
            Assert.IsNull(u.DefaultReminder);
            Assert.AreEqual((uint)0, u.AutoReminder);
            Assert.IsNull(u.MobileHost);
            Assert.IsNull(u.MobileNumber);
            Assert.AreEqual((uint)1, u.CompletedCount);
            Assert.AreEqual((uint)1, u.CompletedToday);
            Assert.AreEqual((uint)1000, u.Karma);
            Assert.AreEqual("up", u.KarmaTrend);
            Assert.IsTrue(u.IsPremium);
            Assert.AreEqual(date, u.PremiumUntil);
            Assert.IsFalse(u.IsBizAdmin);
            Assert.IsNull(u.BusinessAccountId);
            Assert.AreEqual(nameof(u.ImageId), u.ImageId);
            Assert.AreEqual(testUri, u.AvatarSmall);
            Assert.AreEqual(testUri, u.AvatarMedium);
            Assert.AreEqual(testUri, u.AvatarBig);
            Assert.AreEqual(testUri, u.AvatarS640);
            Assert.AreEqual((uint)0, u.Theme);
            Assert.AreEqual(date.ToString(), u.JoinDate);
            Assert.AreEqual(features, u.Features);
        }
    }
}