using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

// Autencitcación 
namespace Drugstore.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
<<<<<<< Updated upstream
            await Task.Delay(1000); // Tiempo de espera 3 segundos para comprobar la autorización 
=======
            //await Task.Delay(3000); // Tiempo de espera 3 segundos para comprobar la autorización 
>>>>>>> Stashed changes
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim>
            {
            //Nombre que utilizaremos de autenticación 
            new Claim("FirstName", "Juan"),
            new Claim("LastName", "Cartago"),
            new Claim(ClaimTypes.Name, "JuanCartago@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin")
        },

        authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}

