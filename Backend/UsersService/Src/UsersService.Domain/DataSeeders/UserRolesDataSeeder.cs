namespace UsersService.Domain.DataSeeders;

internal static class UserRolesDataSeeder
{
    internal static void SeedData(
        this EntityTypeBuilder<UserRoles> builder)
    {
        builder
            .HasData(
                new UserRoles(
                    1, 1),
                new UserRoles(
                    2, 3));
    }
}