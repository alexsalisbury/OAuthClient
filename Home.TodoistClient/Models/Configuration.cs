namespace Home.Todoist.Models
{
    public class Configuration
    {
        public bool Initialized = false;
        public string ApiToken { get; internal set; }
        public string SyncToken { get; internal set; }
        public string LastFullSyncResult { get; internal set; }

        public void Initialize(string apiToken, string syncToken = "*")
        {
            this.ApiToken = apiToken;
            this.SyncToken = syncToken;
            this.LastFullSyncResult = null;

            this.Initialized = !string.IsNullOrWhiteSpace(this.ApiToken);
        }
    }
}