using LoginBlazorToken.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginBlazorToken.Client.Services
{
    public class AccountService: IAccountService
    {
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		public AccountService(AuthenticationStateProvider authenticationStateProvider)
		{
			_authenticationStateProvider = authenticationStateProvider;
		}
		public bool Login()
		{
			(_authenticationStateProvider as CustomAuthenticationProvider).LoginNotify();
			return true;
		}

		public bool Logout()
		{
			(_authenticationStateProvider as CustomAuthenticationProvider).LogoutNotify();
			return true;
		}
	}
}
