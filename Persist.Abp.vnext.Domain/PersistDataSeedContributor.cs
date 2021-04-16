using Persist.Abp.vnext.Domain.Book.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Persist.Abp.vnext.Domain
{
    public class PersistDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Author.Entities.Author, string> _authorRepository;
        private readonly IRepository<Book.Entites.Book, string> _bookRepository;
        private readonly IRepository<Category.Entities.Category, string> _categoryRepository;
        private readonly List<Guid> _guids;

        public PersistDataSeedContributor(
            IRepository<Author.Entities.Author, string> authorRepository,
            IRepository<Book.Entites.Book, string> bookRepository,
            IRepository<Category.Entities.Category, string> categoryRepository,
            IGuidGenerator guidGenerator)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _guids = new List<Guid>();

            for (int i = 0; i < 3; i++)
            {
                _guids.Add(guidGenerator.Create());
            }
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateAuthorAsync();
            await CreateBookAsync();
            await CreateCategoryAsync();
        }

        public async Task CreateAuthorAsync()
        {
            var book = new Author.Entities.Author(
                _guids[0].ToString(),
                "南派三叔",
                "盗墓笔记作者"
            );

            await _authorRepository.InsertAsync(book);
        }

        public async Task CreateCategoryAsync()
        {
            var category = new Category.Entities.Category(
                _guids[1].ToString(),
                "奇幻"
            );

            await _categoryRepository.InsertAsync(category);
        }


        public async Task CreateBookAsync()
        {

            var book = new Book.Entites.Book(
                _guids[2].ToString(),
                "盗墓笔记",
                "盗墓题材小说，讲述古墓探险的故事",
                _guids[0].ToString(),
                "南派三叔",
                _guids[1].ToString(),
                "奇幻"
            );

            book.AddVolume(new Volume("七星鲁王宫"));
            book.Volumes[0].AddChapter(new Chapter("第一章", "正文1"));

            await _bookRepository.InsertAsync(book);
        }
    }
}
