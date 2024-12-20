namespace Infra.Services;

public class TokenService 
    : BaseService, ITokenService
{
    public TokenService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
}