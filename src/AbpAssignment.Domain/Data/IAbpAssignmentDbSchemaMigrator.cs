using System.Threading.Tasks;

namespace AbpAssignment.Data;

public interface IAbpAssignmentDbSchemaMigrator
{
    Task MigrateAsync();
}
