using ServiceContracts.Dto;

namespace ServiceContracts
{
    public interface ICountryService
    {
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
        
    }
}
