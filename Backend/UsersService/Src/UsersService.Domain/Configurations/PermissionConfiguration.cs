namespace UsersService.Domain.Configurations;

public class PermissionConfiguration
    : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasQueryFilter(
            p => !p.IsDeleted);

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(Title.MAX_LENGHT)
            .HasConversion(
            title => title.Value,
            value => new Title(value));
        builder
            .HasIndex(p => p.Title)
            .IsUnique()
            .HasFilter("'IsDeleted' IS NULL");
        
        builder
            .Property(p => p.Description)
            .IsRequired(false)
            .HasMaxLength(Description.MAX_LENGHT)
            .HasConversion(
            description => description.Value,
            value => new Description(value));
        
        builder
            .HasMany(p => p.Roles)
            .WithMany(r => r.Permissions)
            .UsingEntity<RolePermissions>(
                l => l
                    .HasOne(rp => rp.Role)
                    .WithMany(r => r.RolePermissions)
                    .HasForeignKey(rp => rp.RoleId),
                r => r
                    .HasOne(rp => rp.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(rp => rp.PermissionId));
    }
}