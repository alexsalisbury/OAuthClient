namespace Home.Todoist.Models
{
    using Newtonsoft.Json;
    using System;

    public class SyncCommand
    {
        [JsonProperty("type")]
        internal string Type { get; set; }

        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("args")]
        internal Args Args { get; set; }

        public SyncCommand(string command, Args args)
        {
            this.Type = command;
            this.UUID = Guid.NewGuid().ToString();
            this.Args = args;
        }

        public SyncCommand(string command, uint id)
        {
            var ids = new uint[] { id };
            this.Type = command;
            this.UUID = Guid.NewGuid().ToString();
            this.Args = new Args(ids);
        }
    }
}