using AbpAssignment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpAssignment.Permissions;

public class AbpAssignmentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpAssignmentPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpAssignmentPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpAssignmentResource>(name);
    }
}
