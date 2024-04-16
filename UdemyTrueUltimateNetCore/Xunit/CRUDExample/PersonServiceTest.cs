using Entity;
using ServiceContracts;
using ServiceContracts.Dto;
using Services;
using Xunit;

namespace CRUDExample
{
    public class PersonServiceTest
    {
        private readonly IPersonService _personService;
        public PersonServiceTest()
        {
            _personService = new PersonService();
        }

        #region AddPerson

        [Fact]
        public void AddPerson_NullPerson()
        {

            //Arrange
            PersonAddRequest personAddRequest = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                var result = _personService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public void AddPerson_PersonNameIsNull() {
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                CountryId = Guid.NewGuid(),
                DateOfBirth = "2023-03-03",
                Email = "toan@gmail.com",
                FullName = "Le Khanh Toan",
                GenderOptions = Entity.Enum.GenderOptions.Female,
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                var result = _personService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public void AddPerson_ProperPersonDetail()
        {
            // Arrange
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                CountryId = Guid.NewGuid(),
                DateOfBirth = "2023-03-03",
                Email = "toan@gmail.com",
                FullName = "Le Khanh Toan",
                GenderOptions = Entity.Enum.GenderOptions.Female,
                PersonName = "Toan"
            };

            // Act
            var personResponse = _personService.AddPerson(personAddRequest);
            // Assert
            Assert.Equal(personAddRequest.ToPerson().ToPersonResponse(), personResponse);
        }

        #endregion

        #region GetPeople
        [Fact]
        public void GetPeople()
        {
            // Arrange
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                CountryId = Guid.NewGuid(),
                DateOfBirth = "2023-03-03",
                Email = "toan@gmail.com",
                FullName = "Le Khanh Toan",
                GenderOptions = Entity.Enum.GenderOptions.Female,
                PersonName = "Toan"
            };
            _personService.AddPerson(personAddRequest);

            // Act
            var result = _personService.GetPeople().ToList<Person>();

            // Assert
            Console.WriteLine(result);
        }
        #endregion

        #region GetPersonById

        [Fact]
        public void GetPersonById_NullId()
        {
            // Arrange
            Guid? id = null;

            // Act
            var actualResult = _personService.GetPersonById(id);

            // Assert
            Assert.Null(actualResult);
        }

        [Fact]
        public void GetPersonById_NotFoundPerson()
        {

        }
        #endregion
    }
}
