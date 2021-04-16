using Persist.Abp.vnext.Domain.Category.Entities;
using Persist.Abp.vnext.Domain.Category.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Persist.Abp.vnext.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfCoreRepository<PersistDbContext, Category, string>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<PersistDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
