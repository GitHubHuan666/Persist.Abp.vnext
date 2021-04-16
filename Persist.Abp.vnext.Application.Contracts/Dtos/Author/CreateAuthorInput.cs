using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Persist.Abp.vnext.Application.Contracts.Dtos.Author
{
    public class CreateAuthorInput : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
