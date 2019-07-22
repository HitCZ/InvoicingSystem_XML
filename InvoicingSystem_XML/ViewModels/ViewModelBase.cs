using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using InvoicingSystem_XML.Annotations;

namespace InvoicingSystem_XML.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Public Methods

        public virtual async Task InitializeAsync(params object[] parameters)
        {
            await Task.Run(() => Initialize(parameters));
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
    }
}
