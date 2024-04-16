using Entity;
using ServiceContracts.Dto;
using System.Diagnostics.CodeAnalysis;

namespace ServiceContracts
{
    public interface ICountryService
    {
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
        public List<CountryResponse> GetCountry();
        public CountryResponse? GetCountryById(Guid? countryId);
    }
}
