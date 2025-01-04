namespace UsersService.Domain.Configurations;

public class SessionConfiguration 
    : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder
            .HasQueryFilter(
            s => !s.IsDeleted);

        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Token)
            .IsRequired();

        builder
            .Property(s => s.ExpiresAt)
            .IsRequired();

        builder
            .HasOne(s => s.User)
            .WithMany(u => u.Sessions)
            .HasForeignKey(s => s.UserId);
    }
}