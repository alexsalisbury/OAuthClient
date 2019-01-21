namespace Home.TodoistClient.Models
{
    using System.Net;
    using Newtonsoft.Json;
    using Home.OAuthClients.Models;

    public class TodoistSyncResult : HTTPResult
    {
        public SyncData Data { get; private set; }

        public TodoistSyncResult(HttpStatusCode responsecode, string result, bool success) : base(responsecode, result, success)
        {
            if (success)
            {
                Data = JsonConvert.DeserializeObject<SyncData>(result);
            }
        }
    }
}