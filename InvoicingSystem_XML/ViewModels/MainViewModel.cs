﻿using InvoicingSystem_XML.Logic.Extensions;
using InvoicingSystem_XML.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using InvoicingSystem_XML.Logic;

namespace InvoicingSystem_XML.ViewModels
{
    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields

        private bool isValidationNeeded;
        public Func<bool> ValidateFunc;

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

        #endregion Properties

        #region Commands

        public ICommand ValidateCommand { get; set; }

        #endregion Commands

        #region Constructor

        public MainViewModel()
        {
            ValidateCommand = new RelayCommand(ValidateCommandExecute);
        }

        private void ValidateCommandExecute()
        {
            ValidateFunc.Invoke();
        }

        #endregion Constructor

        #region IDataErrorInfo

        public string this[string columnName]
        {
            get
            {
                if (!isValidationNeeded)
                {
                    isValidationNeeded = true;
                    return string.Empty;
                }

                switch (columnName)
                {
                    case nameof(ContractorName):
                        return ValidateContractorName();
                }

                return string.Empty;
            }
        }

        public string Error { get; } = null;

        #endregion IDataErrorInfo

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
