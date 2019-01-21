namespace Home.Todoist.Models
{
    using System;
    using Newtonsoft.Json;

    internal class SyncCommand
    {
        internal struct ArgsObject
        {
            public ArgsObject(uint[] args)
            {
                this.Ids = args;
            }

            [JsonProperty("ids")]
            uint[] Ids { get; set; }
        }

        [JsonProperty("type")]
        internal string Type { get; set; }

        [JsonProperty("uuid")]
        internal string UUID { get; set; }

        [JsonProperty("args")]
        internal ArgsObject Args { get; set; }

        internal SyncCommand(string command, uint[] ids)
        {
            this.Type = command;
            this.UUID = Guid.NewGuid().ToString();
            this.Args = new ArgsObject(ids);
        }

        internal SyncCommand(string command, uint id)
        {
            var ids = new uint[] { id };
            this.Type = command;
            this.UUID = Guid.NewGuid().ToString();
            this.Args = new ArgsObject(ids);
        }
    }
}