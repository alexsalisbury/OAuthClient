namespace Home.TodoistClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using TechTalk.SpecFlow;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Home.TodoistClient.Clients;
    using Home.TodoistClient.Models;

    [Binding]
    public class TodoistClientSteps
    {
        private TestHttpMessageHandler thmh;
        private TodoistSyncClient tsc;
        private SyncResult syncResult;

        [Given(@"I have a Mocked TodoistClient")]
        public void GivenIHaveAMockedTodoistClient()
        {
            thmh = new TestHttpMessageHandler();

            tsc = new TodoistSyncClient("Token");
            tsc.SetHandler(thmh);
        }

        [Given(@"My Client can respond to a basic Sync")]
        public void GivenMyClientCanRespondToABasicSync()
        {
            thmh.SetExpectedResponse(new HttpResponseMessage()
            {
                Content = new StringContent("{\"full_sync\": true}"),
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }

        [Given(@"My Client can respond to a basic Command")]
        public void GivenMyClientCanRespondToABasicCommand()
        {
            thmh.SetExpectedResponse(new HttpResponseMessage()
            {
                Content = new StringContent("{\"full_sync\": true}"),
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }

        [When(@"I execute a full sync")]
        public async void WhenIExecuteAFullSync()
        {
            syncResult = await tsc.SyncAsync();
        }

        [When(@"I execute a command")]
        public async void WhenIExecuteACommand()
        {
            var commands = new List<SyncCommand>();
            commands.Add(new SyncCommand("Test", 0));

            syncResult = await tsc.SendCommandAsync(commands);
        }

        [Then(@"I recieve a valid full sync response")]
        public void ThenIRecieveAValidSyncResponse()
        {
            Assert.IsNotNull(syncResult);
            Assert.IsNull(syncResult.Result);

            Assert.IsNotNull(syncResult.Data);
            Assert.AreEqual(SyncResult.APIKeyStatus.Valid, syncResult.KeyStatus);
        }

        [Then(@"My sync response contains data")]
        public void ThenMySyncResponseContainsData()
        {
            var syncData = syncResult.Data;
            Assert.IsTrue(syncData.FullSync);
        }

        [Then(@"I recieve a valid command response")]
        public void ThenIRecieveAValidCommandResponse()
        {
            Assert.IsNotNull(syncResult);
            Assert.IsNull(syncResult.Data);
            Assert.IsNotNull(syncResult.Result);

            Assert.AreEqual(SyncResult.APIKeyStatus.Valid, syncResult.KeyStatus);
        }
        
        [Then(@"My command response is populated")]
        public void ThenMyCommandResponseIsPopulated()
        { 
            var commandResult = syncResult.Result;
            Assert.IsTrue(commandResult.FullSync);
        }
    }
}