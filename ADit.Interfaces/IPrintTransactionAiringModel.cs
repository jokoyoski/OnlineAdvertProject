using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface IPrintTransactionAiringModel
    {
        IList<DateTime> StartDate { get; set; }
        /// <summary>
        /// Gets or sets the print transaction airing identifier.
        /// </summary>
        /// <value>
        /// The print transaction airing identifier.
        /// </value>
        int PrintTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets the news paper.
        /// </summary>
        /// <value>
        /// The news paper.
        /// </value>
         IList<INewsPaper> NewsPaper { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
         IList<IList<SelectListItem>> SeviceCodes { get; set; }


        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
         IList<int> InsertNumbers { get; set; }


        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
         IList<decimal> Price { get; set; }
    }
}