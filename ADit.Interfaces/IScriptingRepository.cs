namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptingRepository
    {
        /// <summary>
        /// Saves the scripting detail admin.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="TvScriptingId">The tv scripting identifier.</param>
        /// <returns></returns>
        string SaveScriptingDetailAdmin(IScriptingView view, out int TvScriptingId);
        /// <summary>
        /// Saves the scripting detail user.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="TvScriptingId">The tv scripting identifier.</param>
        /// <returns></returns>
        string SaveScriptingDetailUser(IScriptingView view, out int TvScriptingId);
        /// <summary>
        /// Gets the script transaction by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IScriptingDetailModel GetScriptTransactionById(int Id);
    }
}
