﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace GreenFairy.Data.Authentication
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly ProtectedSessionStorage protectedSessionStorage;
		private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());

		public CustomAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage)
		{
			this.protectedSessionStorage = protectedSessionStorage;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			try
			{

				var result = await protectedSessionStorage.GetAsync<UserSession>("UserSession");
				var userSession = result.Success ? result.Value : null;
				if (userSession is null)
				{
					return await Task.FromResult(new AuthenticationState(anonymous));
				}

				var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
			{
				new Claim(ClaimTypes.Name, userSession.UserName),
				new Claim(ClaimTypes.Role, userSession.Role),
			}, "CustomAuth"));

				return await Task.FromResult(new AuthenticationState(claimsPrincipal));
			}
			catch (Exception)
			{
				//TODO: Вставить логер
				return await Task.FromResult(new AuthenticationState(anonymous));
			}
		}

		public async Task UpdateAuthenticationState(UserSession userSession)
		{
			ClaimsPrincipal claimsPrincipal;
			if (userSession is not null)
			{
				await protectedSessionStorage.SetAsync("UserSession", userSession);
				claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
			{
				new Claim(ClaimTypes.Name, userSession.UserName),
				new Claim(ClaimTypes.Role, userSession.Role),
			}));
			}
			else
			{
				await protectedSessionStorage.DeleteAsync("UserSession");
				claimsPrincipal = anonymous;
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}
	}
}
