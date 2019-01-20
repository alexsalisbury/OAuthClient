namespace Home.OAuthClients.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal class ExampleDataObject : IEquatable<ExampleDataObject>
    {
        [JsonProperty("content")]
        string Content { get; set; }

        [JsonProperty("timestamp")]
        DateTime Timestamp { get; set; }

        internal ExampleDataObject()
        {
        }

        internal static ExampleDataObject Generate()
        {
            return new ExampleDataObject()
            {
                Content = Guid.NewGuid().ToString(),
                Timestamp = DateTime.UtcNow
            };
        }

        public IEnumerable<KeyValuePair<string, string>> GenerateBody()
        {
            var result = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("content", Content),
                new KeyValuePair<string, string>("timestamp", Timestamp.ToString())
            };

            return result;
        }

        /// <summary>
        /// Deep compare of properties to check if responses are equivalent.
        /// </summary>
        /// <param name="other">the object to compare this item to.</param>
        /// <returns>Whether all properties match. Case sensitive check on content (for now)</returns>
        public bool Equals(ExampleDataObject other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Content == other.Content && this.Timestamp == other.Timestamp;
        }
    }
}