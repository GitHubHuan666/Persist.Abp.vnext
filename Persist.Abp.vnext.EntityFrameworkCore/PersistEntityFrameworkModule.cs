using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Persist.Abp.vnext.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule),
         typeof(AbpEntityFrameworkCoreSqlServerModule))]
    public class PersistEntityFrameworkModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PersistDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}
