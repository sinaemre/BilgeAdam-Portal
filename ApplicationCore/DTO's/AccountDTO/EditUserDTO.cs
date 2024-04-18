using ApplicationCore.DTO_s.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.AccountDTO
{
    public class EditUserDTO : AppUserDTO<string?>
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }

        [Display(Name = "Şifre")]
        public string? Password { get; set; }
    }
}
