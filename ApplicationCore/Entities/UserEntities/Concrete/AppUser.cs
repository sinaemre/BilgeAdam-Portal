using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.UserEntities.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.UserEntities.Concrete
{
    public class AppUser : IdentityUser, IBaseUser
    {
        private DateTime _createdDate = DateTime.Now;
        private Status _status = Status.Active;

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int LoginCount { get; set; }

        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get => _status; set => _status = value; }
    }
}
