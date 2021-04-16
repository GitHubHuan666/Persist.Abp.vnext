using AutoMapper;
using Persist.Abp.vnext.Application.Contracts.Dtos.Author;
using Persist.Abp.vnext.Domain.Author.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;

namespace Persist.Abp.vnext.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorInput, Author>()
                .Ignore(author => author.Id);

            CreateMap<Author, AuthorDto>();
        }
    }
}
