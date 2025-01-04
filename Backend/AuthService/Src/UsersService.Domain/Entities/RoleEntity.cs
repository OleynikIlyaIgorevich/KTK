using UsersService.Domain.Entities.Base;

namespace UsersService.Domain.Entities;

public class RoleEntity : BaseEntity<int>
{
    public string Title { get; set; }
    public string? Description { get; set; }

    public List<PermissionEntity> Permissions { get; set; } = [];

    internal RoleEntity()
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