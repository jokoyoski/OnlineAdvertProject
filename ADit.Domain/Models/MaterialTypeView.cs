using ADit.Interfaces;

namespace ADit.Domain.Models
{
  public  class MaterialTypeView : IMaterialTypeView
    {
        /// <summary>
        /// 
        /// </summary>
        public int MaterialTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
    }
}
