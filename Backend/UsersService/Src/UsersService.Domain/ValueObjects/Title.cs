namespace UsersService.Domain.ValueObjects;

public record Title
{
    public const int MAX_LENGHT = 64;
    public const int MIN_LENGHT = 4;

    public string Value { get; }

    internal Title(string value) => Value = value;

    public static async Task<OperationResult<Title>> CreateAsync(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return await OperationResult<Title>.FailAsync("Заголовок не может быть пустым!");

        value = value.Trim();

        if (MIN_LENGHT > value.Length || value.Length > MAX_LENGHT)
            return await OperationResult<Title>.FailAsync($"Заголовок должен иметь минимум {MIN_LENGHT} и не больше {MAX_LENGHT}!");

        return await OperationResult<Title>.SuccessAsync(new Title(value));
    }
}
