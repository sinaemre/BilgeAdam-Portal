using ApplicationCore.DTO_s.ClassroomDTO;
using ApplicationCore.DTO_s.TeacherDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly IClassroomRepository _classroomRepo;
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IUserRepository _userRepo;

        public ClassroomsController(IClassroomRepository classroomRepo, IMapper mapper, ITeacherRepository teacherRepo, IUserRepository userRepo)
        {
            _classroomRepo = classroomRepo;
            _mapper = mapper;
            _teacherRepo = teacherRepo;
            _userRepo = userRepo;
        }

        [Authorize(Roles = "admin, humanResources")]
        public async Task<IActionResult> Index()
        {
            var classrooms = await _classroomRepo.GetFilteredListAsync
                (
                    select: x => new GetClassroomVM
                    {
                        Id = x.Id,
                        ClassroomName = x.ClassroomName,
                        ClassroomDescription = x.Description,
                        TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName,
                        ClassroomSize = x.Students.Where(z => z.Status != Status.Passive).ToList().Count,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Status = x.Status
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate),
                    join: x => x.Include(z => z.Teacher).Include(z => z.Students)
                );

            return View(classrooms);
        }

        [Authorize(Roles = "admin, humanResources")]
        public async Task<IActionResult> CreateClassroom()
        {
            var teachers = await _teacherRepo.GetFilteredListAsync
                (
                    select: x => new ShowTeacherDTO
                    {
                        Id = x.Id,
                        Name = x.FirstName + " " + x.LastName
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                );

            var model = new CreateClassroomDTO { Teachers = teachers };

            return View(model);
        }

        [Authorize(Roles = "admin, humanResources")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClassroom(CreateClassroomDTO model)
        {
            var teachers = await _teacherRepo.GetFilteredListAsync
                (
                    select: x => new ShowTeacherDTO
                    {
                        Id = x.Id,
                        Name = x.FirstName + " " + x.LastName
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                );

            model.Teachers = teachers;

            if (ModelState.IsValid)
            {
                if (await _classroomRepo.AnyAsync(x => x.Status != Status.Passive && x.ClassroomName == model.ClassroomName))
                {
                    TempData["Error"] = "Bu isim kullanılmaktadır. Başka bir isim seçiniz!";
                    return View(model);
                }
                var classroom = _mapper.Map<Classroom>(model);
                await _classroomRepo.AddAsync(classroom);
                TempData["Success"] = $"{classroom.ClassroomName} sınıfı kaydedilmiştir.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        [Authorize(Roles = "admin, humanResources")]
        public async Task<IActionResult> UpdateClassroom(int id)
        {
            if (id > 0)
            {
                var classroom = await _classroomRepo.GetByIdAsync(id);
                if (classroom is not null)
                {
                    var teachers = await _teacherRepo.GetFilteredListAsync
                        (
                            select: x => new ShowTeacherDTO
                            {
                                Id = x.Id,
                                Name = x.FirstName + " " + x.LastName
                            },
                            where: x => x.Status != Status.Passive,
                            orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                        );

                    var model = _mapper.Map<UpdateClassroomDTO>(classroom);
                    model.Teachers = teachers;
                    return View(model);
                }
            }
            TempData["Error"] = "Sınıf bulunamadı!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, humanResources")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateClassroom(UpdateClassroomDTO model)
        {
            var teachers = await _teacherRepo.GetFilteredListAsync
                       (
                           select: x => new ShowTeacherDTO
                           {
                               Id = x.Id,
                               Name = x.FirstName + " " + x.LastName
                           },
                           where: x => x.Status != Status.Passive,
                           orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                       );
            model.Teachers = teachers;

            var classroom = await _classroomRepo.GetByIdAsync(model.Id);

            if (classroom != null)
            {
                if (ModelState.IsValid)
                {
                    if (await _classroomRepo.AnyAsync(x =>
                                                        x.Status != Status.Passive &&
                                                        x.Id != model.Id &&
                                                        x.ClassroomName == model.ClassroomName))
                    {
                        TempData["Error"] = "Bu isim kullanılmatadır. Başka bir isim seçiniz1";
                        return View(model);
                    }
                    var entity = _mapper.Map<Classroom>(model);
                    await _classroomRepo.UpdateAsync(entity);
                    TempData["Success"] = $"{entity.ClassroomName} sınıfı güncellenmiştir!";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Lütfen kırallara uyunuz!";
                return View(model);
            }
            TempData["Error"] = "Sınıf bulunamadı!";
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "admin, humanResources")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            if (id > 0)
            {
                var classroom = await _classroomRepo.GetByIdAsync(id);

                if (classroom is not null)
                {
                    if (await _classroomRepo.IsThereAnyStudents(id))
                    {
                        TempData["Error"] = "Sınıfa kayıtlı öğrenciler vardır. Silme işlemi yapılamaz!";
                        return RedirectToAction("Index");
                    }
                    await _classroomRepo.DeleteAsync(classroom);
                    TempData["Success"] = $"{classroom.ClassroomName} sınıfı silinmiştir!";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Sınıf bulunamadı!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, humanResources, teacher")]
        public async Task<IActionResult> GetClassroomByTeacher()
        {
            var appUser = await _userRepo.FindUser(HttpContext.User);
            var teacher = await _teacherRepo.GetByDefaultAsync(x => x.AppUserID == appUser.Id);
            if (teacher is not null)
            {
                var classrooms = await _classroomRepo.GetFilteredListAsync
                    (
                        x => new GetClassroomByTeacherVM
                        {
                            Id = x.Id,
                            ClassroomName = x.ClassroomName,
                            ClassroomDescription = x.Description,
                            ClassroomSize = x.Students.Count()
                        },
                        x => x.TeacherId == teacher.Id && x.Status != Status.Passive,
                        x => x.OrderByDescending(z => z.CreatedDate),
                        x => x.Include(z => z.Students)
                    );

                return View(classrooms);
            }
            TempData["Error"] = "Sınıflar bulunamadı!";
            return RedirectToAction("Index", "Home");
        }
    }
}
