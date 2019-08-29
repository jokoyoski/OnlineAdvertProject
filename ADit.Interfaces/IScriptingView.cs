using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptingView
    {
        /// <summary>
        /// Gets or sets the tv scripting identifier.
        /// </summary>
        /// <value>
        /// The tv scripting identifier.
        /// </value>
        int TvScriptingId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }

        // int ScripterDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets the scripting digital file identifier.
        /// </summary>
        /// <value>
        /// The scripting digital file identifier.
        /// </value>
        int ScriptingDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the scripter identifier.
        /// </summary>
        /// <value>
        /// The scripter identifier.
        /// </value>
        int ScripterId { get; set; }

        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        /// <value>
        /// The topic.
        /// </value>
        string Topic { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        //string UserComment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        DateTime DateApproved { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>
        /// The date updated.
        /// </value>
        DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the pictures.
        /// </summary>
        /// <value>
        /// The pictures.
        /// </value>
        IDigitalFile pictures { get; set; }
    }
}
