namespace Domain.Configurations;

public class RoleConfiguration 
    : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder
            .Property(r => r.Title)
            .HasMaxLength(64);
        builder
            .HasIndex(r => r.Title)
            .IsUnique();
        
        builder
            .Property(r => r.Description)
            .HasMaxLength(512);
    }
}