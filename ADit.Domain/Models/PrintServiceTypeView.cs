using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class PrintServiceTypeView : IPrintServiceTypeView
    {
        /// <summary>
        /// 
        /// </summary>
       public int PrintServiceTypeId { get; set; }
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
       public string  ProcessingMessage { get; set; }



    }
}
