using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

// Autencitcación 
namespace Drugstore.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(3000); // Tiempo de espera 3 segundos
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity (new List<Claim>
            {
            
            new Claim("FirstName", "Juan"),
            new Claim("LastName", "Cartago"),
            new Claim(ClaimTypes.Name, "juanCar@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin")
        },
        authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}

