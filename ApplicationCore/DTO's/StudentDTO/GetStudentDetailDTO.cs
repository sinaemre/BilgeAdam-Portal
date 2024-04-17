using ApplicationCore.Consts;
using ApplicationCore.DTO_s.Abstract;

namespace ApplicationCore.DTO_s.StudentDTO
{ 
    public class GetStudentDetailDTO : AppUserDTO
    {
        public string? ClassroomName { get; set; }
        public string? TeacherName { get; set; }
        public double? Exam1 { get; set; }
        public double? Exam2 { get; set; }
        public double? ProjectExam { get; set; }
        public string? ProjectName { get; set; }
        public double? Average { get; set; }
        public StudentStatus IsSucceed 
        {
            get
            {
                if (Average is not null)
                {
                    if (Average >= 70)
                    {
                        return StudentStatus.Succeed;
                    }
                    else
                    {
                        return StudentStatus.Failed;
                    }
                }
                return StudentStatus.Continue;
            }
        }
    }
}
