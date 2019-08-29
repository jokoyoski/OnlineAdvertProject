﻿using ADit.Interfaces;
using System;

namespace ADit.Domain.Models
{
    public class ApconApprovalTypeView : IApconApprovalTypeView
    {
        /// <summary>
        /// Gets or sets the apocon type identifier.
        /// </summary>
        /// <value>
        /// The apocon type identifier.
        /// </value>
        public int ApoconTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
