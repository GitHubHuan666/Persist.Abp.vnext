using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Domain.Book.Entities
{
    public class Book : Entity<string>, IHasCreationTime
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Volume> Volumes { get; protected set; }

        public DateTime CreationTime { get; set; }

        protected Book()
        {

        }

        public Book(
            string id,
            string name,
            string description,
            string authorId,
            string authorName,
            string categoryId,
            string categoryName)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
            AuthorId = authorId;
            AuthorName = Check.NotNullOrWhiteSpace(authorName, nameof(authorName));
            CategoryId = categoryId;
            CategoryName = Check.NotNullOrWhiteSpace(categoryName, nameof(categoryName));
            Volumes = new List<Volume>();
        }

        public void AddVolume(Volume volume)
        {
            if (Volumes.Any(v => v.Title == volume.Title))
            {
                return;
            }

            Volumes.Add(volume);
        }

        public void RemoveVolue(string volumeId)
        {
            Volumes.RemoveAll(v => v.Id == volumeId);
        }
    }
}
