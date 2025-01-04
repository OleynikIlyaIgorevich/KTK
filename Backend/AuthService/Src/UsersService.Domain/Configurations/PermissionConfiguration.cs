using UsersService.Domain.Entities;

namespace UsersService.Domain.Configurations;

public class PermissionConfiguration
    : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder
            .Property(p => p.Title)
            .HasMaxLength(64);
        builder
            .HasIndex(p => p.Title)
            .IsUnique();
        
        builder
            .Property(p => p.Description)
            .HasMaxLength(512);
    }
}