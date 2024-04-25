using ApplicationCore.DTO_s.AccountDTO;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepo;

        public AccountController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [AllowAnonymous]
        public IActionResult Login() => View();

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _userRepo.Login(model.UserName, model.Password);
                if (loginResult)
                {
                    var appUser = await _userRepo.FindUser(HttpContext.User);
                    if (appUser != null)
                    {
                        if (await _userRepo.IsUserInRole(appUser, "admin"))
                        {
                            TempData["Success"] = "Hoşgeldin Admin!";
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        }

                        if (appUser.LoginCount == 1 && !await _userRepo.IsUserInRole(appUser, "admin"))
                        {
                            TempData["Success"] = "Hoşgeldiniz. İlk kez giriş yağptığınız için şifrenizi değiştirmeniz gerekiyor. Lütfen yeni şifre giriniz!";
                            return RedirectToAction("ChangePassword", new { id = appUser.Id });
                        }
                      

                        TempData["Success"] = $"Hoşgeldiniz {appUser.FirstName} {appUser.LastName}";

                        if (await _userRepo.IsUserInRole(appUser, "teacher"))
                            return RedirectToAction("GetClassroomByTeacher", "Classrooms");

                        return RedirectToAction("Index", "Home");
                    }
                    TempData["Error"] = "Kullanıcı bulunamadı!";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Kullanıcı adı veya şifre yanlış!";
                return View(model);
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userRepo.FindUser(id);
            if (user != null)
            {
                var model = new ChangePasswordDTO { Id = id };
                return View(model);
            }
            TempData["Error"] = "Kullanıcı bulunamadı!";
            return RedirectToAction("Login");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userRepo.FindUser(model.Id);
                var result = await _userRepo.ChangePassword(appUser, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _userRepo.Logout();
                    TempData["Success"] = "Şifreniz başarıyla değiştirildi. Giriş yapınız...";
                    return RedirectToAction("Login");
                }
                TempData["Error"] = "Şifreniz değiştirilemedi!";
                return View(model);
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await _userRepo.Logout();
                TempData["Success"] = "Çıkış yapıldı!";
                return RedirectToAction("Login");
            }
            TempData["Error"] = "Önce giriş yapınız!";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EditUser()
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            if (user != null)
            {
                var model = new EditUserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    BirthDate = user.BirthDate.ToShortDateString(),
                    Password = user.PasswordHash,
                    CreatedDate = user.CreatedDate,
                    UpdatedDate = user.UpdatedDate
                };
                return View(model);
            }
            TempData["Error"] = "Bu sayfayı görüntülemek için giriş yapmanız gerekiyor!";
            return RedirectToAction("Login");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserDTO model)
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            model.BirthDate = user.BirthDate.ToShortDateString();

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var result = await _userRepo.UpdateAppUser(model);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Profiliniz güncellendi!";
                    }
                    else
                    {
                        TempData["Error"] = "Profiliniz güncellenemedi!";
                    }
                }
                else
                {
                    TempData["Error"] = "Kullanıcı bulunamadı!";
                }
            }
            else
            {
                TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            }
            return View(model);
        }
    }
}
