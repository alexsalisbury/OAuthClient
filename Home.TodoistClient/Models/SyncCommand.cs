namespace Home.TodoistClient.Models
{
    using System;
    using Newtonsoft.Json;

    public class SyncCommand
    {
        public struct ArgsObject
        {
            public ArgsObject(uint[] args)
            {
                this.Ids = args;
            }

            [JsonProperty("ids")]
            public uint[] Ids { get; set; }
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("args")]
        public ArgsObject Args { get; set; }

        public SyncCommand(string command, uint[] ids)
        {
            this.Type = command;
            this.UUID = Guid.NewGuid().ToString();
            this.Args = new ArgsObject(ids);
        }

        public SyncCommand(string command, uint id)
        {
            var ids = new uint[] { id };
            this.Type = command;
            this.UUID = Guid.NewGuid().ToString();
            this.Args = new ArgsObject(ids);
        }
    }
}