namespace Home.TodoistClient.Tests.Models
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.Todoist.Models;

    [TestClass]
    public class FileAttachment_Tests
    {
        [TestMethod]
        public void FileAttachmentCreate()
        {
            Uri testUri = new Uri("http://127.0.0.1");

            var fa = new FileAttachment()
            {
                FileType = "FileType",
                FileName = "FileName",
                FileSize = 0,
                FileUrl = testUri,
                UploadState = "UploadState"
            };
            Assert.IsNotNull(fa);
            Assert.AreEqual(nameof(fa.FileType), fa.FileType);
            Assert.AreEqual(nameof(fa.FileName), fa.FileName);
            Assert.AreEqual((uint)0, fa.FileSize);
            Assert.AreEqual(testUri, fa.FileUrl);
            Assert.AreEqual(nameof(fa.UploadState), fa.UploadState);
        }
    }
}