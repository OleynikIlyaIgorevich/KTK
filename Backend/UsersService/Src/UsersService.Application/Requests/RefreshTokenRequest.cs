namespace UsersService.Application.Requests;

public record RefreshTokenRequest(
    [property: JsonPropertyName("access_token")]
    string AccessToken,
    [property: JsonPropertyName("refresh_token")]
    string RefreshToken);