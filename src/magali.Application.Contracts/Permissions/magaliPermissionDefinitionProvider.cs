using Volo.Abp.Authorization.Permissions;

namespace magali.Permissions;

public class magaliPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var magaliGroup = context.AddGroup(magaliPermissions.GroupName);
        
        var authorsPermission = magaliGroup.AddPermission(magaliPermissions.Authors.Default);
        authorsPermission.AddChild(magaliPermissions.Authors.Create);
        authorsPermission.AddChild(magaliPermissions.Authors.Edit);
        authorsPermission.AddChild(magaliPermissions.Authors.Delete);
    }
}
