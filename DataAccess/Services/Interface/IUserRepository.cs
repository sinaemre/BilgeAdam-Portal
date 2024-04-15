using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.Entities.UserEntities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IUserRepository
    {
        Task<AppUser> CreateAppUser(AppUserDTO model);

        Task<bool> IsEmailUsed(string email);

        Task<AppUser> FindUser(string id);

        Task<IdentityResult> UpdateAppUser(AppUser appUser);

        Task<string> UpdateUserName(string firstName, string lastName);

        Task<IdentityResult> DeleteAppUser(AppUser appUser);
    }
}
