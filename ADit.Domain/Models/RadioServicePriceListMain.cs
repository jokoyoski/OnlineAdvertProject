using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class RadioServicePriceListMain : IRadioServicePriceList
    {
        /// <summary>
        /// Gets or sets the timing belt identifier.
        /// </summary>
        /// <value>
        /// The timing belt identifier.
        /// </value>
        public int TimingBeltId { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the radio identifier.
        /// </summary>
        /// <value>
        /// The radio identifier.
        /// </value>
        public int RadioId { get; set; }
        /// <summary>
        /// Gets or sets the type of the radio station.
        /// </summary>
        /// <value>
        /// The type of the radio station.
        /// </value>
        public IList<SelectListItem> RadioStationType { get; set; }
        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        public int TimingId { get; set; }
        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        public IList<SelectListItem> TimingType { get; set; }
        /// <summary>
        /// Gets or sets the radio description.
        /// </summary>
        /// <value>
        /// The radio description.
        /// </value>
        public string RadioDescription { get; set; }
        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        public string TimingDescription { get; set; }
        /// <summary>
        /// Gets or sets the material description.
        /// </summary>
        /// <value>
        /// The material description.
        /// </value>
        public string MaterialDescription { get; set; }
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public IList<SelectListItem> MaterialType { get; set; }
        /// <summary>
        /// Gets or sets the timing belt.
        /// </summary>
        /// <value>
        /// The timing belt.
        /// </value>
        public IList<SelectListItem> TimingBelt { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date effective.
        /// </summary>
        /// <value>
        /// The date effective.
        /// </value>
        public Nullable<System.DateTime> DateEffective { get; set; }
        /// <summary>
        /// Gets or sets the date in active.
        /// </summary>
        /// <value>
        /// The date in active.
        /// </value>
        public Nullable<System.DateTime> DateInActive { get; set; }
        /// <summary>
        /// Gets or sets the processing messages.
        /// </summary>
        /// <value>
        /// The processing messages.
        /// </value>
        public string ProcessingMessages { get; set; }
       
    }
}
