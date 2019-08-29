using System;

namespace ADit.Interfaces
{
   public interface IPrintTransactionPublish
    {
        int PrintTransactionPublishId { get; set; }
        int PrintTransactionId { get; set; }
        Nullable<int> PrintServiceTypePriceId { get; set; }
        decimal PrintServiceAmount { get; set; }

    }
}
