using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITVServicePricesList" />
    public class TvServicesPriceListModel : ITVServicePricesList
    {

        /// <summary>
        /// Gets or sets the material type description.
        /// </summary>
        /// <value>
        /// The material type description.
        /// </value>
        public string MaterialTypeDescription { get; set; }
        /// <summary>
        /// Gets or sets the timing belt identifier.
        /// </summary>
        /// <value>
        /// The timing belt identifier.
        /// </value>
        public int TimingBeltId { get; set; }
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }

        /// <summary>
        /// Gets or sets the tv services price list identifier.
        /// </summary>
        /// <value>
        /// The tv services price list identifier.
        /// </value>
        public int TvServicesPriceListId { get; set; }

        /// <summary>
        /// Gets or sets the tv station.
        /// </summary>
        /// <value>
        /// The tv station.
        /// </value>
        public int TvStation { get; set; }

        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        public string TimingDescription { set; get; }


        /// <summary>
        /// Gets or sets the tv station description.
        /// </summary>
        /// <value>
        /// The tv station description.
        /// </value>
        public string TvStationDescription { set; get; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date effective.
        /// </summary>
        /// <value>
        /// The date effective.
        /// </value>
        public DateTime DateEffective { get; set; }

        /// <summary>
        /// Gets or sets the date in active.
        /// </summary>
        /// <value>
        /// The date in active.
        /// </value>
        public DateTime? DateInActive { get; set; }

        /// <summary>
        /// Gets or sets the date craeted.
        /// </summary>
        /// <value>
        /// The date craeted.
        /// </value>
        public DateTime DateCraeted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
       // int?  TimingBeltId { get; set; }
    }
}