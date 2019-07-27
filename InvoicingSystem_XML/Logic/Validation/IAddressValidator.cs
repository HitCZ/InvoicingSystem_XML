namespace InvoicingSystem_XML.Logic.Validation
{
    public interface IAddressValidator
    {
        string ValidateStreet(string street);
        string ValidateBuildingNumber(string number);
        string ValidateCity(string city);
        string ValidateZipCode(string zipCode);
        string ValidateCountry(string country);
    }
}
