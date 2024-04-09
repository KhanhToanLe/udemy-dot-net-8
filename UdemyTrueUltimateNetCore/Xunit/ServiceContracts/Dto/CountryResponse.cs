using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Dto
{
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public int CountryNumber { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(CountryResponse)) return false;
            var compare_response = (CountryResponse)obj;
            return 
                compare_response.CountryId == this.CountryId &&
                compare_response.CountryName == this.CountryName &&
                compare_response.CountryNumber == this.CountryNumber;
        }
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                CountryNumber = country.CountryNumber
            };
        }
    }

}
