using Persist.Abp.vnext.Application.Profiles;
using Persist.Abp.vnext.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Persist.Abp.vnext.Application
{
    [DependsOn(typeof(PersistDomainModule),
        typeof(AbpAutoMapperModule))]
    public class PersistApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AuthorProfile>(true);
            });
        }
    }
  
}
