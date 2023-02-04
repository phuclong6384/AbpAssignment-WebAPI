using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpAssignment.Data;
using Volo.Abp.DependencyInjection;

namespace AbpAssignment.EntityFrameworkCore;

public class EntityFrameworkCoreAbpAssignmentDbSchemaMigrator
    : IAbpAssignmentDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpAssignmentDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpAssignmentDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpAssignmentDbContext>()
            .Database
            .MigrateAsync();
    }
}
