using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpAssignment.Data;

/* This is used if database provider does't define
 * IAbpAssignmentDbSchemaMigrator implementation.
 */
public class NullAbpAssignmentDbSchemaMigrator : IAbpAssignmentDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
