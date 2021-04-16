using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Persist.Abp.vnext.Domain.Author.Entities;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;


namespace Persist.Abp.vnext.EntityFrameworkCoreTest.UnitTests
{
    public class AuthorRepositoryTests : PersistEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Author, string> _auhorReposity;
        private readonly IGuidGenerator _guidGenerator;

        public AuthorRepositoryTests()
        {
            _auhorReposity = GetRequiredService<IRepository<Author, string>>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Author()
        {
            var result = await _auhorReposity.InsertAsync(new Author(
                _guidGenerator.Create().ToString(), "张家老三", "不知名小说作家"));
     
           result.Id.ShouldNotBe(default);
        }

        [Fact]
        public async Task Should_Get_List_Of_Author()
        {
            var result = await _auhorReposity.GetListAsync();
            result.Count.ShouldBeGreaterThan(0);
        }
    }
}
