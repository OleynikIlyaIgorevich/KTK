namespace Infra.Services;

public class SessionService 
    : BaseService, ISessionService
{
    public SessionService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
}