namespace UsersService.Application.Requests;

public record RevokeTokenRequest(
    [property: JsonPropertyName("refresh_token")]
    string RefreshToken);