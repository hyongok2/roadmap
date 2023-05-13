using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Portal.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Portal.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _stateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly IConfiguration _configuration;
        private readonly string? _authTokenStorageKey;

        public AuthenticationService(HttpClient client,
                                    AuthenticationStateProvider stateProvider,
                                    ILocalStorageService localStorage,
                                    IConfiguration configuration)
        {
            _client = client;
            _stateProvider = stateProvider;
            _localStorage = localStorage;
            _configuration = configuration;
            _authTokenStorageKey = _configuration["authTokenStorageKey"];
        }

        public async Task<AuthenticatedUserModel?> Login(AuthenticationUserModel userForAuthentication)
        {
            try
            {
                var data = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username", userForAuthentication.Email),
                new KeyValuePair<string, string>("password", userForAuthentication.Password)
                });

                string api = _configuration["api"] + _configuration["tokenEndpoint"];

                var authResult = await _client.PostAsync(api, data);
                var authContent = await authResult.Content.ReadAsStringAsync();

                if (authResult.IsSuccessStatusCode == false)
                {
                    return null;
                }

                var result = JsonSerializer.Deserialize<AuthenticatedUserModel>(
                    authContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result is not null)
                {
                    await _localStorage.SetItemAsync(_authTokenStorageKey, result.Access_Token);

                    await ((AuthStateProvider)_stateProvider).NotifyUserAuthentication(result.Access_Token);

                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Access_Token);
                }

                return result;
            }
            catch// (Exception ex)
            {
                //throw new Exception(ex.Message);
                return null; // 추후 로깅이나 리턴 타입 보강 필요
            }
        }

        public async Task Logout()
        {
            await ((AuthStateProvider)_stateProvider).NotifyUserLogOut();
        }
    }
}
