using System;

namespace ADit.Interfaces
{
    public interface IScriptingDetailModel
    {
         Nullable<int> UserId { get; set; }
         int AppRoleId { get; set; }
         int TvScriptingId { get; set; }
         int ScripterDigitalFileId { get; set; }
         string UserComment { get; set; }
         int UserDigitalFileId { get; set; }
         Nullable<int> ScripterId { get; set; }
         string Topic { get; set; }
         int ProcessingMessage { get; set; }
         string ScripterComment { get; set; }
         bool IsActive { get; set; }
         bool IsApproved { get; set; }
         DateTime DateCreated { get; set; }
         DateTime DateApproved { get; set; }
         Nullable<DateTime> DateUpdated { get; set; }
    }
}
