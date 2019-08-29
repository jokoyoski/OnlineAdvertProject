using ADit.Interfaces;
using System;

namespace ADit.Domain.Models
{
   public  class PrintTransactionAiringUI: IPrintTransactionAiringUI
    {
        public PrintTransactionAiringUI()
        {
            this.IsSelected = false;
            this.NewsPaperId = -1;
            this.IsActive = true;
        }

        /// <summary>
        /// Gets or sets the print color identifier.
        /// </summary>
        /// <value>
        /// The print color identifier.
        /// </value>
        public int PrintColorId { get; set; }
        /// <summary>
        /// Gets or sets the news paper price.
        /// </summary>
        /// <value>
        /// The news paper price.
        /// </value>
        public decimal NewsPaperPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public  DateTime? EndDate { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the type of the print service.
        /// </summary>
        /// <value>
        /// The type of the print service.
        /// </value>
       public  string PrintServiceType { get; set; }
        /// <summary>
        /// Gets or sets the print transaction airing identifier.
        /// </summary>
        /// <value>
        /// The print transaction airing identifier.
        /// </value>
      public   int PrintTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
       public  int PrintTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the news paper identifier.
        /// </summary>
        /// <value>
        /// The news paper identifier.
        /// </value>
       public  int NewsPaperId { get; set; }
        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
        public int PrintMediaTypeId { get; set; }
        /// <summary>
        /// Gets or sets the print service identifier.
        /// </summary>
        /// <value>
        /// The print service identifier.
        /// </value>
      public   int PrintServiceId { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
       public  bool? IsActive { get; set; }
        /// <summary>
        /// Gets or sets the newspaper.
        /// </summary>
        /// <value>
        /// The newspaper.
        /// </value>
      public   string Newspaper { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
      public   string ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
      public   decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the number of inserts.
        /// </summary>
        /// <value>
        /// The number of inserts.
        /// </value>
       public  int NumberOfInserts { get; set; }

        public int PrintMediaTypePriceId { get; set; }
    }
}
