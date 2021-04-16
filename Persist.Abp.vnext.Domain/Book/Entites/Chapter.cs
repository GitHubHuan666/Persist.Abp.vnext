using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Domain.Book.Entites
{
    public class Chapter : Entity<string>, IHasCreationTime
    {
        public Volume Volume { get; set; }
        public string VolumeId { get; set; } = "";

        public string Title { get; set; }
        public ChapterText ChapterText { get; protected set; }

        public int WordsNumber { get; set; }

        public DateTime CreationTime { get; set; }

        public override string Id { get; protected set; } =Guid.NewGuid().ToString();
        protected Chapter()
        {

        }

        public Chapter(string title, string content)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            WordsNumber = content.Length;
            ChapterText = new ChapterText(content);
        }
    }
}
