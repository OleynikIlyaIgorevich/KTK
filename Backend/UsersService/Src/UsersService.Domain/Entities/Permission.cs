
namespace UsersService.Domain.Entities;

public class Permission : BaseEntity<int>
{
    public int Id { get; set; }

    public Title Title { get; set; }
    public Description Description { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<RolePermissions> RolePermissions { get; set; }



    internal Permission() { }
    
    internal Permission(
        int id,
        Title title,
        Description description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    
    public Permission(
        Title title,
        Description description)
    {
        Title = title;
        Description = description;  
    }

}