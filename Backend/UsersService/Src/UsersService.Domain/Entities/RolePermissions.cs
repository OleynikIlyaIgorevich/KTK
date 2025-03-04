﻿namespace UsersService.Domain.Entities;

public class RolePermissions
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public virtual Role Role { get; set; }
    public virtual Permission Permission { get; set; }

    internal RolePermissions() { }

    internal RolePermissions(
        int roleId,
        int permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }
}
