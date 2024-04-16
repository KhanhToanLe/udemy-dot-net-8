using CRUDExample;
using Entity;
using ServiceContracts;
using ServiceContracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _people = new List<Person>();
        public PersonResponse AddPerson(PersonAddRequest AddRequest)
        {
            if(AddRequest is null)
            {
                throw new ArgumentNullException();
            }
            var AddPerson =  AddRequest.ToPerson();
            ValidateHelper<Person>.Validate(AddPerson);
            _people.Add(AddPerson);
            return AddPerson.ToPersonResponse();
        }

        public IEnumerable<Person> GetPeople()
        {
            foreach (var person in _people)
            {
                yield return person;
            }
        }

        public PersonResponse? GetPersonById(Guid? id)
        {
            if (id is null) return default;
            var foundPerson = _people.Find(x => x.Id == id);
            return foundPerson?.ToPersonResponse();
        }
    }
}
