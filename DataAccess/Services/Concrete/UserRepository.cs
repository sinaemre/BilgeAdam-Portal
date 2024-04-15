using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(IPasswordHasher<AppUser> passwordHasher, UserManager<AppUser> userManager)
        {
            _passwordHasher = passwordHasher;
            _userManager = userManager;
        }

        public async Task<AppUser> CreateAppUser(AppUserDTO model)
        {
            var userName = await UpdateUserName(model.FirstName, model.LastName);

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

        public async Task<IdentityResult> DeleteAppUser(AppUser appUser)
            => await _userManager.DeleteAsync(appUser);

        public async Task<AppUser> FindUser(string id)
            => await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> IsEmailUsed(string email)
            => await _userManager.Users.AnyAsync(x => x.Email == email);

        public async Task<IdentityResult> UpdateAppUser(AppUser appUser)
        {
            var userName = await UpdateUserName(appUser.FirstName, appUser.LastName);
            appUser.UserName = userName;
            appUser.Status = Status.Modified;
            appUser.UpdatedDate = DateTime.Now;

            var result = await _userManager.UpdateAsync(appUser);
            return result;
        }

        public async Task<string> UpdateUserName(string firstName, string lastName)
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
            result = await _userManager.Users.AnyAsync(x => x.UserName == userName);
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
    }
}
