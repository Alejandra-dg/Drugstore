using Drugstore.Shared.DTOs;
using Drugstore.Shared.Entities.Usuario;
using Microsoft.AspNetCore.Identity;

namespace Drugstore.API.Helpers
{
    //Permite manilupar los usuarios
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();


    }
}
