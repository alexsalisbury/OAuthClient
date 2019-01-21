namespace Home.TodoistClient.Tests.Clients
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Clients;
    using Home.TodoistClient.Tests;
    using Home.TodoistClient.Models;
    using System.Collections.Generic;

    [TestClass]
    public class TodoistSyncClient_Tests
    {
        [TestMethod]
        public async Task FullSync()
        {
            var thmh = new TestHttpMessageHandler();
            thmh.SetExpectedResponse(new HttpResponseMessage()
            {
                Content = new StringContent("{\"full_sync\": true}"),
                StatusCode = System.Net.HttpStatusCode.OK
            });

            TodoistSyncClient tsc = new TodoistSyncClient("Token");
            tsc.SetHandler(thmh);

            var syncResult = await tsc.SyncAsync();
            Assert.IsNotNull(syncResult);
            Assert.IsNull(syncResult.Result);

            Assert.IsNotNull(syncResult.Data);
            Assert.AreEqual(SyncResult.APIKeyStatus.Valid, syncResult.KeyStatus);

            var data = syncResult.Data;
            Assert.IsTrue(data.FullSync);
        }

        [TestMethod]
        public async Task SendCommand()
        {
            var thmh = new TestHttpMessageHandler();
            thmh.SetExpectedResponse(new HttpResponseMessage()
            {
                Content = new StringContent("{\"full_sync\": true}"),
                StatusCode = System.Net.HttpStatusCode.OK
            });

            TodoistSyncClient tsc = new TodoistSyncClient("Token");
            tsc.SetHandler(thmh);

            var commands = new List<SyncCommand>();
            commands.Add(new SyncCommand("Test", 0));

            var syncResult = await tsc.SendCommandAsync(commands);
            Assert.IsNotNull(syncResult);
            Assert.IsNotNull(syncResult.Result);

            Assert.AreEqual(SyncResult.APIKeyStatus.Valid, syncResult.KeyStatus);

            var commandResult = syncResult.Result;
            Assert.IsTrue(commandResult.FullSync);
        }
    }
}