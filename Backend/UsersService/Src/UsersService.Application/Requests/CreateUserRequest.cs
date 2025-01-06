namespace UsersService.Application.Requests;

public record CreateUserRequest(
    [property: JsonPropertyName("last_name")] 
    string LastName,
    [property: JsonPropertyName("first_name")]
    string FirstName,
    [property: JsonPropertyName("middle_name")]
    string? MiddleName,

    [property: JsonPropertyName("username")]
    string Username,
    [property: JsonPropertyName("password")] 
    string Password,

    [property: JsonPropertyName("activate_user")]
    bool ActivateUser);
