namespace Home.Todoist.Models
{
    using Newtonsoft.Json;
    using Home.Todoist.Converters;

    public partial class Label
    {
        /// <summary>
        /// The id of the label.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of the label.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The color of the label (a number between 0 and 7, or between 0 and 12 for premium users). 
        /// The color codes corresponding to these numbers are: #019412, #a39d01, #e73d02, #e702a4, #9902e7, #1d02e7, #0082c5, #555555. 
        /// And for the additional colors of the premium users: #008299, #03b3b2, #ac193d, #82ba00, #111111.
        /// </summary>
        [JsonProperty("color")]
        public long Color { get; set; }

        /// <summary>
        /// Label’s order in the label list (a number, where the smallest value should place the label at the top).
        /// </summary>
        [JsonProperty("item_order")]
        public long ItemOrder { get; set; }

        /// <summary>
        /// Whether the label is marked as deleted (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_deleted")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the label is favorite (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_favorite")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsFavorite { get; set; }
    }
}