using Drugstore.API.Helpers;
using Drugstore.Shared.Enums;
using Drugstore.Shared.Entities.Usuario;
using Drugstore.API.Date;

namespace Drugstore.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        //private readonly IUserHelper _userHelper; 

        public SeedDb(DataContext context)
        {
            //IUserHelper userHelper
            _context = context;
            //_userHelper = userHelper;
        }

        //public async Task SeedAsync()
        //{
        //    await _context.Database.EnsureCreatedAsync();
        //    await CheckRolesAsync();
        //    await CheckUserAsync("123", "admin", "super", "oap@yopmail.com", "300666666", "Cualquier cosa", UserType.Admin);
        //}


        //private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        //{
        //    var user = await _userHelper.GetUserAsync(email);
        //    if (user == null)
        //    {
        //        user = new User
        //        {
        //            FirstName = firstName,
        //            LastName = lastName,
        //            Email = email,
        //            UserName = email,
        //            PhoneNumber = phone,
        //            Address = address,
        //            Document = document,
        //            UserType = userType,
        //        };

        //        await _userHelper.AddUserAsync(user, "123456");
        //        await _userHelper.AddUserToRoleAsync(user, userType.ToString());
        //    }

        //    return user;
        //}


        //private async Task CheckRolesAsync()
        //{
        //    await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
        //    await _userHelper.CheckRoleAsync(UserType.User.ToString());
        //}
        
        
       
    }
}
                
            
        
    


