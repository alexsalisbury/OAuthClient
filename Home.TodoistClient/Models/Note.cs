namespace Home.Todoist.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Home.Todoist.Converters;

    public partial class Note
    {
        /// <summary>
        /// The id of the note.
        /// </summary>
        [JsonProperty("id")]
        public uint Id { get; set; }

        /// <summary>
        /// The id of the user that posted the note.
        /// </summary>
        [JsonProperty("posted_uid")]
        public uint PostedUid { get; set; }

        /// <summary>
        /// The project which the note is part of.
        /// </summary>
        [JsonProperty("project_id")]
        public uint ProjectId { get; set; }

        /// <summary>
        /// The item which the note is part of.
        /// </summary>
        [JsonProperty("item_id")]
        public uint ItemId { get; set; }

        /// <summary>
        /// The content of the note.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// A file attached to the note.
        /// </summary>
        [JsonProperty("file_attachment")]
        public FileAttachment FileAttachment { get; set; }

        /// <summary>
        /// A list of user ids to notify.
        /// </summary>
        [JsonProperty("uids_to_notify")]
        public uint[] UidsToNotify { get; set; }

        /// <summary>
        /// Whether the note is marked as deleted (where 1 is true and 0 is false), converted to bool on client..
        /// </summary>
        [JsonProperty("is_deleted")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the note is marked as archived (where 1 is true and 0 is false), converted to bool on client..
        /// </summary>
        [JsonProperty("is_archived")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsArchived { get; set; }

        /// <summary>
        /// The date when the note was posted.
        /// </summary>
        [JsonProperty("posted")]
        public string Posted { get; set; }

        /// <summary>
        /// List of emoji reactions and corresponding user ids.
        /// </summary>
        [JsonProperty("reactions")]
        public KeyValuePair<string, string>? Reactions { get; set; }
    }

    /// <summary>
    /// A file attachment is represented as a JSON object. 
    /// The file attachment may point to a document previously uploaded by the uploads/add API call, or by any external resource.
    /// <seealso cref="https://developer.todoist.com/sync/v7/?shell#notes"/>
    /// </summary>
    public partial class FileAttachment
    {
        /// <summary>
        /// MIME type (for example text/plain or image/png).
        /// </summary>
        [JsonProperty("file_type")]
        public string FileType { get; set; }
        
        /// <summary>
        /// The name of the file.
        /// </summary>
        [JsonProperty("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        [JsonProperty("file_size")]
        public uint FileSize { get; set; }

        /// <summary>
        /// The URL where the file is located. 
        /// Note that we don’t cache the remote content on our servers and stream or expose files directly from third party resources. 
        /// In particular this means that you should avoid providing links to non-encrypted (plain HTTP) resources, 
        /// as exposing this files in Todoist may issue a browser warning.
        /// </summary>
        [JsonProperty("file_url")]
        public Uri FileUrl { get; set; }

        /// <summary>
        /// Upload completion state (for example pending or completed).
        /// </summary>
        [JsonProperty("upload_state")]
        public string UploadState { get; set; }
    }
}