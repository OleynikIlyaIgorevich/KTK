namespace UsersService.Domain.Entities.Base;

public abstract class BaseEntity<TId>
{    
    public TId Id { get; protected set; }
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;  
    public DateTime? UpdatedAt { get; set; }
    
    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }
}