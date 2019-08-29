using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class FulfilmentStatusSummaryViewModel : IFulfilmentStatusSummaryViewModel
    {
        public IList<IFulfilmentStatusSummaryModel> FulfilmentStatusSummaries { get; set; }
    }
}