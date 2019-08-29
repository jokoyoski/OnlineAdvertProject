using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IFulfilmentStatusSummaryViewModel
    {
        IList<IFulfilmentStatusSummaryModel> FulfilmentStatusSummaries { get; set; }
    }
}