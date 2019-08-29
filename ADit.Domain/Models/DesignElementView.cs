using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class DesignElementView : IDesignElementView
    {
        /// <summary>
        /// 
        /// </summary>
       public int DesignElementId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }
    }
}
