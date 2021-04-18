using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Persist.Abp.vnext.EntityFrameworkCore.DbMigrations
{
    [DependsOn(typeof(PersistEntityFrameworkModule))]
    public class PersistEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PersistMigrationsDbContext>();
        }
    }
}
