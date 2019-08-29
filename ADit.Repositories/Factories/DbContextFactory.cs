using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity;

using Environment = AA.Infrastructure.Utility.Environment;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System.Data.Common;
using ADit.Repositories.DataAccess;
using AA.Infrastructure.Interfaces;

namespace ADit.Repositories.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IEnvironment environment;

        public DbContextFactory(IEnvironment environment)
        {
            this.environment = environment ?? new Environment();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            var userId = this.environment[EnvironmentValues.ADitUId];
            var password = this.environment[EnvironmentValues.ADitPwd];
            var server = this.environment[EnvironmentValues.ADitSvr];
            var contextType = this.environment[EnvironmentValues.ADitDb];

            if (string.IsNullOrEmpty(contextType))
            {
                throw new ApplicationException("Database not specified in Environment file.");
            }
            
            if (string.IsNullOrEmpty(server))
            {
                throw new ApplicationException(string.Format("Server not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApplicationException(string.Format("UserId not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ApplicationException(string.Format("Password not specified in Environment file for database{0}",
                    contextType));
            }

            string connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server,
                contextType, userId, password);

            var entities = new EntityConnectionStringBuilder
            {
                Metadata = @"res://*/DataAccess.Adit.csdl|res://*/DataAccess.ADit.ssdl|res://*/DataAccess.Adit.msl",
                ProviderConnectionString = connString,
                Provider = "System.Data.SqlClient"
            };

            DbConnection dbConnection = new EntityConnection(entities.ConnectionString);
            DbContext dbContext = new ADitEntities(dbConnection, true);


            return dbContext;
        }


    }
}
