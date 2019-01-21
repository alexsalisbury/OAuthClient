namespace Home.Todoist.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class TemporaryResourceIdMapping
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("temp_id")]
        public Guid TempId { get; set; }

        [JsonProperty("args")]
        public Args Arguments { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }
    }
}