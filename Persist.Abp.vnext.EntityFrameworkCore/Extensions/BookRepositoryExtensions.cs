using Microsoft.EntityFrameworkCore;
using Persist.Abp.vnext.Domain.Book.Entites;
using Persist.Abp.vnext.Domain.Book.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Threading;

namespace Persist.Abp.vnext.EntityFrameworkCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static Chapter FindChapterById(this IBookRepository repository, string id, bool include = true)
        {
            return AsyncHelper.RunSync(() => repository.FindChapterByIdAsync(id, include));
        }

        public static IQueryable<Book> IncludeDetails(this IQueryable<Book> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(book => book.Volumes)
                .ThenInclude(volume => volume.Chapters);
        }
    }
}
