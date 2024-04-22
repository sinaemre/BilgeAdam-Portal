using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.RoleDTO
{
    public class UpdateRoleDTO
    {
        public string RoleId { get; set; }

        [Display(Name = "Rol")]
        public string? RoleName { get; set; }
    }
}
