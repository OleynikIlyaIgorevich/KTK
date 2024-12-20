namespace Infra.Services.Base;

public abstract class BaseService
{
    protected IUnitOfWork _unitOfWork;

    public BaseService(
        IUnitOfWork _unitOfWork)
    {
        _unitOfWork = _unitOfWork;
    }
}