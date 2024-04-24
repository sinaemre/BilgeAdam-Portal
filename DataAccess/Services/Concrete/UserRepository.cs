using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.DTO_s.AccountDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(IPasswordHasher<AppUser> passwordHasher, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUser(AppUser appUser)
            => await _userManager.CreateAsync(appUser);

        public async Task<IdentityResult> AddUserToRole(AppUser appUser, string roleName)
            => await _userManager.AddToRoleAsync(appUser, roleName);

        public async Task<AppUser> CreateAppUser(AppUserDTO<DateTime?> model)
        {
            var userName = await UpdateUserName(model.FirstName, model.LastName, null);

            var appUser = new AppUser
            {
                UserName = userName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = (DateTime)model.BirthDate,
            };

            appUser.PasswordHash = _passwordHasher.HashPassword(appUser, "1234");
            return appUser;
        }

        public async Task<AppUser> CreateAppUser(AppUserDTO<DateTime> model)
        {
            var userName = await UpdateUserName(model.FirstName, model.LastName, null);

            var appUser = new AppUser
            {
                UserName = userName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
            };

            appUser.PasswordHash = _passwordHasher.HashPassword(appUser, "1234");
            return appUser;
        }

        public async Task<IdentityResult> DeleteAppUser(AppUser appUser)
            => await _userManager.DeleteAsync(appUser);

        public async Task<AppUser> FindUser(string id)
            => await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<AppUser> FindUser(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            return await FindUser(userId);
        }

        public async Task<bool> IsEmailUsed(string email)
            => await _userManager.Users.AnyAsync(x => x.Email == email);

        public async Task<IdentityResult> UpdateAppUser(AppUser appUser)
        {
            var userName = await UpdateUserName(appUser.FirstName, appUser.LastName, appUser.Id);
            appUser.UserName = userName;
            appUser.Status = Status.Modified;
            appUser.UpdatedDate = DateTime.Now;

            var result = await _userManager.UpdateAsync(appUser);
            return result;
        }

        public async Task<IdentityResult> UpdateAppUser(EditUserDTO model)
        {
            var appUser = await FindUser(model.Id);
            if (appUser != null)
            {
                appUser.Email = model.Email;
                if (model.Password != null)
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, model.Password);
                }
                return await UpdateAppUser(appUser);
            }
            return null;
        }

        public async Task<string> UpdateUserName(string firstName, string lastName, string? userId)
        {
            var userName = firstName
                               .ToLower()
                               .Replace("ı", "i")
                               .Replace("ö", "o")
                               .Replace("ü", "u")
                               .Replace("ş", "s")
                               .Replace("ğ", "g")
                               .Replace("ç", "c")
                               .Replace(" ", "")
                               + "." +
                               lastName
                               .ToLower()
                               .Replace("ı", "i")
                               .Replace("ö", "o")
                               .Replace("ü", "u")
                               .Replace("ş", "s")
                               .Replace("ğ", "g")
                               .Replace("ç", "c")
                               .Replace(" ", "");

            bool result = true;
            int number = 0;

            if (userId == null)
                result = await _userManager.Users.AnyAsync(x => x.UserName == userName);
            else
                result = await _userManager.Users.AnyAsync(x => x.UserName == userName && x.Id != userId);

            while (result)
            {
                if (!userName.EndsWith(lastName.Substring(lastName.Length - 1)))
                {
                    userName = userName.Substring(0, userName.Length - 1);
                }
                userName = userName + (++number).ToString();
                result = await _userManager.Users.AnyAsync(x => x.UserName == userName);
            }

            return userName;
        }

        public async Task<bool> IsUserInRole(AppUser appUser, string roleName)
            => await _userManager.IsInRoleAsync(appUser, roleName);

        public async Task<bool> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (userName != null)
                {
                    user.LoginCount++;
                    var resultUpdate = await UpdateAppUser(user);
                    if (resultUpdate.Succeeded)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public async Task Logout()
            => await _signInManager.SignOutAsync();

        public async Task<IdentityResult> ChangePassword(AppUser appUser, string oldPassword, string newPassword)
            => await _userManager.ChangePasswordAsync(appUser, oldPassword, newPassword);

        public async Task<IdentityResult> RemoveUserFromRole(AppUser user, string roleName)
            => await _userManager.RemoveFromRoleAsync(user, roleName);

        public async Task<List<AppUser>> GetUsers()
            => await _userManager.Users.ToListAsync();

        public async Task<List<AppUser>> GetUsersByRole(string roleName, bool status)
        {
            var users = await GetUsers();
            var usersInRole = new List<AppUser>();
            var usersOutRole = new List<AppUser>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, roleName))
                    usersInRole.Add(user);
                
                else
                    usersOutRole.Add(user);
            }

            return status ? usersInRole : usersOutRole;
        }

        public async Task<bool> IsThereAnyUser(string roleName)
            => (await GetUsersByRole(roleName, true)).Count() > 0 ? true : false;
    }
}
