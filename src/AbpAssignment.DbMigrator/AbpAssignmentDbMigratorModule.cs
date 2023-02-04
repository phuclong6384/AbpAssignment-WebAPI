using AbpAssignment.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpAssignment.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAssignmentEntityFrameworkCoreModule),
    typeof(AbpAssignmentApplicationContractsModule)
    )]
public class AbpAssignmentDbMigratorModule : AbpModule
{

}
