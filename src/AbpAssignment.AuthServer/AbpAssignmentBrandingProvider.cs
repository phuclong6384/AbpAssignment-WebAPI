using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpAssignment;

[Dependency(ReplaceServices = true)]
public class AbpAssignmentBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpAssignment";
}
