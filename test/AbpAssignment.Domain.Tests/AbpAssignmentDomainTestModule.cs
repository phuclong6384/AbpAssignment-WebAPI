using AbpAssignment.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpAssignment;

[DependsOn(
    typeof(AbpAssignmentEntityFrameworkCoreTestModule)
    )]
public class AbpAssignmentDomainTestModule : AbpModule
{

}
