namespace UsersService.Domain.DataSeeders;

internal static class RolesDataSeeder
{
    internal static void SeedData(this EntityTypeBuilder<Role> builder)
    {
        builder
            .HasData(
                new Role(
                    id: 1,
                    title: new Title(Roles.SuperUser),
                    description: new Description(Roles.SuperUser)),
                new Role(
                    id: 2,
                    title: new Title(Roles.ScheduleOperator),
                    description: new Description(Roles.ScheduleOperator)),
                new Role(
                    id: 3,
                    title: new Title(Roles.Teacher),
                    description: new Description(Roles.Teacher)),
                new Role(
                    id: 4,
                    title: new Title(Roles.Student),
                    description: new Description(Roles.Student)));
    }
}
