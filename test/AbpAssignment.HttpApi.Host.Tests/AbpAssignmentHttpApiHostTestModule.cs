using Volo.Abp.Modularity;

namespace AbpAssignment;

[DependsOn(
    typeof(AbpAssignmentApplicationTestModule)
    )]
public class AbpAssignmentHttpApiHostTestModule : AbpModule
{

}
