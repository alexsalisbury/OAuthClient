namespace Home.TodoistClient.Helpers
{
    using System;
    using Home.TodoistClient.Models;

    public class SyncResultEventArgs : EventArgs
    {
        public SyncResult Result { get; private set; }

        public SyncResultEventArgs(SyncResult result)
        {
            this.Result = result;
        }
    }
}