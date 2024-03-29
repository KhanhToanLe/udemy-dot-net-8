using ServiceContracts;
using ServiceContracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountryService : ICountryService
    {
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            return new CountryResponse();
        }
    }
}
