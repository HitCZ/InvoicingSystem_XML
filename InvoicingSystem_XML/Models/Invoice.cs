namespace InvoicingSystem_XML.Models
{
    public class Invoice
    {
        #region Properties

        public int Id { get; set; }
        public int IdContractor { get; set; }
        public int IdCustomer { get; set; }
        public int IdPaymentCondition { get; set; }
        public long InvoiceNumber { get; set; }
        public virtual Contractor Contractor { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PaymentCondition PaymentCondition { get; set; }
        public string JobDescription { get; set; }
        public decimal Price { get; set; }

        #endregion Properties

        #region Constructor

        public Invoice()
        {
            Initialize();
        }

        #region Private Methods

        private void Initialize()
        {
            Contractor = new Contractor();
            Customer = new Customer();
            PaymentCondition = new PaymentCondition();
        }

        #endregion Private Methods

        #endregion Constructor

        #region Overriden Methods

        public override string ToString()
        {
            return InvoiceNumber.ToString();
        }

        #endregion Overriden Methods
    }
}
