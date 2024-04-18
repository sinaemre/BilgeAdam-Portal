using ApplicationCore.DTO_s.TeacherDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public TeachersController(ITeacherRepository teacherRepo, IMapper mapper, IUserRepository userRepo)
        {
            _teacherRepo = teacherRepo;
            _mapper = mapper;
            _userRepo = userRepo;
        }
        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherRepo.GetFilteredListAsync
                (
                    select: x => new GetTeacherVM
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        BirthDate = x.BirthDate,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Status = x.Status
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                );

            return View(teachers);
        }

        public IActionResult CreateTeacher() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeacher(CreateTeacherDTO model)
        {
            if (ModelState.IsValid)
            {
                var teacher = _mapper.Map<Teacher>(model);

                var isEmailUsed = await _userRepo.IsEmailUsed(model.Email);
                if (isEmailUsed)
                {
                    TempData["Error"] = "Bu email kullanılmaktadır!";
                    return View(model);
                }

                var appUser = await _userRepo.CreateAppUser(model);

                var result = await _userRepo.AddUser(appUser);

                if (result.Succeeded)
                {
                    var resultRole = await _userRepo.AddUserToRole(appUser, "teacher");
                    if (resultRole.Succeeded)
                    {
                        teacher.AppUserID = appUser.Id;
                        await _teacherRepo.AddAsync(teacher);
                        TempData["Success"] = $"{teacher.FirstName} {teacher.LastName} öğretmeni sisteme kayıt edilmiştir. Kullanıcı adı: {appUser.UserName},\nŞifre: 1234";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "Öğretmen role eklenemedi!";
                    return View(model);
                }
                TempData["Error"] = "Öğretmen sisteme kaydedilemedi!";
                return View(model);
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> UpdateTeacher(int id)
        {
            if (id > 0)
            {
                var teacher = await _teacherRepo.GetByIdAsync(id);

                if (teacher is not null)
                {
                    var model = _mapper.Map<UpdateTeacherDTO>(teacher);
                    return View(model);
                }
            }
            TempData["Error"] = "Öğretmen bulunamadı!";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherDTO model)
        {
            if (ModelState.IsValid)
            {
                var teacher = _mapper.Map<Teacher>(model);
                var appUser = await _userRepo.FindUser(teacher.AppUserID);
                if (appUser != null)
                {
                    appUser.FirstName = teacher.FirstName;
                    appUser.LastName = teacher.LastName;
                    appUser.Email = teacher.Email;
                    appUser.BirthDate = teacher.BirthDate;
                    var result = await _userRepo.UpdateAppUser(appUser);
                    if (result.Succeeded)
                    {
                        await _teacherRepo.UpdateAsync(teacher);
                        TempData["Success"] = $"{teacher.FirstName} {teacher.LastName} öğretmeni güncellendi!";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "Öğretmen güncellenemedi!";
                    return View(model);
                }
                TempData["Error"] = "Öğretmen bulunamadı!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            if (id > 0)
            {
                var teacher = await _teacherRepo.GetByIdAsync(id);
                if (teacher is not null)
                {
                    var appUser = await _userRepo.FindUser(teacher.AppUserID);
                    if (appUser is not null)
                    {
                        var result = await _userRepo.DeleteAppUser(appUser);
                        if (result.Succeeded)
                        {
                            await _teacherRepo.DeleteAsync(teacher);
                            TempData["Success"] = "Öğretmen silindi!";
                            return RedirectToAction("Index");
                        }
                        TempData["Error"] = "Öğretmen silinemedi!";
                        return RedirectToAction("Index");
                    }
                }
            }
            TempData["Error"] = "Öğretmen bulunamadı!";
            return RedirectToAction("Index");
        }
    }
}
