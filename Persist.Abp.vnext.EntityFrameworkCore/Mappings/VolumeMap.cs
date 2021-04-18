using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Abp.vnext.Domain.Book.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Persist.Abp.vnext.EntityFrameworkCore.Mappings
{
    public class VolumeMap : IEntityTypeConfiguration<Volume>
    {
        public void Configure(EntityTypeBuilder<Volume> builder)
        {
            builder.ToTable(nameof(Volume));

            builder.ConfigureByConvention();

            builder.Property(volume => volume.Title)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(volume => volume.Description)
                .HasMaxLength(100);
        }
    }
}
