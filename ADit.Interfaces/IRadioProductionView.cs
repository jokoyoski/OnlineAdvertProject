using System.Web;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioProductionView
    {

        /// <summary>
        /// Gets or sets the production manager identifier.
        /// </summary>
        /// <value>
        /// The production manager identifier.
        /// </value>
        int ProductionManagerId { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        int RadioTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the production manager note.
        /// </summary>
        /// <value>
        /// The production manager note.
        /// </value>
        string ProductionManagerNote { get; set; }
        /// <summary>
        /// Gets or sets the production material.
        /// </summary>
        /// <value>
        /// The production material.
        /// </value>
        HttpPostedFileBase productionMaterial { get; set; }


        /// <summary>
        /// Gets or sets the radio manager production digital identifier.
        /// </summary>
        /// <value>
        /// The radio manager production digital identifier.
        /// </value>
        int RadioManagerProductionDigitalId { get; set; }
    }
}
