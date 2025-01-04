using UsersService.Infra.Services.Base;

namespace UsersService.Infra.Services;

public class RoleService
    : BaseService, IRoleService
{
    public RoleService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
}