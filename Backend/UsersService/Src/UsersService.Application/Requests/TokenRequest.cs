namespace UsersService.Application.Requests;

public record TokenRequest(
    [proteperty: JsonPropertyName("username")]
    string Username,
    [proteperty: JsonPropertyName("password")]
    string Password);