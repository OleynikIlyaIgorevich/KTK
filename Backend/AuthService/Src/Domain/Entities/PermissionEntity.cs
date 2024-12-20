namespace Domain.Entities;

public class PermissionEntity : BaseEntity, IHaveKey
{
    public int Id { get; }
    public string Title { get; set; }
    public string? Description { get; set; }

    public List<RoleEntity> Roles { get; set; } = [];

    public PermissionEntity()
    {
    }
    
    internal PermissionEntity(
        int id,
        string title,
        string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    
    public PermissionEntity(
        string title,
        string description)
    {
        Title = title;
        Description = description;  
    }

}