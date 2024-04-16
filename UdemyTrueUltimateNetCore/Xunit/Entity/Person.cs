using Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public GenderOptions Gender { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public Guid? CountryId { get; set; }
    }
}
