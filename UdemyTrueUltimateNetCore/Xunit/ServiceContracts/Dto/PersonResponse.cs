using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceContracts.Dto
{
    public class PersonResponse
    {
        public string FullName { get; set; }
        public string PersonName { get; set; }
        public GenderOptions GenderOptions { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public Guid? CountryId { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(PersonResponse)) return false;
            PersonResponse person = (PersonResponse)obj;
            return this.FullName == person.FullName && this.PersonName == person.PersonName && this.GenderOptions == person.GenderOptions && this.Email == person.Email && this.DateOfBirth == person.DateOfBirth && this.CountryId == person.CountryId;
        }

    }
    public static class PersonResponseExtension
    {
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse {

                FullName = person.FullName,
                GenderOptions = person.Gender,
                CountryId = person.CountryId,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                PersonName = person.PersonName,
            };
        }
    }
    
}
