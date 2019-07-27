using InvoicingSystem_XML.Logic.Extensions;
using InvoicingSystem_XML.Properties;
using System.ComponentModel.Composition;

namespace InvoicingSystem_XML.Logic.Validation
{
    [Export(typeof(IAddressValidator)), PartCreationPolicy(CreationPolicy.Shared)]
    public class CzAddressValidator : IAddressValidator
    {
        public string ValidateStreet(string street)
        {
            return street.IsNullOrEmpty() ? Strings.ERR_STREET_EMPTY : string.Empty;
        }

        public string ValidateBuildingNumber(string number)
        {
            if (number.IsNullOrEmpty())
                return Strings.ERR_CONTRACTOR_BUILDING_EMPTY;

            return number.ContainsDigit() ? Strings.ERR_CONTRACTOR_BUILDING_INVALID : string.Empty;
        }

        public string ValidateCity(string city)
        {
            return city.IsNullOrEmpty() ? Strings.ERR_CITY_EMPTY : string.Empty;
        }

        public string ValidateZipCode(string zipCode)
        {
            if (zipCode.IsNullOrEmpty())
                return Strings.ERR_ZIPCODE_EMPTY;

            if (!zipCode.ContainsDigit())
                return Strings.ERR_ZIPCODE_INVALID;

            var zipcodeWithoutSpace = zipCode.Replace(" ", string.Empty);

            return zipcodeWithoutSpace.Length != 5 ? Strings.ERR_ZIPCODE_INVALID : string.Empty;
        }

        public string ValidateCountry(string country)
        {
            return country.IsNullOrEmpty() ? Strings.ERR_COUNTRY_EMPTY : string.Empty;
        }
    }
}
