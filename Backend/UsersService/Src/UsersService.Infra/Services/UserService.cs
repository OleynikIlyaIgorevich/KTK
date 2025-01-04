using UsersService.Infra.Services.Base;

namespace UsersService.Infra.Services;

public class UserService 
    : BaseService, IUserService
{
    public UserService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
}