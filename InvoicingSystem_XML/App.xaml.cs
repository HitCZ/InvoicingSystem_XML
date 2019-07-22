using InvoicingSystem_XML.Logic.ServiceLocation;
using System.Windows;

namespace InvoicingSystem_XML
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
