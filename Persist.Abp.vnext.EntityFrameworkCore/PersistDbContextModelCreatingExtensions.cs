using Microsoft.EntityFrameworkCore;
using Persist.Abp.vnext.EntityFrameworkCore.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Abp.vnext.EntityFrameworkCore
{
    public static class PersistDbContextModelCreatingExtensions
    {
        public static void ConfigurePersist(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new ChapterMap());
            builder.ApplyConfiguration(new ChapterTextMap());
            builder.ApplyConfiguration(new VolumeMap());
        }
    }
}
