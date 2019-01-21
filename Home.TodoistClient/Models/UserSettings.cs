namespace Home.TodoistClient.Models
{
    using Newtonsoft.Json;

    public class UserSettings
    {
        [JsonProperty("reminder_push")]
        public bool ReminderPush { get; set; }

        [JsonProperty("reminder_sms")]
        public bool ReminderSms { get; set; }

        [JsonProperty("reminder_desktop")]
        public bool ReminderDesktop { get; set; }

        [JsonProperty("reminder_email")]
        public bool ReminderEmail { get; set; }
    }
}