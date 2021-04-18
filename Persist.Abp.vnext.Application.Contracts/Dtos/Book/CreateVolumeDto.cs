using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Abp.vnext.Application.Contracts.Dtos.Book
{
    public class CreateVolumeDto
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
