namespace UsersService.Domain.DataSeeders;

internal static class PermissionDataSeeder
{
    internal static void SeedData(this EntityTypeBuilder<Permission> builder)
    {
        builder
            .HasData(
                new Permission(
                    1,
                    new Title(Permissions.Users.Get),
                    new Description(Permissions.Users.Get)),
                new Permission(
                    2,
                    new Title(Permissions.Users.Create),
                    new Description(Permissions.Users.Create)),
                new Permission(
                    3,
                    new Title(Permissions.Users.Update),
                    new Description(Permissions.Users.Update)),
                new Permission(
                    4,
                    new Title(Permissions.Users.Delete),
                    new Description(Permissions.Users.Delete)),
                new Permission(
                    5,
                    new Title(Permissions.Users.Export),
                    new Description(Permissions.Users.Export)),
                new Permission(
                    6,
                    new Title(Permissions.Users.Import),
                    new Description(Permissions.Users.Import)));
    }
}