namespace Home.Todoist.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class CommandResult
    {
        [JsonProperty("sync_status")]
        public Dictionary<string, SyncDetails> SyncStatus { get; set; }

        [JsonProperty("temp_id_mapping")]
        public TemporaryResourceIdMapping TempIdMapping { get; set; }

        [JsonProperty("full_sync")]
        public bool FullSync { get; set; }

        [JsonProperty("sync_token")]
        public string SyncToken { get; set; }
    }

    public partial class SyncDetails
    {
        [JsonProperty("error_tag")]
        public string ErrorTag { get; set; }

        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }

        [JsonProperty("http_code")]
        public long HttpCode { get; set; }

        [JsonProperty("error_extra")]
        public ErrorExtra ErrorExtra { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }

    public partial class ErrorExtra
    {
        public string Unknown { get; set; }
    }
}