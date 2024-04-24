namespace WEB.Models.ViewModels
{
    public class GetStudentsVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public double? Exam1 { get; set; }
        public double? Exam2 { get; set; }
        public double? Average { get; set; }
        public double? ProjectExam { get; set; }
        public string? ProjectPath { get; set; }
    }
}
