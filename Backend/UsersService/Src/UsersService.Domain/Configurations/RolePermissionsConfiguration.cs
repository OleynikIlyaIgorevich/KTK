﻿namespace UsersService.Domain.Configurations;

public class RolePermissionsConfiguration 
    : IEntityTypeConfiguration<RolePermissions>
{
    public void Configure(EntityTypeBuilder<RolePermissions> builder)
    {
        builder.SeedData();
    }
}