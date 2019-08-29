using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITVServicePricesList
    {
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the material type description.
        /// </summary>
        /// <value>
        /// The material type description.
        /// </value>
        string MaterialTypeDescription { get; set; }
        /// <summary>
        /// Gets or sets the tv services price list identifier.
        /// </summary>
        /// <value>
        /// The tv services price list identifier.
        /// </value>
        int TvServicesPriceListId { get; set; }
        /// <summary>
        /// Gets or sets the timing belt identifier.
        /// </summary>
        /// <value>
        /// The timing belt identifier.
        /// </value>
        int TimingBeltId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the tv station.
        /// </summary>
        /// <value>
        /// The tv station.
        /// </value>
        int TvStation { get; set; }
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        int Time { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the date effective.
        /// </summary>
        /// <value>
        /// The date effective.
        /// </value>
        DateTime DateEffective { get; set; }
        /// <summary>
        /// Gets or sets the date in active.
        /// </summary>
        /// <value>
        /// The date in active.
        /// </value>
        DateTime? DateInActive { get; set; }
        /// <summary>
        /// Gets or sets the date craeted.
        /// </summary>
        /// <value>
        /// The date craeted.
        /// </value>
        DateTime DateCraeted { get; set; }

        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        string TimingDescription { set; get; }

        /// <summary>
        /// Gets or sets the tv station description.
        /// </summary>
        /// <value>
        /// The tv station description.
        /// </value>
        string TvStationDescription { set; get; }
    }
}