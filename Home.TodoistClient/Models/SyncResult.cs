namespace Home.TodoistClient.Models
{
    public class SyncResult
    {
        public enum APIKeyStatus
        {
            Unknown = 0,
            Unset = 1,
            Invalid = 2,
            Valid = 3,
        }

        public APIKeyStatus KeyStatus { get; private set; }
        public SyncData Data { get; private set; }
        public CommandResult Result { get; private set; }

        public SyncResult(APIKeyStatus status, SyncData data) : this(status)
        {
            this.Data = data;
        }

        public SyncResult(APIKeyStatus status, CommandResult result) : this(status)
        {
            this.Result = result;
        }

        public SyncResult(APIKeyStatus status)
        {
            this.KeyStatus = status;
        }
    }
}