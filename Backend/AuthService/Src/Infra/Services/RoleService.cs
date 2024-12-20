namespace Infra.Services;

public class RoleService
    : BaseService, IRoleService
{
    public RoleService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
}