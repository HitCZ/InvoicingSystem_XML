using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem_XML.Logic.Validation
{
    public interface IPersonOfInterestValidator
    {
        string ValidateIn(string identificationNumber);
        string ValidateVatin(string vatin);
        string ValidateStreet(string street);
        string ValidateBuildingNumber(string building);
        string ValidateZipCode(int zipcode);
        string Country(string country);
    }
}
