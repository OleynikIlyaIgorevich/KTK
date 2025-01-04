using UsersService.Domain.Entities.Base;

namespace UsersService.Domain.Entities;

public class Role : BaseEntity<int>
{
    public Title Title { get; set; }
    public Description Description { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; }
    public virtual ICollection<RolePermissions> RolePermissions { get; set; }

    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<UserRoles> UserRoles { get; set; }

    internal Role() {  }
    
    internal Role(
        int id,
        Title title,
        Description description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Role(
        Title title,
        Description description)
    {
        Title = title;  
        Description = description;  
    }
}