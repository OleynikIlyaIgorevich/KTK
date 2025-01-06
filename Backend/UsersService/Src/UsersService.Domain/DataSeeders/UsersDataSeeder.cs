namespace UsersService.Domain.DataSeeders;

internal static class UsersDataSeeder
{
    internal static void SeedData(this EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User(
                id: 1,
                username: new Username("ilya1203"),
                passwordHash: BCrypt.Net.BCrypt.EnhancedHashPassword("12032003"),
                activateUser: true),
            new User(
                id: 2,
                username: new Username("gabitov123"),
                passwordHash: BCrypt.Net.BCrypt.EnhancedHashPassword("12345"),
                activateUser: true));

    

    }
}
