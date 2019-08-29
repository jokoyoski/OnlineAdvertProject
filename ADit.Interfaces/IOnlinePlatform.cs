namespace ADit.Interfaces
{
   public  interface IOnlinePlatform
    {
        
        int OnlinePlatformId { get; set; }
        
        string Description { get; set; }
        
        bool IsActive { get; set; }
    }
}
