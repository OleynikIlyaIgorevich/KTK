using UsersService.Domain.Entities.Base;

namespace UsersService.Domain.Entities;

public class UserEntity : BaseEntity<int>
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public bool IsActive { get; set; } = true;

    public List<SessionEntity> Sessions { get; set; } = [];
    public List<RoleEntity> Roles { get; set; } = [];

    public UserEntity()
    {
    }
    
    internal UserEntity(
        int id,
        string lastName,
        string firstName, 
        string middleName, 
        string username, 
        string passwordHash)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Username = username;    
        PasswordHash = passwordHash;
    }

    public UserEntity(
        string lastName,
        string firstName,
        string middleName,
        string username,
        string passwordHash)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Username = username;
        PasswordHash = passwordHash;
    }
}