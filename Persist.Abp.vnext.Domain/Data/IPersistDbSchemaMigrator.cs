using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persist.Abp.vnext.Domain.Data
{
    public interface   IPersistDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
