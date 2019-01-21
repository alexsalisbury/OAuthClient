namespace Home.TodoistClient.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class TemporaryResourceIdMapping
    {
        public partial class Args
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
            public string Content { get; set; }

            [JsonProperty("project_id", NullValueHandling = NullValueHandling.Ignore)]
            public Guid? ProjectId { get; set; }
        }

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