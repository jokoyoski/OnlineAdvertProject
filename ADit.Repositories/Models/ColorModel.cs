using ADit.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ADit.Repositories.Models
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IColor" />
    public class ColorModel : IColor
    {
        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        public int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required]
        public string Description { get; set; }
    }
}


