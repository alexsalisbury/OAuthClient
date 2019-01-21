namespace Home.Todoist.Models
{
    using Newtonsoft.Json;
    using Home.Todoist.Converters;

    public partial class Reminder
    {
        /// <summary>
        /// The id of the reminder.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The user id which should be notified of the reminder, typically the current user id creating the reminder.
        /// </summary>
        [JsonProperty("notify_uid")]
        public long NotifyUid { get; set; }

        /// <summary>
        /// The item id for which the reminder is about.
        /// </summary>
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// The way to get notified of the reminder: email for e-mail, mobile for mobile text message, or push for mobile push notification.
        /// </summary>
        [JsonProperty("service")]
        public string Service { get; set; }

        /// <summary>
        /// 	The type of the reminder: relative for a time-based reminder specified in minutes from now, absolute for a time-based reminder with a specific time and date in the future, and location for a location-based reminder.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The date of the reminder, added in free form text, for example it can be every day @ 10 (or null or an empty string if not set). Look at our reference to see which formats are supported.
        /// </summary>
        [JsonProperty("date_string")]
        public string DateString { get; set; }

        /// <summary>
        /// The language of the date_string (valid languages are: en, da, pl, zh, ko, de, pt, ja, it, fr, sv, ru, es, nl).
        /// </summary>
        [JsonProperty("date_lang")]
        public string DateLang { get; set; }

        /// <summary>
        /// The date of the reminder in a format like Mon 07 Aug 2006 12:34:56 +0100 (or null if not set).
        /// </summary>
        [JsonProperty("due_date_utc")]
        public string DueDateUtc { get; set; }

        /// <summary>
        /// The relative time in minutes before the due date of the item, in which the reminder should be triggered. Note, that the item should have a due date set in order to add a relative reminder.
        /// </summary>
        [JsonProperty("mm_offset")]
        public long MmOffset { get; set; }

        /// <summary>
        /// An alias name for the location.
        /// </summary>
        [JsonProperty("name")]
        public string LocationName { get; set; }

        /// <summary>
        /// The location latitude.
        /// </summary>
        [JsonProperty("loc_lat")]
        public string LocationLatitude { get; set; }

        /// <summary>
        /// The location longitude.
        /// </summary>
        [JsonProperty("loc_long")]
        public string LocationLongitude { get; set; }

        /// <summary>
        /// What should trigger the reminder: on_enter for entering the location, or on_leave for leaving the location.
        /// </summary>
        [JsonProperty("loc_trigger")]
        public string LocationTrigger { get; set; }

        /// <summary>
        /// The radius around the location that is still considered as part of the location (in meters).
        /// </summary>
        [JsonProperty("radius")]
        public uint Radius { get; set; }

        /// <summary>
        /// Whether the label is marked as deleted (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_deleted")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDeleted { get; set; }
    }
}
