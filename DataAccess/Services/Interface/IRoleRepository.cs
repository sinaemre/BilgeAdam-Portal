using ApplicationCore.Entities.UserEntities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IRoleRepository
    {
        Task<List<IdentityRole>> GetRoles();
        Task<IdentityRole> FindRole(string id);
        Task<IdentityResult> AddRole(IdentityRole role);
        Task<IdentityResult> UpdateRole(IdentityRole role);
        Task<IdentityResult> DeleteRole(IdentityRole role);
        Task<bool> CheckRoleName(string roleName, string? roleId);

    }
}
