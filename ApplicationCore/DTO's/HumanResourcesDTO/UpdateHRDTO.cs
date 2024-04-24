using ApplicationCore.DTO_s.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.HumanResourcesDTO
{
    public class UpdateHRDTO : AppUserDTO<DateTime>
    {
        public int Id { get; set; }
        public string AppUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public DateTime HireDate { get; set; }
    }
}
