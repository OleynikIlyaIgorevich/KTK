using UsersService.Domain.Entities.Base;

namespace UsersService.Domain.Entities;

public class PermissionEntity : BaseEntity<int>
{
    public string Title { get; set; }
    public string? Description { get; set; }

    public List<RoleEntity> Roles { get; set; } = [];

    internal PermissionEntity()
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