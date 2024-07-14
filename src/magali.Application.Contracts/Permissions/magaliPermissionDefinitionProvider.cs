using magali.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace magali.Permissions;

public class magaliPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var magaliGroup = context.AddGroup(magaliPermissions.GroupName, L("Permission:Magali"));
        
        var authorsPermission = magaliGroup.AddPermission(magaliPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(magaliPermissions.Authors.Create, L("Permissions:Authors.Create"));
        authorsPermission.AddChild(magaliPermissions.Authors.Edit, L("Permissions:Authors.Edit"));
        authorsPermission.AddChild(magaliPermissions.Authors.Delete, L("Permissions:Authors.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<magaliResource>(name);
    }
}
