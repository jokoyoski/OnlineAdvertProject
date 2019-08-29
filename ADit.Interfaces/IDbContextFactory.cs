using System.Data.Entity;

namespace ADit.Interfaces
{
    public interface IDbContextFactory
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}
