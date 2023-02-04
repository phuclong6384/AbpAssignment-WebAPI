using Volo.Abp.Settings;

namespace AbpAssignment.Settings;

public class AbpAssignmentSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpAssignmentSettings.MySetting1));
    }
}
