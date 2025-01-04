using UsersService.Domain.Entities;

namespace UsersService.Domain.Configurations;

public class RoleConfiguration 
    : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .HasQueryFilter(
            r => !r.IsDeleted);

        builder.HasKey(r => r.Id);
        
        builder
            .Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(Title.MAX_LENGHT)
            .HasConversion(
            title => title.Value,
            value => new Title(value));
        builder
            .HasIndex(r => r.Title)
            .IsUnique()
            .HasFilter("'IsDeleted' IS NULL");
        
        builder
            .Property(r => r.Description)
            .IsRequired(false)
            .HasMaxLength(Description.MAX_LENGHT)
            .HasConversion(
            description => description.Value,
            value => new Description(value));

        builder
            .HasMany(r => r.Permissions)
            .WithMany(r => r.Roles)
            .UsingEntity<RolePermissions>(
                l => l
                    .HasOne(rp => rp.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(rp => rp.PermissionId),
                r => r
                    .HasOne(rp => rp.Role)
                    .WithMany(r => r.RolePermissions)
                    .HasForeignKey(rp => rp.RoleId));
    }
}