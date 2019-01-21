namespace Home.TodoistClient.Models
{
    using Newtonsoft.Json;

    public partial class Args
    {
        public Args(){}

        public Args(uint[] args)
        {
            this.Ids = args;
        }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("project_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectId { get; set; }

        [JsonProperty("ids")]
        public uint[] Ids { get; set; }
    }
}