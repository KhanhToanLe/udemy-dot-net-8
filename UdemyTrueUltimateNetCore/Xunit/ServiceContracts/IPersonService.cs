using Entity;
using ServiceContracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IPersonService
    {
        public PersonResponse AddPerson(PersonAddRequest AddRequest);
        public IEnumerable<Person> GetPeople();
        public PersonResponse? GetPersonById(Guid? id);
    }
}
