namespace Infra.Services;

public class PermissionService 
    : BaseService, IPermissionService
{
    public PermissionService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
}