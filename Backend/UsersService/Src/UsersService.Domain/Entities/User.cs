namespace UsersService.Domain.Entities;

public class User : BaseEntity<int>
{
    public Username Username { get; set; }
    public string PasswordHash { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual ICollection<Session> Sessions { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<UserRoles> UserRoles { get; set; }

    internal User() { }
    
    internal User(
        int id,
        Username username, 
        string passwordHash,
        bool activateUser)
    {
        Id = id;
        Username = username;    
        PasswordHash = passwordHash;
        IsActive = activateUser;
    }

    public User(
        Username username,
        string passwordHash,
        bool activateUser)
    {
        Username = username;
        PasswordHash = passwordHash;
        IsActive = activateUser;
    }

 
 
}