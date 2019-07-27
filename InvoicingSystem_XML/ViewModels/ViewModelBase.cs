using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using InvoicingSystem_XML.Annotations;

namespace InvoicingSystem_XML.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields

        private bool isBusy;

        #endregion Fields

        #region Properties

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        #endregion Properties

        #region Public Methods

        public async Task InitializeAsync(params object[] parameters)
        {
            IsBusy = true;
            try
            {
                await Task.Run(() => Initialize(parameters));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public virtual void Initialize(params object[] parameters) { }

        #endregion Public Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged

        #region IDataErrorInfo

        public virtual string this[string columnName] => string.Empty;

        public string Error { get; } = null;

        #endregion IDataErrorInfo
    }
}
