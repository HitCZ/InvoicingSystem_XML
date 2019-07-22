using InvoicingSystem_XML.Logic.Constants;

namespace InvoicingSystem_XML.Models
{
    public class Address
    {
        #region Properties

        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; } = Constants.DEFAULT_COUNTRY;

        #endregion Properties

        #region Overriden Methods
        
        public override string ToString()
        {
            return $"{Street} {BuildingNumber}, {ZipCode} {City}; {Country}";
        }

        #endregion
    }
}
