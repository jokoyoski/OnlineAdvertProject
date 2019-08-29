using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioServicePriceList
    {

        /// <summary>
        /// Gets or sets the timing belt identifier.
        /// </summary>
        /// <value>
        /// The timing belt identifier.
        /// </value>
        int TimingBeltId { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }
        /// <summary>
        /// Gets or sets the radio identifier.
        /// </summary>
        /// <value>
        /// The radio identifier.
        /// </value>
        int RadioId { get; set; }
        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        int TimingId { get; set; }
        /// <summary>
        /// Gets or sets the radio description.
        /// </summary>
        /// <value>
        /// The radio description.
        /// </value>
        string RadioDescription { get; set; }
        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        string TimingDescription { get; set; }
        /// <summary>
        /// Gets or sets the material description.
        /// </summary>
        /// <value>
        /// The material description.
        /// </value>
        string MaterialDescription { get; set; }
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the timing belt.
        /// </summary>
        /// <value>
        /// The timing belt.
        /// </value>
        IList<SelectListItem> TimingBelt { get; set; }
        /// <summary>
        /// Gets or sets the date effective.
        /// </summary>
        /// <value>
        /// The date effective.
        /// </value>
        Nullable<System.DateTime> DateEffective { get; set; }
        /// <summary>
        /// Gets or sets the date in active.
        /// </summary>
        /// <value>
        /// The date in active.
        /// </value>
        Nullable<System.DateTime> DateInActive { get; set; }
        /// <summary>
        /// Gets or sets the processing messages.
        /// </summary>
        /// <value>
        /// The processing messages.
        /// </value>
        string ProcessingMessages { get; set; }
        /// <summary>
        /// Gets or sets the type of the radio station.
        /// </summary>
        /// <value>
        /// The type of the radio station.
        /// </value>
        IList<SelectListItem> RadioStationType { get; set; }
        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        IList<SelectListItem> TimingType { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        IList<SelectListItem> MaterialType { get; set; }
    }
}
