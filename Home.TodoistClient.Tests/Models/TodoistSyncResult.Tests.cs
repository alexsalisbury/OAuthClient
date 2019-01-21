namespace Home.TodoistClient.Tests.Models
{
    using System.Net;
    using Home.Todoist.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TodoistSyncResult_Tests
    {
        [TestMethod]
        public void CreateTodoistSyncResult()
        {
            var anonymizedData = "{\"full_sync\": true,\"temp_id_mapping\": {},\"labels\": [{\"item_order\": 1,\"is_deleted\": 0,\"name\": \"Planning\",\"color\": 0,\"is_favorite\": 0,\"id\": 1}],\"locations\": [],\"project_notes\": [],\"user\": {\"start_page\": \"today\",\"features\": {\"karma_disabled\": false,\"restriction\": 3,\"karma_vacation\": false,\"dateist_lang\": null,\"beta\": 0,\"has_push_reminders\": true,\"dateist_inline_disabled\": false},\"completed_today\": 1,\"is_premium\": true,\"sort_order\": 0,\"full_name\": \"Test User\",\"auto_reminder\": 30,\"id\": 1,\"share_limit\": 26,\"days_off\": [7],\"magic_num_reached\": true,\"next_week\": 1,\"completed_count\": 19,\"daily_goal\": 5,\"theme\": 11,\"tz_info\": {\"hours\": -5,\"timezone\": \"America\\/New_York\",\"is_dst\": 0,\"minutes\": 0,\"gmt_string\": \"-05:00\"},\"email\": \"testuser@contoso.com\",\"start_day\": 7,\"weekly_goal\": 30,\"date_format\": 1,\"websocket_url\": \"wss:\\/\\/ws.todoist.com\\/ws?token=1\",\"inbox_project\": 1,\"time_format\": 1,\"image_id\": null,\"karma_trend\": \"-\",\"business_account_id\": null,\"mobile_number\": null,\"mobile_host\": null,\"premium_until\": \"Mon 11 Nov 2019 12:13:14 +0000\",\"dateist_lang\": null,\"join_date\": \"Sun 18 Nov 2018 03:42:42 +0000\",\"karma\": 1234.0,\"is_biz_admin\": false,\"default_reminder\": \"email\",\"dateist_inline_disabled\": false,\"token\": \"1a\"},\"filters\": [{\"name\": \"Assigned to me\",\"color\": 12,\"item_order\": 1,\"is_favorite\": 0,\"query\": \"assigned to: me\",\"is_deleted\": 0,\"id\": 2}],\"sync_token\": \"fg\",\"day_orders\": {},\"projects\": [{\"color\": 7,\"collapsed\": 0,\"inbox_project\": true,\"is_favorite\": 0,\"indent\": 1,\"is_deleted\": 0,\"id\": 3,\"name\": \"Inbox\",\"has_more_notes\": false,\"parent_id\": null,\"item_order\": 0,\"shared\": false,\"is_archived\": 0}],\"collaborators\": [],\"day_orders_timestamp\": \"1344642992.1\",\"live_notifications_last_read_id\": 1,\"items\": [{\"day_order\": -1,\"assigned_by_uid\": 19738756,\"is_archived\": 0,\"labels\": [],\"sync_id\": null,\"date_completed\": null,\"all_day\": false,\"in_history\": 0,\"date_added\": \"Sun 18 Nov 2018 03:42:42 +0000\",\"indent\": 1,\"date_lang\": null,\"id\": 5,\"priority\": 1,\"checked\": 0,\"user_id\": 1,\"has_more_notes\": false,\"due_date_utc\": null,\"content\": \"Welcome to Todoist \\ud83d\\udc4b Let\\u2019s get you started with a few tips:\",\"parent_id\": null,\"item_order\": 1,\"is_deleted\": 0,\"responsible_uid\": null,\"project_id\": 3,\"collapsed\": 0,\"date_string\": null}],\"notes\": [],\"reminders\": [{\"is_deleted\": 0,\"service\": \"push\",\"id\": 4,\"due_date_utc\": \"Sun 18 Nov 2018 23:30:00 +0000\",\"minute_offset\": 30,\"item_id\": 1,\"notify_uid\": 1,\"type\": \"relative\",\"date_lang\": \"en\",\"date_string\": \"2018-11-18 18:30\"}],\"user_settings\": {\"reminder_push\": true,\"reminder_sms\": true,\"reminder_desktop\": true,\"reminder_email\": false},\"live_notifications\": [{\"created\": 1,\"is_deleted\": 0,\"notification_key\": \"karma_level_1\",\"notification_type\": \"karma_level\",\"promo_img\": \"https:\\/\\/d3ptyyxy2at9ui.cloudfront.net\\/1-d3c52f.png\",\"karma_level\": 1,\"id\": 1,\"is_unread\": 0}],\"collaborator_states\": []}";

            var tsr = new TodoistSyncResult(HttpStatusCode.Accepted, anonymizedData, true);
            Assert.IsNotNull(tsr);
            Assert.IsNotNull(tsr.Data);
        }
    }
}
