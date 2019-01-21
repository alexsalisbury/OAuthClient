namespace Home.TodoistClient.Models
{
    using Newtonsoft.Json;
    using Home.TodoistClient.Converters;

    public partial class Project
    {
        public enum IndentLevel
        {
            Level1 = 1,
            Level2 = 2,
            Level3 = 3,
            Level4 = 4
        }

        /// <summary>
        /// The id of the project.
        /// </summary>
        [JsonProperty("id")]
        public uint Id { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The color of the project (a number between 0 and 11, or between 0 and 21 for premium users). 
        /// The color codes corresponding to these numbers are: #95ef63, #ff8581, #ffc471, #f9ec75, #a8c8e4, #d2b8a3, #e2a8e4, #cccccc, #fb886e, #ffcc00, #74e8d3, #3bd5fb. 
        /// And for the additional colors of the premium users: #dc4fad, #ac193d, #d24726, #82ba00, #03b3b2, #008299, #5db2ff, #0072c6, #000000, #777777.
        /// </summary>
        [JsonProperty("color")]
        public uint Color { get; set; }

        /// <summary>
        /// The indent of the item (a number between 1 and 4, where 1 is top-level).
        /// </summary>
        [JsonProperty("indent")]
        public IndentLevel Indent { get; set; }

        /// <summary>
        /// 	Project’s order in the project list (a number, where the smallest value should place the project at the top).
        /// </summary>
        [JsonProperty("item_order")]
        public uint ItemOrder { get; set; }

        /// <summary>
        /// Whether the project’s sub-projects are collapsed (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("collapsed")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Collapsed { get; set; }

        /// <summary>
        /// Whether the project is shared (a true or false value).
        /// </summary>
        [JsonProperty("shared")]
        public bool Shared { get; set; }

        /// <summary>
        /// Whether the project is marked as deleted (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_deleted")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the project is marked as archived (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_archived")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsArchived { get; set; }

        /// <summary>
        /// Whether the project is favorite (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_favorite")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsFavorite { get; set; }

        /// <summary>
        /// Whether the project is Inbox (true or otherwise this property is not sent).
        /// </summary>
        [JsonProperty("inbox_project")]
        public bool InboxProject { get; set; } = false;

        /// <summary>
        /// Whether the project is TeamInbox (true or otherwise this property is not sent).
        /// </summary>
        [JsonProperty("team_inbox")]
        public bool TeamInbox { get; set; } = false;
    }
}