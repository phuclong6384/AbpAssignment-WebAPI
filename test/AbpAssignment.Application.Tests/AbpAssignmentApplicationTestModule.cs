using Volo.Abp.Modularity;

namespace AbpAssignment;

[DependsOn(
    typeof(AbpAssignmentApplicationModule),
    typeof(AbpAssignmentDomainTestModule)
    )]
public class AbpAssignmentApplicationTestModule : AbpModule
{

}
