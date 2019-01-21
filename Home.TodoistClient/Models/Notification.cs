namespace Home.Todoist.Models
{
    using System.Collections.Generic;
    using System.Dynamic;
    using Newtonsoft.Json;
    using Home.Todoist.Converters;

    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject?view=netframework-4.7.2
    /// </summary>
    public partial class Notification : DynamicObject
    {
        private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

        /// <summary>
        /// The id of the live notification.
        /// </summary>
        [JsonProperty("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Live notification creation date. A number representing a timestamp since epoch.
        /// </summary>
        [JsonProperty("created")]
        public uint Created { get; set; }

        /// <summary>
        /// The id of the user who initiated this live notification.
        /// </summary>
        [JsonProperty("from_uid")]
        public uint FromUid { get; set; }

        /// <summary>
        /// Unique notification key.
        /// </summary>
        [JsonProperty("notification_key")]
        public string NotificationKey { get; set; }

        /// <summary>
        /// Type of notification. Different notification type define different extra fields which are described below.
        /// </summary>
        [JsonProperty("notification_type")]
        public string NotificationType { get; set; }

        /// <summary>
        /// Notification sequence number.
        /// </summary>
        [JsonProperty("seq_no")]
        public ulong SeqNo { get; set; }

        /// <summary>
        /// Whether the notification is marked as unread (1) or read (0), converted to bool on client.
        /// </summary>
        [JsonProperty("is_unread")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsUnread { get; set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();
            return dictionary.TryGetValue(name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name.ToLower()] = value;
            return true;
        }
    }
}