﻿namespace ADit.Interfaces
{
   public interface IMaterialTypeView : IMaterialType
    {

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        string ProcessingMessage { get; set; }
    }
}
