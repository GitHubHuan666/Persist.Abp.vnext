using Persist.Abp.vnext.Domain;
using Persist.Abp.vnext.EntityFrameworkCore.DbMigrations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Persist.Abp.vnext.DbMigration
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(PersistEntityFrameworkCoreDbMigrationsModule),
        typeof(PersistDomainModule))]
    public class PersistDbMigratorModule : AbpModule
    {

    }
}
