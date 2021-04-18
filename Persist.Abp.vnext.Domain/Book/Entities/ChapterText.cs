using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Domain.Book.Entities
{
    public class ChapterText : Entity<string>
    {
        public string Content { get; set; }
        public string Memo { get; set; }
        public override string Id { get; protected set; } = Guid.NewGuid().ToString();
        protected ChapterText()
        {

        }

        public ChapterText(
            string content, string memo = null)
        {
            Content = content;
            Memo = memo;
        }
    }
}
