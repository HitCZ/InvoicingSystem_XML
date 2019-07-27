using InvoicingSystem_XML.Logic;
using InvoicingSystem_XML.Logic.Extensions;
using InvoicingSystem_XML.Logic.Validation;
using InvoicingSystem_XML.Models;
using InvoicingSystem_XML.Properties;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace InvoicingSystem_XML.ViewModels
{
    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        public Func<bool> ValidateFunc;
        private IAddressValidator addressValidator;
        private bool isValidationNeeded;

        #endregion Fields

        #region Properties

        public Invoice Invoice { get; set; } = new Invoice();

        public long InvoiceId
        {
            get => Invoice.InvoiceNumber;
            set
            {
                Invoice.InvoiceNumber = value;
                OnPropertyChanged(nameof(InvoiceId));
            }
        }

        public string ContractorName
        {
            get => Invoice.Contractor.ToString();
            set
            {
                if (!IsContractorNameValid(value, out var firstName, out var lastName))
                    return;

                Invoice.Contractor.FirstName = firstName;
                Invoice.Contractor.LastName = lastName;
            }
        }

        public string ContractorStreet
        {
            get => Invoice.Contractor.Address.Street;
            set => Invoice.Contractor.Address.Street = value;
        }

        public string ContractorBuildingNumber
        {
            get => Invoice.Contractor.Address.BuildingNumber;
            set => Invoice.Contractor.Address.BuildingNumber = value;
        }

        #endregion Properties

        #region Commands

        public ICommand ValidateCommand { get; set; }

        #endregion Commands

        #region Constructor

        [ImportingConstructor]
        public MainViewModel(IAddressValidator addressValidator)
        {
            this.addressValidator = addressValidator;
            ValidateCommand = new RelayCommand(ValidateCommandExecute);
        }

        private void ValidateCommandExecute()
        {
            isValidationNeeded = true;
            ValidateFunc.Invoke();
        }

        #endregion Constructor

        #region Overriden Members

        public override string this[string columnName]
        {
            get
            {
                if (!isValidationNeeded)
                    return string.Empty;

                switch (columnName)
                {
                    case nameof(ContractorName):
                        return ValidateContractorName();
                    case nameof(ContractorStreet):
                        return addressValidator.ValidateStreet(ContractorStreet);
                    case nameof(ContractorBuildingNumber):
                        return addressValidator.ValidateBuildingNumber(ContractorBuildingNumber);
                }

                return string.Empty;
            }
        }

        #endregion Overriden Members

        #region Private Methods

        private string ValidateContractorName()
        {
            var isValid = Invoice?.Contractor?.ToString().IsNullOrEmpty();

            if (!isValid.HasValue)
                throw new ArgumentNullException($"{nameof(isValid)}");

            return (bool)isValid ? string.Empty : Strings.ERR_CONTRACTOR_NAME_INVALID;
        }

        private bool IsContractorNameValid(string name, out string firstName, out string lastName)
        {
            firstName = string.Empty;
            lastName = string.Empty;

            if (name.IsNullOrEmpty())
                return false;

            var split = name.Split(' ');

            if (split.Length != 2)
                return false;

            firstName = split[0];
            lastName = split[1];

            return true;
        }
        #endregion Private Methods
    }
}
