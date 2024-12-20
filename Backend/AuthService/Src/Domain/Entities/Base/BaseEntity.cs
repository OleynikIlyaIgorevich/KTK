namespace Domain.Entities.Base;

public abstract class BaseEntity<TId>
{
    public TId Id { get; protected set; }
    
    public DateTime CreatedAt { get; } = DateTime.UtcNow;  
    public DateTime? UpdatedAt { get; set; }
}