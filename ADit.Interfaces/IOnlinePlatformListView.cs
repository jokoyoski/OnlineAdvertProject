using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IOnlinePlatformListView
    {

        
        int SelectOnlinePlatformId { get; set; }
        
        string SelectDescription { get; set; }
        
        bool IsActive { get; set; }

        
        string ProcessingMessage { get; set; }
        
        IList<IOnlinePlatform> OnlinePlatformCollection { get; set; }
    }
}
