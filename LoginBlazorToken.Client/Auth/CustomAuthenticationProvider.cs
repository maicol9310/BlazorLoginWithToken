using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using LoginBlazorToken.Client.Helpers;

namespace LoginBlazorToken.Client.Auth
{
    //public class CustomAuthenticationProvider : AuthenticationStateProvider
    //{
    //    private ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
    //    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //    {
    //        await Task.FromResult(0);
    //        return new AuthenticationState(claimsPrincipal);
    //    }

    //    public void LoginNotify()
    //    {
    //        var identity = new ClaimsIdentity(new[]
    //        {
    //            new Claim(ClaimTypes.Name, "Test"),
    //            new Claim(ClaimTypes.Email, "test@test.com")
    //            }, "Fake Authentication");
    //        claimsPrincipal = new ClaimsPrincipal(identity);
    //        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    //    }

    //    public void LogoutNotify()
    //    {
    //        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
    //        claimsPrincipal = anonymous;
    //        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    //    }
    //}

    #region WithToken
    public class CustomAuthenticationProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthenticationProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            string token = await _localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                var anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity() { }));
                return anonymous;
            }
            var userClaimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "Fake Authentication"));
            var loginUser = new AuthenticationState(userClaimPrincipal);
            return loginUser;
        }

        public void Notify()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
    #endregion
}
