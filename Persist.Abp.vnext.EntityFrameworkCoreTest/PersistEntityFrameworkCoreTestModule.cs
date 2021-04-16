using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Persist.Abp.vnext.EntityFrameworkCore;
using Persist.Abp.vnext.TestBase;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Persist.Abp.vnext.EntityFrameworkCoreTest
{
    [DependsOn(
       typeof(AbpEntityFrameworkCoreSqliteModule),
       typeof(PersistTestBaseModule),
       typeof(PersistEntityFrameworkModule)
   )]
    public class PersistEntityFrameworkCoreTestModule : AbpModule
    {
        private SqliteConnection _sqliteConnection;

        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<PersistDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new PersistDbContext(options);
            context.GetService<IRelationalDatabaseCreator>().CreateTables();

            return connection;
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            _sqliteConnection = CreateDatabaseAndGetConnection();

            context.Services.Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(configurationContext =>
                    configurationContext.DbContextOptions.UseSqlite(_sqliteConnection)
                );
            });
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            _sqliteConnection.Dispose();
        }
    }
}
