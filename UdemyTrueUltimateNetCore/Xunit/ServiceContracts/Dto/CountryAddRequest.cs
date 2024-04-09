using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Dto
{
    public class CountryAddRequest
    {
        public string? CountryName { get; set; }
        public int CountryNumber { get; set; }
        public Country ToCountry() {
            return new Country()
            {
                CountryId = Guid.NewGuid(),
                CountryName = CountryName,
                CountryNumber = CountryNumber
            };
        }
        

    }
}
