namespace UsersService.Domain.ValueObjects;

public record Description
{
    public const int MAX_LENGHT = 512;

    public string Value { get; }

    internal Description(string value) => Value = value;

    public static async Task<OperationResult<Description>> CreateAsync(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return await OperationResult<Description>.SuccessAsync(new Description(value));

        value = value.Trim();

        if (value.Length > MAX_LENGHT)
            return await OperationResult<Description>.FailAsync($"Описание не может быть больше {MAX_LENGHT} символов!");

        return await OperationResult<Description>.SuccessAsync(new Description(value));
    }
}
