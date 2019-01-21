namespace Home.TodoistClient.Helpers
{
    using System;

    public class ApiTokenChangedEventArgs : EventArgs
    {
        public string ApiToken { get; private set; }

        public ApiTokenChangedEventArgs(string apiToken)
        {
            this.ApiToken = apiToken;
        }
    }
}