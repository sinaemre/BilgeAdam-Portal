using ApplicationCore.DTO_s.HumanResourcesDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.Areas.Admin.Models;

namespace WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class HumanResourcesController : Controller
    {
        private readonly IHumanResourcesRepository _humanResourcesRepo;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public HumanResourcesController(IHumanResourcesRepository humanResourcesRepo, IMapper mapper, IUserRepository userRepo)
        {
            _humanResourcesRepo = humanResourcesRepo;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> Index()
        {
            var hrList = await _humanResourcesRepo.GetFilteredListAsync
                (
                    x => new GetHRVM
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        BirthDate = x.BirthDate,
                        HireDate = x.HireDate,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Status = x.Status
                    },
                    x => x.Status != Status.Passive,
                    x => x.OrderByDescending(z => z.CreatedDate)
                );


            return View(hrList);
        }

        public IActionResult CreateHR() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHR(CreateHRDTO model)
        {
            if (ModelState.IsValid)
            {
                var hr = _mapper.Map<HumanResources>(model);

                var isMailUsed = await _userRepo.IsEmailUsed(model.Email);
                if (isMailUsed)
                {
                    TempData["Error"] = "Bu mail kullanılmaktadır!";
                    return View(model);
                }

                var appUser = await _userRepo.CreateAppUser(model);

                var result = await _userRepo.AddUser(appUser);

                if (result.Succeeded)
                {
                    var resultRole = await _userRepo.AddUserToRole(appUser, "humanResources");
                    if (resultRole.Succeeded)
                    {
                        hr.AppUserID = appUser.Id;
                        await _humanResourcesRepo.AddAsync(hr);
                        TempData["Success"] = $"İnsan kaynakları sisteme kaydedildi. Kullanıcı ad: {appUser.UserName}\nŞifre: \"1234\"";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "İnsan kaynakları rolüne eklenemedi!";
                    return View(model);
                }
                TempData["Error"] = "İnsan kaynakları sisteme kaydedilemedi!";
                return View(model);
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }
        
        public async Task<IActionResult> UpdateHR(int id)
        {
            if (id > 0)
            {
                var hr = await _humanResourcesRepo.GetByIdAsync(id);
                if (hr != null)
                {
                    var model = _mapper.Map<UpdateHRDTO>(hr);
                    return View(model);
                }
            }
            TempData["Error"] = "İnsan kaynakları bulunamadı!";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHR(UpdateHRDTO model)
        {
            if (ModelState.IsValid)
            {
                var hr = _mapper.Map<HumanResources>(model);
                var appUser = await _userRepo.FindUser(hr.AppUserID);
                if (appUser != null)
                {
                    appUser.FirstName = hr.FirstName;
                    appUser.LastName = hr.LastName;
                    appUser.BirthDate = hr.BirthDate;
                    appUser.Email = hr.Email;
                    var result = await _userRepo.UpdateAppUser(appUser);
                    if (result.Succeeded)
                    {
                        await _humanResourcesRepo.UpdateAsync(hr);
                        TempData["Success"] = $"{hr.FirstName} {hr.LastName} adlı insan kaynakları güncellendi!";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "İnsan kaynakları güncellenemedi!";
                    return View(model);
                }
                TempData["Error"] = "İnsan kaynakları bulunamadı!";
                return View(model);
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> DeleteHR(int id)
        {
            if (id > 0)
            {
                var hr = await _humanResourcesRepo.GetByIdAsync(id);
                if (hr != null)
                {
                    var appUser = await _userRepo.FindUser(hr.AppUserID);
                    if (appUser != null)
                    {
                        var result = await _userRepo.DeleteAppUser(appUser);
                        if (result.Succeeded) 
                        {
                            await _humanResourcesRepo.DeleteAsync(hr);
                            TempData["Success"] = "İnsan kaynakları silindi!";
                            return RedirectToAction("Index");
                        }
                        TempData["Error"] = "İnsan kaynakları silinemedi!";
                        return RedirectToAction("Index");
                    }
                }
            }
            TempData["Error"] = "İnsan kaynakları bulunamadı!";
            return RedirectToAction("Index");
        }
    }
}
