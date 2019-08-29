using System.Data.Common;

namespace ADit.Repositories.DataAccess
{
    public partial class ADitEntities
    {
        public ADitEntities(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {
        }
    }
}
