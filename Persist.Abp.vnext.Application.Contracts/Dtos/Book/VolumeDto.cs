using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Application.Contracts.Dtos.Book
{
    public class VolumeDto : Entity<string>, IHasCreationTime
    {
        public virtual BookDto Book { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<ChapterDto> Chapters { get; protected set; }

        public DateTime CreationTime { get; set; }
    }
}
