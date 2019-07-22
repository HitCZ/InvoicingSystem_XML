using InvoicingSystem_XML.Logic.Constants;
using InvoicingSystem_XML.Logic.Enumerations;
using InvoicingSystem_XML.Logic.Extensions;
using System;

namespace InvoicingSystem_XML.Models
{
    public class PaymentCondition
    {
        #region Properties

        public int Id { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string PaymentMethodString
        {
            get => PaymentMethod is PaymentMethod.BankTransfer 
                ? Constants.PAYMENT_METHOD_TRANSFER : Constants.PAYMENT_METHOD_CASH;
            set => PaymentMethod = value.ParseEnum<PaymentMethod>();
        }

        public string BankConnection { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string VariableSymbol { get; set; } = string.Empty;
        public DateTime DateOfIssue { get; set; }
        public DateTime DueDate { get; set; }

        #endregion Properties

        #region Overriden Methods

        public override string ToString()
        {
            return PaymentMethodString;
        }

        #endregion
    }
}
