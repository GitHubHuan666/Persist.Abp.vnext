using Persist.Abp.vnext.Domain.Book.Entites;
using Persist.Abp.vnext.Domain.Book.Repository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using Xunit;

namespace Persist.Abp.vnext.EntityFrameworkCoreTest.UnitTests
{
    public class BookRepositoryTests : PersistEntityFrameworkCoreTestBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGuidGenerator _guidGenerator;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IBookRepository>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Book()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = new Book(
                    _guidGenerator.Create().ToString(),
                    "三体",
                    "地球人类文明和三体文明",
                    _guidGenerator.Create().ToString(),
                    "刘慈欣",
                    _guidGenerator.Create().ToString(),
                    "科幻");

                return await _bookRepository.InsertAsync(book);
            });

            result.CreationTime.ShouldNotBe(default);
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Volume()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "盗墓笔记");
                book.AddVolume(new Volume("秦岭神树"));
                return await _bookRepository.UpdateAsync(book);
            });

            result.Volumes.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Chapter()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "盗墓笔记");
                book.Volumes[0].AddChapter(new Chapter("第二章", "正文2"));
                return await _bookRepository.UpdateAsync(book);
            });

            result.Volumes[0].Chapters.Count.ShouldBe(2);
        }


        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await WithUnitOfWorkAsync(async () =>
                await _bookRepository.GetListAsync());

            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_A_Book_Without_Catalog()
        {
            var result = await WithUnitOfWorkAsync(async () =>
                await _bookRepository.GetAsync(b => b.Name == "盗墓笔记")
                );

            result.ShouldNotBeNull();
            result.Volumes.Count.ShouldBe(1);
            result.Volumes[0].Chapters.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_A_Chapter()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "盗墓笔记");
                var chapterId = book.Volumes[0].Chapters[0].Id;
                return await _bookRepository.FindChapterByIdAsync(chapterId);
            });

            result.ShouldNotBeNull();
            result.WordsNumber.ShouldBeGreaterThan(0);
            result.ChapterText.ShouldNotBeNull();
            result.ChapterText.Content.ShouldNotBeNullOrEmpty();
        }
    }
}
