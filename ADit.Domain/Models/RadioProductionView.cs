using ADit.Interfaces;
using System.Web;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IRadioProductionView" />
    public class RadioProductionView :IRadioProductionView 
    {


        /// <summary>
        /// Gets or sets the radio manager production digital identifier.
        /// </summary>
        /// <value>
        /// The radio manager production digital identifier.
        /// </value>
        public int RadioManagerProductionDigitalId { get; set; }
        /// <summary>
        /// </summary>
        public int  RadioTransactionId { get; set; }
        /// <summary>
        /// </summary>
        public string ProductionManagerNote { get; set; }
        /// <summary>
        /// </summary>
        public HttpPostedFileBase productionMaterial { get; set; }

        /// <summary>
        /// Gets or sets the production manager identifier.
        /// </summary>
        /// <value>
        /// The production manager identifier.
        /// </value>
        public int ProductionManagerId { get; set; }
    }
}
