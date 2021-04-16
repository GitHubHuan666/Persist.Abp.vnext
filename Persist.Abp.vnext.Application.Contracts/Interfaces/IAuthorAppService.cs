using Persist.Abp.vnext.Application.Contracts.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Persist.Abp.vnext.Application.Contracts.Interfaces
{
    public interface IAuthorAppService : IApplicationService
    {
        Task CreateAsync(CreateAuthorInput input);

        Task<AuthorDto> GetAsync(string id);

        Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input);

    }
}
