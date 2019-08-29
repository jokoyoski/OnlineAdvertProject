using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class PrintTransactionAiringModel : IPrintTransactionAiringModel
    {
        public PrintTransactionAiringModel()
        {
            NewsPaper = new List<INewsPaper>();
            SeviceCodes = new List<IList<SelectListItem>>();

            InsertNumbers = new List<int>();
            Price = new List<decimal>();
            StartDate = new List<DateTime>();
        }

        /// <summary>
        /// Gets or sets the print transaction airing identifier.
        /// </summary>
        /// <value>
        /// The print transaction airing identifier.
        /// </value>
        public int PrintTransactionAiringId { get; set; }
        
        /// <summary>
        /// Gets or sets the news paper.
        /// </summary>
        /// <value>
        /// The news paper.
        /// </value>
        public IList<INewsPaper> NewsPaper { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        public IList<IList<SelectListItem>> SeviceCodes { get; set; }

        public IList<DateTime> StartDate { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        public IList<int> InsertNumbers { get; set; }


        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public IList<decimal> Price { get; set; }
    }
}