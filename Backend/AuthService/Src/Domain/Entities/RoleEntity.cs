namespace Domain.Entities;

public class RoleEntity : BaseEntity, IHaveKey
{
    public int Id { get; }

    public string Title { get; set; }
    public string? Description { get; set; }

    public List<PermissionEntity> Permissions { get; set; } = [];

    public RoleEntity()
    {
    }
    
    internal RoleEntity(
        int id,
        string title,
        string Description)
    {
        Id = id;
        Title = title;
        Description = Description;
    }

    public RoleEntity(
        string title,
        string description)
    {
        Title = title;  
        Description = description;  
    }
}