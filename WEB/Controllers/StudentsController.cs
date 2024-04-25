using ApplicationCore.DTO_s.ClassroomDTO;
using ApplicationCore.DTO_s.StudentDTO;
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
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly IClassroomRepository _classroomRepo;
        private readonly IUserRepository _userRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentsController(IStudentRepository studentRepo, IMapper mapper, IClassroomRepository classroomRepo, IUserRepository userRepo, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
            _classroomRepo = classroomRepo;
            _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepo.GetFilteredListAsync
                (
                    select: x => new GetStudentVM
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        BirthDate = x.BirthDate,
                        Email = x.Email,
                        ClassroomName = x.Classroom.ClassroomName,
                        TeacherName = x.Classroom.Teacher.FirstName + " " + x.Classroom.Teacher.LastName,
                        Average = x.Average,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Status = x.Status
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate),
                    join: x => x.Include(z => z.Classroom).ThenInclude(z => z.Teacher)

                );

            return View(students);
        }

        public async Task<IActionResult> DetailStudent(int id)
        {
            if (id > 0)
            {
                var student = await _studentRepo.GetStudentById(id);
                if (student is not null)
                {
                    var model = _mapper.Map<GetStudentDetailDTO>(student);
                    model.ClassroomName = student.Classroom.ClassroomName;
                    model.TeacherName = student.Classroom.Teacher.FirstName + " " + student.Classroom.Teacher.LastName;
                    return View(model);
                }
            }
            TempData["Error"] = "Öğrenci bulunamadı!";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateStudent()
        {
            var classrooms = await _classroomRepo.GetFilteredListAsync
                (
                    select: x => new ShowClassroomDTO
                    {
                        Id = x.Id,
                        ClassroomName = x.ClassroomName,
                        ClassroomDescription = x.Description,
                        ClassroomSize = x.Students.Count,
                        TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(z => z.CreatedDate),
                    join: x => x.Include(z => z.Students).Include(x => x.Teacher)
                );

            var model = new CreateStudentDTO { Classrooms = classrooms };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO model)
        {
            var classrooms = await _classroomRepo.GetFilteredListAsync
              (
                  select: x => new ShowClassroomDTO
                  {
                      Id = x.Id,
                      ClassroomName = x.ClassroomName,
                      ClassroomDescription = x.Description,
                      ClassroomSize = x.Students.Count,
                      TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                  },
                  where: x => x.Status != Status.Passive,
                  orderBy: x => x.OrderByDescending(z => z.CreatedDate),
                  join: x => x.Include(z => z.Students).Include(x => x.Teacher)
              );
            model.Classrooms = classrooms;

            if (ModelState.IsValid)
            {
                string imageName = "default.png";
                if (model.Image != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "studentsImages");
                    imageName = $"{Guid.NewGuid()}_{model.FirstName}_{model.LastName}_{model.Image.FileName}";
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.Image.CopyToAsync(fileStream);
                    fileStream.Close();
                }
                
                var student = _mapper.Map<Student>(model);
                
                student.ImagePath = imageName;
                
                var appUser = await _userRepo.CreateAppUser(model);
                var result = await _userRepo.AddUser(appUser);
                if (result.Succeeded)
                {
                    var resultRole = await _userRepo.AddUserToRole(appUser, "student");
                    if (resultRole.Succeeded)
                    {
                        student.AppUserID = appUser.Id;
                        await _studentRepo.AddAsync(student);
                        TempData["Success"] = $"{student.FirstName} {student.LastName} öğrencisi sisteme kayıt edilmiştir. Kullanıcı adı: {appUser.UserName}\nŞifre: \"1234\"";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "Öğrenci role eklenemedi!";
                    return View(model);
                }
                TempData["Error"] = "Öğrenci sisteme kayıt edilemedi!";
                return View(model);
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> UpdateStudent(int id)
        {
            if (id > 0)
            {
                var student = await _studentRepo.GetByIdAsync(id);
                if (student is not null)
                {
                    var model = _mapper.Map<UpdateStudentDTO>(student);
                    var classrooms = await _classroomRepo.GetFilteredListAsync
                                      (
                                          select: x => new ShowClassroomDTO
                                          {
                                              Id = x.Id,
                                              ClassroomName = x.ClassroomName,
                                              ClassroomDescription = x.Description,
                                              ClassroomSize = x.Students.Count,
                                              TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                                          },
                                          where: x => x.Status != Status.Passive,
                                          orderBy: x => x.OrderByDescending(z => z.CreatedDate),
                                          join: x => x.Include(z => z.Students).Include(x => x.Teacher)
                                      );
                    model.Classrooms = classrooms;
                    return View(model);
                }
            }
            TempData["Error"] = "Öğrenci bulunamadı!";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDTO model)
        {
            var classrooms = await _classroomRepo.GetFilteredListAsync
                                     (
                                         select: x => new ShowClassroomDTO
                                         {
                                             Id = x.Id,
                                             ClassroomName = x.ClassroomName,
                                             ClassroomDescription = x.Description,
                                             ClassroomSize = x.Students.Count,
                                             TeacherName = x.Teacher.FirstName + " " + x.Teacher.LastName
                                         },
                                         where: x => x.Status != Status.Passive,
                                         orderBy: x => x.OrderByDescending(z => z.CreatedDate),
                                         join: x => x.Include(z => z.Students).Include(x => x.Teacher)
                                     );
            model.Classrooms = classrooms;
            if (ModelState.IsValid)
            {
                string imageName = "default.png";
                if (model.Image != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "studentsImages");
                    if (!string.Equals(model.ImagePath, "default.png"))
                    {
                        string oldPath = Path.Combine(uploadDir, model.ImagePath);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    imageName = $"{Guid.NewGuid()}_{model.FirstName}_{model.LastName}_{model.Image.FileName}";
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.Image.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                var student = _mapper.Map<Student>(model);
                student.ImagePath = imageName;
                var appUser = await _userRepo.FindUser(student.AppUserID);
                if (appUser is not null)
                {
                    appUser.FirstName = student.FirstName;
                    appUser.LastName = student.LastName;
                    appUser.BirthDate = student.BirthDate;
                    appUser.Email = student.Email;
                    var result = await _userRepo.UpdateAppUser(appUser);
                    if (result.Succeeded)
                    {
                        await _studentRepo.UpdateAsync(student);
                        TempData["Success"] = $"{student.FirstName} {student.LastName} öğrencisi güncellenmitir.";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "Öğrenci bilgileri güncellenemedi!";
                    return View(model);
                }
                TempData["Error"] = "Kişi bulunamadı!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id > 0)
            {
                var student = await _studentRepo.GetByIdAsync(id);
                if (student != null)
                {
                    await _studentRepo.DeleteAsync(student);
                    var appUser = await _userRepo.FindUser(student.AppUserID);
                    var result = await _userRepo.DeleteAppUser(appUser);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Öğrencinin kaydı silinmiştir!";
                        return RedirectToAction("Index");
                    }
                    TempData["Error"] = "Öğrenci silinemedi!";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Öğrenci bulunamadı!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetStudentsByClassroomId(int id)
        {
            if (id > 0)
            {
                var students = await _studentRepo.GetFilteredListAsync
                    (
                        x => new GetStudentsVM
                        {
                            Id = x.Id,
                            FullName = x.FirstName + " " + x.LastName,
                            BirthDate = x.BirthDate,
                            Exam1 = x.Exam1,
                            Exam2 = x.Exam2,
                            ProjectExam = x.ProjectExam,
                            Average = x.Average,
                            ProjectPath = x.ProjectPath
                        },
                        x => x.ClassroomId == id && x.Status != Status.Passive,
                        x => x.OrderByDescending(z => z.CreatedDate)
                    );

                return View(students);
            }
            TempData["Error"] = "Sınıf bulunamadı!";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> EnterExam(GetStudentDetailDTO model)
        {
            if (ModelState.IsValid)
            {
                var student = await _studentRepo.GetByIdAsync(model.Id);
                if (student != null)
                {
                    student.Exam1 = model.Exam1;
                    student.Exam2 = model.Exam2;
                    student.ProjectExam = model.ProjectExam;
                    await _studentRepo.UpdateAsync(student);
                    TempData["Success"] = "Not girişi yapılmıştır!";
                    return RedirectToAction("DetailStudent", new { id = model.Id });
                }
                TempData["Error"] = "Hata oluştu!";
                return RedirectToAction("DetailStudent", new { id = model.Id });
            }
            TempData["Error"] = "Lütfen aşağıdaki kurallara uyunuz!";
            return RedirectToAction("DetailStudent", new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> SendProject(GetStudentDetailDTO model)
        {
            if (model.Project is not null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "projects");
                string fileName = $"{Guid.NewGuid()}_{model.FirstName}_{model.LastName}_{model.Project.FileName}";
                string filePath = Path.Combine(uploadDir, fileName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await model.Project.CopyToAsync(fileStream);
                fileStream.Close();

                var student = await _studentRepo.GetByIdAsync(model.Id);
                student.ProjectPath = fileName;
                student.ProjectName = model.ProjectName;

                await _studentRepo.UpdateAsync(student);
                TempData["Success"] = "Proje yüklendi!";
                return RedirectToAction("DetailStudent", new { id = model.Id });
            }
            TempData["Error"] = "Proje yüklenemedi!";
            return RedirectToAction("DetailStudent", new { id = model.Id });
        }

        public FileResult Download(string filePath)
        {
            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "projects/");
            byte[] fileBytes = System.IO.File.ReadAllBytes(uploadDir + filePath);
            string fileName = filePath;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
