using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Persist.Abp.vnext.Domain.Category.Entities
{
    public class Category : Entity<string>
    {
        public string Name { get; set; }

        protected Category()
        {

        }

        public Category(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
