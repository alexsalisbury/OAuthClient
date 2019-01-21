namespace Home.TodoistClient.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Models;

    [TestClass]
    public class UserSettings_Tests
    {
        [TestMethod]
        public void UserSettingsCreate()
        {
            var us = new UserSettings();
            var usPop = new UserSettings()
            {
                ReminderPush = true,
                ReminderSms = true,
                ReminderDesktop = true,
                ReminderEmail = true,
            };

            Assert.IsNotNull(us);
            Assert.IsFalse(us.ReminderPush);
            Assert.IsFalse(us.ReminderSms);
            Assert.IsFalse(us.ReminderDesktop);
            Assert.IsFalse(us.ReminderEmail);

            Assert.IsNotNull(usPop);
            Assert.IsTrue(usPop.ReminderPush);
            Assert.IsTrue(usPop.ReminderSms);
            Assert.IsTrue(usPop.ReminderDesktop);
            Assert.IsTrue(usPop.ReminderEmail);
        }
    }
}