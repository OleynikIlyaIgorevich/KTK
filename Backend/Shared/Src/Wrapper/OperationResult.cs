namespace Shared.Wrapper;

public class OperationResult : IOperationResult 
{
    public OperationResult() { }

    public List<string> Messages { get; set; } = [];

    public bool Succeeded { get; set; }

    public static IOperationResult Fail() => new OperationResult { Succeeded = false };
        

    public static IOperationResult Fail(string message) => new OperationResult { Succeeded = false, Messages = new List<string> { message } };
        

    public static IOperationResult Fail(List<string> messages) => new OperationResult { Succeeded = false, Messages = messages };
        

    public static Task<IOperationResult> FailAsync() => Task.FromResult(Fail());
        

    public static Task<IOperationResult> FailAsync(string message) => Task.FromResult(Fail(message));
        

    public static Task<IOperationResult> FailAsync(List<string> messages) => Task.FromResult(Fail(messages));
        

    public static IOperationResult Success() => new OperationResult { Succeeded = true };
        

    public static IOperationResult Success(string message) => new OperationResult { Succeeded = true, Messages = new List<string> { message } };
        

    public static Task<IOperationResult> SuccessAsync() => Task.FromResult(Success());
        

    public static Task<IOperationResult> SuccessAsync(string message) => Task.FromResult(Success(message));
        
}

public class OperationResult<T> : OperationResult, IResult<T> 
{
    public OperationResult() { }

    public T Data { get; set; }

    public new static OperationResult<T> Fail() => new OperationResult<T> { Succeeded = false };
        
    public new static OperationResult<T> Fail(string message) => new OperationResult<T> { Succeeded = false, Messages = new List<string> { message } };
        
    public new static OperationResult<T> Fail(List<string> messages) => new OperationResult<T> { Succeeded = false, Messages = messages };
        
    public new static Task<OperationResult<T>> FailAsync() => Task.FromResult(Fail());

    public new static Task<OperationResult<T>> FailAsync(string message) => Task.FromResult(Fail(message));
        
    public new static Task<OperationResult<T>> FailAsync(List<string> messages) => Task.FromResult(Fail(messages));

    public new static OperationResult<T> Success() => new OperationResult<T> { Succeeded = true };

    public new static OperationResult<T> Success(string message) => new OperationResult<T> { Succeeded = true, Messages = new List<string> { message } };
        
    public static OperationResult<T> Success(T data) => new OperationResult<T> { Succeeded = true, Data = data };
        
    public static OperationResult<T> Success(T data, string message) => new OperationResult<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };

    public static OperationResult<T> Success(T data, List<string> messages) => new OperationResult<T> { Succeeded = true, Data = data, Messages = messages };
        
    public new static Task<OperationResult<T>> SuccessAsync() => Task.FromResult(Success());
        
    public new static Task<OperationResult<T>> SuccessAsync(string message) => Task.FromResult(Success(message));
        
    public static Task<OperationResult<T>> SuccessAsync(T data) => Task.FromResult(Success(data));

    public static Task<OperationResult<T>> SuccessAsync(T data, string message) => Task.FromResult(Success(data, message));
}
