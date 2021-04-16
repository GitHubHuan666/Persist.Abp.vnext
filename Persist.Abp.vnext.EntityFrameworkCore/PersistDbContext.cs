using Microsoft.EntityFrameworkCore;
using Persist.Abp.vnext.Domain.Author.Entities;
using Persist.Abp.vnext.Domain.Book.Entites;
using Persist.Abp.vnext.Domain.Category.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Persist.Abp.vnext.EntityFrameworkCore
{
    [ConnectionStringName("Persist")]
    public class PersistDbContext : AbpDbContext<PersistDbContext>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ChapterText> ChapterTexts { get; set; }

        public PersistDbContext(DbContextOptions<PersistDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
