using Persist.Abp.vnext.Domain.Book.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Persist.Abp.vnext.Domain.Book.Repository
{
    public interface IBookRepository : IRepository<Entites.Book, string>
    {
        Task<Chapter> FindChapterByIdAsync(string id, bool include = true,
            CancellationToken cancellationToken = default);
    }
}
