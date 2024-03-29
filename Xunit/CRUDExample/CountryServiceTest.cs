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
    }
}
