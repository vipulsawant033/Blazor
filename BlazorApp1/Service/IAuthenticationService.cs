using static BlazorApp1.Pages.Login;
using static BlazorApp1.Pages.Register;

namespace BlazorApp1.Service
{
    public interface IAuthenticationService
    {
        event Action AuthenticationStateChanged;

        bool IsAuthenticated { get; }
        string UserName { get; }
        Task<int> RegisterUser(RegisterAccountForm user);
        Task<int> LoginUser(LoginAccountForm user);
        Task Logout();
       
    }
}
