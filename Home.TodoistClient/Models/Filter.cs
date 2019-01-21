namespace Home.Todoist.Models
{
    using Newtonsoft.Json;
    using Home.Todoist.Converters;

    public partial class Filter
    {
        /// <summary>
        /// The id of the filter.
        /// </summary>
        [JsonProperty("id")]
        public uint Id { get; set; }

        /// <summary>
        /// The name of the filter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The query to search for. Examples of searches can be found in the Todoist help page.
        /// <seealso cref="https://todoist.com/Help/Filtering"/>
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// The color of the filter (between 0 and 7, or between 0 and 12 for premium users). 
        /// The color codes corresponding to these numbers are: #019412, #a39d01, #e73d02, #e702a4, #9902e7, #1d02e7, #0082c5, #555555. 
        /// And for the additional colors of the premium users: #008299, #03b3b2, #ac193d, #82ba00, #111111.
        /// </summary>
        [JsonProperty("color")]
        public uint Color { get; set; }

        /// <summary>
        /// Filter’s order in the filter list (where the smallest value should place the filter at the top).
        /// </summary>
        [JsonProperty("item_order")]
        public uint ItemOrder { get; set; }

        /// <summary>
        /// Whether the filter is marked as deleted (where 1 is true and 0 is false), converted to bool on client..
        /// </summary>
        [JsonProperty("is_deleted")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the filter is favorite (where 1 is true and 0 is false), converted to bool on client..
        /// </summary>
        [JsonProperty("is_favorite")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsFavorite { get; set; }
    }
}