using Microsoft.AspNetCore.Components.Authorization;
using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace FermerProject.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        //Используем SessionStorage, чтобы при перезагрузке юзер оставался авторизованным
        private ISessionStorageService _sessionStorageService;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() //Авторизируется. Если юзер зарегистрирован, то название кнопки "Регистрация" сразу меняется на имя юзера
        {
            var userLogin = await _sessionStorageService.GetItemAsync<string>("userLogin");

            ClaimsIdentity identity;
            
            if (userLogin != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userLogin),

                }, "user_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }



            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string userLogin) //Авторизируется (меняется название кнопки "Регистрация" и "Вход"   на   "имя пользователя" и "Выход")
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userLogin),

            }, "user_type");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut() //Сбрасывает авторизацию (меняется название кнопки "имя пользователя" и "Выход"  на  "Регистрация" и "Вход") 
        {
            _sessionStorageService.RemoveItemAsync("userLogin");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
