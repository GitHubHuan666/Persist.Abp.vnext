using Persist.Abp.vnext.Domain.Author.Entities;
using Persist.Abp.vnext.Domain.Author.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Persist.Abp.vnext.EntityFrameworkCore.Repositories
{
    public class AuthorRepository : EfCoreRepository<PersistDbContext, Author, string>, IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<PersistDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
