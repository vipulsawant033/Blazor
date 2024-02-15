using BlazorApp1.Layout;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static BlazorApp1.Pages.Login;
using static BlazorApp1.Pages.Register;
using static MudBlazor.CategoryTypes;
using NavMenu = BlazorApp1.Layout.NavMenu;

namespace BlazorApp1.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private bool isAuthenticated = false;
        private string userName = string.Empty;
        private readonly HttpClient _httpClient;
        public event Action AuthenticationStateChanged;
        private NavMenu _navMenu;
        public void SetNavMenu(NavMenu navMenu)
        {
            _navMenu = navMenu;
        }

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public bool IsAuthenticated => isAuthenticated;
        public string UserName => userName;

        public async Task<int> RegisterUser(RegisterAccountForm user)
        {
            try
            {
                var jsonUser = JsonSerializer.Serialize(user);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:44393/register", content);
                response.EnsureSuccessStatusCode();
                isAuthenticated = true;
                NotifyAuthenticationStateChanged();

                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                throw;
            }
        }

        public async Task<int> LoginUser(LoginAccountForm user)
        {
            try
            {
                var jsonUser = JsonSerializer.Serialize(user);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:44393/login?useCookies=false&useSessionCookies=false", content);
                response.EnsureSuccessStatusCode();
                isAuthenticated = true;
                NotifyAuthenticationStateChanged();

                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging in user: {ex.Message}");
                throw;
            }
        }
        
        private void NotifyAuthenticationStateChanged()
        {
            AuthenticationStateChanged?.Invoke();
        }
        public async Task Logout()
        {
            // Reset authentication state
            isAuthenticated = false;
            userName = string.Empty;
            // Perform any other cleanup or logout-related tasks
            NotifyAuthenticationStateChanged();
            // Call the Refresh method after logout

        }

    }
}
