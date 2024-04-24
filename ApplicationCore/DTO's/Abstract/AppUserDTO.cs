using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.Abstract
{
    public abstract class AppUserDTO<T>
    {
        [Display(Name = "Ad")]
        public string? FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string? LastName { get; set; }

        [Display(Name = "E-Mail")]
        public string? Email { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public T BirthDate { get; set; }
    }
}
