using WEB.Models.ViewModels.Abstract;

namespace WEB.Models.ViewModels
{
    public class GetStudentVM : AppUserVM
    {
        public string? ClassroomName { get; set; }
        public double? Average { get; set; }
        public string? TeacherName { get; set; }
    }
}
