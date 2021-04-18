using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Application.Contracts.Dtos.Book
{
    public class ChapterTextDto : Entity<string>
    {
        public ChapterDto Chapter { get; set; }

        public string Content { get; set; }
        public string AuthorMessage { get; set; }
    }
}
