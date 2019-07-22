using InvoicingSystem_XML.Annotations;
using InvoicingSystem_XML.ViewModels;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;

namespace InvoicingSystem_XML.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public partial class MainView : INotifyPropertyChanged
    {
        #region Fields

        private MainViewModel viewModel;

        #endregion Fields

        #region Properties

        public MainViewModel ViewModel
        {
            get => viewModel;
            set
            {
                viewModel = value;
                viewModel.ValidateFunc += OnValidate;
                OnPropertyChanged(nameof(ViewModel));
            }
        }

        #endregion Properties

        #region Constructor

        public MainView()
        {
            InitializeComponent();
            ViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
        }

        #endregion Constructor

        #region Private Methods

        private bool OnValidate()
        {
            BankAccountTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            BankConnectionTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

            ContractorBuildingNumberTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            ContractorCityOfEvidenceTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            ContractorCityTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            ContractorInTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            ContractorNameTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            ContractorStreetTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            ContractorZipTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

            CustomerBuildingNumberTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CustomerCityTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CustomerInTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CustomerNameTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CustomerStreetTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CustomerVatinTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CustomerZipTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

            JobDescriptionTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            PriceTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            VariableSymbolTxt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

            return !ValidationErrorFound();
        }

        private bool ValidationErrorFound()
        {
            var errors = new[]
            {
                Validation.GetHasError(BankAccountTxt),
                Validation.GetHasError(BankConnectionTxt),

                Validation.GetHasError(ContractorBuildingNumberTxt),
                Validation.GetHasError(ContractorCityOfEvidenceTxt),
                Validation.GetHasError(ContractorInTxt),
                Validation.GetHasError(ContractorCityTxt),
                Validation.GetHasError(ContractorNameTxt),
                Validation.GetHasError(ContractorStreetTxt),
                Validation.GetHasError(ContractorZipTxt),

                Validation.GetHasError(CustomerBuildingNumberTxt),
                Validation.GetHasError(CustomerCityTxt),
                Validation.GetHasError(CustomerInTxt),
                Validation.GetHasError(CustomerNameTxt),
                Validation.GetHasError(CustomerStreetTxt),
                Validation.GetHasError(CustomerVatinTxt),
                Validation.GetHasError(CustomerZipTxt),

                Validation.GetHasError(JobDescriptionTxt),
                Validation.GetHasError(PriceTxt),
                Validation.GetHasError(VariableSymbolTxt),
            };

            var errorFound = errors.Any(x => true);

            return errorFound;
        }

        #endregion Private Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged

    }
}
