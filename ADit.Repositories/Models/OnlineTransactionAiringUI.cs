using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
    public class OnlineTransactionAiringUI : IOnlineTransactionAiringUI
    {
        public OnlineTransactionAiringUI()
        {
            this.IsSelected = false;
            this.OnlineTransactionId = -1;
            this.IsActive = true;
        }



        /// <summary>
        /// Gets or sets the online duration desccription.
        /// </summary>
        /// <value>
        /// The online duration desccription.
        /// </value>
        public string OnlineDurationDesccription { get; set; }
        /// <summary>
        /// Gets or sets the online platform description.
        /// </summary>
        /// <value>
        /// The online platform description.
        /// </value>
        public string  OnlinePlatformDescription{get;set;}
        /// <summary>
        /// Gets or sets the online transaction airing identifier.
        /// </summary>
        /// <value>
        /// The online transaction airing identifier.
        /// </value>
        public int OnlineTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        public int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the online duration identifier.
        /// </summary>
        /// <value>
        /// The online duration identifier.
        /// </value>
        public int OnlineDurationId { get; set; }
        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        public int OnlinePlatformId { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
    }
}
