namespace UsersService.Domain.Configurations;

public class UserConfiguration 
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(
            u => !u.IsDeleted);

        builder.HasKey(u => u.Id);

        builder.OwnsOne(u => u.FullName, fullname =>
        {
            fullname
                .Property(fn => fn.Last)
                .IsRequired()
                .HasColumnName("LastName");
            fullname
                .Property(fn => fn.First)
                .IsRequired()
                .HasColumnName("FirstName");
            fullname
                .Property(fn => fn.Middle)
                .IsRequired(false)
                .HasColumnName("MiddleName");
        });

        builder
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(Username.MAX_LENGHT)
            .HasConversion(
            username => username.Value,
            value => new Username(value));
        builder
            .HasIndex(u => u.Username)
            .IsUnique()
            .HasFilter("'IsDeleted' IS NULL");

        builder
            .Property(u => u.PasswordHash)
            .IsRequired();
        
        builder
            .HasMany(u => u.Sessions)
            .WithOne(s => s.User);

        builder
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRoles>(
                l => l
                    .HasOne(ur => ur.Role)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.RoleId),
                r => r
                    .HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId));
        
    }
}