namespace UsersService.Domain.DataSeeders;

internal static class RolePermissionsDataSeeder
{
    internal static void SeedData(
        this EntityTypeBuilder<RolePermissions> builder)
    {
        builder
            .HasData(
                new RolePermissions(
                    1, 1),
                new RolePermissions(
                    1, 2),
                new RolePermissions(
                    1, 3),
                new RolePermissions(
                    1, 4),
                new RolePermissions(
                    1, 5),
                new RolePermissions(
                    1, 6));
    }
}