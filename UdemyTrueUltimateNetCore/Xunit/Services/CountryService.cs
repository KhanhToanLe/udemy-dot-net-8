using Entity;
using ServiceContracts;
using ServiceContracts.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountryService : ICountryService
    {
        private readonly List<Country> _countries = new List<Country>();
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            if(countryAddRequest == null)
            {
                throw new ArgumentNullException();
            }

            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentNullException("CountryName");
            }

            if (_countries.Any((item) => item.CountryName == countryAddRequest.CountryName))
            {
                throw new ArgumentException();
            }

            var newCountry = new Country()
            {
                CountryId = Guid.NewGuid(),
                CountryName = countryAddRequest.CountryName,
                CountryNumber = countryAddRequest.CountryNumber
            };
            _countries.Add(newCountry);

            return new CountryResponse()
            {
                CountryId = newCountry.CountryId,
                CountryName = newCountry.CountryName,
                CountryNumber = newCountry.CountryNumber
            };
        }

        public List<CountryResponse> GetCountry() {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryById(Guid? countryId)
        {
            if(countryId == null)
            {
                return null;
            }
            var foundCountry = _countries.Find(country => country.CountryId == countryId);
            return foundCountry == null ? null : foundCountry.ToCountryResponse();
        }
    }
}
