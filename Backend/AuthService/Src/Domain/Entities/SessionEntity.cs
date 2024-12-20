namespace Domain.Entities;

public class SessionEntity : BaseEntity, IHaveKey
{
    public int Id { get; }
    public int UserId { get; set; }
    
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }

    public SessionEntity()
    {
    }

    public SessionEntity(
        int userId,
        string token,
        DateTime expiresAt)
    {
        UserId = userId;    
        Token = token;
        ExpiresAt = expiresAt;
    }
}