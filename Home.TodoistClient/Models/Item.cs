namespace Home.TodoistClient.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Home.TodoistClient.Converters;

    public partial class Item
    {
        public enum Indent
        {
            Level1 = 1,
            Level2 = 2,
            Level3 = 3,
            Level4 = 4,
            Level5 = 5
        }
        public enum Priority
        {
            P1 = 1,
            P2 = 2,
            P3 = 3,
            P4 = 4
        };

        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("user_id")]
        public uint UserId { get; set; }

        /// <summary>
        /// The id of the project to add the task to (a number or a temp id). By default the task is added to the user’s Inbox project.
        /// </summary>
        [JsonProperty("project_id")]
        public uint ProjectId { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// The date of the task, added in free form text, for example it can be every day @ 10 (or null or an empty string if not set). 
        /// Look at our reference to see which formats are supported. <see cref="https://todoist.com/Help/DatesTimes"/>
        /// </summary>
        [JsonProperty("date_string")]
        public string DateString { get; set; }

        /// <summary>
        /// The language of the date_string (valid languages are: en, da, pl, zh, ko, de, pt, ja, it, fr, sv, ru, es, nl).
        /// </summary>
        [JsonProperty("date_lang")]
        public string DateLang { get; set; }

        ///The date of the task in the format Mon 07 Aug 2006 12:34:56 +0000 (or null if not set). For all day task(i.e.task due “Today”), the time part will be set as xx:xx:59.
        [JsonProperty("due_date_utc")]
        public string DueDateUtcString { get; set; }

        /// <summary>
        /// The indent of the task (a number between 1 and 5, where 1 is top-level).
        /// </summary>
        [JsonProperty("indent")]
        public Indent IndentLevel { get; set; }

        /// <summary>
        //The priority of the task(a number between 1 and 4, 4 for very urgent and 1 for natural). 
        //Note: Keep in mind that very urgent is the priority 1 on clients.So, p1 will return 4 in the API.
        /// </summary>
        [JsonProperty("priority")]
        public Priority PriorityValue { get; set; }

        /// <summary>
        /// The order of the task inside a project (the smallest value would place the task at the top).
        /// </summary>
        [JsonProperty("item_order")]
        public uint ItemOrder { get; set; }

        /// <summary>
        /// The order of the task inside the Today or Next 7 days view (a number, where the smallest value would place the task at the top).
        /// -1 seems to be valid.
        /// </summary>
        [JsonProperty("day_order")]
        public int DayOrder { get; set; }

        /// <summary>
        /// Whether the task’s sub-tasks are collapsed (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("collapsed")]
        public bool Collapsed { get; set; }

        //TODO: Object?
        [JsonProperty("children")]
        public List<Item> Children { get; set; }

        //TODO: Object?
        [JsonProperty("parent_id")]
        public Item Parent { get; set; }

        //The tasks labels (a list of label ids such as [2324,2525]).
        [JsonProperty("labels")]
        public uint[] Labels { get; set; }

        /// <summary>
        /// The id of the user who assigns the current task. This makes sense for shared projects only. 
        /// Accepts 0 or any user id from the list of project collaborators. 
        /// If this value is unset or invalid, it will automatically be set up to your uid.
        /// </summary>
        [JsonProperty("assigned_by_uid")]
        public uint? AssignedByUid { get; set; }

        /// <summary>
        /// The id of user who is responsible for accomplishing the current task. 
        /// This makes sense for shared projects only. 
        /// Accepts any user id from the list of project collaborators or null or an empty string to unset.
        /// </summary>
        [JsonProperty("responsible_uid")]
        public uint? ResponsibleUid { get; set; }

        /// <summary>
        /// Whether the task is marked as completed (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("checked")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Checked { get; set; }

        /// <summary>
        /// Whether the task has been marked as completed and is marked to be moved to history, 
        /// because all the child tasks of its parent are also marked as completed (where 1 is true and 0 is false)
        /// </summary>
        [JsonProperty("in_history")]
        [JsonConverter(typeof(BoolConverter))]
        public bool InHistory { get; set; }

        /// <summary>
        /// Whether the task is marked as deleted (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_deleted")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the task is marked as archived (where 1 is true and 0 is false), converted to bool on client.
        /// </summary>
        [JsonProperty("is_archived")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsArchived { get; set; }

        /// <summary>
        /// A special id for shared tasks (a number or null if not set). Used internally and can be ignored.
        /// </summary>
        [JsonProperty("sync_id")]
        public uint? SyncId { get; set; }

        /// <summary>
        /// The date when the task was created.
        /// </summary>
        [JsonProperty("date_added")]
        public string DateAdded { get; set; }
    }
}