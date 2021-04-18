using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persist.Abp.vnext.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace Persist.Abp.vnext.DbMigration
{
    public class DbMigratorHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger<DbMigratorHostedService> _logger;

        public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, ILogger<DbMigratorHostedService> logger)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var application = AbpApplicationFactory.Create<PersistDbMigratorModule>(options =>
            {
                options.UseAutofac();
            });

            application.Initialize();

            _logger.LogInformation("开始执行数据迁移……");
            await application
                .ServiceProvider
                .GetRequiredService<PersistDbMigrationService>()
                .MigrateAsync();

            application.Shutdown();

            _hostApplicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("数据迁移已完成。");
            return Task.CompletedTask;
        }
    }
}
