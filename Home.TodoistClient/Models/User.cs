namespace Home.Todoist.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Home.Todoist.Converters;
    using Newtonsoft.Json;

    public partial class User
    {
        /// <summary>
        /// Specifies the day of the week.
        /// </summary>
        public enum DoistDayOfWeek
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        /// <summary>
        /// The user’s id.
        /// </summary>
        [JsonProperty("id")]
        public uint Id { get; set; }

        /// <summary>
        /// The user’s token that should be used to call the other API methods.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// The user’s email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The user’s real name formatted as Firstname Lastname.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// The id of the user’s Inbox project.
        /// </summary>
        [JsonProperty("inbox_project")]
        public uint InboxProject { get; set; }

        /// <summary>
        /// The user’s timezone (a dictionary structure), which includes the following elements: the timezone as a string value, 
        /// the hours and minutes difference from GMT, whether daylight saving time applies denoted by is_dst, 
        /// and a string value of the time difference from GMT that is gmt_string.
        /// </summary>
        [JsonProperty("tz_info")]
        public TzInfo TzInfo { get; set; }

        /// <summary>
        /// The user’s default view on Todoist. The start page can be one of the following: _info_page for the info page, _blank for a blank page, _project_<PROJECT_ID> for project with id <PROJECT_ID>, and <ANY_QUERY> to query after anything.
        /// </summary>
        [JsonProperty("start_page")]
        public string StartPage { get; set; }

        /// <summary>
        /// The first day of the week (between 1 and 7, where 1 is Monday and 7 is Sunday).
        /// </summary>
        [JsonProperty("start_day")]
        public DoistDayOfWeek StartDay { get; set; }

        /// <summary>
        /// The day of the next week, that tasks will be postponed to (between 1 and 7, where 1 is Monday and 7 is Sunday).
        /// </summary>
        [JsonProperty("next_week")]
        public DoistDayOfWeek NextWeek { get; set; }

        /// <summary>
        /// Whether to use the DD-MM-YYYY date format (if set to 0), or the MM-DD-YYYY format (if set to 1).
        /// </summary>
        [JsonProperty("date_format")]
        [Range(0, 1)]
        public uint DateFormat { get; set; }

        /// <summary>
        /// Whether to use a 24h format such as 13:00 (if set to 0) when displaying time, or a 12h format such as 1:00pm (if set to 1).
        /// </summary>
        [JsonProperty("time_format")]
        [Range(0, 1)]
        public uint TimeFormat { get; set; }

        /// <summary>
        /// Whether to show projects in an oldest dates first order (if set to 0, or a oldest dates last order (if set to 1).
        /// </summary>
        [JsonProperty("sort_order")]
        [Range(0, 1)]
        public uint SortOrder { get; set; }

        /// <summary>
        /// The default reminder for the user. Reminders are only possible for Premium users. 
        /// The default reminder can be one of the following: email to send reminders by email, mobile to send reminders to mobile devices via SMS, 
        /// push to send reminders to smart devices using push notifications 
        /// (one of the Android or iOS official clients must be installed on the client side to receive these notifications), 
        /// no_default to turn off sending default reminders.
        /// </summary>
        [JsonProperty("default_reminder")]
        public object DefaultReminder { get; set; }

        /// <summary>
        /// The default time in minutes for the automatic reminders set, whenever a due date has been specified for a task.
        /// </summary>
        [JsonProperty("auto_reminder")]
        public uint AutoReminder { get; set; }

        /// <summary>
        /// The user’s mobile host (null if not set).
        /// </summary>
        [JsonProperty("mobile_host")]
        public object MobileHost { get; set; }

        /// <summary>
        /// The user’s mobile number (null if not set).
        /// </summary>
        [JsonProperty("mobile_number")]
        public object MobileNumber { get; set; }

        /// <summary>
        /// The total number of completed tasks.
        /// </summary>
        [JsonProperty("completed_count")]
        public uint CompletedCount { get; set; }

        /// <summary>
        /// The number of completed tasks for today.
        /// </summary>
        [JsonProperty("completed_today")]
        public uint CompletedToday { get; set; }

        /// <summary>
        /// The user’s karma score.
        /// </summary>
        [JsonProperty("karma")]
        public uint Karma { get; set; }

        /// <summary>
        /// The user’s karma trend (for example up, "-", ).
        /// </summary>
        [JsonProperty("karma_trend")]
        public string KarmaTrend { get; set; }

        /// <summary>
        /// Whether the user has a Premium subscription (a true or false value).
        /// </summary>
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        /// <summary>
        /// The date when the user’s Premium subscription ends (null if not a Premium user). 
        /// This should be used for informational purposes only as this does not include the grace period upon expiration. 
        /// As a result, avoid using this to determine whether someone has premium and use is_premium instead.
        /// </summary>
        [JsonProperty("premium_until")]
        public DateTime PremiumUntil { get; set; }

        /// <summary>
        /// Whether the user is a business account administrator (a true or false value).
        /// </summary>
        [JsonProperty("is_biz_admin")]
        public bool IsBizAdmin { get; set; }

        /// <summary>
        /// The id of the user’s business account.
        /// </summary>
        [JsonProperty("business_account_id")]
        public uint? BusinessAccountId { get; set; }

        /// <summary>
        /// The id of the user’s avatar.
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        /// <summary>
        /// The link to a 35x35 pixels image of the user’s avatar.
        /// </summary>
        [JsonProperty("avatar_small")]
        public Uri AvatarSmall { get; set; }

        /// <summary>
        /// The link to a 60x60 pixels image of the user’s avatar.
        /// </summary>
        [JsonProperty("avatar_medium")]
        public Uri AvatarMedium { get; set; }

        /// <summary>
        /// The link to a 195x195 pixels image of the user’s avatar.
        /// </summary>
        [JsonProperty("avatar_big")]
        public Uri AvatarBig { get; set; }

        /// <summary>
        /// The link to a 640x640 pixels image of the user’s avatar.
        /// </summary>
        [JsonProperty("avatar_s640")]
        public Uri AvatarS640 { get; set; }

        /// <summary>
        /// The currently selected Todoist theme (a number between 0 and 10).
        /// </summary>
        [JsonProperty("theme")]
        [Range(0, 10)]
        public uint Theme { get; set; }

        /// <summary>
        /// Used internally for any special features that apply to the user. 
        /// Current special features include whether any special restriction applies to the user, whether the user is in beta status, 
        /// whether the user has_push_reminders enabled, and whether dateist_inline_disabled that is inline date parsing support is disabled.
        /// </summary>
        [JsonProperty("features")]
        public Features Features { get; set; }

        /// <summary>
        /// The date when the user joined Todoist.
        /// </summary>
        [JsonProperty("join_date")]
        public string JoinDate { get; set; }
    }

    /// <summary>
    /// Used internally for any special features that apply to the user. 
    /// Current special features include whether any special restriction applies to the user, whether the user is in beta status, 
    /// whether the user has_push_reminders enabled, and whether dateist_inline_disabled that is inline date parsing support is disabled.
    /// </summary>
    public partial class Features
    {
        [JsonProperty("beta")]
        public long Beta { get; set; }

        [JsonProperty("restriction")]
        public long Restriction { get; set; }

        [JsonProperty("has_push_reminders")]
        public bool HasPushReminders { get; set; }
    }

    /// <summary>
    /// The user’s timezone (a dictionary structure), which includes the following elements: the timezone as a string value, 
    /// the hours and minutes difference from GMT, whether daylight saving time applies denoted by is_dst, 
    /// and a string value of the time difference from GMT that is gmt_string.
    /// </summary>
    public partial class TzInfo
    {
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Minutes from GMT
        /// </summary>
        [JsonProperty("minutes")]
        public int Minutes { get; set; }

        /// <summary>
        /// Hours from GMT
        /// </summary>
        [JsonProperty("hours")]
        public int Hours { get; set; }

        /// <summary>
        /// Is Daylight Savings Time
        /// </summary>
        [JsonProperty("is_dst")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDst { get; set; }

        /// <summary>
        /// String representation of Distance from GMT.
        /// </summary>
        [JsonProperty("gmt_string")]
        public string GmtString { get; set; }
    }
}