using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class ApconApprovalTypePriceListView : IApconApprovalTypePriceListView
    {
        /// <summary>
        /// 
        /// </summary>
        public int SelectedApconApprovalTypePriceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedApconApprovalId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<IApconApprovalTypePrice> ApconApprovalTypePriceCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }
    }
}
