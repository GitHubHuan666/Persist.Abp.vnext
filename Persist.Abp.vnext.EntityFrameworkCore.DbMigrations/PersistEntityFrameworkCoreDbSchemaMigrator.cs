using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persist.Abp.vnext.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Persist.Abp.vnext.EntityFrameworkCore.DbMigrations
{

    [ExposeServices(typeof(IPersistDbSchemaMigrator))]
    public class PersistEntityFrameworkCoreDbSchemaMigrator : IPersistDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public PersistEntityFrameworkCoreDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            await _serviceProvider
                .GetRequiredService<PersistMigrationsDbContext>()
                .Database.MigrateAsync();
        }
    }
}
