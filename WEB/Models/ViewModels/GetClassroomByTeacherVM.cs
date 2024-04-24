using ApplicationCore.Entities.Abstract;

namespace WEB.Models.ViewModels
{
    public class GetClassroomByTeacherVM
    {
        public int Id { get; set; }
        public string ClassroomName { get; set; }
        public string ClassroomDescription { get; set; }
        public int ClassroomSize { get; set; }
    }
}
