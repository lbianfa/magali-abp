using magali.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace magali.Permissions;

public class magaliPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(magaliPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(magaliPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<magaliResource>(name);
    }
}
