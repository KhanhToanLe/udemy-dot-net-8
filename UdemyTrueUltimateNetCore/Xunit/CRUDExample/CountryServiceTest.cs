using Entity;
using ServiceContracts;
using ServiceContracts.Dto;
using Services;
using Xunit;

namespace CRUDExample
{
    public class CountryServiceTest
    {
        private readonly ICountryService _countryService;

        public CountryServiceTest()
        {
            _countryService = new CountryService();
        }
        #region AddCountry

        // add country will null CountryAddRequest
        [Fact]
        public void AddCountry_NullCountry()
        {
            // Arrange
            CountryAddRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _countryService.AddCountry(request);
            });
        }

        // add country if country name is null
        [Fact]
        public void AddCountry_NullCountryName()
        {
            // Arrange
            CountryAddRequest request = new CountryAddRequest()
            {
                CountryName = null,
                CountryNumber = 12
            };

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _countryService.AddCountry(request);
            });
        }

        [Fact]
        public void AddCountry_ExistCoutryName()
        {
            // Arrange
            var duplicateCountryName = new CountryAddRequest()
            {
                CountryName = "Viet Nam",
                CountryNumber = 12
            };
            var response = _countryService.AddCountry(duplicateCountryName);
            
            CountryAddRequest request = new CountryAddRequest()
            {
                CountryName = response.CountryName,
                CountryNumber = 123
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countryService.AddCountry(request);
            });
        }

        [Fact]
        public void AddCountry_ProperCountryValue()
        {
            // Arrange
            CountryAddRequest request = new CountryAddRequest()
            {
                CountryName = "Turkey",
                CountryNumber = 989
            };

            // Act
            var response = _countryService.AddCountry(request);
            List<CountryResponse> actual_country_list = _countryService.GetCountry();

            // Assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, actual_country_list);
        }
        #endregion

        #region GetAllCountry

        [Fact]
        public void GetAllCountry_EmptyList()
        {
            // Act
            List<CountryResponse> actual_response_country_list = _countryService.GetCountry();

            // Assert

            Assert.Empty(actual_response_country_list);
        }

        [Fact]
        public void GetAllCountry_FewCountry()
        {
            // Arrange
            List<CountryAddRequest> newCountriesList = new List<CountryAddRequest>()
            {
                new()
                {
                    CountryName = "Dummy Test",
                    CountryNumber = 123
                },
                new()
                {
                    CountryName = "Dummy value",
                    CountryNumber = 123
                },
                new()
                {
                    CountryName = "Dummy name",
                    CountryNumber = 123
                },
                new()
                {
                    CountryName = "Dummy string",
                    CountryNumber = 123
                }
            };

            var actualCountryList = new List<CountryResponse>();
            foreach (var newCountry in newCountriesList)
            {
                var addedCountry = _countryService.AddCountry(newCountry);
                actualCountryList.Add(addedCountry);
            }

            var expectedCountryList = _countryService.GetCountry();
            // Act
            foreach (var countryResponse in actualCountryList)
            {
                Assert.Contains(countryResponse, expectedCountryList);
            }
        }

        #endregion

        #region GetCountryById
        [Fact]
        public void GetCountryById_NullCountryId()
        {
            // Arrange
            Guid? nullCountryId = null;
            // Act
            CountryResponse? actualResult = _countryService.GetCountryById(nullCountryId);
            Assert.Null(actualResult);
            //Assert
            
        }

        [Fact]
        public void GetCountryById_NotFoundCountryId()
        {
            // Arrange
            Guid? notFoundCountryId = Guid.NewGuid();

            // Act
            CountryResponse? actual = _countryService.GetCountryById(notFoundCountryId);

            // Assert
            Assert.Null(actual);
        }

        #endregion
    }
}
