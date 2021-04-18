using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Persist.Abp.vnext.Application.Contracts.Dtos.Category
{
    public class CategoryDto : EntityDto<string>
    {
        public string Name { get; set; }
    }
}
