using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Persist.Abp.vnext.Domain.Data
{
    public class PersistDbMigrationService : ITransientDependency
    {
        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<IPersistDbSchemaMigrator> _dbSchemaMigrators;

        public PersistDbMigrationService(
            IDataSeeder dataSeeder,
            IEnumerable<IPersistDbSchemaMigrator> dbSchemaMigrators)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;
        }

        public async Task MigrateAsync()
        {
            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }

            await _dataSeeder.SeedAsync();
        }
    }
}
