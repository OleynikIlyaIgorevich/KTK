namespace UsersService.Domain.ValueObjects;

public record FullName
{
    public string Last { get; private set; }
    public string First { get; private set; }
    public string Middle { get; private set; }

    internal FullName(
        string last,
        string first,
        string middle)
    {
        Last = last;
        First = first;
        Middle = middle;
    }

    public static async Task<OperationResult<FullName>> CreateAsync(
        string last, string first, string? middle)
    {
        if (string.IsNullOrWhiteSpace(last))
            return await OperationResult<FullName>.FailAsync("Фамилия не может быть пустой!");

        last = last.Trim();

        if (string.IsNullOrWhiteSpace(first))
            return await OperationResult<FullName>.FailAsync("Имя не может быть пустым!");

        first = first.Trim();

        if (!string.IsNullOrWhiteSpace(middle))
            middle = middle.Trim();

        return await OperationResult<FullName>.SuccessAsync(new FullName(last, first, middle));
    }
}
