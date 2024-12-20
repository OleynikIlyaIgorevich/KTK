namespace Infra.Services;

public class UserService 
    : BaseService, IUserService
{
    public UserService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
}