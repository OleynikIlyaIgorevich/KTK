namespace Domain.Configurations;

public class UserConfiguration 
    : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder
            .Property(u => u.Username)
            .HasMaxLength(32);
        builder
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}