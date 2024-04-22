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
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddRole(IdentityRole role)
            => await _roleManager.CreateAsync(role);

        public async Task<IdentityResult> DeleteRole(IdentityRole role)
            => await _roleManager.DeleteAsync(role);

        public async Task<IdentityResult> UpdateRole(IdentityRole role)
            => await _roleManager.UpdateAsync(role);

        public async Task<IdentityRole> FindRole(string id)
            => await _roleManager.FindByIdAsync(id);

        public async Task<List<IdentityRole>> GetRoles()
            => await _roleManager.Roles.ToListAsync();

        public async Task<bool> CheckRoleName(string roleName, string? roleId)
        {
            if (roleId != null)
                return await _roleManager.Roles.AnyAsync(x => x.Name == roleName && x.Id != roleId);
            
            return await _roleManager.Roles.AnyAsync(x => x.Name == roleName);
        }

    }
}
