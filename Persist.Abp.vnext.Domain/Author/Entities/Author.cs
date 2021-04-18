using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Domain.Author.Entities
{
   public class Author: Entity<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public override string Id { get; protected set; } = Guid.NewGuid().ToString();
        protected Author()
        {

        }

        public Author(string id, string name, string description = null)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
        }
    }
}
