using UsersService.Domain.Entities;

namespace UsersService.Domain.Configurations;

public class SessionConfiguration 
    : IEntityTypeConfiguration<SessionEntity>
{
    public void Configure(EntityTypeBuilder<SessionEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Token)
            .HasMaxLength(64);
    }
}