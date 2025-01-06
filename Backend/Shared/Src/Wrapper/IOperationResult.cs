namespace Shared.Wrapper;

public interface IOperationResult
{
    List<string> Messages { get; set; }

    bool Succeeded { get; set; }
}

public interface IOperationResult<out T> : IOperationResult
{
    T Data { get; }
}
