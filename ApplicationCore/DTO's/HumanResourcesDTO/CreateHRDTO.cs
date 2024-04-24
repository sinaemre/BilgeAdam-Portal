using ApplicationCore.DTO_s.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.HumanResourcesDTO
{
    public class CreateHRDTO : AppUserDTO<DateTime>
    {
        [Display(Name = "İşe Giriş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
