using Microsoft.EntityFrameworkCore;
using Persist.Abp.vnext.Domain.Book.Entites;
using Persist.Abp.vnext.Domain.Book.Repository;
using Persist.Abp.vnext.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Persist.Abp.vnext.EntityFrameworkCore.Repositories
{
    public class BookRepository : EfCoreRepository<PersistDbContext, Book, string>, IBookRepository
    {
        public BookRepository(IDbContextProvider<PersistDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Chapter> FindChapterByIdAsync(string id, bool include = true, CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Chapters
                .IncludeIf(include, chapter => chapter.ChapterText)
                .FirstOrDefaultAsync(chapter => chapter.Id == id,
                    GetCancellationToken(cancellationToken));
            return result;
        }

        public override IQueryable<Book> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }
    }
}
