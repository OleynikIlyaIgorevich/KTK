namespace UsersService.Infra.Services;

public class AccountService 
    : BaseService, IAccountService
{
    public AccountService(
        IUnitOfWork _unitOfWork)
        : base(_unitOfWork)
    {
    }
}