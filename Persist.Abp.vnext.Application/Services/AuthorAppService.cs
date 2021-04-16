﻿using Microsoft.EntityFrameworkCore;
using Persist.Abp.vnext.Application.Contracts.Dtos.Author;
using Persist.Abp.vnext.Application.Contracts.Interfaces;
using Persist.Abp.vnext.Domain.Author.Entities;
using Persist.Abp.vnext.Domain.Author.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Persist.Abp.vnext.Application.Services
{
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAtuthorRepository _authorRepository;

        public AuthorAppService(IAtuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task CreateAsync(CreateAuthorInput input)
        {
            var author = ObjectMapper.Map<CreateAuthorInput, Author>(input);
            await _authorRepository.InsertAsync(author);
        }

        public async Task<AuthorDto> GetAsync(string id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var count = await _authorRepository.CountAsync();
            var list = await _authorRepository.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<AuthorDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
            };
        }
    }
    
}
