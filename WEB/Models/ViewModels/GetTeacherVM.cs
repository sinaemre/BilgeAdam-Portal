using ApplicationCore.Entities.Abstract;

namespace WEB.Models.ViewModels
{
    public class GetTeacherVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
    }
}
