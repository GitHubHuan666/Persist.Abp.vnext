using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Abp.vnext.Application.Contracts.Dtos.Book
{
    /// <summary>
    /// 小说
    /// </summary>
    public class CreateBookDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<VolumeDto> Volumes { get; protected set; }
    }
}
