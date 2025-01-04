namespace UsersService.Domain.Entities;

public class Session : BaseEntity<int>
{
    public int UserId { get; set; }
    
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }

    public virtual User User { get; set; }

    internal Session() {  }

    public Session(
        int userId,
        string token,
        DateTime expiresAt)
    {
        UserId = userId;    
        Token = token;
        ExpiresAt = expiresAt;
    }

   
}