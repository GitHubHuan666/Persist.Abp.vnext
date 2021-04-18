using Persist.Abp.vnext.Domain.Book.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Persist.Abp.vnext.Domain.Book.Services
{
    public interface IBookDomainService : IDomainService
    {
        Task<Entities.Book> CreateBook(Entities.Book book);

        Task UpdateBook(Entities.Book book);

        Task RemoveBook(Entities.Book book);

        Task<Entities.Book> FindBookById(string id);

        Task<Volume> CreateVolume(Entities.Book book, Volume volume);

        Task<Chapter> CreateChapter(Entities.Book book, Volume volume, Chapter chapter);
    }
}
