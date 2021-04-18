using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Persist.Abp.vnext.EntityFrameworkCore.DbMigrations
{
    public class PersistMigrationsDbContextFactory : IDesignTimeDbContextFactory<PersistMigrationsDbContext>
    {
        public PersistMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<PersistMigrationsDbContext>()
                .UseSqlServer(
                    configuration.GetConnectionString("Persist"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            return new PersistMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
