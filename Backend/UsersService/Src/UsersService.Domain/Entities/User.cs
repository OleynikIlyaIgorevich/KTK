namespace UsersService.Domain.Entities;

public class User : BaseEntity<int>
{
    public FullName FullName { get; }
    public Username Username { get; set; }
    public string PasswordHash { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual ICollection<Session> Sessions { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<UserRoles> UserRoles { get; set; }

    internal User() { }
    
    internal User(
        int id,
        FullName fullName,
        Username username, 
        string passwordHash,
        bool activateUser)
    {
        Id = id;
        FullName = fullName;
        Username = username;    
        PasswordHash = passwordHash;
        IsActive = activateUser;
    }

    public User(
        FullName fullName,
        Username username,
        string passwordHash,
        bool activateUser)
    {
        FullName = fullName;
        Username = username;
        PasswordHash = passwordHash;
        IsActive = activateUser;
    }

 
 
}