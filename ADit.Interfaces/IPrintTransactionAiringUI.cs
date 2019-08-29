﻿using System;

namespace ADit.Interfaces
{
   public  interface IPrintTransactionAiringUI
    {
        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
        int PrintMediaTypeId { get; set; }
        /// <summary>
        /// Gets or sets the print color identifier.
        /// </summary>
        /// <value>
        /// The print color identifier.
        /// </value>
        int PrintColorId { get; set; }
        /// <summary>
        /// Gets or sets the news paper price.
        /// </summary>
        /// <value>
        /// The news paper price.
        /// </value>
        decimal NewsPaperPrice { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime? EndDate { get; set; }
        /// <summary>
        /// Gets or sets the type of the print service.
        /// </summary>
        /// <value>
        /// The type of the print service.
        /// </value>
        string PrintServiceType { get; set; }
        /// <summary>
        /// Gets or sets the print transaction airing identifier.
        /// </summary>
        /// <value>
        /// The print transaction airing identifier.
        /// </value>
        int PrintTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
        int PrintTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the news paper identifier.
        /// </summary>
        /// <value>
        /// The news paper identifier.
        /// </value>
        int NewsPaperId { get; set; }
        /// <summary>
        /// Gets or sets the print service identifier.
        /// </summary>
        /// <value>
        /// The print service identifier.
        /// </value>
        int PrintServiceId { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        bool? IsActive { get; set; }
        /// <summary>
        /// Gets or sets the newspaper.
        /// </summary>
        /// <value>
        /// The newspaper.
        /// </value>
        string Newspaper { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        string ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the number of inserts.
        /// </summary>
        /// <value>
        /// The number of inserts.
        /// </value>
        int NumberOfInserts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        bool IsSelected { get; set; }

         int PrintMediaTypePriceId { get; set; }
    }
}
