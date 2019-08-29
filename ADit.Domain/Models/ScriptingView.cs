using System;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class ScriptingView : IScriptingView
    {
        /// <summary>
        /// Gets or sets the tv scripting identifier.
        /// </summary>
        /// <value>
        /// The tv scripting identifier.
        /// </value>
        public int TvScriptingId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the scripting digital file identifier.
        /// </summary>
        /// <value>
        /// The scripting digital file identifier.
        /// </value>
        public int ScriptingDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the scripter identifier.
        /// </summary>
        /// <value>
        /// The scripter identifier.
        /// </value>
        public int ScripterId { get; set; }

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
        public string ProcessingMessage { get; set; }

        // public string UserComment { get; set; }
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
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the pictures.
        /// </summary>
        /// <value>
        /// The pictures.
        /// </value>
        public IDigitalFile pictures { get; set; }
    }
}
