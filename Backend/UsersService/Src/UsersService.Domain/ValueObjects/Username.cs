namespace UsersService.Domain.ValueObjects;

public record Username
{
    public const int MAX_LENGHT = 32;
    public const int MIN_LENGHT = 4;

    public string Value { get; }

    internal Username(string value) =>  Value = value;

    public static async Task<OperationResult<Username>> CreateAsync(
        string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return await OperationResult<Username>.FailAsync("Имя пользователя не может быть пустым!");

        value = value.Trim();

        if (MIN_LENGHT < value.Length || value.Length > MAX_LENGHT)
            return await OperationResult<Username>.FailAsync($"Имя пользовотеля не может быть меньше {MIN_LENGHT} и не больше {MAX_LENGHT} символов!");

        return await OperationResult<Username>.SuccessAsync(new Username(value));
    }
}
