namespace UserExample.Api.Inputs
{
    public record RoleCreationData(string roleName, string? description, PermissionType permissionType);
}
