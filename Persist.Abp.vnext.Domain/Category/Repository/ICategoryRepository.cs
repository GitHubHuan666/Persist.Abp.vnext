using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Persist.Abp.vnext.Domain.Category.Repository
{
    public interface ICategoryRepository:IRepository<Entities.Category,string>
    {
    }
}
