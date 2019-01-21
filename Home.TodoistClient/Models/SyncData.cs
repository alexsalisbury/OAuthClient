namespace Home.Todoist.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SyncData
    {
        /// <summary>
        /// Whether the response contains all data (a full synchronization) or just a part of them since the last sync.
        /// </summary>
        [JsonProperty("full_sync")]
        public bool FullSync { get; set; }

        [JsonProperty("temp_id_mapping")]
        public Dictionary<string, string> Mappings { get; set; }

        /// <summary>
        /// An array of label objects.
        /// </summary>
        [JsonProperty("labels")]
        public IReadOnlyCollection<Label> Labels { get; set; }

        [JsonProperty("locations")]
        public IReadOnlyCollection<Location> Locations { get; set; }

        [JsonProperty("project_notes")]
        public IReadOnlyCollection<Note> ProjectNotes { get; set; }

        /// <summary>
        /// A user object.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// 	A array of filter objects.
        /// </summary>
        [JsonProperty("filters")]
        public IReadOnlyCollection<Filter> Filters { get; set; }

        /// <summary>
        /// 	A new synchronization token. Used by the client in the next sync request to perform an incremental sync.
        /// </summary>
        [JsonProperty("sync_token")]
        public string SyncToken { get; set; }

        /// <summary>
        /// A JSON object specifying the order of items in daily agenda.
        /// </summary>
        [JsonProperty("day_orders")]
        public KeyValuePair<string, string> DayOrders { get; set; }

        /// <summary>
        /// 	An array of project objects.
        /// </summary>
        [JsonProperty("projects")]
        public IReadOnlyCollection<Project> Projects { get; set; }

        /// <summary>
        /// A JSON object containing all collaborators for all shared projects. The projects field contains the list of all shared projects, where the user acts as one of collaborators.
        /// </summary>
        [JsonProperty("collaborators")]
        public IReadOnlyCollection<Collaborator> Collaborators { get; set; }

        /// <summary>
        /// Undocumented magic number. 
        /// </summary>
        [JsonProperty("day_orders_timestamp")]
        public decimal DayOrdersTimestamp { get; set; }

        /// <summary>
        /// What is the last live notification the user has seen? This is used to implement unread notifications.
        /// </summary>
        [JsonProperty("live_notifications_last_read_id")]
        public long? LastReadNotificationId { get; set; }

        /// <summary>
        /// 	A array of item objects.
        /// </summary>
        [JsonProperty("items")]
        public IReadOnlyCollection<Item> Items { get; set; }

        [JsonProperty("notes")]
        public IReadOnlyCollection<Note> Notes { get; set; }

        /// <summary>
        /// 	An array of live_notification objects
        /// </summary>
        [JsonProperty("live_notifications")]
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        /// <summary>
        /// An array of reminder objects.
        /// </summary>
        [JsonProperty("reminders")]
        public IReadOnlyCollection<Reminder> Reminders { get; set; }

        /// <summary>
        /// 	An array specifying the state of each collaborator in each project. The state can be invited, active, inactive, deleted.
        /// </summary>
        [JsonProperty("collaborator_states")]
        public IReadOnlyCollection<CollaboratorState> CollaboratorStates { get; set; }

        /// <summary>
        /// 	An array specifying the state of each collaborator in each project. The state can be invited, active, inactive, deleted.
        /// </summary>
        [JsonProperty("user_settings")]
        public UserSettings UserSettings { get; set; }
    }
}