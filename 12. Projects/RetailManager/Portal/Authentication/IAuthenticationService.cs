using Portal.Models;

namespace Portal.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel?> Login(AuthenticationUserModel userForAuthentication);
        Task Logout();
    }
}