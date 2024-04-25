using ApplicationCore.DTO_s.RoleDTO;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;

        public RolesController(IUserRepository userRepo, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleRepo.GetRoles();
            return View(roles);
        }

        public IActionResult CreateRole() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleDTO model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(model.RoleName);

                var checkName = await _roleRepo.CheckRoleName(role.Name, null);
                if (checkName)
                {
                    TempData["Error"] = "Bu rol sistemde vardır. Başka bir rol adı seçiniz!";
                    return View(model);
                }

                var result = await _roleRepo.AddRole(role);
                if (result.Succeeded)
                {
                    TempData["Success"] = $"{role.Name} rolü sisteme kaydedilmiştir.";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Role kaydedilemedi!";
                return View(model);
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> UpdateRole(string id)
        {
            var role = await _roleRepo.FindRole(id);
            if (role != null)
            {
                var model = new UpdateRoleDTO { RoleId = id, RoleName = role.Name };
                return View(model);
            }
            TempData["Error"] = "Rol bulunamadı!";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRole(UpdateRoleDTO model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleRepo.FindRole(model.RoleId);
                if (role != null)
                {
                    if (await _roleRepo.CheckRoleName(model.RoleName, model.RoleId))
                    {
                        TempData["Error"] = "Bu rol sistemde vardır. Başka bir rol adı seçiniz!";
                        return View(model);
                    }
                    role.Name = model.RoleName;
                    var result = await _roleRepo.UpdateRole(role);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = $"{role.Name} rolü güncellenmiştir.";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "Rol güncellenemedi!";
                    return View(model);
                }
                TempData["Error"] = "Rol bulunamadı!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> AssignedUser(string roleId)
        {
            var role = await _roleRepo.FindRole(roleId);

            if (role != null)
            {
                var model = new AssignedRoleDTO();
                model.HasRole = await _userRepo.GetUsersByRole(role.Name, true);
                model.HasNotRole = await _userRepo.GetUsersByRole(role.Name, false); ;
                model.Role = role;
                model.RoleName = role.Name;

                return View(model);
            }

            TempData["Error"] = "Rol bulunamadı!";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignedUser(AssignedRoleDTO model)
        {
            model.HasRole = await _userRepo.GetUsersByRole(model.Role.Name, true);
            model.HasNotRole = await _userRepo.GetUsersByRole(model.Role.Name, false);

            var result = new IdentityResult();

            foreach (var userId in model.AddIds ?? new string[] { })
            {
                var user = await _userRepo.FindUser(userId);
                result = await _userRepo.AddUserToRole(user, model.RoleName);
            }

            foreach (var userId in model.DeleteIds ?? new string[] { })
            {
                var user = await _userRepo.FindUser(userId);
                result = await _userRepo.RemoveUserFromRole(user, model.RoleName);
            }

            if (result.Succeeded)
            {
                TempData["Success"] = "Rol işlemleri başarılı bir şekilde gerçekleşti!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Rol işlemleri yapılamadı!";
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleRepo.FindRole(roleId);
            if (role != null)
            {
                if (await _userRepo.IsThereAnyUser(role.Name))
                {
                    TempData["Error"] = "Bu rolde kullanıcılar vardır. Silinemez! Eğer silmek istiyorsanız önce kullanıcıları bu rolden kaldırın!";
                    return RedirectToAction("AssignedUser", new { roleId = role.Id });
                }

                var result = await _roleRepo.DeleteRole(role);

                if (result.Succeeded)
                {
                    TempData["Success"] = "Rol başarılı bir şekilde silindi!";
                    return RedirectToAction("Index");
                }

                TempData["Error"] = "Rol silinemedi!";
                return RedirectToAction("Index");

            }
            TempData["Error"] = "Rol bulunamadı!";
            return RedirectToAction("Index");
        }

    }
}
