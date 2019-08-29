using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IScriptingDetailModel" />
    public class ScriptingDetailModel : IScriptingDetailModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Nullable<int> UserId { get; set; }
        /// <summary>
        /// Gets or sets the application role identifier.
        /// </summary>
        /// <value>
        /// The application role identifier.
        /// </value>
        public int AppRoleId { get; set; }
        /// <summary>
        /// Gets or sets the tv scripting identifier.
        /// </summary>
        /// <value>
        /// The tv scripting identifier.
        /// </value>
        public int TvScriptingId { get; set; }
        /// <summary>
        /// Gets or sets the scripter digital file identifier.
        /// </summary>
        /// <value>
        /// The scripter digital file identifier.
        /// </value>
        public int ScripterDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the user comment.
        /// </summary>
        /// <value>
        /// The user comment.
        /// </value>
        public string UserComment { get; set; }
        /// <summary>
        /// Gets or sets the user digital file identifier.
        /// </summary>
        /// <value>
        /// The user digital file identifier.
        /// </value>
        public int UserDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the scripter identifier.
        /// </summary>
        /// <value>
        /// The scripter identifier.
        /// </value>
        public Nullable<int> ScripterId { get; set; }
        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        /// <value>
        /// The topic.
        /// </value>
        public string Topic { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public int ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the scripter comment.
        /// </summary>
        /// <value>
        /// The scripter comment.
        /// </value>
        public string ScripterComment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        public DateTime DateApproved { get; set; }
        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>
        /// The date updated.
        /// </value>
        public Nullable<DateTime> DateUpdated { get; set; }
    }
}
