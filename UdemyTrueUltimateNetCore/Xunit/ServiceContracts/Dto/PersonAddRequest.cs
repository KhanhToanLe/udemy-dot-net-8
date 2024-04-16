using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Dto
{
    public class PersonAddRequest
    {
        public string FullName { get; set; }
        public string PersonName { get; set; }
        public GenderOptions GenderOptions { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public Guid? CountryId { get; set; }

        public Person ToPerson()
        {
            return new Person()
            {
                Id = Guid.NewGuid(),
                CountryId = CountryId,
                DateOfBirth = DateOfBirth,
                Email = Email,
                FullName = FullName,
                PersonName = PersonName,
                Gender = GenderOptions
            };
        }
    }


}
