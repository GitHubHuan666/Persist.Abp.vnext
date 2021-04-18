using Persist.Abp.vnext.EntityFrameworkCoreTest;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Persist.Abp.vnext.Application.Test
{
    [DependsOn(typeof(PersistApplicationModule),
       typeof(PersistEntityFrameworkCoreTestModule))]
    public class PersistApplicationTestModule:AbpModule
    {

    }
}
