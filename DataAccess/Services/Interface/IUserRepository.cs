using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.DTO_s.AccountDTO;
using ApplicationCore.Entities.UserEntities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IUserRepository
    {
        Task<AppUser> CreateAppUser(AppUserDTO<DateTime?> model);
        Task<AppUser> CreateAppUser(AppUserDTO<DateTime> model);

        Task<bool> IsEmailUsed(string email);

        Task<AppUser> FindUser(string id);
        
        Task<AppUser> FindUser(ClaimsPrincipal claimsPrincipal);

        Task<IdentityResult> UpdateAppUser(AppUser appUser);
      
        Task<IdentityResult> UpdateAppUser(EditUserDTO model);

        Task<string> UpdateUserName(string firstName, string lastName, string? userId);

        Task<IdentityResult> DeleteAppUser(AppUser appUser);

        Task<IdentityResult> AddUser(AppUser appUser);

        Task<IdentityResult> AddUserToRole(AppUser appUser, string roleName);
        
        Task<IdentityResult> RemoveUserFromRole(AppUser user, string roleName);

        Task<bool> IsUserInRole(AppUser appUser, string roleName);
        
        Task<bool> Login(string userName, string password);
        
        Task Logout();
        
        Task<IdentityResult> ChangePassword(AppUser appUser, string oldPassword, string newPassword);

        Task<List<AppUser>> GetUsers();

        Task<List<AppUser>> GetUsersByRole(string roleName, bool status);

        Task<bool> IsThereAnyUser(string roleName);
    }
}
