using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Abp.vnext.Domain.Category.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Persist.Abp.vnext.EntityFrameworkCore.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.ConfigureByConvention();

            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
