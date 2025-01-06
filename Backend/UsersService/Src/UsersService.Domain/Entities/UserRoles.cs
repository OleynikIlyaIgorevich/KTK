namespace UsersService.Domain.Entities;

public class UserRoles
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public virtual User User { get; set; }
    public virtual Role Role { get; set; }

    internal UserRoles() { }

    internal UserRoles(
        int userId, int roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}
