using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Persist.Abp.vnext.EntityFrameworkCore.DbMigrations
{
    [ConnectionStringName("Novel")]
    public class PersistMigrationsDbContext : AbpDbContext<PersistMigrationsDbContext>
    {
        public PersistMigrationsDbContext(DbContextOptions<PersistMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigurePersist();
        }
    }
}
