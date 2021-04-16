using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Persist.Abp.vnext.Service
{
    public class ServiceModule:AbpModule
    {
        /// <summary>
        /// 加载模块的配置
        /// </summary>
        /// <param name="context"></param>
        public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {
            PreConfigure<ServiceModulePreOptions>(options => options.IsEnable = true);
        }
        /// <summary>
        /// 模块的配置
        /// </summary>
        /// <param name="context"></param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var PreOptions = context.Services.ExecutePreConfiguredActions<ServiceModulePreOptions>();
            if (PreOptions.IsEnable)
            {
                context.Services.AddTransient<TestService>();
            }
            
        }
        /// <summary>
        /// 模块覆盖的配置
        /// </summary>
        /// <param name="context"></param>
        public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {
            base.OnPostApplicationInitialization(context);
        }
    }
}
