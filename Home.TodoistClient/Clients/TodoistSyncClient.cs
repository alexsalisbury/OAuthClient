namespace Home.TodoistClient.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Home.OAuthClients.Clients;
    using Home.TodoistClient.Models;
    using System;
    using System.Net.Http;

    public class TodoistSyncClient : RestApiClient
    {
        private string endpoint = "https://todoist.com/api/v7/sync";
        private const string urlencodedContentType = "application/x-www-form-urlencoded";
        private string apiToken;
        private string syncToken;

        public TodoistSyncClient(string apitoken)
        {
            this.apiToken = apitoken;
        }

        public void SetHandler(HttpMessageHandler handler)
        {
            Client = new HttpClient(handler);
        }
        
        public void SetApiToken(string apitoken)
        {
            this.apiToken = apitoken;
        }

        /// <summary>
        /// https://developer.todoist.com/sync/v7/?shell#sync
        /// </summary>
        /// <returns></returns>
        public async Task<SyncResult> SyncAsync(bool fullSync = true, bool useCache = false, string resourceTypes = "[\"all\"]")
        {
            string syncToken = fullSync ? "*" : (this.syncToken ?? "*");
            var body = GenerateSyncBody(syncToken, resourceTypes);
            var result = await RestApiClient.PostAsync<SyncData>(new Uri(endpoint), body);
            
            if (result.Success)
            {
                try
                {
                    this.syncToken = result.Result.SyncToken;
                    return new SyncResult(SyncResult.APIKeyStatus.Valid, result.Result);
                }
                catch
                {
                    return new SyncResult(SyncResult.APIKeyStatus.Invalid);
                }
            }

            return new SyncResult(SyncResult.APIKeyStatus.Unknown);
        }

        public async Task<SyncResult> SendCommandAsync(List<SyncCommand> command)
        {
            var body = GenerateCommmandBody(JsonConvert.SerializeObject(command));
            var result = await PostAsync<CommandResult>(new Uri(endpoint), body);

            if (result.Success)
            {
                try
                {
                    this.syncToken = result.Result.SyncToken;
                    return new SyncResult(SyncResult.APIKeyStatus.Valid, result.Result);
                }
                catch
                {
                    return new SyncResult(SyncResult.APIKeyStatus.Invalid);
                }
            }

            return new SyncResult(SyncResult.APIKeyStatus.Unknown);
        }

        private IEnumerable<KeyValuePair<string, string>> GenerateSyncBody(string syncToken, string resourceTypes)
        {
            var result = new List<KeyValuePair<string, string>>();
            result.Add(new KeyValuePair<string, string>("token", this.apiToken));
            result.Add(new KeyValuePair<string, string>("sync_token", syncToken));
            result.Add(new KeyValuePair<string, string>("resource_types", resourceTypes));
            return result;
        }

        private IEnumerable<KeyValuePair<string, string>> GenerateCommmandBody(string command)
        {
            var result = new List<KeyValuePair<string, string>>();
            result.Add(new KeyValuePair<string, string>("token", this.apiToken));
            result.Add(new KeyValuePair<string, string>("commands", command));
            return result;
        }
    }
}