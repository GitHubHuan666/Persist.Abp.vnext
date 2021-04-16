using Microsoft.Extensions.DependencyInjection;
using Persist.Abp.vnext.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Persist.Abp.vnext.TestBase
{
    [DependsOn(typeof(AbpAutofacModule),
         typeof(AbpTestBaseModule),
         typeof(PersistDomainModule))]
    public class PersistTestBaseModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                using var scope = context.ServiceProvider.CreateScope();
                await scope.ServiceProvider.GetRequiredService<IDataSeeder>().SeedAsync();
            });
        }
    }
}
