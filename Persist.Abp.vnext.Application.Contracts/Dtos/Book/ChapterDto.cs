using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Application.Contracts.Dtos.Book
{
    public class ChapterDto : Entity<string>, IHasCreationTime
    {
        public VolumeDto Volume { get; set; }

        public string Title { get; set; }

        public int WordsNumber { get; set; }

        public ChapterTextDto ChapterText { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
